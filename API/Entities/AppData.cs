namespace API.Entities
{
    public class AppData
    {
        public int Id { get; set; }
        public string username { get; set; }

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }
    }
}