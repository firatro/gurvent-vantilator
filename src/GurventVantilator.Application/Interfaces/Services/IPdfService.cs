using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.DTOs.Pdf;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IPdfService
    {
        byte[] GenerateProductPerformancePdf(
            ProductDto product,
            ProductPdfHeaderDto header,
            ProductPerformancePdfRequestDto request);
    }
}
