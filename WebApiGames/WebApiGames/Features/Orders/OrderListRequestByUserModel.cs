using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Features.Orders
{
    public class OrderListRequestByUserModel
    {
        public int Id { get; set; }

        public string DeliverAdress { get; set; }

        public string City { get; set; }

        public int GameId { get; set; }

        public bool IsProcesed { get; set; }

        public bool IsDelivered { get; set; }

        public string CurrentCurierLocation { get; set; }

        public int RentedHours { get; set; }

        public string ClientPhoneNumber { get; set; }

        public string CurrierPhoneNumber { get; set; }

    }
}
