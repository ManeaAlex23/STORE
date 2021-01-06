using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Data.Models.Base;
using WebApiGames.Features;

namespace WebApiGames.Data.Models
{
    public class OrdersReq: DeletableEntity, IEntity
    {
        public int Id { get; set; }

        [Required]
        public string DeliverAdress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public string UserId { get; set; }

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

        public User User { get; set; }



    }
}
