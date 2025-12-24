using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace GurventVantilator.Application.DTOs
{
    public class ProductModelDto
    {
        // Temel
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Seri bağlantısı
        public int ProductSeriesId { get; set; }
        public string? ProductSeriesName { get; set; }

        // Kullanım Tipleri (Many-to-Many)
        public List<int> UsageTypeIds { get; set; } = new();
        public List<string>? UsageTypeNames { get; set; }

        // Çalışma Koşulları (Many-to-Many)
        public List<int> WorkingConditionIds { get; set; } = new();
        public List<string>? WorkingConditionNames { get; set; }

        // İçerik Özellikleri — Product ile birebir aynı
        public string? ContentTitle { get; set; }
        public string? ContentDescription { get; set; }
        public List<ProductContentFeatureDto> ContentFeatures { get; set; } = new();

        // Teknik Değerler
        public double? AirFlow { get; set; }
        public string? AirFlowUnit { get; set; }
        public double? TotalPressure { get; set; }
        public string? TotalPressureUnit { get; set; }
        public string? Power { get; set; }
        public double? Voltage { get; set; }
        public double? Frequency { get; set; }
        public string? SpeedControl { get; set; }
        public double? Temperature { get; set; }

        // Görseller
        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public string? Image3Path { get; set; }
        public string? Image4Path { get; set; }
        public string? Image5Path { get; set; }

        // Dosya Yolları
        public string? DataSheetPath { get; set; }
        public string? Model3DPath { get; set; }
        public string? TestDataPath { get; set; }
        public string? ScaleImagePath { get; set; }

        // Durum
        public bool IsActive { get; set; } = true;
        public int? Order { get; set; } = 0;

        // Tarihler
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Bu modele bağlı ürünler
        public List<ProductDto> Products { get; set; } = new();

        // İsteğe bağlı yükleme
        public IFormFile? ImageFile { get; set; }
        public List<ProductModelDocumentDto> Documents { get; set; }
        public string? BodyMaterialStandard { get; set; }
        public string? ImpellerMaterialStandard { get; set; }
        public string? CarryingBracketStandard { get; set; }
        public string? HeatResistanceStandard { get; set; }
        public string? ColdResistanceStandard { get; set; }
        public string? MotorProtectionCapStandard { get; set; }
        public string? BodyMaterialOptional { get; set; }
        public string? ImpellerMaterialOptional { get; set; }
        public string? CarryingBracketOptional { get; set; }
        public string? HeatResistanceOptional { get; set; }
        public string? ColdResistanceOptional { get; set; }
        public string? MotorProtectionCapOptional { get; set; }
        public List<ProductModelFeatureDto> ModelFeatures { get; set; } = new();
        public List<int> DeletedFeatureIds { get; set; } = new();


    }
}
