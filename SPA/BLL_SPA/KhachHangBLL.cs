using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SPA;
using DTO_SPA;

namespace BLL_SPA
{
    public class KhachHangBLL
    {
        private KhachHangDAL khachHangDAL;
        public KhachHangDAL KhachHangDAL { get => khachHangDAL; set => khachHangDAL = value; }

        public KhachHangBLL()
        {
            KhachHangDAL = new KhachHangDAL();
        }
        public List<KhachHangDTO> getList()
        {
            return khachHangDAL.docFile(@"../../../DAL_SPA/Data/DSKhachHang.xml");
        }

    }
}
