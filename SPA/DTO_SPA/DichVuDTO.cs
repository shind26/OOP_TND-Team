using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class DichVuDTO
    {
        #region Attributes
        private string maDichVu;
        private string tenDichVu;
        private string loaiDichVu;
        private double giaThanh;
        private List<DichVuDiKemDTO> dsDVDiKem;
    
        public string MaDichVu
        {
            get
            {
                return maDichVu;
            }
            set
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    maDichVu = value;
                else maDichVu = "DV000";
            }
        }

        public string TenDichVu { get => tenDichVu;
            set 
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    tenDichVu = value;
                else tenDichVu = "Cạo lông mày";
            } 
        }

        

        public double GiaThanh { get => giaThanh;
            set 
            {
                if (value > 0)
                    giaThanh = value;
                else value = 20000;
            } 
        }

        public string LoaiDichVu
        {
            get => loaiDichVu;
            set
            {
                if ((!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value)) && 
                    (value == "Chăm sóc sức đẹp" || value == "Chăm sóc Body" || value == "Dưỡng sinh"))
                    LoaiDichVu = value;
                else loaiDichVu = "Chăm sóc sức đẹp";
            }
        }

        public List<DichVuDiKemDTO> DsDVDiKem { get => dsDVDiKem; set => dsDVDiKem = value; }
        #endregion

        #region Methods
        public DichVuDTO()
        {
            DsDVDiKem = new List<DichVuDiKemDTO>();
        }

        public DichVuDTO(string madv, string tendv, string loaidv, double giathanh)
        {
            MaDichVu = madv;
            TenDichVu = tendv;
            LoaiDichVu = loaidv;
            GiaThanh = giathanh;
            DsDVDiKem = new List<DichVuDiKemDTO>();
        }

        public DichVuDTO(DichVuDTO dv)
        {
            MaDichVu = dv.MaDichVu;
            TenDichVu = dv.TenDichVu;
            LoaiDichVu = dv.LoaiDichVu;
            GiaThanh = dv.GiaThanh;
            DsDVDiKem = dv.DsDVDiKem;
        }

        public virtual void nhapDichVu()
        {
            Console.Write("Nhập mã dịch vụ: ");
            MaDichVu = Console.ReadLine();
            Console.Write("Nhập tên dịch vụ: ");
            TenDichVu = Console.ReadLine();
            int lc;
            do
            {
                Console.Write("Nhâp loại dịch vụ (Chăm sóc sức đẹp (1) / Chăm sóc Body (2) / Dưỡng sinh (3)): ");
                lc = int.Parse(Console.ReadLine());
                if (lc == 1)
                {
                    LoaiDichVu = "Chăm sóc sức đẹp";
                }
                else if (lc == 2)
                {
                    LoaiDichVu = "Chăm sóc Body";
                }
                else if (lc == 3)
                {
                    LoaiDichVu = "Dưỡng sinh";
                }
                if(lc < 1 || lc > 3)
                    Console.WriteLine("Chỉ nhận 1, 2, 3");
            } while (lc < 1 || lc > 3);
            Console.Write("Nhập giá thành: ");
            GiaThanh = double.Parse(Console.ReadLine());
            Console.Write("Nhập vào số lượng dịch vụ đi kèm");
            int soLuong = int.Parse(Console.ReadLine());
            for (int i = 0; i < soLuong; i++)
            {
                DichVuDiKemDTO dvdk = new DichVuDiKemDTO();
                Console.Write("Nhập mã dịch vụ đi kèm: ");
                dvdk.MaDichVu = Console.ReadLine();
                Console.Write("Nhập tên dịch vụ đi kèm: ");
                dvdk.TenDichVu = Console.ReadLine();
                DsDVDiKem.Add(dvdk);
            }

        }
        public void xuatDichVu()
        {
            Console.WriteLine($"Mã dịch vụ: {MaDichVu}\nTên dịch vụ: {TenDichVu}\nLoại dịch vụ: {LoaiDichVu}\nGiá thành: {GiaThanh}");
            Console.WriteLine("DỊCH VỤ ĐI KÈM");
            foreach(DichVuDiKemDTO d in DsDVDiKem) {
                Console.WriteLine($"Dịch vụ đi kèm thứ {(DsDVDiKem.IndexOf(d) + 1)}"); 
                Console.WriteLine($"Mã dịch vụ đi kèm: {d.MaDichVu}\nTên dịch vụ đi kèm: {d.TenDichVu}");
            }
        }
        #endregion
    }
}
