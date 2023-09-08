using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
/*using HowToStock.Validations;*/

namespace HowToStock.Models
{
    public class Items
    {        
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? TypeId { get; set; }
        public string? Size { get; set; }
        public string? PurchaseOrigin{ get; set; }
        public int? PurchasePrice { get; set; }
        public DateTime? PurchaseDate{ get; set; }
        public string? State { get; set; }
        public string? SaleOrigin { get; set; }
        public string? SalePrice { get; set; }
        public int? Payback { get; set; }
        public DateTime? Inserted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }

    }
}