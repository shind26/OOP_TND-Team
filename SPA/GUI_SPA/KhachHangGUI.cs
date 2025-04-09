using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_SPA;
using DTO_SPA;
using Spectre.Console;

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

            List<KhachHangDTO> khachHangDTOs = khachHangBLL.getList();

            foreach (var kh in khachHangDTOs)
            {

                AnsiConsole.MarkupLine($"[bold yellow]KHÁCH HÀNG: {kh.TenKhachHang}[/]");
                AnsiConsole.MarkupLine($"Mã: [blue]{kh.MaKhachHang}[/] | SĐT: [green]{kh.SoDienThoai}[/]\n");


                var table = new Table();
                table.AddColumn("[bold yellow]Mã Dịch Vụ[/]");
                table.AddColumn("[bold green]Tên Dịch Vụ[/]");
                table.AddColumn("[bold blue]Loại Dịch Vụ[/]");
                table.AddColumn("[bold red]Giá Thành[/]");

                foreach (var dv in kh.DanhSachDichVu)
                {
                    table.AddRow(dv.MaDichVu, dv.TenDichVu, dv.LoaiDichVu, $"{dv.GiaThanh:N0} VND");


                    if (dv.DsDVDiKem.Count > 0)
                    {
                        var subTable = new Table();
                        subTable.AddColumn("[bold yellow]Mã DV Đi Kèm[/]");
                        subTable.AddColumn("[bold green]Tên DV Đi Kèm[/]");

                        foreach (var dvdk in dv.DsDVDiKem)
                        {
                            subTable.AddRow(dvdk.MaDichVu, dvdk.TenDichVu);
                        }

                        table.AddRow("[italic]Dịch vụ đi kèm ↓[/]", "", "", "");
                        table.AddRow(subTable);
                    }
                }


                AnsiConsole.Write(table);
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
