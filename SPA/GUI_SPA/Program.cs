using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_SPA;
using DTO_SPA;

namespace GUI_SPA
{
    class Program
    {
        static void Main(string[] args)
        {
            DichVuGUI dichVuGUI = new DichVuGUI();
            //Console.WriteLine("DANH SÁCH DỊCH VỤ");
            //dichVuGUI.showList();
            //Console.WriteLine("DANH SÁCH SAU KHI CẬP NHẬT GIÁ");
            //dichVuGUI.showListAfterDiscount();
            //dichVuGUI.xuatDVGiaTren500();
            //dichVuGUI.xuatDVChamSocSacDep();
            //Console.WriteLine();
            //Console.Write("Nhập tên dịch vụ cần tìm: ");
            //string tenDV = Console.ReadLine();
            //Console.WriteLine($"Dịch vụ có tên {tenDV}: ");
            //dichVuGUI.xuatDVTimTheoTen(tenDV);
            KhachHangGUI khachHangGUI = new KhachHangGUI();
            khachHangGUI.showList();
            //khachHangGUI.xuatDVTheoTenKH();
            Console.WriteLine("DANH SÁCH KHÁCH HÀNG NHIỀU HƠN 3 DỊCH VỤ");
            khachHangGUI.xuatDSKHNhieuHon3DV();
            Console.ReadKey();
        }
    }
}
