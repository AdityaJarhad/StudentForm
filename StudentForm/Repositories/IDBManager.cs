using StudentForm.Models;
using System.Collections;

namespace StudentForm.Repositories
{
    public interface IDBManager
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Insert(Student student);
        public void DeleteById(int id);
        public void Update(Student student);
        public List<Student> GetByStatus(bool status);
        public IEnumerable<Student> SortByStatus();
        public List<Student> Login(Login login);
        void save();
    }
}
