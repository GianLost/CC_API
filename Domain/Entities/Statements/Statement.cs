using CC_API.Domain.Entities.Printers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC_API.Domain.Entities.Statements;

[Table("tbl_statement")]
public class Statement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Year { get; set; } = default;
    public int Month { get; set; } = default;
    public int Ppb { get; set; } = default;
    public int Cpb { get; set; } = default;
    public int Pb { get; set; } = default;
    public double Cpp { get; set; } = default;
    public double Pt { get; set; } = default;
    public double Gt { get; set; } = default;

    [ForeignKey("tbl_printer")]
    public Guid PrinterId { get; set; }
    public Printer? Printer { get; set; } = default;
}