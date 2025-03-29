using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_SPA;

namespace GUI_SPA
{
    class Program
    {
        static void Main(string[] args)
        {
            DichVuDTO dichVu = new DuongSinhDTO();
            dichVu.nhapDichVu();
            dichVu.xuatDichVu();
        }
    }
}
