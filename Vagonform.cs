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
    public partial class Vagonform : Form
    {
        public Vagonform()
        {
            InitializeComponent();
        }

        tcddDBEntities db = new tcddDBEntities();
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VagonTip tp = new VagonTip();
            tp.tipadi = textBox1.Text;
            tp.koltuksayisi = int.Parse(textBox2.Text);
            db.VagonTips.Add(tp);
            db.SaveChanges();
            listele();

        }
        void listele ()
        {
            var query = from t in db.VagonTips
                        select new { t.tipID, t.tipadi, t.koltuksayisi };
            dataGridView1.DataSource = query.ToList();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sil = db.VagonTips.Single(q => q.tipID == (int)dataGridView1.CurrentRow.Cells[0].Value);
            db.VagonTips.Remove(sil);
            db.SaveChanges();
            listele();
        }

        private void Vagonform_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
