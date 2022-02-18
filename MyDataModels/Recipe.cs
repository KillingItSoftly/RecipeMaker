using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataModels
{
    public class Recipe
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Dish { get; set; }
        //change length later
        [Required, StringLength(3000)]
        public string Instructions { get; set; }

        public virtual List<RecipeItem> RecipeItems { get; set; } = new List<RecipeItem>();

        public override string ToString()
        {
            return Dish;
        }
    }
}
