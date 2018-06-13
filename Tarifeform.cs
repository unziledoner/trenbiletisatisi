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
    public partial class Tarifeform : Form
    {
        public Tarifeform()
        {
            InitializeComponent();
        }
        tcddDBEntities db = new tcddDBEntities();
        int id = 0;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tarifeform_Load(object sender, EventArgs e)
        {
            tarf();
        }
        void tarf()
        {
            dataGridView1.DataSource = db.Tarifes.ToList();            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tarife trf = new Tarife();
            trf.tarifAdi = textBox1.Text;
            trf.fiyat = decimal.Parse(textBox2.Text);
            db.Tarifes.Add(trf);
            db.SaveChanges();
            tarf();
            MessageBox.Show("Eklendi");

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            var trf = db.Tarifes.Single(q => q.tarifID ==id);
            db.Tarifes.Remove(trf);
            db.SaveChanges();
            MessageBox.Show("Silindi");
            tarf();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.CurrentRow.Cells[0].Value;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
