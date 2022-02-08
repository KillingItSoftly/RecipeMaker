using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataModels
{
    public class Food
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int FoodGroupId { get; set; }

        public virtual FoodGroup? FoodGroup { get; set; }

        public virtual List<RecipeItem> RecipeItems { get; set; } = new List<RecipeItem>();

        public virtual List<StockItem> StockItems { get; set; } = new List<StockItem>();
    }
}
