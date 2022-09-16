using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiTutorial.Models {

    [Index("Code", IsUnique = true, Name = "CodeIndex")]
    public class Customer {

        [Key] //optional
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(4)]
        public string Code { get; set; }

        [Column(TypeName ="Decimal(11,2)")]
        public decimal Sales { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
