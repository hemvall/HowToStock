using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
/*using HowToStock.Validations;
*/
namespace HowToStock.Models
{
    public class Color
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? Label { get; set; }
    }
}