using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_SPA;

namespace BLL_SPA
{
    internal interface ICapNhatGia
    {
        void giamGia(List<DichVuDTO> danhSachDichVu);
        void tangGia(List<DichVuDTO> danhSachDichVu);
    }
}
