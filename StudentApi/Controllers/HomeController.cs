using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using StudentApi.Model;
using System.Data;
using System.Data.SqlClient; 
 

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        string connection = "Server=(localdb)\\MSSQLLocalDB;Database=Deepa;Trusted_Connection=True;";

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> save(Student st)
        {


            using (SqlConnection con = new SqlConnection(connection))
            {

                await con.OpenAsync();

                SqlCommand cmd = new SqlCommand("Savestudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", st.id);
                cmd.Parameters.AddWithValue("@name", st.name);
                cmd.Parameters.AddWithValue("@gender", st.gender);
                cmd.Parameters.AddWithValue("@age", st.age);
                cmd.Parameters.AddWithValue("@subject", st.subject);
                cmd.Parameters.AddWithValue("@grade", st.grade);
                cmd.Parameters.AddWithValue("@status", st.status);
                if (st.id == 0)
                {
                    var id = await cmd.ExecuteNonQueryAsync();
                    st.id = id;
                }
                await cmd.ExecuteNonQueryAsync();

            }



            return Ok(new { message = "Saved Successfully", data = st });


        }



        [HttpGet]
        [Route("getdetails")]
        public async Task<IActionResult >getdetails(int id)


        {
            Student st = new Student();


            using (SqlConnection  con =new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand(" select * from studentdetails  where id="+id+"", con);
             await   con.OpenAsync();
                SqlDataReader ra = cmd.ExecuteReader();
                if (ra.Read())
                {
                  
                    st.name = ra["name"].ToString();
                    st.age =  Convert.ToInt32( ra["age"]);
                    st.subject = ra["subject"].ToString();
                    st.grade = ra["grade"].ToString();
                    st.id = id;
                    st.gender = ra["gender"].ToString(); 
                }
                return Ok(st);

            }


        }
















        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
