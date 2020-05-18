using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MagicalGoods.Pages.Checkout.PaymentModel;

namespace MagicalGoods.Models.Interfaces
{
    public interface IPaymentManager
    {
        string Run(CheckoutInput checkoutInput);
    }
}
