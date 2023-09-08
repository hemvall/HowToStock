using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
/*using HowToStock.Validations;
*/
namespace HowToStock.Models
{
    public class Marketplace
    {
        public int Id { get; set; }
        public string? Label { get; set; }
    }
}