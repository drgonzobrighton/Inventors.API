using Inventors.API.Data;
using Inventors.API.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inventors.API.Domain.EntityValidators
{
    public class InventorValidator
    {
        public static bool ValidateInventor(Inventor inventor, ApplicationDbContext context, out List<string> messages)
        {
            messages = new();

            if (context.Inventors.Any(i => i.FirstName == inventor.FirstName && i.LastName == inventor.LastName && i.Id != inventor.Id))
            {
                messages.Add($"{inventor.FirstName} {inventor.LastName} already exists");
                return false;
            }

            return true;
        }
    }
}
