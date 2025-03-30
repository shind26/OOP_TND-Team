using System;
using System.Collections;
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
            return DichVuDAL.docFile(@"../../../DAL_SPA/Data/DSDichVu.xml");
        }

        public List<DichVuDTO> timDichVuTheoTen(string tenDV)
        {
            return DichVuDAL.ListDichVu.Where(dv => dv.TenDichVu.Equals(tenDV, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void xuatDichVuGiaTren500()
        {
            var dsDichVuGiaCao = DichVuDAL.ListDichVu.Where(dv => dv.GiaThanh > 500).ToList();

            if (dsDichVuGiaCao.Count == 0)
            {
                Console.WriteLine("Không có dịch vụ nào có giá trên 500");
                return;
            }

            foreach (var dichVu in dsDichVuGiaCao)
                dichVu.xuatDichVu();
        }

        public void xuatDichVu_ChamSocSacDep()
        {
            int count = 0;
            foreach (var dichVu in DichVuDAL.ListDichVu)
            {
                if (dichVu.LoaiDichVu == "Chăm sóc sắc đẹp" || dichVu is ChamSocSacDepDTO)
                {
                    dichVu.xuatDichVu();
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Không có dịch vụ chăm sóc sắc đẹp trong danh sách");
            }
        }

        public void xuatDichVu_DuongSinh()
        {
            int count = 0;
            foreach (var dichVu in DichVuDAL.ListDichVu)
            {
                if (dichVu.LoaiDichVu == "Dưỡng sinh" || dichVu is DuongSinhDTO)
                {
                    dichVu.xuatDichVu();
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Không có dịch vụ dưỡng sinh trong danh sách");
            }
        }
    }
}
