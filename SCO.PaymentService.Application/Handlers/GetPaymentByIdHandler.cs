using AutoMapper;
using MediatR;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Application.Queries;
using SCO.PaymentService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.PaymentService.Application.Handlers;

public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public GetPaymentByIdHandler(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
        this.mapper = mapper;
    }

    public async Task<PaymentDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.Payments.GetById(request.Id);

        var payment = mapper.Map<PaymentDto>(result);   

        return await Task.FromResult(payment);
    }
}
