using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataModels
{
    public class RecipeItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int FoodId{ get; set; }
        [Required, StringLength(50)]
        public string Amount { get; set; }

        public virtual Food? Food { get; set; }

        public virtual Recipe? Recipe { get; set; }
    }
}
