using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class ChamSocSucDepDTO:DichVuDTO
    {
        public ChamSocSucDepDTO():base()
        {
            
        }

        public ChamSocSucDepDTO(string ma, string ten, double gia):base(ma, ten, "Chăm sóc sức đẹp", gia) 
        {
            
        }
    }
}
