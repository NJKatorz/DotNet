namespace Nortwind_API.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }

        public string? ShipName { get; set; }
    }
}
