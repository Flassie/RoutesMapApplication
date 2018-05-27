using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutesMapApplication
{
    public partial class SelectDatabaseForm : Form
    {
        public SelectDatabaseForm()
        {
            InitializeComponent();
        }

        private void DBSelectButton_Click(object sender, EventArgs e)
        {
            DBSelectDialog.ShowDialog();
            var filepath = DBSelectDialog.FileName;

            var db = new DB();
            try
            {
                db.Connect(filepath, new List<String>() { "koordinat" });
                ErrorLabel.Text = "";

                this.Hide();
                new RouteMap(db).ShowDialog();
                this.Close();
            } catch(Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}
