using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class DuongSinhDTO:DichVuDTO
    {
        public DuongSinhDTO():base()
        {
        }
        public DuongSinhDTO(string ma, string ten, double gia):base(ma, ten, "Dưỡng sinh", gia)
        {
        }

    }
}
