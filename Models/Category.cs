using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryMVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
       
        [Required]
        //[Range(1, int.Maxvalue,ErrorMessage="Not valid Number")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

    }
}
