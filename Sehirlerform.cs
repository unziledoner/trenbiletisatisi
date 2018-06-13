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
    public partial class Sehirlerform : Form
    {
        public Sehirlerform()
        {
            InitializeComponent();
        }

        int id;
        tcddDBEntities db = new tcddDBEntities();
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sehirler shr = new Sehirler();
            shr.sehirAdi = textBox1.Text;
            db.Sehirlers.Add(shr);
            db.SaveChanges();
            listele();
        }
        void listele()
        {
            var query = from t in db.Sehirlers
                        select new { t.SehirID, t.sehirAdi };
            dataGridView1.DataSource = query.ToList();
        }

        private void Sehirlerform_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var delete = db.Sehirlers.Single(q => q.SehirID == id);
            db.Sehirlers.Remove(delete);
            db.SaveChanges();
            listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.CurrentRow.Cells[0].Value;
        }
    }
}
