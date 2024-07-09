using System.ComponentModel.DataAnnotations;

namespace StudentForm.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        //[EmailAddress]
        public string email { get; set; }
        //[RegularExpression(@"^\d{10}$")]
        public string contact_number {  get; set; }
        public string address { get; set; }
        public DateTime admission_date {  get; set; }
        public double fees{ get; set; }
        public bool isactive { get; set; }
    }
}
