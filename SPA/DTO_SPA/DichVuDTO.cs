using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    class DichVuDTO
    {
        #region Attributes
        private string maDichVu;
        private string tenDichVu;
        private string loaiDichVu;
        private double giaThanh;
        List<DichVuDTO> dichVuDiKem; 
    
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

        public string LoaiDichVu { get => loaiDichVu;
            set 
            {
                if ((!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value)) &&
                    (value == "Chăm sóc sức đẹp" || value == "Chăm sóc Body" || value == "Dưỡng sinh"))
                    loaiDichVu = value;
                else loaiDichVu = "Chăm sóc sức đẹp";
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

        internal List<DichVuDTO> DichVuDiKem { get => dichVuDiKem; set => dichVuDiKem = value; }
        #endregion

        #region Methods
        public DichVuDTO()
        {
            DichVuDiKem = new List<DichVuDTO>();
        }

        public DichVuDTO(string madv, string tendv, string loaidv, double giathanh, List<DichVuDTO> list)
        {
            MaDichVu = madv;
            TenDichVu = tendv;
            LoaiDichVu = loaidv;
            GiaThanh = giathanh;
            DichVuDiKem = list;
        }

        public DichVuDTO(DichVuDTO dv)
        {
            MaDichVu = dv.MaDichVu;
            TenDichVu = dv.TenDichVu;
            LoaiDichVu = dv.LoaiDichVu;
            GiaThanh = dv.GiaThanh;
            DichVuDiKem = dv.DichVuDiKem;
        }

        public void nhapDichVu()
        {
            Console.WriteLine("Nhập mã dịch vụ: ");
            MaDichVu = Console.ReadLine();
            Console.WriteLine("Nhập tên dịch vụ: ");
            TenDichVu = Console.ReadLine();
            Console.WriteLine("Nhâp loại dịch vụ (Chăm sóc sức đẹp / Chăm sóc Body / Dưỡng sinh): ");
            LoaiDichVu = Console.ReadLine();
            Console.WriteLine("Nhập giá thành: ");
            GiaThanh = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập số lượng dịch vụ đi kèm");
            int sl = int.Parse(Console.ReadLine());
            for(int i = 0; i < sl; i++)
            {
                Console.WriteLine($"Nhập dịch vụ đi kèm thứ {(i + 1)}");
                
            }
        }
        #endregion
    }
}
