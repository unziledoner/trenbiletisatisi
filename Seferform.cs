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
    public partial class Seferform : Form
    {
        public Seferform()
        {
            InitializeComponent();
        }
        tcddDBEntities db = new tcddDBEntities();
        int id = 0;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Seferler tr = new Seferler();
            tr.cikis = dateTimePicker1.Value;
            tr.CikisSehir = (int)comboBox2.SelectedValue;
            tr.VarisSehir = (int)comboBox1.SelectedValue;
            tr.trenadi = comboBox1.Text+"__"+ comboBox2.Text;
            tr.sure = maskedTextBox1.Text;
            db.Seferlers.Add(tr);
            db.SaveChanges();
            Listele();
        }
        void Listele()
        {
            var query = from t in db.Seferlers
                        select new { t.seferID,t.cikis, t.sure, t.trenadi, t.Sehirler.sehirAdi ,t.CikisSehir };
            dataGridView1.DataSource = query.ToList();
        }
        void tarifelerim()
        {
            comboBox3.DataSource = db.Tarifes.ToList();
            comboBox3.DisplayMember = "tarifAdi";
            comboBox3.ValueMember = "tarifID";
        }
        void sehirler()
        {
            comboBox1.DataSource = db.Sehirlers.ToList();
            comboBox1.DisplayMember = "sehirAdi"; 
            comboBox1.ValueMember = "SehirID";

            comboBox2.DataSource = db.Sehirlers.ToList();
            comboBox2.DisplayMember = "sehirAdi";
            comboBox2.ValueMember = "SehirID";
        }

        private void Seferform_Load(object sender, EventArgs e)
        {
            sehirler();
            tarifelerim();
            Listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tcddDBEntities b = new tcddDBEntities();
            Seferler sil = b.Seferlers.Single(q => q.seferID == id);
            b.Seferlers.Remove(sil);
            b.SaveChanges();
            Listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            }
            catch { }
        }
    }
}
