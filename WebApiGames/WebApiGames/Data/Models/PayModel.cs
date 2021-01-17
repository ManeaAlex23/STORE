using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Data.Models.Base
{
    public class PayModel
    {


        [Required]
        public string cardNumber { get; set; }

        [Required]
        public long? cardMonth { get; set; }

        [Required]
        public long? cardYear { get; set; }

        [Required]
        public string cvv { get; set; }

        [Required]
        public long? value { get; set; }



    }
}
