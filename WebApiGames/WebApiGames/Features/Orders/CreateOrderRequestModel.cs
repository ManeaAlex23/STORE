using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Features.Orders
{
    public class CreateOrderRequestModel
    {    
        [Required]
        public string DeliverAdress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public bool IsProcesed { get; set; }

        [Required]
        public bool IsDelivered { get; set; }

        [Required]
        public string CurrentCurierLocation { get; set; }

        [Required]
        public int RentedHours { get; set; }

        [Required]
        public string ClientPhoneNumber { get; set; }

        public string CurrierPhoneNumber { get; set; }

    }
}
