using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using GB.OrdersAPI.Models;
using GB.OrdersAPI.Repositories;

namespace GB.OrdersAPI.Controllers
{
    public class OrdersController : ApiController
    {

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public IHttpActionResult Post([FromBody]CreateOrder order)
        {
            try
            {
                ServiceBusRepository reposistory = new ServiceBusRepository();
                reposistory.Send(order);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}

