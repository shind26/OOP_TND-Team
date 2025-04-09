using System;
using System.Collections.Generic;
using System.Text;
using BLL_SPA;
using DTO_SPA;
using Spectre.Console;  

namespace GUI_SPA
{
    internal class MenuGUI
    {
        public static void Show()
        {
            DichVuGUI dichVuGUI = new DichVuGUI();
            KhachHangGUI khachHangGUI = new KhachHangGUI();
            DichVuBLL dichVuBLL = new DichVuBLL();
            KhachHangBLL khachHangBLL = new KhachHangBLL();

            while (true)
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;


                var table = new Table();
                table.AddColumn("[bold yellow]MÃ[/]");
                table.AddColumn("[bold green]CHỨC NĂNG[/]");

                table.AddRow("[bold]0[/]", "Thoát chương trình");
                table.AddRow("[bold]1[/]", "Xuất danh sách dịch vụ và khách hàng.");
                table.AddRow("[bold]2[/]", "Thêm dịch vụ mới.");
                table.AddRow("[bold]3[/]", "Thêm khách hàng mới.");
                table.AddRow("[bold]4[/]", "Tìm kiếm dịch vụ khi biết tên.");
                table.AddRow("[bold]5[/]", "Xuất danh sách các dịch vụ khi biết tên khách hàng.");
                table.AddRow("[bold]6[/]", "Cập nhật kinh phí các dịch vụ chăm sóc sắc đẹp tăng lên 3 %.");
                table.AddRow("[bold]7[/]", "Xuất danh sách các dịch vụ có giá thành trên 500.");
                table.AddRow("[bold]8[/]", "Xuất danh sách các dịch vụ thuộc dịch vụ chăm sóc sắc đẹp.");
                table.AddRow("[bold]9[/]", "In ra danh sách các khách hàng đã thực hiện nhiều hơn 3 dịch vụ.");
                table.AddRow("[bold]10[/]", "In ra danh sách dịch vụ dưỡng sinh.");





                AnsiConsole.Write(table);

                Console.Write("\nChọn một tùy chọn: ");
                string choice = Console.ReadLine();
                Console.WriteLine("----------------------------------------------");

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thoát chương trình...");
                        return;

                    case "1":
                        Console.Clear();
                        dichVuGUI.showList();
                        Console.WriteLine();
                        khachHangGUI.showList();
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        DichVuDTO newDichVu = new DichVuDTO();
                        newDichVu.nhapDichVu(); 
                        dichVuBLL.addDichVuBLL(newDichVu);
                        Console.WriteLine("\nDịch vụ đã được thêm thành công!");
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        KhachHangDTO newKhachHang = new KhachHangDTO();
                        newKhachHang.nhapKhachHang();
                        khachHangBLL.addKhachHangBLL(newKhachHang);
                        Console.WriteLine("\nKhách hàng đã được thêm thành công!");
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Nhập tên dịch vụ cần tìm: ");
                        string tenDV = Console.ReadLine();
                        Console.WriteLine($"Dịch vụ có tên {tenDV}: ");
                        dichVuGUI.xuatDVTimTheoTen(tenDV);
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "5":
                        khachHangGUI.showList();
                        khachHangGUI.xuatDVTheoTenKH();
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "6":
                        
                        dichVuGUI.showList();
                        Console.WriteLine("DANH SÁCH SAU KHI CẬP NHẬT GIÁ");
                        dichVuGUI.showListAfterDiscount();
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "7":
                        Console.WriteLine("DANH SÁCH DỊCH VỤ GIÁ TRÊN 500.000VNĐ");
                        dichVuGUI.xuatDVGiaTren500();
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "8":
                        Console.WriteLine("DANH SÁCH DỊCH VỤ CHĂM SÓC SẮC ĐẸP");
                        dichVuGUI.xuatDVChamSocSacDep();
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "9":
                        Console.WriteLine("DANH SÁCH KHÁCH HÀNG NHIỀU HƠN 3 DỊCH VỤ");
                        khachHangGUI.xuatDSKHNhieuHon3DV();
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;

                    case "10":
                        Console.WriteLine("DANH SÁCH DỊCH VỤ DƯỠNG SINH");
                        dichVuGUI.xuatDVDuongSinh();
                        Console.WriteLine("\nNhấn Enter để quay lại menu...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
