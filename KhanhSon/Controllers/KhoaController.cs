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
    public class KhoaController : ControllerBase
    {
        Khoa khoa = new Khoa();
        // GET: api/Khoa
        [HttpGet]
        public async Task<JsonResult> DanhSach()
        {
            var rs = await khoa.DanhSachKhoa();
            return new JsonResult(rs);
        }

        // GET: api/Khoa/5
        

        // POST: api/Khoa
        [HttpPost]
        public async Task<JsonResult> ThemMoiKhoa([FromBody] Khoa khoaInsert)
        {
            var rs = await khoa.ThemMoiKhoa(khoaInsert);
            if(rs == 0)
            {
                return new JsonResult(new ThongBao(1, "xay ra loi"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "them moi thanh cong"));
            }
        }

        // PUT: api/Khoa/5
        [HttpPut]
        public async Task<JsonResult> SuaKhoa([FromBody] Khoa khoaUpdate)
        {
            var rs = await khoa.SuaKhoa(khoaUpdate);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "xay ra loi"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "sua thanh cong"));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> XoaKhoa(int id)
        {
            var rs = await khoa.XoaKhoa(id);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(1, "xay ra loi"));
            }
            else
            {
                return new JsonResult(new ThongBao(0, "xoa thanh cong"));
            }
        }
    }
}
