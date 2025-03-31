using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_SPA;
using DTO_SPA;
namespace GUI_SPA
{
    internal class KhachHangGUI
    {
        private KhachHangBLL khachHangBLL;
        public KhachHangBLL KhachHangBLL { get => khachHangBLL; set => khachHangBLL = value; }
        public KhachHangGUI()
        {
            KhachHangBLL = new KhachHangBLL();
        }

        public void showList()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("DANH SÁCH KHÁCH HÀNG");
            List<KhachHangDTO> khachHangDTOs = new List<KhachHangDTO>();
            khachHangDTOs = khachHangBLL.getList();
            foreach (KhachHangDTO k in khachHangDTOs)
            {
                Console.WriteLine($"KHÁCH HÀNG THỨ {(khachHangDTOs.IndexOf(k) + 1)}");
                k.xuatKhachHang();
                Console.WriteLine();
            }
        }

        public void xuatDVTheoTenKH()
        {
            khachHangBLL.xuatDSDV_TenKhachHang("Trương Ích Thái Duy");
        }
        public void xuatDSKHNhieuHon3DV()
        {
            khachHangBLL.xuatDSKH_NhieuDichVu();
        }
    }
}
