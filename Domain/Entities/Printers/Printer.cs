using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC_API.Domain.Entities.Printers;

[Table("tbl_Printer")]
public class Printer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public char Status { get; set; } = default;
    public string? Location { get; set; } = default;
    public DateTime? ImplementationDate { get; set; } = default;
    public DateTime WithdrawallDate { get; set; } = default;
    public int Patrimony { get; set; } = default;

    [ForeignKey("tbl_PrinterType")]
    public Guid PrinterTypeId { get; set; }
    public PrinterType? PrinterType { get; set; } = default;
}