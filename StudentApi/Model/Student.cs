using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace StudentApi.Model
{
    public class Student
    {
        public int age { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string subject { get; set; }
        public string gender {  get; set; }
        public string status { get; set; }

        public  string grade { get; set; }
          
    }

//    use deepa



//select* from studentdetails


//alter proc Savestudent(
//@id int = null,
//@name varchar
//(299),@age int
//,@gender varchar
//(299),@subject varchar
//(299),@grade varchar
//(299),@status varchar(100)
//)
//as begin 

//if @id=0  
//begin
//insert into studentdetails(name, age, gender, subject, grade, status) values(@name , @age , @gender , @subject , @grade, @status)
// end
// select CAST(SCOPE_IDENTITY() as int) as id;
//    end
}
