using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AuctionSystem.Pages.AdminHome.AdminProduct
{
    public class AdminProductModel : PageModel
    {
        public List<ProductInfo> listProducts = new List<ProductInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=HotelDB;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM addHotel";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductInfo productInfo = new ProductInfo();
                                productInfo.id = "" + reader.GetInt32(0);
                                productInfo.hotelname = reader.GetString(1);
                                productInfo.location = " "+ reader.GetInt32(2);
                                productInfo.rating = " " + reader.GetInt32(3);
                                productInfo.hotelimage = " " + reader.GetString(4);




                                listProducts.Add(productInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ProductInfo
    {
        public String id;
        public String hotelname;
        public String location;
        public String rating;
        public String hotelimage;
    }
}
