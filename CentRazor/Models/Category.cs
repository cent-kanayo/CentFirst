﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CentRazor.Models
{
    public class Category
    {

            [Key]
            public int Id { get; set; }
            [Required]
            [StringLength(30)]
            public string Name { get; set; }
            [DisplayName("Display Order")]
            [Range(1, 100)]
            public int DisplayOrder { get; set; }
        
    }
}
