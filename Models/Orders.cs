using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_id { get; set; }


        [Required]
        public DateTime order_date { get; set; }
        
        [ForeignKey("ModelId")]
        public int ModelId { get; set; }


     
        [ForeignKey("Accessories_id")]
        public int  Accessories_id { get; set; }

        [Required]
        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderStatus { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string shipping_address { get; set; }



        [Required]
    
        public string transaction_id { get; set; }

       

        [Required]
        public string shipping_method { get; set; }

        [Required]
        public string tracking_number { get; set; }

        [Required]
        public string notes { get; set; }

        [Required]
        public DateTime cancelled_date { get; set; }

        [Required]
        public DateTime completed_date { get; set; }

        [Required]
        public int quantity { get; set; }



    }
}

