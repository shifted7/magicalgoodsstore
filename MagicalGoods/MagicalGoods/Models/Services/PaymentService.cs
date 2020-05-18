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
using static MagicalGoods.Pages.Checkout.PaymentModel;

namespace MagicalGoods.Models.Services
{
    public class PaymentService : IPaymentManager
    {
        private IConfiguration _config;

        public PaymentService(IConfiguration configuration)
        {
            _config = configuration;
        }

        /// <summary>
        /// controllers.Base for authorize.net. Sets up the environment needed for authorize.net to run. We had also created/ set up a credit card, sets up our transactions
        /// </summary>
        /// <param name="checkoutInput">The users input from the checkout form</param>
        /// <returns></returns>
        public string Run(CheckoutInput checkoutInput)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _config["AN-ApiLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["AN-TransactionKey"]
            };

            // creates the credits cards and passes in the type of card the user chooses to use. Either it be mastercard, visa, or american express
            var creditCard = new creditCardType
            {
                cardNumber = checkoutInput.Payment,
                expirationDate = "1021",
                cardCode = "102"
            };


            customerAddressType billingAddress = GetAddress(checkoutInput);

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

            // if the response fails, the user will see an error that the payment has failed to recieve a response
            if(response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return "Response recieved.";
                }
            }

            return "Failed to recieve response";
        }

        /// <summary>
        /// Brings in what user types into the entry to create the user's address
        /// </summary>
        /// <param name="checkoutInput">the input of the user from the form</param>
        /// <returns>the address</returns>
        public customerAddressType GetAddress(CheckoutInput checkoutInput)
        {
            customerAddressType address = new customerAddressType
            {
                firstName = checkoutInput.FirstName,
                lastName = checkoutInput.LastName,
                address = $"{checkoutInput.ShippingAddressLine1} {checkoutInput.ShippingAddressLine2}",
                city = checkoutInput.City,
                state = checkoutInput.StateOrProvince,
                zip = checkoutInput.ZipCode,
                country = checkoutInput.Country
            };
            return address;
        }
    }
}
