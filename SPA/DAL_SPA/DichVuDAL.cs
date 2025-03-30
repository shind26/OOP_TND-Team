using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DTO_SPA;

namespace DAL_SPA
{
    public class DichVuDAL
    {
        List<DichVuDTO> listDichVu;


        public List<DichVuDTO> ListDichVu { get => listDichVu; set => listDichVu = value; }
        public DichVuDAL()
        {
            ListDichVu = new List<DichVuDTO>();
        }

        public List<DichVuDTO> docFile(string path)
        {
            XmlDocument document = new XmlDocument();
            List<DichVuDTO> listDichVu = new List<DichVuDTO>();
            document.Load(path);
            XmlNodeList nodeList = document.SelectNodes("DSDichVu/DichVu");
            foreach (XmlNode node in nodeList)
            {
                
                string maDichVu = node["MaDichVu"].InnerText;
                string tenDichVu = node["TenDichVu"].InnerText;
                string loaiDichVu = node["LoaiDichVu"].InnerText;
                double giaThanh = double.Parse(node["GiaThanh"].InnerText);
                DichVuDTO dv = new DichVuDTO();
                switch (loaiDichVu)
                {
                    case "Chăm sóc sắc đẹp":
                        dv = new ChamSocSacDepDTO(maDichVu, tenDichVu, giaThanh);
                        break;
                    case "Chăm sóc Body":
                        dv = new ChamSocBodyDTO(maDichVu, tenDichVu, giaThanh);
                        break;
                    case "Dưỡng sinh":
                        dv = new DuongSinhDTO(maDichVu, tenDichVu, giaThanh);
                        break;
                    default:
                        Console.WriteLine("Lỗi");
                        break;
                }
                XmlNodeList listDVDiKem = node.SelectNodes("DSDichVuDiKem/DichVuDiKem");
                foreach (XmlNode xmlNode in listDVDiKem)
                {
                    DichVuDiKemDTO dvdk = new DichVuDiKemDTO();
                    dvdk.MaDichVu = xmlNode["MaDichVu"].InnerText;
                    dvdk.TenDichVu = xmlNode["TenDichVu"].InnerText;
                    dv.DsDVDiKem.Add(dvdk);
                }
                    listDichVu.Add(dv);
            }
            return listDichVu;
        }

        public void xuatDanhSachDichVu()
        {
            foreach (DichVuDTO dichVu in ListDichVu)
                dichVu.xuatDichVu();
        }
    }
}
