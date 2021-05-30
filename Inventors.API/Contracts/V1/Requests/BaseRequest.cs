using System.Collections.Generic;

namespace Inventors.API.Contracts.V1.Requests
{
    public abstract class BaseRequest
    {
        public abstract bool IsValid(out List<string> errorMessages);
    }
}
