using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KhanhSon.Models
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string tenMon { get; set; }
        public int giaoVienId { get; set; }
        public MonHoc()
        {
            this.Id = this.giaoVienId = 0;
            this.tenMon = "";
        }
        public async Task<List<MonHoc>> DanhSachMonHoc()
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM MonHoc";
                CommandType c = CommandType.Text;
                var rs = await Data.Connection().QueryAsync<MonHoc>(Query, null, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<int> ThemMoiMonHoc(MonHoc monHoc)
        {
            using (Data.Connection())
            {
                var insert = 0;
                string Query = "INSERT INTO MonHoc VALUES(@tenMon,@giaoVienId)";
                var pa = new DynamicParameters();
                pa.Add("@tenMon", monHoc.tenMon);
                pa.Add("@giaoVienId", monHoc.giaoVienId);
                CommandType c = CommandType.Text;
                insert = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return insert;
            }
        }
        public async Task<List<MonHoc>> MonHocTheoGiaoVien(int id)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM MonHoc WHERE Id = @Id";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@Id", id);
                var rs = await Data.Connection().QueryAsync<MonHoc>(Query, pa, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<int> SuaMonHoc(MonHoc monHoc)
        {
            using (Data.Connection())
            {
                string Query = "UPDATE MonHoc SET tenMon = @tenMon, giaoVienId = @giaoVienId";
                CommandType c = CommandType.Text;
                var updateId = 0;
                var pa = new DynamicParameters();
                pa.Add("@tenMon", monHoc.tenMon);
                pa.Add("@giaoVienId", monHoc.giaoVienId);
                updateId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return updateId;
            }
        }
        public async Task<int> XoaMonHoc(int Id)
        {
            using (Data.Connection())
            {
                var delete = 0;
                string Query = "DELETE MonHoc WHERE Id = @Id";
                var pa = new DynamicParameters();
                pa.Add("@Id", Id);
                CommandType c = CommandType.Text;
                delete = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return delete;
            }
        }
    }
}
