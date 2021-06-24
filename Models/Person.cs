using System.ComponentModel.DataAnnotations;
namespace Certificates.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string NameTitle { get; set; }
    }
}
