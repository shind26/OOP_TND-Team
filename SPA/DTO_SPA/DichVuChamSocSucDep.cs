using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    internal class DichVuChamSocSucDep:DichVu, ICapNhatGia
    {
        public DichVuChamSocSucDep():base()
        {
            
        }

        public override double TinhGiaSauGiamGia()
        {
            return GiaThanh; // Không giảm giá
        }

        public void CapNhatGia()
        {
            GiaThanh *= 1.03; // Tăng 3%
        }
    }
}
