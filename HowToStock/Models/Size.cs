using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
/*using HowToStock.Validations;
*/
namespace HowToStock.Models
{
    public class Size
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string? Label { get; set; }
    }
}