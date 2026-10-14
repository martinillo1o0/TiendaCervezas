using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class BeerInsertDto
{
	[Required]
	public string Name { get; set; } = string.Empty;

	[Range(1, int.MaxValue)]
	public int BrandId { get; set; }

	[Range(typeof(decimal), "0", "100")]
	public decimal Alcohol { get; set; }
}
