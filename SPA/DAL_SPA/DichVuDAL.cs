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

        public void docFile(string path)
        {
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XmlNodeList nodeList = document.SelectNodes("DSDichVu/DichVu");
            foreach (XmlNode node in nodeList)
            {
                DichVuDTO dv = new DichVuDTO();
                dv.MaDichVu = node["MaDichVu"].InnerText;
                dv.TenDichVu = node["TenDichVu"].InnerText;
                dv.LoaiDichVu = node["LoaiDichVu"].InnerText;
                XmlNodeList listDVDiKem = document.SelectNodes("DSDichVu/DichVu/DSDichVuDiKem/DichVuDiKem");
                foreach (XmlNode xmlNode in listDVDiKem)
                {
                    DichVuDiKemDTO dvdk = new DichVuDiKemDTO();
                    dvdk.MaDichVu = node["MaDichVu"].InnerText;
                    dvdk.TenDichVu = node["TenDichVu"].InnerText;
                }
            }
        }

    }
}
