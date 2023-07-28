using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models
{
    public partial class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        public string username { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string pass { get; set; } = null!;

        public string City { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Phonenumber { get; set; }


    }
}