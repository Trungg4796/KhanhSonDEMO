using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhanhSon.Models
{
    public class ThongBao
    {
        public int Loi { get; set; }
        public string noiDung { get; set; }
        public ThongBao(int loi, string noiDung)
        {
            this.Loi = loi;
            this.noiDung = noiDung;
        }
    }
}
