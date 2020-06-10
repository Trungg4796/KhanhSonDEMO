using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KhanhSon.Models
{
    public class Lop
    {
        public int Id { get; set; }
        public string TenLop { get; set; }
        public int khoaId { get; set; }
        public Lop()
        {
            this.Id = this.khoaId = 0;
            this.TenLop = "";
        }
        public async Task<List<Lop>> DanhSachLop()
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM Lop";
                CommandType c = CommandType.Text;
                var rs = await Data.Connection().QueryAsync<Lop>(Query, null, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<List<Lop>> ChiTietLop(int Id)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM Lop WHERE Id = @Id";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@Id", Id);
                var rs = await Data.Connection().QueryAsync<Lop>(Query, pa, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<List<Lop>> DanhSachLopTheoKhoa(int Id)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM Lop WHERE KhoaId = @Id";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@Id", Id);
                var rs = await Data.Connection().QueryAsync<Lop>(Query, pa, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<int> ThemMoiLop(Lop lop)
        {
            using (Data.Connection())
            {
                var insertId = 0;
                string Query = "INSERT INTO Lop VALUES(@TenLop,@KhoaId)";
                var pa = new DynamicParameters();
                pa.Add("@TenLop", lop.TenLop);
                pa.Add("@KhoaId", lop.khoaId);
                CommandType c = CommandType.Text;
                insertId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return insertId;
            }
        }
        public async Task<int> SuaLop(Lop lop)
        {
            using (Data.Connection())
            {
                var updateId = 0;
                string Query = "UPDATE Lop SET TenLop = @tenLop, KhoaId = @KhoaId WHERE Id = @Id";
                var pa = new DynamicParameters();
                pa.Add("@Id", lop.Id);
                pa.Add("@tenLop",lop.TenLop);
                pa.Add("@KhoaId", lop.khoaId);
                CommandType c = CommandType.Text;
                updateId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return updateId;
            }
        }
        public async Task<int> XoaLop(int Id)
        {
            using (Data.Connection())
            {
                var xoaId = 0;
                string Query = "DELETE Lop WHERE Id = @Id";
                var pa = new DynamicParameters();
                pa.Add("@Id", Id);

                CommandType c = CommandType.Text;
                xoaId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return xoaId;
            }
        }
    }
}
