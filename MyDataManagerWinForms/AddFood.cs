using DataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDataManagerWinForms
{
    public partial class AddFood : Form
    {
        public AddFood()
        {
            InitializeComponent();
        }

        private void txtFoodName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveFood_Click(object sender, EventArgs e)
        {
            //check if user selected item from list
            /*if ()
            {
                MessageBox.Show("Select a Food Item Please");
                return;
            }*/
        }

        private void listBoxFoodSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new DataDbContext(MainForm._optionsBuilder.Options))
            {
               
                //Items = db.Items.ToList();
                var foods = db.Foods.OrderBy(x => x.Name).ToList();

                listBoxFoodSelection.DataSource = foods;

            }
        }
    }
}
