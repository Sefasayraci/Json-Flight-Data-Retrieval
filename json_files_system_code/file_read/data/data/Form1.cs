using System.Drawing.Imaging;
using System.IO;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JsonConveter;
using Json;
using System.Windows;
using System.Windows.Forms;
using System.IO.Pipes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text;

namespace data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Seçmeden okuma üst code, alt code seçerek okumadır.
        {
            
            try
            {
                StreamReader oku = new StreamReader(@"C:\Users\sefas\Desktop\eklenecek");
                StreamReader oku = new StreamReader("readfile");
                richTextBox1.Text = oku.ReadToEnd();
                oku.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("dosya okunmadı");

            }
            
            try
            {
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                string readfile = File.ReadAllText(filename);
                richTextBox1.Text = readfile;
            }
            catch (Exception)
            {
                MessageBox.Show("dosya okunmadı");
            }
        }

        private void button2_Click(object sender, EventArgs e) // JSON to XML Gelecek_Convert_Data
        {
            try
            {
                using (Converter converter = new Converter(@"C:\Users\sefas\Desktop\mmu.json"))
                {
                    DataConvertOptions options = new DataConvertOptions
                    {
                        Format = DataFileType.Xml
                    };
                    converter.Convert(@"path/jsonToXML.xml", options);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("dosya cevrilmedi");         
            }
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);
        }

        private void button3_Click(object sender, EventArgs e) // JSON Saved Select
        {
            string metin = richTextBox1.Text;
            FileStream fileStream = new FileStream("mmujson.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine(metin);
            sw.Close();
            MessageBox.Show("Kayıt Başarılı", "Dosya Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            string metin2 = richTextBox2.Text;
            FileStream fileStream2 = new FileStream("sefa2.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw2 = new StreamWriter(fileStream);
            sw.WriteLine(metin);
            sw.Close();
            MessageBox.Show("Kayıt Başarılı", "Dosya Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button4_Click(object sender, EventArgs e) // Clear in textbox.rich
        {
            string metin = richTextBox1.Text;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e) // Okuma Kısmı Üst Kısma Geçirildi.
        {
            string[] secilendosyayolu;
            openFileDialog1.ShowDialog();
            secilendosyayolu = openFileDialog1.FileNames;

            for (int i = 0; i < secilendosyayolu.Length; i++)
            {
 
                OpenFileDialog file = new OpenFileDialog();
                file.FilterIndex = 2;
                file.RestoreDirectory = true;
                file.CheckFileExists = false;
                file.Title = "Json File Dosyası Açınız";
                file.Multiselect = true;

                if (file.ShowDialog() == DialogResult.OK)
                {
                    string DosyaYolu = file.FileName;
                    string DosyaAdi = file.SafeFileName;
                }
            }
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readfile = File.ReadAllText(filename);
            richTextBox2.Text = readfile;
          
        }

        private void button7_Click(object sender, EventArgs e) // JSON List Selected
        {
            JsonListe();
        }

        private void button6_Click(object sender, EventArgs e)  // XML Saved Select
        {
            string metin = richTextBox3.Text;
            FileStream fileStream = new FileStream("mmuxml.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine(metin);
            sw.Close();
            MessageBox.Show("Kayıt Başarılı", "Dosya Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)  // JSON List Saved
        {
            string metin = richTextBox2.Text;
            FileStream fileStream = new FileStream("mmujsonlist.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine(metin);
            sw.Close();
            MessageBox.Show("Kayıt Başarılı", "Dosya Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public List<JsonModel> JsonListe()
        {
            List<JsonModel> LsonModelList = null;
            try
            {
                StreamReader oku = new StreamReader(@"C:\Users\sefas\Desktop\mmu.json"); // deneme için okunmuş dosya çekilmeli
                richTextBox1.Text = oku.ReadToEnd();
                
                JsonModelList = Newtonsoft.Json.JsonConvert.SerializeObject<List<JsonModel>>(JsonText);
                oku.Close();
            }
            catch (Exception)
            {
                JsonModelList = null;

            }
            return JsonModelList;
        }
        public class RootoObject //başlangıç
        {

            public class Rootobject
            {
                public int IcdParameterId { get; set; }
                public string IrsParameterName { get; set; }
                public string DataType { get; set; }
                public float Default { get; set; }
                public bool DTSUpdate { get; set; }
                public bool GlobalReset { get; set; }
                public bool ElectronicsReset { get; set; }
                public bool Nvm { get; set; }
                public bool Monitor { get; set; }
                public bool IsConstantParameter { get; set; }
                public int[] RelatedSources { get; set; }
                public int IrsParameterId { get; set; }
                public string IcdParameterName { get; set; }
                public Parameterrange ParameterRange { get; set; }
                public string Direction { get; set; }
                public string Unit { get; set; }
            }

            public class Parameterrange
            {
                public string RangeType { get; set; }
                public float MinValue { get; set; }
                public float MaxValue { get; set; }
            }
            
        }//bitiş
    }
}
