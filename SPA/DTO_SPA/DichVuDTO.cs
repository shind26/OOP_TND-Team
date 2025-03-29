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
        private LoaiDichVu loaiDichVu;
        private double giaThanh;
        List<DichVuDiKemDTO> dichVuDiKem; 
    
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

        internal List<DichVuDiKemDTO> DichVuDiKem { get => dichVuDiKem; set => dichVuDiKem = value; }
        public LoaiDichVu LoaiDichVu { get => loaiDichVu; set => loaiDichVu = value; }
        #endregion

        #region Methods
        public DichVuDTO()
        {
            DichVuDiKem = new List<DichVuDiKemDTO>();
        }

        public DichVuDTO(string madv, string tendv, LoaiDichVu loaidv, double giathanh, List<DichVuDiKemDTO> list)
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
                    LoaiDichVu = LoaiDichVu.Cham_Soc_Suc_Dep;
                }
                else if (lc == 2)
                {
                    LoaiDichVu = LoaiDichVu.Cham_Soc_Body;
                }
                else if (lc == 3)
                {
                    LoaiDichVu = LoaiDichVu.Duong_Sinh;
                }
                if(lc < 1 || lc > 3)
                    Console.WriteLine("Chỉ nhận 1, 2, 3");
            } while (lc < 1 || lc > 3);
            Console.Write("Nhập giá thành: ");
            GiaThanh = double.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng dịch vụ đi kèm");
            int sl = int.Parse(Console.ReadLine());
            for(int i = 0; i < sl; i++)
            {
                Console.Write($"Nhập dịch vụ đi kèm thứ {(i + 1)}");
                DichVuDiKemDTO dvdk = new DichVuDiKemDTO();
                dvdk.nhapDichVuDiKem();
            }
        }
        public void xuatDichVu()
        {
            Console.WriteLine($"Mã dịch vụ: {MaDichVu}\nTên dịch vụ: {TenDichVu}\nLoại dịch vụ: {LoaiDichVu}\n");
        }
        #endregion
    }
}
