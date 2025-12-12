namespace CodeFirstAproch.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //tostring 
        public override string ToString()
        {
            return $"Employe [Id {Id} , Name :{Name} ,Email : {Email}, Password : {Password}] ";
        }
    }
}
