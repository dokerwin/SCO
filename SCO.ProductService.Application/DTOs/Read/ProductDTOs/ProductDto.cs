using SCO.ProductService.Application.DTOs.Read.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.ProductService.Application.DTOs.Read.ProductDTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Barcode { get; set; }
    public string ShortName { get; set; }
    public decimal Price { get; set; }
    public Guid VatId { get; set; }
    public Guid CategoryId { get; set; }
}
