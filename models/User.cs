namespace educational_practice.models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }
        public string Name {  get; set; }
        public Role Role { get; set; }
}
}
