using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentForm.Models;
using System.Collections;

namespace StudentForm.Repositories
{
    public class DBManager : IDBManager
    {
        CollectionContext _Context = new CollectionContext();
        public List<Student> GetAll()
        {
            return _Context.Student.ToList();
        }
        public Student GetById(int id)
        {
            return _Context.Student.Find(id);
        }
        public void Insert(Student student)
        {
            _Context.Student.Add(student);
        }
        public void DeleteById(int id)
        {
            var student = _Context.Student.Find(id);
            if (student != null) 
            {
                _Context.Student.Remove(student);
                _Context.SaveChanges();
            }
        }
        public void Update(Student student)
        {
            _Context.Student.Update(student);
            _Context.SaveChanges();
        }
        public List<Student> GetByStatus(bool status)
        {
            var student = (from s in _Context.Student
                          where s.isactive == status
                          select s).ToList();

            return student;
        }
        public IEnumerable<Student> SortByStatus()
        {
            List<Student> list = new List<Student>(); 
            var students = GetAll();
            var sort = students.OrderByDescending(s => s.isactive);
            return sort;
        }
        public List<Student> Login(Login login)
        {
            List<Student> student = GetAll();
            if (student == null)
            {
                return null;
            }
            var stud = (from s in student
                           where Equals(s.email, login.Email) && Equals(s.contact_number, login.Password)
                           select s).ToList();
            return stud;
        }
        public void save()
        {
            _Context.SaveChanges();
        }
    }
}
