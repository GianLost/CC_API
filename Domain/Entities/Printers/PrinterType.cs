using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC_API.Domain.Entities.Printers;

[Table("tbl_PrinterType")]
public class PrinterType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Type { get; set; } = default;
    public string? Model { get; set; } = default;
    public double RentalValue { get; set; } = default;
}