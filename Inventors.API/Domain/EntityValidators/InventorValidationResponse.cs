using System.Collections.Generic;

namespace Inventors.API.Domain.EntityValidators
{
    public class InventorValidationResponse
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new();
    }
}
