using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Features.MakePayment
{
    public class MakePaymentService : IMakePaymentInterface
    {
        

        public async Task<dynamic> PayAsync(string number, long? cardmonth, long? cardyear, string cvv, long? value)
        {
            try
            {
                StripeConfiguration.ApiKey = "pk_test_51IAUaXFVuNXPug7N4U9f0Km2MlV3ohxC1LCRuLpuNZNEDBc5kx9oiL0ICdjXEOGUrdXN6fOGw2g8G8B1DkcV2Uu900heVYyB73";

                var optionstoken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = number,
                        ExpMonth = cardmonth,
                        ExpYear = cardyear,
                        Cvc = cvv
                    },
                };

                var servicetoken = new TokenService();
                Token stripetoken = await servicetoken.CreateAsync(optionstoken);

                var options = new ChargeCreateOptions
                {
                    Amount = value,
                    Currency = "lei",
                    Description = "test",
                    Source = stripetoken.Id
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    return "Success!!!";
                }
                else
                {
                    return "Failed!!!";
                }

            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

    }
    }


