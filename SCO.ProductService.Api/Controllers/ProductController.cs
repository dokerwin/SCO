using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;
using SCO.ProductService.Application.Queries;

namespace SCO.Api.Conrollers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductQueryService _productQueryService;
    private readonly IMediator _mediator;

    public IRequest<object> GetAllProductQuery { get; private set; }

    public ProductController(IProductQueryService productQueryService, IMediator mediator)
    {
        _productQueryService = productQueryService;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> Get([FromRoute] Guid id)
    {
        var restaurant = _productQueryService.GetById(id);
        return Ok(restaurant);
    }


    [HttpGet("ProductByCategory/{categoryName}")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetRestaurantByCategoryAsync([FromRoute] string categoryName)
    {

        var result = await _mediator.Send(new GetProductsByCategoryQuery(new CategoryDto() { Name = categoryName }));

        if (result is not null)
        {
            return Ok(result);
        }
        return NotFound("The category does not exist or empty");
    }

    [HttpGet("ProductByName/{productName}")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByNameAsync([FromRoute] string productName)
    {

        var result = await _mediator.Send(new GetProductsByNameQuery(new ProductDto() { ShortName = productName}));

        if (result is not null)
        {
            return Ok(result);
        }

        return NotFound("The product was not found");
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());

        if (result is not null)
        {
            return Ok(result);
        }
        return NotFound("No found products");
    }
}