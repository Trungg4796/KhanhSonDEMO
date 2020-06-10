using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KhanhSon.Models
{
    public class GiaoVien
    {
        public int Id { get; set; }
        public string tenGiaoVien { get; set; }
        public string hocVi { get; set; }
        public string maGiaoVien { get; set; }
        public int khoaId { get; set; }
        public GiaoVien()
        {
            this.Id = this.khoaId = 0;
            this.tenGiaoVien = this.hocVi = this.maGiaoVien = "";
        }
        public async Task<List<GiaoVien>> DanhSachGiaoVien()
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM GiaoVien";
                CommandType c = CommandType.Text;
                var rs = await Data.Connection().QueryAsync<GiaoVien>(Query, null, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<List<GiaoVien>> DanhSachGiaoVienTheoKhoa(int KhoaId)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM GiaoVien WHERE khoaId = @khoaId";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@khoaId", KhoaId);
                var rs = await Data.Connection().QueryAsync<GiaoVien>(Query, pa, null, null, c);
                return rs.ToList();
            }
        }
        public async Task<GiaoVien> ChiTietGiaoVien(int id)
        {
            using (Data.Connection())
            {
                string Query = "SELECT * FROM GiaoVien WHERE Id = @Id";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@Id", id);
                var rs = await Data.Connection().QueryAsync<GiaoVien>(Query, pa, null, null, c);
                return rs.FirstOrDefault();
            }
        }
        public async Task<int> ThemMoiGiaoVien(GiaoVien gv)
        {
            using (Data.Connection())
            {
                var rs = 0;
                string Query = "INSERT INTO GiaoVien VALUES(@tenGiaoVien,@hocVi,@maGiaoVien,@khoaId)";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@tenGiaoVien", gv.tenGiaoVien);
                pa.Add("@hocVi", gv.hocVi);
                pa.Add("@maGiaoVien", gv.maGiaoVien);
                pa.Add("@khoaId", gv.khoaId);
                 rs = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return rs;
            }
        }
        public async Task<int> CapNhatGiaoVien(GiaoVien gv)
        {
            using (Data.Connection())
            {
                var rs = 0;
                string Query = "UPDATE GiaoVien SET tenGiaoVien = @tenGiaoVien, hocVi = @hocVi, maGiaoVien = @maGiaoVien, khoaId = @khoaId";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@tenGiaoVien", gv.tenGiaoVien);
                pa.Add("@hocVi", gv.hocVi);
                pa.Add("@maGiaoVien", gv.maGiaoVien);
                rs = await Data.Connection().ExecuteAsync(Query, null, null, null, c);
                return rs;
            }
        }
        public async Task<int> XoaGiaoVien(int Id)
        {
            using (Data.Connection())
            {
                var delete = 0;
                string Query = "DELETE GiaoVien WHERE Id = @Id";
                CommandType c = CommandType.Text;
                var pa = new DynamicParameters();
                pa.Add("@Id",Id);
                delete = await Data.Connection().ExecuteAsync(Query, pa, null, null, c);
                return delete;
            }
        }
    }
}
