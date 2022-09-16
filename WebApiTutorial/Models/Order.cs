using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTutorial.Models {


    public class Order {

        public int Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        //?? [Column(TypeName = "DateTime2(7)")]
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        
        public virtual Customer? Customer { get; set; }
    
        public virtual IEnumerable<OrderLine>? OrderLines { get; set; }
    }
}
