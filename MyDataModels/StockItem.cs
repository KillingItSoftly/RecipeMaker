using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataModels
{
    public class StockItem
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Amount { get; set; }
        [Required, Range(0, 100)]
        public int Count { get; set; }
        [Required]
        public int FoodId { get; set; }

        public virtual Food? Food { get; set; }
    }
}
