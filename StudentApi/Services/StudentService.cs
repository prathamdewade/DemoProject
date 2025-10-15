using StudentApi.Models;
using StudentApi.Repository;

namespace StudentApi.Services
{
    public class StudentService
    {
        private readonly StudentRepository repo;
        public StudentService(StudentRepository repo)
        {
            this.repo = repo;
        }
        public bool CreateStudent(Student s)
        {
            return repo.AddStudent(s);
        }

        public IList<Student> GetAllStudents()
        {
            return repo.GetAllStudents();
        }
    }
}
