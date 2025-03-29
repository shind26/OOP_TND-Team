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
                    (value == "Chăm sóc sức đẹp" || value == "Chăm sóc body" || value == "Dưỡng sinh"))
                    LoaiDichVu = value;
                else loaiDichVu = "Chăm sóc sức đẹp";
            }
        }
        #endregion

        #region Methods
        public DichVuDTO()
        {
        }

        public DichVuDTO(string madv, string tendv, string loaidv, double giathanh)
        {
            MaDichVu = madv;
            TenDichVu = tendv;
            LoaiDichVu = loaidv;
            GiaThanh = giathanh;
        }

        public DichVuDTO(DichVuDTO dv)
        {
            MaDichVu = dv.MaDichVu;
            TenDichVu = dv.TenDichVu;
            LoaiDichVu = dv.LoaiDichVu;
            GiaThanh = dv.GiaThanh;
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
                    LoaiDichVu = "Chăm sóc body";
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
        }
        public virtual void xuatDichVu()
        {
            Console.WriteLine($"Mã dịch vụ: {MaDichVu}\nTên dịch vụ: {TenDichVu}\nLoại dịch vụ: {LoaiDichVu}\nGiá thành: {GiaThanh}");
        }
        #endregion
    }
}
