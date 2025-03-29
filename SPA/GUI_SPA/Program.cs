using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_SPA;
using DTO_SPA;

namespace GUI_SPA
{
    class Program
    {
        static void Main(string[] args)
        {
            DichVuGUI dichVuGUI = new DichVuGUI();
            dichVuGUI.showList();
        }
    }
}
