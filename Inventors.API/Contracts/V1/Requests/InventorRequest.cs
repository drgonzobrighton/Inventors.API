using System.Collections.Generic;

namespace Inventors.API.Contracts.V1.Requests
{
    public class InventorRequest : BaseRequest
    {

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public override bool IsValid(out List<string> errorMessages)
        {
            errorMessages = new();

            ValidateName(errorMessages);


            return errorMessages.Count == 0;
        }

        private void ValidateName(List<string> errorMessages)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                errorMessages.Add("First Name is required");
            }
            else if (FirstName.Length > 50)
            {
                errorMessages.Add("First Name cannot be longer than 50 characters");
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                errorMessages.Add("Last Name is required");
            }
            else if (LastName.Length > 50)
            {
                errorMessages.Add("Last Name cannot be longer than 50 characters");
            }
        }
    }
}
