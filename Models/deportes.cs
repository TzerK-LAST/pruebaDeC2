using GESTIONES.Models;

namespace GESTIONES.Models;

public class deporte
{
    public int Id { get; set; }
    public required string tipo_espacio { get; set; }
    public  int Stock { get; set;}
    public required string Description { get; set; }
    public required string Author { get; set; }
    public required string genero { get; set; }
    public int Quantity { get; set; }

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    
}