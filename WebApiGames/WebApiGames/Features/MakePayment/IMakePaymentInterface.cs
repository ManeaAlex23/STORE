using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Features.MakePayment
{
    public interface IMakePaymentInterface
    {
       public Task<dynamic> PayAsync(string number, long? cardmonth, long? cardyear, string cvv, long? value);
    }
}
