using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SPA;
using DTO_SPA;

namespace BLL_SPA
{
    public class DichVuBLL
    {
        private DichVuDAL dichVuDAL;

        public DichVuDAL DichVuDAL { get => dichVuDAL; set => dichVuDAL = value; }
        public DichVuBLL()
        {
            DichVuDAL = new DichVuDAL();
        }

        public List<DichVuDTO> getList()
        {
            return DichVuDAL.docFile("D:\\Documents\\BaiTapOOP\\BaiTapNhom\\SPA\\DAL_SPA\\Data\\DSDichVu.xml");
        }
    }
}
