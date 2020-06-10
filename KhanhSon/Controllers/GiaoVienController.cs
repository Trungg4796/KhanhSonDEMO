using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KhanhSon.Models;

namespace KhanhSon.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        GiaoVien gv = new GiaoVien();
        // GET: api/GiaoVien
        [HttpGet]
        public async Task<JsonResult> DanhSachGiaoVien()
        {
            var rs = await gv.DanhSachGiaoVien();
            return new JsonResult(rs);
        }

        // GET: api/GiaoVien/5
        [HttpGet("{id}")]
        public async Task<JsonResult> ChiTietGiaoVien(int id)
        {
            var rs = await gv.ChiTietGiaoVien(id);
            return new JsonResult(rs);
        }
        [HttpGet("{id}")]
        public async Task<JsonResult> DanhSachGiaoVienTheoKhoa(int id)
        {
            var rs = await gv.DanhSachGiaoVienTheoKhoa(id);
            return new JsonResult(rs);
        }

        // POST: api/GiaoVien
        [HttpPost]
        public async Task<JsonResult> ThemMoiGiaoVien([FromBody] GiaoVien giaoVien)
        {
            var rs = await gv.ThemMoiGiaoVien(giaoVien);
            if(rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể thêm mới Giáo Viên"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Thêm mới giáo viên thành công"));
            }
        }

        // PUT: api/GiaoVien/5
        [HttpPut]
        public async Task<JsonResult> SuaGiaoVien([FromBody] GiaoVien giaoVien)
        {
            var rs = await gv.CapNhatGiaoVien(giaoVien);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể sửa Giáo Viên"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Sửa giáo viên thành công"));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> XoaGiaoVien(int id)
        {
            var rs = await gv.XoaGiaoVien(id);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể xoá Giáo Viên"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Xóa giáo viên thành công"));
            }
        }
    }
}
