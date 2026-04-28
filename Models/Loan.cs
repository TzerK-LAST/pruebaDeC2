using System.ComponentModel.DataAnnotations;
using GESTIONES.Models;

namespace GESTIONES.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debes seleccionar un usuario")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Debes seleccionar un libro")]
        public int deporteid { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string estado { get; set; } = string.Empty;

        public User? User { get; set; }   
        public deporte? Deporte { get; set; }  
    }
}