using AutoMapper;
using MassTransit;
using SCO.ConfigurationService.Infrastructure.Respositories;
using SCO.Contracts.Requests.Configuration;
using SCO.Contracts.Responses.Configuration;

namespace SCO.ConfigurationService.Application.MassTransit;

public class ShopDataRequestConsumer : IConsumer<ShopDataRequest>
{
    private readonly ShopSettingsRepository _stationSettingsRepository;

    public ShopDataRequestConsumer(ShopSettingsRepository stationSettingsRepository)
    {
        _stationSettingsRepository = stationSettingsRepository;
    }

    public async Task Consume(ConsumeContext<ShopDataRequest> context)
    {
        try
        {
            await context.RespondAsync(new ShopDataResponse()
            {
               ShopName =  _stationSettingsRepository.GetShopName(),
               ShopAddress =_stationSettingsRepository.GetShopAddress()
            });
        }
        catch (Exception ex)
        {

        }
    }
}
