using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsikVeysel_Tccd
{
    public partial class Biletform : Form
    {
        public Biletform()
        {
            InitializeComponent();
        }

        tcddDBEntities db = new tcddDBEntities();
         public  int vagonid = 0;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var query = from t in db.Seferlers                      
                        where t.CikisSehir == (int)cmb_nerden.SelectedValue
                         && t.VarisSehir == (int)cmb_nereye.SelectedValue
                         && t.cikis == dateTimePicker1.Value
                        select new { t.seferID , t.Sehirler.sehirAdi,t.sure,t.trenadi,t.cikis};
         
            searchLookUpEdit1.Properties.DataSource = query.ToList();
            searchLookUpEdit1.Properties.ValueMember = "seferID";
            searchLookUpEdit1.Properties.DisplayMember = "trenadi";
           

        }

        private void Biletform_Load(object sender, EventArgs e)
        {
            Sehirler();
        }
        void Sehirler()
        {
            cmb_nerden.DataSource = db.Sehirlers.ToList();
            cmb_nerden.DisplayMember = "sehirAdi";
            cmb_nerden.ValueMember = "SehirID";

            cmb_nereye.DataSource = db.Sehirlers.ToList();
            cmb_nereye.DisplayMember = "sehirAdi";
            cmb_nereye.ValueMember = "SehirID";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == false)
            {
                dateTimePicker2.Enabled = true;
            }
            else dateTimePicker2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaatleriSec sec = new SaatleriSec();
            sec.ShowDialog();

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            searchLookUpEdit2.Properties.DataSource = db.Tarifes.ToList();
            searchLookUpEdit2.Properties.DisplayMember = "tarifAdi";
            searchLookUpEdit2.Properties.ValueMember = "fiyat";
        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            label16.Text = searchLookUpEdit2.EditValue.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Bilet blt = new Bilet();
            blt.Ad = txt_ad.Text;
            blt.Soyad = textBox1.Text;
            blt.TC = textBox2.Text;
            blt.CepTelefon = textBox3.Text;
            blt.Eposta = textBox4.Text;
            blt.Cinsiyet = comboBox1.Text;
            blt.seferID =(int)searchLookUpEdit1.EditValue;
            blt.koltuk = int.Parse(label8.Text);
            if (radioButton4.Checked)
                blt.satrezv = "Rezerve";
            else blt.satrezv = "Satiş";
            blt.vagonID = vagonid;
            blt.bilettip = searchLookUpEdit2.Text;
            db.Bilets.Add(blt);
            Koltuklar klt = new Koltuklar();
            klt.koltukno = int.Parse(label8.Text);
            klt.seferid = (int)searchLookUpEdit1.EditValue;
            klt.vagonId = vagonid;
            db.Koltuklars.Add(klt);
            db.SaveChanges();
            MessageBox.Show("Bilet Eklendi");


        }
    }
}
