using ButikKafe.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButikKafe
{
    public partial class GunSonu : Form
    {
        KafeVeri db;
        private string jsonFilePath = "gunsonu.json";

        public GunSonu(KafeVeri gunsonu, Giderler gider)
        {
            db = gunsonu;
            InitializeComponent();

        }


        private void GunSonu_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime baslangic = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, 0);
            DateTime bitis = new DateTime(dt.Year, dt.Month, dt.Day + 1, 0, 0, 0, 0, 0);
            var q = db.GecmisSiparisler.GroupBy(p => ((DateTime)p.KapanisZamani).Date).Select(p => new gunsonutip()
            {
                OdenenTutar = p.Sum(k => k.OdenenTutar),
                KapanisZamani = ((DateTime)p.FirstOrDefault().KapanisZamani).Date
            }).ToList();



            dataGridView1.DataSource = q;

            //ekrana yazdirma ve olusturma
            InitializeJsonFile();
            goster();

            label1.Text = db.GecmisSiparisler.Sum(p => p.OdenenTutar).ToString();
            // .OrderByDescending(x => x.KapanisZamani > baslangic && x.KapanisZamani < bitis && x.Durum == SiparisDurum.Odendi).ToList();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model newData = new Model
            {
                Dukkan = listBox1.SelectedItem.ToString(),
                Gider = Convert.ToInt32(textBox1.Text),
                KapanisZamani = DateTime.Now
            };
            List<Model> dataList = ReadDataFromJsonFile(jsonFilePath);

            // Yeni veriyi mevcut verilere ekle
            dataList.Add(newData);

            // Verileri JSON formatına dönüştür
            string json = JsonConvert.SerializeObject(dataList, Formatting.Indented);

            // JSON verisini dosyaya yaz
            File.WriteAllText(jsonFilePath, json);
            goster();
        }

        private List<Model> ReadDataFromJsonFile(string filePath)
        {
            // Dosya yoksa boş bir liste döndür
            if (!File.Exists(filePath))
            {
                return new List<Model>();
            }

            // JSON dosyasını oku
            string json;
            using (StreamReader r = new StreamReader(filePath))
            {
                json = r.ReadToEnd();
            }

            // JSON verisini List<Model> türüne dönüştür
            List<Model> dataList = JsonConvert.DeserializeObject<List<Model>>(json);

            return dataList;
        }

        public class Model
        {
            public string Dukkan { get; set; }
            public int Gider { get; set; }
            public DateTime? KapanisZamani { get; set; }
        }

        Model t;

        public void goster()
        {
                string json;
                using (StreamReader r = new StreamReader(jsonFilePath))
                {
                    json = r.ReadToEnd();
                }

                // JSON verisini List<Model> türüne dönüştürme
                List<Model> dataList = JsonConvert.DeserializeObject<List<Model>>(json);

            

            // DataGridView'e verileri yükleme
            dataGridView2.DataSource = dataList;

            label4.Text = dataList.Sum(t=>t.Gider).ToString();
            
        }

        private void InitializeJsonFile()
        {
            if (!File.Exists(jsonFilePath))
            {
                // Dosya yoksa boş bir dosya oluştur
                File.WriteAllText(jsonFilePath, "[]");
            }
        }
    }

    


    public class gunsonutip
    {
        public DateTime? KapanisZamani { get; set; }

        public decimal OdenenTutar { get; set; }
    }
}
