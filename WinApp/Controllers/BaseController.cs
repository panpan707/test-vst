using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Controllers
{
    using Models;

    public class UpdateContext : EditContext
    {
        public string Message { get; set; }
    }

    public class BaseController : System.Mvc.Controller
    {
        public virtual object Index() => View();
    }

    public class DataController<T> : BaseController
    {
        protected Type EntityType => typeof(T);
        protected virtual DataSchema.Table DataEngine => Provider.GetTable<T>();
        protected virtual T CreateEntity() => (T)Activator.CreateInstance(EntityType);

        protected virtual string GetProcName()
        {
            var name = EntityType.Name;
            if (name.ToLower().StartsWith("view"))
                name = name.Substring(4);
            return "update" + name;
        }

        // ==========================================
        // 1. HÀM TÌM KIẾM (Đã sửa lỗi thiếu hàm GetSearchCondition)
        // ==========================================

        // Đây là hàm bị thiếu gây ra lỗi của bạn
        protected virtual string GetSearchCondition(string keyword)
        {
            return null; // Mặc định không tìm gì cả
        }

        public override object Index()
        {
            // Khi không có từ khóa (Values rỗng), gọi Index(null)
            return Index(null);
        }

        // 2. THÊM MỚI hàm Index có tham số (để khớp với lệnh tìm kiếm)
        public virtual object Index(string keyword)
        {
            string condition = null;

            // Nếu có từ khóa -> Lấy điều kiện SQL từ hàm con (LoRungController)
            if (!string.IsNullOrEmpty(keyword))
            {
                condition = GetSearchCondition(keyword);
            }

            // Truy vấn dữ liệu với điều kiện tìm được
            return View(DataEngine.ToList<T>(condition, null));
        }

        // ==========================================
        // 2. CÁC HÀM CRUD CƠ BẢN
        // ==========================================
        public virtual object Delete(T entity)
        {
            return View(new EditContext(entity, EditActions.Delete));
        }
        public virtual object Edit(T entity)
        {
            return View(new EditContext(entity));
        }
        public virtual object Add()
        {
            return View(new EditContext(CreateEntity(), EditActions.Insert));
        }

        protected UpdateContext UpdateContext { get; set; }

        // ==========================================
        // 3. HÀM UPDATE (CÓ GHI LOG)
        // ==========================================
        public object Update(EditContext context)
        {
            UpdateContext = new UpdateContext
            {
                Action = context.Action,
                Model = context.Model,
            };

            // [FIX ERROR]: Sửa doc.Get("Id") thành doc.GetString("Id")
            var doc = Document.FromObject(context.Model);
            var recordId = doc.GetString("Id");

            // Thực hiện Update vào DB
            UpdateCore((T)context.Model);

            // Nếu có lỗi thì trả về lỗi
            if (UpdateContext.Message != null)
                return UpdateError();

            // Nếu thành công -> GHI LOG
            try
            {
                string actionName = context.Action.ToString();
                string tableName = typeof(T).Name;
                string user = "admin"; // Sau này thay bằng Session user

                // Lưu ý: recordId có thể null nếu là Insert mới (chưa có ID)
                // Nhưng với logic hiện tại, ta chấp nhận ghi log Insert với Id=0 hoặc null
                string sqlLog = $"INSERT INTO LichSuTacDong (NguoiThucHien, BangTacDong, IdBanGhi, LoaiTacDong, NoiDungThayDoi) " +
                                $"VALUES (N'{user}', '{tableName}', {recordId ?? "0"}, '{actionName}', N'Thao tác {actionName}')";

                ExecSQL(sqlLog);
            }
            catch { /* Bỏ qua lỗi log để không chặn flow chính */ }

            return UpdateSuccess();
        }

        // ==========================================
        // 4. CÁC HÀM HỖ TRỢ SQL (CORE)
        // ==========================================
        protected virtual void TryInsert(T e)
        {
            ExecSQL(DataEngine.CreateInsertSql(e));
        }
        protected virtual void TryUpdate(T e)
        {
            ExecSQL(DataEngine.CreateUpdateSql(e));
        }
        protected virtual void TryDelete(T e)
        {
            ExecSQL(DataEngine.CreateDeleteSql(e));
        }
        protected virtual object UpdateSuccess()
        {
            return RedirectToAction("Index");
        }
        protected virtual object UpdateError() => Error(1, UpdateContext.Message);

        protected virtual void UpdateCore(T e)
        {
            var procName = GetProcName();
            var proc = procName == null ? null : Provider.GetStoredProcedure(procName);
            if (proc != null)
            {
                ExecPROC(proc);
            }
            else
            {
                switch (UpdateContext.Action)
                {
                    case EditActions.Delete: TryDelete(e); break;
                    case EditActions.Update: TryUpdate(e); break;
                    case EditActions.Insert: TryInsert(e); break;
                }
            }
        }
        protected void ExecPROC(DataSchema.StoredProc proc)
        {
            Provider.CreateCommand(cmd => {
                cmd.CommandText = proc.Name;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var doc = Document.FromObject(UpdateContext.Model);
                var res = 0;

                doc.Add("action", (int)UpdateContext.Action);
                foreach (var p in proc.Parameters.Values)
                {
                    // Fix lỗi nếu tham số null
                    var val = doc.GetString(p.Name);
                    if (val == null) cmd.Parameters.AddWithValue($"@{p.Name}", DBNull.Value);
                    else cmd.Parameters.AddWithValue($"@{p.Name}", val);
                }
                try
                {
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    UpdateContext.Message = ex.Message;
                }
                if (res == 0 && UpdateContext.Message == null)
                {
                    UpdateContext.Message = $"Không cập nhật được dữ liệu\n{cmd.CommandText}";
                }
            });
        }
        protected void ExecSQL(string sql)
        {
            Provider.CreateCommand(cmd => {
                cmd.CommandText = sql;
                if (cmd.ExecuteNonQuery() == 0)
                {
                    // UpdateContext.Message = sql; 
                }
            });
        }
    }
}