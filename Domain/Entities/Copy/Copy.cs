using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC_API.Domain.Entities.Copy;

[Table("tbl_copy")]
public class Copy
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Year { get; set; } = default;
    public double CopyCost { get; set; } = default;
}