using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Models
{
    public class Photo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        [Required]
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Food Food { get; set; }
    }
}
