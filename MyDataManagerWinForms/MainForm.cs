using DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyDataModels;
using System.Diagnostics;

namespace MyDataManagerWinForms
{
    public partial class MainForm : Form
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<DataDbContext> _optionsBuilder;

        private IList<Category> Categories = new List<Category>();
        private IList<Item> Items = new List<Item>();

        private IList<FoodGroup> FoodGroups = new List<FoodGroup>();
        private IList<Food> Foods = new List<Food>();

        public MainForm()
        {
            InitializeComponent();
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyDataManagerData"));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BuildOptions();

            //load categories
            using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                FoodGroups = db.FoodGroups.OrderBy(x => x.Group).ToList();
                //Items = db.Items.ToList();
                Foods = db.Foods.OrderBy(x => x.Name).ToList();
                cboCategories.DataSource = FoodGroups;
                
            }
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
            var curData =  Foods.Where(x => x.FoodGroupId == selectedItem.Id).ToList();
            dgItems.DataSource = curData;
        }

       

        private void dgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}