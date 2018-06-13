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
    public partial class AşıkVeyselDemiryolları : Form
    {
        public AşıkVeyselDemiryolları()
        {
            InitializeComponent();
        }

        public void OpenForm(Type FormType)
        {

            var form = this.MdiChildren.SingleOrDefault(p => p.GetType() == FormType);
            if (form == null)
                form = (Form)Activator.CreateInstance(FormType);
            form.MdiParent = this;
            form.Show();
            form.Focus();

        }
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm(typeof(Biletform));
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm(typeof(Seferform));
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm(typeof(Tarifeform));
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm(typeof(Vagonform));
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm(typeof(Sehirlerform));
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();

        }
    }
}
