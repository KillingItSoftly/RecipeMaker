
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyDataModels;
using System.Diagnostics;
using MyDataManagerDataOperations;

namespace MyDataManagerWinForms
{
    public delegate void RespondToMessageEvent(string message);

    public partial class MainForm : Form
    {
        private IList<FoodGroup> FoodGroups = new List<FoodGroup>();
        public IList<Food> Foods = new List<Food>();
        private IList<Recipe> Recipes = new List<Recipe>();
        private IList<RecipeItem> RecipeItems = new List<RecipeItem>();
        private IList<StockItem> StockItems = new List<StockItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void RespondToMessage(string m)
        {
            MessageBox.Show(m);
            Refresh();
        }

        public void Refresh()
        {
            var dataOperation = new DataOperations();

            FoodGroups = dataOperation.GetFoodGroups().Result;
            Recipes = dataOperation.GetRecipes().Result;
            Foods = dataOperation.GetFoods().Result;
            StockItems = dataOperation.GetStockItems().Result;
            RecipeItems = dataOperation.GetRecipeItems().Result;
            cboCategories.DataSource = FoodGroups;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cboBox = sender as ComboBox;
            var selItem = cboBox.SelectedItem as FoodGroup;

            LoadGrid(selItem);
        }

        private void LoadGrid(FoodGroup selectedItem)
        {
            //Debug.WriteLine($"Selected Item {selectedItem.Id}| {selectedItem.Name}");
            var curData = Foods.Where(x => x.FoodGroupId == selectedItem.Id).ToList();
            dgItems.DataSource = curData;
        }

        private void dgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            var moreFood = new AddorUpdate();
            moreFood._respondToMessageEvent += new RespondToMessageEvent(RespondToMessage);
            moreFood.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count > 0)
            {
                var foodInfo = dgItems.SelectedRows[0].Cells;
                var foodName = foodInfo[1].Value;
                DialogResult userChoice = MessageBox.Show($"Do you really want to delete {foodName}?","Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (userChoice == DialogResult.Yes)
                {
                    DialogResult userChoice2 = MessageBox.Show("Are you sure??????", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    
                    if(userChoice2 == DialogResult.Yes)
                    {
                        var deleteID = (int)foodInfo[0].Value;

                        //var dataOperation = new DataOperations();
                        //Foods = dataOperation.GetFoods();
                        var deleteOperation = new DataOperations();
                        deleteOperation.DeleteFood(deleteID);
                        MessageBox.Show($"You deleted {foodName}, why would you do this?", "Do you feel good about yourself?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //System.Console.Beep();  
                        Refresh();
                    }
                }           
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            var loadData = new DataOperations();
            loadData.LoadData();
        }
    }
}