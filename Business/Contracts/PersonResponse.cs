
namespace _final_project.BusinessLogic.Contracts
{
    public record PersonResponse
    {
        public string personalCode { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public byte[] profilePicture { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int houseNumber { get; set; }
        public int appNumber { get; set; }
    }
}
