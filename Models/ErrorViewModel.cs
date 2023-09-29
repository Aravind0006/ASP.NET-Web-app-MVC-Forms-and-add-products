using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net_MVC_page_with_form.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Product
    {
        public int No { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Sub_Total { get; set; }
        public int Unit_price { get; set; }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public object No { get; internal set; }
    }

    public class ShippingAddress
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }
    }

    public class BillingAddress
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }
    }

    public class Order
    {
        public ShippingAddress ShippingAddress { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}