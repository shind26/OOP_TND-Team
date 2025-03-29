using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    // Lớp dịch vụ chăm sóc body (giảm 7%)
    public class DichVuChamSocBody : DichVu
    {
        public DichVuChamSocBody() : base()
        {
            LoaiDichVu = LoaiDichVuEnum.ChamSocBody;
        }
        public override double TinhGiaSauGiamGia()
        {
            return GiaThanh * 0.93; // Giảm 7%
        }
    }
}
