using AutoMapper;
using SCO.PromotionService.Application.Common.Interfaces.Persistance;
using SCO.PromotionService.Domain.Entities;
using SCO.PromotionService.Domain.PromoEngine;
using SCO.PromotionService.Domain.PromoHelper;
using SCO.PromotionService.Domain.ValueObjects;
using System.Linq.Expressions;

namespace SCO.PromotionService.Application.StandartEngine;

public class StandartPromoEngine : IPromoEngine
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;
    private readonly IPromoCalculator _promoCalculator;

    public StandartPromoEngine(IUnitOfWork unitOfWork, Mapper mapper, IPromoCalculator promoCalculator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _promoCalculator = promoCalculator;
    }

    public async Task<CalculatedBasket> CalculatePromotion(RawBasket rawBasket)
    {
        var calculatedBasket = new CalculatedBasket();
        var mathcedBasket = await _unitOfWork.PromoBaskets.FindMatchedBaskets(rawBasket);

        foreach (var rawItem in rawBasket.Items)
        {
            var promoBasket = mathcedBasket.FirstOrDefault(s => s.Items.Any(s=>s.Id == rawItem.Id));
            if (promoBasket != null)
            {
                if (promoBasket.PromotionType == Domain.Enums.PromotionType.PromotionPercent)
                {
                    calculatedBasket.Items.Add(new CalculatedItem()
                    {
                        Id = rawItem.Id,
                        OldUnitPrice = rawItem.UnitPrice,
                        UnitPrice = _promoCalculator.GetPromoValuePercent( rawItem.UnitPrice, promoBasket.PromotionValue),
                        Quantitity = rawItem.Quantitity,
                        Promoted = false
                    });
                }
                else if (promoBasket.PromotionType == Domain.Enums.PromotionType.PromotionAmount)
                {
                    calculatedBasket.Items.Add(new CalculatedItem()
                    {
                        Id = rawItem.Id,
                        OldUnitPrice = rawItem.UnitPrice,
                        UnitPrice = _promoCalculator.GetPromoValueAmount(rawItem.UnitPrice, (decimal)rawItem.Quantitity, promoBasket.PromotionValue),
                        Quantitity = rawItem.Quantitity,
                        Promoted = false
                    });
                }
            }
            else
            {
                calculatedBasket.Items.Add(new CalculatedItem()
                {
                    Id = rawItem.Id,
                    OldUnitPrice = rawItem.UnitPrice,
                    UnitPrice = rawItem.UnitPrice,
                    Quantitity = rawItem.Quantitity,
                    Promoted = false
                });
            }
        }

        return calculatedBasket;
    }

}
