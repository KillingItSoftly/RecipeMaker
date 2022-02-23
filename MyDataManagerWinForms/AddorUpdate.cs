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
using MyDataManagerDataOperations;

namespace MyDataManagerWinForms
{    
    public partial class AddorUpdate : Form
    {
        public event RespondToMessageEvent _respondToMessageEvent;

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
            string msg = string.Empty;

            if (string.IsNullOrEmpty(this.txtfoodName.Text))
            {
                MessageBox.Show("Please enter a food");
                return;
            }

            var selection = addComboBox.SelectedIndex;
            _food.Name = txtfoodName.Text;
            _food.FoodGroupId = (int)addComboBox.SelectedItem;
            var addOperation = new DataOperations();
            addOperation.AddFood(_food);
            msg = $"{_food.Name} added";

            if (_respondToMessageEvent != null)
            {
                _respondToMessageEvent.Invoke(msg);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtfoodName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // (working on) When enter is pressed .SaveChanges instead of having ^^^^ as output text

                string msg = string.Empty;

                if (string.IsNullOrEmpty(this.txtfoodName.Text))
                {
                    MessageBox.Show("Please enter a food");
                    return;
                }
                var selection = addComboBox.SelectedIndex;
                _food.Name = txtfoodName.Text;
                _food.FoodGroupId = (int)addComboBox.SelectedItem;
                var addOperation = new DataOperations();
                addOperation.AddFood(_food);
                msg = $"{_food.Name} added";

                if (_respondToMessageEvent != null)
                {
                    _respondToMessageEvent.Invoke(msg);
                }

                this.Close();

            }
        }
    }

        

        //private void label2_Click(object sender, EventArgs e)
        //{
           
        //}

        //private void label1_Click(object sender, EventArgs e)
        //{
           
        //}
    
}
