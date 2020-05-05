using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MagicalGoods.Pages.Checkout.IndexModel;

namespace MagicalGoods.Models.Services
{
    public class PaymentService : IPaymentManager
    {
        private IConfiguration _config;

        [BindProperty]
        public CheckoutInput Input { get; set; }
        public PaymentService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string Run()
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _config["AN-ApiLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["AN-TransactionKey"]
            };

            var creditCard = new creditCardType
            {
                cardNumber = Input.Payment,
                expirationDate = "1021",
                cardCode = "102"
            };

            customerAddressType billingAddress = GetAddress();

            var paymentType = new paymentType { Item = creditCard };

            var transaction = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = 200.0m,
                payment = paymentType,
                billTo = billingAddress
            };

            var request = new createTransactionRequest { transactionRequest = transaction };

            var controller = new createTransactionController(request);

            controller.Execute();

            var response = controller.GetApiResponse();

            if(response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return "Response recieved.";
                }
            }

            return "Failed to recieve response";
        }

        public customerAddressType GetAddress()
        {
            customerAddressType address = new customerAddressType
            {
                firstName = Input.FirstName,
                lastName = Input.LastName,
                address = $"{Input.ShippingAddressLine1} {Input.ShippingAddressLine2}",
                city = Input.City,
                state = Input.StateOrProvince,
                zip = Input.ZipCode,
                country = Input.Country
            };
            return address;
        }
    }
}
