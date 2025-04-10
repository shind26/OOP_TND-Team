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
    public class DichVuBLL:ICapNhatGia
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

        public void addDichVuBLL(DichVuDTO dvthem)
        {

            DichVuDAL.ListDichVu.Add(dvthem);


            DichVuDAL.ghiFileDanhSachDichVu(@"../../../DAL_SPA/Data/DSDichVu.xml");

            Console.WriteLine("Thêm dịch vụ thành công!");
        }

        public List<DichVuDTO> timDichVuTheoTen(string tenDV)
        {
            return DichVuDAL.ListDichVu.Where(dv => dv.TenDichVu.Equals(tenDV, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void xuatDichVuGiaTren500()
        {
            List<DichVuDTO> dsDichVuGiaCao = DichVuDAL.ListDichVu.Where(dv => dv.GiaThanh > 500000).ToList();

            if (dsDichVuGiaCao.Count == 0)
            {
                Console.WriteLine("Không có dịch vụ nào có giá trên 500000");
                return;
            }

            foreach (DichVuDTO dichVu in dsDichVuGiaCao)
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

        public void giamGia(List<DichVuDTO> danhSachDichVu)
        {
            foreach(var dv in danhSachDichVu)
            {
                if(dv.LoaiDichVu == "Dưỡng sinh" || dv is DuongSinhDTO)
                {
                    dv.GiaThanh *= 0.9;
                }
                else if(dv.LoaiDichVu == "Chăm sóc Body" || dv is ChamSocBodyDTO)
                {
                    dv.GiaThanh *= 0.93;
                }  
            }
            dichVuDAL.capNhatGia(@"../../../DAL_SPA/Data/DSDichVu.xml", danhSachDichVu);
        }

        public void tangGia(List<DichVuDTO> danhSachDichVu)
        {
            foreach(var dv in danhSachDichVu)
            {
                if(dv.LoaiDichVu == "Chăm sóc sắc đẹp" || dv is ChamSocSacDepDTO)
                {
                    dv.GiaThanh *= 1.03;
                }
            }
            dichVuDAL.capNhatGia(@"../../../DAL_SPA/Data/DSDichVu.xml", danhSachDichVu);
        }
    }
}
