using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NWindBusinessObjects
{
    [Index(nameof(CategoryName), Name = "CategoryName")]
    [Index(nameof(CategoryName), Name = "UQ__Categori__8517B2E072CF55C0", IsUnique = true)]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
