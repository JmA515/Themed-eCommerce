using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eCommerceStarterCode.Models
{
    public class Review
    {
        [Key]        
        public int Id { get; set; }
        public string Body { get; set; }
        public int StarRating { get; set; }        

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
