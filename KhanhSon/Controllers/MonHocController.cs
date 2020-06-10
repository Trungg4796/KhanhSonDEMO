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
    public class MonHocController : ControllerBase
    {
        // GET: api/MonHoc
        MonHoc mh = new MonHoc();
        [HttpGet]
        public async Task<JsonResult> DanhSachMonHoc()
        {
            var rs = await mh.DanhSachMonHoc();
            return new JsonResult(rs);
        }

        // GET: api/MonHoc/5
        

        // POST: api/MonHoc
        [HttpPost]
        public async Task<JsonResult> ThemMoiMonHoc([FromBody] MonHoc monHoc)
        {
            var rs = await mh.ThemMoiMonHoc(monHoc);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể thêm mới Môn học"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Thêm mới Môn học thành công"));
            }
        }

        // PUT: api/MonHoc/5
        [HttpPut]
        public async Task<JsonResult> SuaMonHoc([FromBody] MonHoc monHoc)
        {
            var rs = await mh.SuaMonHoc(monHoc);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể sửa Môn học"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Sửa Môn học thành công"));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> XoaMonHoc(int id)
        {
            var rs = await mh.XoaMonHoc(id);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "Không thể xóa Môn học"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "Xóa Môn học thành công"));
            }
        }
    }
}
