using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class DuongSinhDTO:DichVuDTO
    {
        List<DichVuDiKemDTO> dichVuDiKem;

        public List<DichVuDiKemDTO> DichVuDiKem { get => dichVuDiKem; set => dichVuDiKem = value; }
        public DuongSinhDTO():base()
        {
            DichVuDiKem = new List<DichVuDiKemDTO>();
        }
        public DuongSinhDTO(string ma, string ten, double gia, List<DichVuDiKemDTO> listdv):base(ma, ten, "Dưỡng sinh", gia)
        {
            DichVuDiKem = listdv;
        }
        public override void nhapDichVu()
        {
            base.nhapDichVu();
            Console.WriteLine("Nhập số lượng dịch vụ đi kèm: ");
            int sl = int.Parse(Console.ReadLine());
            for (int i = 0; i < sl; i++)
            {
                DichVuDiKemDTO dichVuDiKemDTO = new DichVuDiKemDTO();
                dichVuDiKemDTO.nhapDichVuDiKem();
                DichVuDiKem.Add(dichVuDiKemDTO);
            }
        }
        public override void xuatDichVu()
        {
            base.xuatDichVu();
            Console.WriteLine("DANH SÁCH DỊCH VỤ ĐI KÈM");
            foreach (DichVuDiKemDTO dv in DichVuDiKem)
            {
                dv.xuatDichVuDiKem();
            }
        }

    }
}
