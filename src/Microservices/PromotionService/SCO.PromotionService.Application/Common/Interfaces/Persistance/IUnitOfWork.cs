﻿namespace SCO.PromotionService.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    IPromotionRepository Promotions { get; }
    IPromoBasketRepository PromoBaskets { get; }
    Task CompleteAsync();
}

