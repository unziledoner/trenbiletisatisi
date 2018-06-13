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
    public partial class SaatleriSec : Form
    {
        public SaatleriSec()
        {
            InitializeComponent();
        }
        int seferid;
        tcddDBEntities db = new tcddDBEntities();
        public string secilen = "";
        private void SaatleriSec_Load(object sender, EventArgs e)
        {
            vagon();
            liste();
           
          
        }
        void liste()
        {
           
                int sol = 1; //formun sol tarafından atanan değer
                int alt = 70; // formun üst tarafından atanan değer
                int bol = 7; // bolme işlemindeki amaç formun boyutuna göre butonları sıralı bir şekilde görebilmek için

            try
            {
                int id = 1;
                panel1.Controls.Clear();
                var query = (from t in db.VagonTips
                             where t.tipID == (int)comboBox1.SelectedValue
                             select new { t.koltuksayisi }).First().koltuksayisi.ToString();
                var sayi = int.Parse(query.ToString());

                for (int i = 1; i <= sayi; i++)
                {
                    Button btn = new Button();
                    btn.Name = i.ToString();
                    btn.AutoSize = false;
                    btn.Size = new Size(this.Width / bol, this.Height / (bol * 2));
                    btn.Text = i.ToString();
                    btn.Font = new Font(btn.Font.FontFamily.Name, 18);
                    btn.Location = new Point(sol, alt);
                    panel1.Controls.Add(btn);
                    sol += btn.Width + 5;

                    if (sol + this.Width / bol > this.Width)
                    {
                        sol = 1;
                        alt += this.Height / (bol * 2) + 5;
                    }
                    btn.Click += new EventHandler(dinamikMetod);
                }
           Biletform  frm = (Biletform)Application.OpenForms["Biletform"];

                seferid = (int)frm.searchLookUpEdit1.EditValue;
                foreach (Control item in panel1.Controls.Cast<Control>())
                {
                    if (Denetle(int.Parse(item.Text), (int)comboBox1.SelectedValue,seferid))
                    {
                        item.BackColor = Color.Red;
                        item.Enabled = false;
                    }
                    else item.BackColor = Color.Green;
                }


            }
            catch (Exception ex){  }

               
           
        }

        private void dinamikMetod(object sender, EventArgs e)
        {
            Button dinamikButon = (sender as Button);
            secilen = dinamikButon.Text;
            Biletform frm = (Biletform)Application.OpenForms["Biletform"];
            frm.label8.Text = secilen;
            frm.vagonid = (int)comboBox1.SelectedValue;
            this.Close();
        }

        void vagon()
        {
            comboBox1.DataSource = db.VagonTips.ToList();
            comboBox1.DisplayMember = "tipadi";
            comboBox1.ValueMember = "tipID";
        }
        bool Denetle(int klkt,int vagon,int seferid)
        {
            if (db.Koltuklars.Any(q => q.koltukno == klkt && q.vagonId == vagon && q.seferid == seferid))
            {
                return true;
            }
            else return false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            liste();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            liste();
        }
    }
}
