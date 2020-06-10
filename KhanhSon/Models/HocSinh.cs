using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KhanhSon.Models
{
    public class HocSinh
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public DateTime ngaySinh { get; set; }
        public string maSinhVien { get; set; }
        public int lopId { get; set; }
        public int khoaId { get; set; }
        public HocSinh()
        {
            this.Id = this.Tuoi = this.lopId = 0;
            this.Ten = this.maSinhVien = "";
            this.ngaySinh = DateTime.Now;
        }
        public async Task<List<HocSinh>> DanhSachHocSinh()
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM HocSinh";
                CommandType c = CommandType.Text;
                var rs = await Data.Connection().QueryAsync<HocSinh>(Query, null, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<int> ThemMoiHocSinh(HocSinh hocSinh)
        {
            using (Data.Connection())
            {
                var insertId = 0;
                string Query = "INSERT INTO HocSinh VALUES (@Ten,@Tuoi,@ngaySinh,@maSoSinhVien,@lopId,@khoaId)";
                var pa = new DynamicParameters();
                pa.Add("@Ten", hocSinh.Ten);
                pa.Add("@Tuoi", hocSinh.Tuoi);
                pa.Add("@ngaySinh", hocSinh.ngaySinh);
                pa.Add("@maSoSinhVien", hocSinh.maSinhVien);
                pa.Add("@lopId", hocSinh.lopId);
                pa.Add("@khoaId", hocSinh.khoaId);
                CommandType c = CommandType.Text;
                insertId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return insertId;
            }
        }
        public async Task<HocSinh> ChiTietHocSinh(int id)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM HocSinh WHERE Id = @Id";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@Id", id);
                var rs = await Data.Connection().QueryAsync<HocSinh>(Query, pa, null, null, c);
                return rs.FirstOrDefault();
            }
        }
        public async Task<List<HocSinh>> DanhSachHocSinhTheoLop(int Id)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM HocSinh WHERE lopId = @lopId";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@lopId", Id);
                var rs = await Data.Connection().QueryAsync<HocSinh>(Query, pa, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<List<HocSinh>> DanhSachHocSinhTheoKhoa(int Id)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM HocSinh WHERE khoaId = @khoaId";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@khoaId", Id);
                var rs = await Data.Connection().QueryAsync<HocSinh>(Query, pa, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<int> XoaHocSinh(int Id)
        {
            using (Data.Connection())
            {
                var rs = 0;
                string Query = "DELETE HocSinh WHERE Id = @Id";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@Id", Id);
                rs = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return rs;
            }
        }
        public async Task<int> SuaHocSinh(HocSinh hocSinh)
        {
            using (Data.Connection())
            {
                var updateId = 0;
                string Query = "UPDATE HocSinh SET Ten = @Ten, Tuoi = @Tuoi, ngaySinh = @ngaySinh, maSinhVien = @maSoSinhVien, lopId = @lopId, khoaId = @khoaId";
                var pa = new DynamicParameters();
                pa.Add("@Ten", hocSinh.Ten);
                pa.Add("@Tuoi", hocSinh.Tuoi);
                pa.Add("@ngaySinh", DateTime.Now);
                pa.Add("@maSoSinhVien", hocSinh.maSinhVien);
                pa.Add("@lopId", hocSinh.lopId);
                pa.Add("@khoaId", hocSinh.khoaId);
                CommandType c = CommandType.Text;
                updateId = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return updateId;
            }
        }
    }
}
