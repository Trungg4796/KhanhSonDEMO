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
    public class HocSinhController : ControllerBase
    {
        HocSinh hs = new HocSinh();
        // GET: api/HocSinh
        [HttpGet]
        public async Task<JsonResult> DanhSachHocSinh()
        {
            var rs = await hs.DanhSachHocSinh();
            return new JsonResult(rs);
        }

        // GET: api/HocSinh/5
        [HttpGet("{id}")]
        public async Task<JsonResult> ChiTietHocSinh(int id)
        {
            var rs = await hs.ChiTietHocSinh(id);
            return new JsonResult(rs);
        }
        [HttpGet("{id}")]
        public async Task<JsonResult> DanhSachHocSinhTheoKhoa(int id)
        {
            var rs = await hs.DanhSachHocSinhTheoKhoa(id);
            return new JsonResult(rs);
        }
        [HttpGet("{id}")]
        public async Task<JsonResult> DanhSachHocSinhTheoLop(int id)
        {
            var rs = await hs.DanhSachHocSinhTheoLop(id);
            return new JsonResult(rs);
        }

        // POST: api/HocSinh
        [HttpPost]
        public async Task<JsonResult> ThemMoiHocSinh([FromBody] HocSinh hsinsert)
        {
            var rs = await hs.ThemMoiHocSinh(hsinsert);
            if(rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể thêm mới"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Thêm mới thành công"));
            }
        }

        // PUT: api/HocSinh/5
        [HttpPut]
        public async Task<JsonResult> SuaHocSinh([FromBody] HocSinh hocsinh)
        {
            var rs = await hs.SuaHocSinh(hocsinh);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể cập nhật"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "cập nhật thành công"));
            }
        }

        //// DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> XoaHocSinh(int id)
        {
            var rs = await hs.XoaHocSinh(id);
            if(rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể xóa"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Xóa thành công"));
            }
        }
    }
}
