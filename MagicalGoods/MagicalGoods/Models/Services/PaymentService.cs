using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using MagicalGoods.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Services
{
    public class PaymentService : IPaymentManager
    {
        private IConfiguration _config;

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
                cardNumber = "4111111111111111",
                expirationDate = "1021",
                cardCode = "102"
            };

            customerAddressType billingAddress = GetAddress("someUserId");

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

        public customerAddressType GetAddress(string userId)
        {
            customerAddressType address = new customerAddressType
            {
                firstName = "Harry",
                lastName = "Potter",
                address = "101 Privet Drive",
                city = "Seattle",
                zip = "98004"
            };
            return address;
        }
    }
}
