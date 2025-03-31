using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_SPA;
using DTO_SPA;

namespace GUI_SPA
{
    internal class DichVuGUI
    {
        DichVuBLL dichVuBLL = new DichVuBLL();
        public void showList()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("DANH SÁCH DỊCH VỤ");
            List<DichVuDTO> dichVuDTOs = new List<DichVuDTO>();
            dichVuDTOs = dichVuBLL.getList();
            foreach (DichVuDTO dichVuDTO in dichVuDTOs)
            {
                Console.WriteLine("DỊCH VỤ THỨ " + (dichVuDTOs.IndexOf(dichVuDTO) + 1));
                dichVuDTO.xuatDichVu();
                Console.WriteLine();
            }
        }

        public void showListAfterDiscount()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("DANH SÁCH DỊCH VỤ");
            List<DichVuDTO> dichVuDTOs = new List<DichVuDTO>();
            dichVuDTOs = dichVuBLL.getList();
            dichVuBLL.giamGia(dichVuDTOs);
            dichVuBLL.tangGia(dichVuDTOs);
            foreach (DichVuDTO dichVuDTO in dichVuDTOs)
            {
                Console.WriteLine("DỊCH VỤ THỨ " + (dichVuDTOs.IndexOf(dichVuDTO) + 1));
                
                dichVuDTO.xuatDichVu();
                Console.WriteLine();
            }
        }

        public void xuatDVTimTheoTen(string tenDV)
        {
           
            List<DichVuDTO> listDV = dichVuBLL.timDichVuTheoTen(tenDV);
            foreach (DichVuDTO dichVu in listDV)
                dichVu.xuatDichVu();
        }

        public void xuatDVGiaTren500()
        {
            dichVuBLL.xuatDichVuGiaTren500();
        }

        public void xuatDVChamSocSacDep()
        {
            dichVuBLL.xuatDichVu_ChamSocSacDep();
        }
    }
}
