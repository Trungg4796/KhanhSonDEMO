using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace KhanhSon.Models
{
    public class Khoa
    {
        public int Id { get; set; }
        public string tenKhoa { get; set; }
        public Khoa()
        {
            this.Id = 0;
            this.tenKhoa = "";
        }
        public async Task<List<Khoa>> DanhSachKhoa()
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM Khoa";
                CommandType c = CommandType.Text;
                var rs = await Data.Connection().QueryAsync<Khoa>(Query, null, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<int> ThemMoiKhoa(Khoa khoa)
        {
            using (Data.Connection())
            {
                var insertId = 0;
                string Query = "INSERT INTO Khoa VALUES(@tenKhoa)";
                var pa = new DynamicParameters();
                pa.Add("@tenKhoa", khoa.tenKhoa);
                CommandType c = CommandType.Text;
                insertId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return insertId;
            }
        }
        public async Task<int> SuaKhoa(Khoa khoa)
        {
            using (Data.Connection())
            {
                var updateId = 0;
                string Query = "UPDATE Khoa SET tenKhoa = @tenKhoa WHERE Id = @Id";
                var pa = new DynamicParameters();
                pa.Add("@Id", khoa.Id);
                pa.Add("@tenKhoa", khoa.tenKhoa);
                CommandType c = CommandType.Text;
                updateId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return updateId;
            }
        }
        public async Task<int> XoaKhoa(int Id)
        {
            using (Data.Connection())
            {
                var xoaId = 0;
                string Query = "DELETE Khoa WHERE Id = @Id";
                var pa = new DynamicParameters();
                pa.Add("@Id",Id);
                
                CommandType c = CommandType.Text;
                xoaId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return xoaId;
            }
        }
    }
}
