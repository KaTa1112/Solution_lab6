using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            LogIn login = new LogIn();
            login.UserLogedIn += Login_UserLogedIn;       
            login.Show(this);
        }

        private void Login_UserLogedIn(object sender, EventArgs e)
        {
            using (DataSet dataset = new DataSet())
            {
                dataset.ReadXml("popisKnjiga.xml");
                dataGridView1.DataSource = dataset.Tables[0];
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
