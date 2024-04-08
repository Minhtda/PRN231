using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Enities.Models;

public partial class SilverJewelry
{
    public string SilverJewelryId { get; set; } = null!;
    [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$",
        ErrorMessage = "Full Name format is invalid. Each word should begin with a capital letter.")]
    public string SilverJewelryName { get; set; } = null!;

    public string? SilverJewelryDescription { get; set; }
    public decimal? MetalWeight { get; set; }
    [Range(0,10000000000000000000, ErrorMessage = "Age must be between 18 and 100.")]

    public decimal? Price { get; set; }
    [Range(1900, 2023, ErrorMessage = "Age must be between 18 and 100.")]

    public int? ProductionYear { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CategoryId { get; set; }
    [JsonIgnore]
    public virtual Category? Category { get; set; }
}
