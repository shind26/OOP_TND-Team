using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class ChamSocSacDepDTO:DichVuDTO
    {
        public ChamSocSacDepDTO():base()
        {
            
        }

        public ChamSocSacDepDTO(string ma, string ten, double gia):base(ma, ten, "Chăm sóc sắc đẹp", gia) 
        {
            
        }
        public double capNhatKinhPhi(double phantram)
        {
            return (phantram * GiaThanh) + GiaThanh;
        }
    }
}
