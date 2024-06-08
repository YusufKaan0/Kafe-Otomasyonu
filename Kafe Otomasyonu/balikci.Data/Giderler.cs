using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikKafe.Data
{
    public class Giderler
    {
       public string ToptancıAd {  get; set; } 

        public decimal Maaliyet {  get; set; }

        public DateTime OdemeZamani {  get; set; }

        public decimal OdenenTutar {  get; set; }
       
        public List<GiderDetay> Giderlers { get; set; }


       
    }
}
