using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Repositories;

namespace Restaurant_WebApiServer.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            var orders = OrderRepository.GetOrders();

            if (orders != null)
            {
                return Ok(orders);
            }

            return NotFound("No orders to display!");
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(long id)
        {
            var order = OrderRepository.GetOrderById(id);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound("Order not found!");
            }
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            OrderRepository.AddOrder(order);

            return Ok($"The '{order.Id}' id of food adding successful!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(Food food, long id)
        {
            return FoodRepository.UpdateFood(food, id)
                ? Ok($"The '{food.Name}' id of order updating successful!")
                : NotFound("Order not found!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var order = OrderRepository.GetOrderById(id);

            if (order != null)
            {
                OrderRepository.DeleteOrder(order);

                return Ok($"{order.Id} food deleting successful!");
            }

            return NotFound("Order not found!");
        }
    }
}
