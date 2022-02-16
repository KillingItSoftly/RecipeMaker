using DataLibrary;
using MyDataModels;
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
            //using (var db = new DataDbContext(MainForm._optionsBuilder.Options))
            //{

            //    //Items = db.Items.ToList();
            //    var foods = db.Foods.OrderBy(x => x.Name).ToList();

            //    listBoxFoodSelection.DataSource = foods;

            //}
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

        private void txtAddFood_TextChanged(object sender, EventArgs e)
        {
            
        }

        //private void list2BoxFoodSelection_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //var checkBox = sender as CheckedListBox;
        //    //var selItem = checkBox.SelectedItem as Food;


        //    //ListBox listBox1 = new ListBox();
        //    //listBox1.Location = new System.Drawing.Point(12, 12);
        //    //listBox1.Name = "Add to Fridge";
        //    //listBox1.Size = new System.Drawing.Size(245, 200);
        //    //listBox1.BackColor = System.Drawing.Color.Orange;
        //    //listBox1.ForeColor = System.Drawing.Color.Black;
        //    //Controls.Add(listBox1);

        //    //listBox1(selItem);
        //}


    }
}
