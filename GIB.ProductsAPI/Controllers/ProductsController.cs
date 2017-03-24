using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace GIB.ProductsAPI.Controllers
{
    /// <summary>
    /// API to manage products 
    /// </summary>
    [ServiceRequestActionFilter] 
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        // GET api/products 
        /// <summary>
        /// Get first 10 products
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError)]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2014;Integrated Security=False;;User Id=gib_demo;Password=secreta;MultipleActiveResultSets=True"))
            {
                using (SqlCommand cmd = new SqlCommand("select top 10 * from [Production].[Product]", con))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt == null || dt.Rows.Count == 0)
                            return NotFound();
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }
            }
            return Json(dt);
        }

        // GET api/products/5
        /// <summary>
        /// Find a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError)]
        public IHttpActionResult Get(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2014;Integrated Security=False;;User Id=gib_demo;Password=secreta;MultipleActiveResultSets=True"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from [Production].[Product] where ProductID = @productId", con))
                {
                    cmd.Parameters.AddWithValue("@productId", id);
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt == null || dt.Rows.Count == 0)
                            return NotFound();
                    }
                    catch (Exception ex) {
                        return InternalServerError(ex);
                    }
                }
            }
            return Json(dt);
        }

        //// POST api/products 
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5 
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5 
        //public void Delete(int id)
        //{
        //}
    }
}
