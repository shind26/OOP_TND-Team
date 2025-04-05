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
    internal class DichVuGUI
    {
        DichVuBLL dichVuBLL = new DichVuBLL();
        public void showList()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("DANH SÁCH DỊCH VỤ");

            List<DichVuDTO> dichVuDTOs = dichVuBLL.getList();

            var table = new Table();


            table.AddColumn("[yellow]STT[/]");
            table.AddColumn("[green]Mã Dịch Vụ[/]");
            table.AddColumn("[blue]Tên Dịch Vụ[/]");
            table.AddColumn("[red]Loại Dịch Vụ[/]");
            table.AddColumn("[purple]Giá Thành[/]");
            table.AddColumn("[cyan]Dịch Vụ Đi Kèm[/]");

            int stt = 1;

            foreach (var dichVuDTO in dichVuDTOs)
            {
                string dsDichVuDiKem = dichVuDTO.DsDVDiKem.Count > 0
                    ? string.Join("\n", dichVuDTO.DsDVDiKem.Select(dk => $"- {dk.TenDichVu} ({dk.MaDichVu})"))
                    : "Không có";

                table.AddRow(
                    stt.ToString(),
                    dichVuDTO.MaDichVu,
                    dichVuDTO.TenDichVu,
                    dichVuDTO.LoaiDichVu,
                    dichVuDTO.GiaThanh.ToString("N0"),
                    dsDichVuDiKem
                );

                stt++;
            }


            AnsiConsole.Write(table);
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

        public void xuatDVDuongSinh()
        {
            dichVuBLL.xuatDichVu_DuongSinh();
        }
    }
}
