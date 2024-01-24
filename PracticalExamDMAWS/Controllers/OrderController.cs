using System.Linq;
using System.Threading.Tasks;
using Practical_Exam_DMAWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Practical_Exam_DMAWS.Controllers;

  [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderSystemContext _context;

        public OrderController(OrderSystemContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] TblOrder order)
        {
            _context.TblOrders.Add(order);
            _context.SaveChanges();
            return Ok(order.OrderId);
        }

        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder(int orderId, [FromBody] TblOrder updatedOrder)
        {
            var existingOrder = _context.TblOrders.Find(orderId);

            if (existingOrder == null)
            {
                return NotFound();
            }

            // Update relevant fields
            existingOrder.DeliveryTime = updatedOrder.DeliveryTime;
            existingOrder.OrderAddress = updatedOrder.OrderAddress;

            _context.SaveChanges();

            return NoContent();
        }
    }

