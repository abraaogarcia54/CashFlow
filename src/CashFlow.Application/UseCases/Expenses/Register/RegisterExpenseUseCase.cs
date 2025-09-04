using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            return new ResponseRegisteredExpenseJson();
        }


        public void Validate(RequestRegisterExpenseJson request)
        {
            var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
            if (titleIsEmpty)
            {
                throw new ArgumentException("The title is required.");
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentException("The amount must be greater than zero.");
            }

            var result = DateTime.Compare(request.Date, DateTime.UtcNow);
            if(result > 0)
            {
                throw new Exception("Expenses cannot be for the future.");
            }

            var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.paymentType);
            if (paymentTypeIsValid == false)
            {
                throw new ArgumentException("The payment type is invalid.");
            }

        }
    }

}   
    