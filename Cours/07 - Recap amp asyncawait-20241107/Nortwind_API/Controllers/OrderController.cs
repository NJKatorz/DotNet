using Microsoft.AspNetCore.Mvc;
using Nortwind_API.DTO;
using Nortwind_API.Entities;
using Nortwind_API.Repositories;
using Nortwind_API.UnitOfWork;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IUnitOfWork _repo;
        private readonly NorthwindContext _dbcontext;

        public OrderController()
        {
            _dbcontext = new NorthwindContext();
            _repo = new UnitOfWorkSQL(_dbcontext);
        }

        [HttpGet]
        public async Task<List<OrderDTO>> GetAllOrders()
        {
            IList<Order> list = await _repo.OrdersRepository.GetAllAsync();
            return list.Select(o => OrderToDTO(o)).ToList();
        }


        private static OrderDTO OrderToDTO(Order ord) =>
        new OrderDTO
        {
            OrderId = ord.OrderId,
            EmployeeId = ord.EmployeeId,
            OrderDate = ord.OrderDate,
            RequiredDate = ord.RequiredDate,
            ShippedDate = ord.ShippedDate,
            ShipVia = ord.ShipVia,
            Freight = ord.Freight,
            ShipName = ord.ShipName,
        };

        private static Order DTOToOrder(OrderDTO ord) =>
            new Order
            {
                OrderId = ord.OrderId,
                EmployeeId = ord.EmployeeId,
                OrderDate = ord.OrderDate,
                RequiredDate = ord.RequiredDate,
                ShippedDate = ord.ShippedDate,
                ShipVia = ord.ShipVia,
                Freight = ord.Freight,
                ShipName = ord.ShipName,
            };
    }
}
