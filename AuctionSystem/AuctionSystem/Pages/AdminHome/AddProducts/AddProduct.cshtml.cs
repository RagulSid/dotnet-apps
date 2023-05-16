using AuctionSystem.Pages.AdminHome.AdminProduct;
 using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
 

 


namespace AuctionSystem.Pages.AdminHome.addHotels
{
    public class addHotelModel : PageModel
    {

        


        public ProductInfo productInfo = new ProductInfo();
        public String errorMessage = "";
        public String successMessage = "";



        

        public void OnGet()
        {

        }
         public void OnPost( ) 
          {
              productInfo.hotelname = Request.Form["hotelname"];
              productInfo.location = Request.Form["location"];
              productInfo.rating = Request.Form["rating"];

            




            try
              {

               

                String connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=HotelDB;Integrated Security=True";
                  using (SqlConnection connection = new SqlConnection(connectionString))
                  {
                      connection.Open();


                      String sql = "INSERT INTO addHotel" + "(hotelname,location,rating) VALUES " + "(@hotelname,@location,@rating );";
                      using (SqlCommand command = new SqlCommand(sql, connection))
                      {
                          command.Parameters.AddWithValue("@hotelname", productInfo.hotelname);
                          command.Parameters.AddWithValue("@location", productInfo.location);
                          command.Parameters.AddWithValue("@rating", productInfo.rating);
                          command.ExecuteNonQuery();
                      }
                  }

              }
              catch (Exception ex)
              {
                  errorMessage = ex.Message;
                  return;
              }

              productInfo.hotelname = "";
              productInfo.location = "";
              productInfo.rating = "";
 



              successMessage = "New Product Added ";

              Response.Redirect("/AdminHome/AdminProduct/AdminProduct");
          }

      }

        
    }


/*  <div class="row mb-3">
        <label class="col-sm-3 col-form-label">PRODUCT IMAGE</label>
        <div class="col-sm-6">
            <input type="file" class="form-control" name="productimage" accept=".jpg,.jpeg,.png,.gif" />
        </div>
    </div>*/