using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HotelBackend.Controllers
{
    public class HotelController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select * from dbo.hotel";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["hoteldbb"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

            using (var data = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
    }
}
