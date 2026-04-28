using GESTIONES.Models;

namespace GESTIONES.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string lastname { get; set; }
    public required string Email { get; set; }
    public required int cedula { get; set; }
    public long number { get; set; }
    public DateTime dateRegistered { get; set; }

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}