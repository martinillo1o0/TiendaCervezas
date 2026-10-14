using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Beer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BeerId { get; set; }

    public string Name { get; set; } = string.Empty;
    public decimal Alcohol { get; set; }

    [ForeignKey("Brand")]
    public int BrandId { get; set; }

    public virtual Brand? Brand { get; set; }
}
