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
    public partial class AddorUpdate : Form
    {
        public AddorUpdate()
        {
            InitializeComponent();
            _food = new Food();
            addComboBox.DataSource = Enum.GetValues(typeof(FoodGroupName));

            //load categories

        }
        private Food _food; 
        public AddorUpdate(Food f)
        {
            InitializeComponent();
            _food = f;
            this.txtfoodName.Text = _food.Name;

        }
         

        private void txtfoodName_TextChanged(object sender, EventArgs e)
        {

        }
        private void addComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkBox = sender as ComboBox;
            var selItem = checkBox.SelectedItem as FoodGroup;
            
                    
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtfoodName.Text))
            {
                MessageBox.Show("Please enter a food");
                return;
            }
            using (var db = new DataDbContext(MainForm._optionsBuilder.Options))
            {
                string msg = string.Empty;
                var selection = addComboBox.SelectedIndex;

                _food.Name = txtfoodName.Text;
                _food.FoodGroupId = (int)addComboBox.SelectedItem;
                db.Foods.Add(_food);
                db.SaveChanges();
            }


            //_person.FirstName = txtFirstName.Text;
            //_person.LastName = txtLastName.Text ?? string.Empty;
            //db.People.Add(_person);
            //db.SaveChanges();
            //msg = $"{_person.FirstName} {_person.LastName} person added";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
