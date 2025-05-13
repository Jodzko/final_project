using System.ComponentModel.DataAnnotations;

namespace _final_project.Database.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public int HouseNumber { get; set; }
        public int AppNumber { get; set; }
        public Person Person { get; set; }
        public string PersonId { get; set; }
    }
}
