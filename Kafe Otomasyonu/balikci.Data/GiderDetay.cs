using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikKafe.Data
{
    public class GiderDetay
    {
        public string ToptancıAd { get; set; }

        public decimal Maaliyet { get; set; }

        

       public string TutarTL => string.Format("{0:0.00}₺", Tutar()); // 9.00₺ //prop geti bu

        public decimal Tutar() => Maaliyet; // metodun returnu bu 
    }
}
