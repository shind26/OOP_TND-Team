using DTO_SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
<<<<<<< Updated upstream
=======
using System.Xml.Linq;
using DTO_SPA;
>>>>>>> Stashed changes

namespace DAL_SPA
{
    public class DichVuDAL
    {
        List<DichVu> listDichVu;

        public List<DichVu> ListDichVu
        {
            get => listDichVu;
            set => listDichVu = value;
        }

        public DichVuDAL()
        {
            ListDichVu = new List<DichVu>();
        }

        // Đọc danh sách dịch vụ từ file xml
        public List<DichVu> docFile(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            //....
            return ListDichVu;
        }

        // Xuất danh sách dịch vụ
        public void xuatDSDV()
        {
            foreach (DichVu dichVu in ListDichVu)
                dichVu.xuatThongTinDichVu();
        }

        public void ghiFileDanhSachDichVu(string f)
        {
            XDocument xmlDoc;

            try
            {
                xmlDoc = XDocument.Load(f);
            }
            catch
            {
                xmlDoc = new XDocument(new XElement("DSDichVu"));
            }

            XElement root = xmlDoc.Element("DSDichVu");

            foreach (var dv in ListDichVu)
            {

                if (root.Elements("DichVu").Any(x => x.Element("MaDichVu")?.Value == dv.MaDichVu))
                {
                    continue;
                }


                XElement newDichVu = new XElement("DichVu",
                    new XElement("MaDichVu", dv.MaDichVu),
                    new XElement("TenDichVu", dv.TenDichVu),
                    new XElement("LoaiDichVu", dv.LoaiDichVu),
                    new XElement("GiaThanh", dv.GiaThanh),
                    new XElement("DSDichVuDiKem",
                        dv.DsDVDiKem.Select(dk =>
                            new XElement("DichVuDiKem",
                                new XElement("MaDichVu", dk.MaDichVu),
                                new XElement("TenDichVu", dk.TenDichVu)
                            )
                        )
                    )
                );

                root.Add(newDichVu);
            }


            xmlDoc.Save(f);
        }

    }
}

