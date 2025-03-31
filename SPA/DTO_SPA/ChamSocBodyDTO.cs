using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DTO_SPA
{
    public class ChamSocBodyDTO:DichVuDTO
    {
        public ChamSocBodyDTO():base()
        {
            
        }

        public ChamSocBodyDTO(string ma, string ten, double gia):base(ma, ten, "Chăm sóc Body", gia)
        {
            
        }

    }
}
