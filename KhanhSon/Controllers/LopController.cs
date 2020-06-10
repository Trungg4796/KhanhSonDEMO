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
    public class LopController : ControllerBase
    {
        Lop lop = new Lop();
        // GET: api/Lop
        [HttpGet]
        public async Task<JsonResult> DanhSachLop()
        {
            var rs = await lop.DanhSachLop();
            return new JsonResult(rs);
        }
        [HttpGet("{Id}")]
        public async Task<JsonResult> ChiTietLop(int Id)
        {
            var rs = await lop.ChiTietLop(Id);
            return new JsonResult(rs);
        }
        [HttpGet("{Id}")]
        public async Task<JsonResult> DanhSachLopTheoKhoa(int Id)
        {
            var rs = await lop.DanhSachLopTheoKhoa(Id);
            return new JsonResult(rs);
        }

        // POST: api/Lop
        [HttpPost]
        public async Task<JsonResult> ThemMoiLop([FromBody] Lop lopInsert)
        {
            var rs = await lop.ThemMoiLop(lopInsert);
            if(rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Thêm mới không thành công"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "thêm mới thành công"));
            }
        }

        // PUT: api/Lop/5
        [HttpPut]
        public async Task<JsonResult> SuaLop([FromBody] Lop lopUpDate)
        {
            var rs = await lop.SuaLop(lopUpDate);
            if(rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể sửa lớp"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Sửa lớp thành công"));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> XoaLop(int id)
        {
            var rs = await lop.XoaLop(id);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể xóa lớp"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Xóa lớp thành công"));
            }
        }
    }
}
