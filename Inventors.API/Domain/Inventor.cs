using System.ComponentModel.DataAnnotations;

namespace Inventors.API.Domain
{
    public class Inventor : IEntity
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
