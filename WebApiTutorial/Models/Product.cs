using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiTutorial.Models {


    public class Product {


        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }


    }
}
