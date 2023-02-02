using Newtonsoft.Json;
using SCO.ConfigurationService.Domain.Entities;

namespace SCO.ConfigurationService.Infrastructure.Respositories;

public sealed class ShopSettingsRepository
{
    private StationsSettings _stationSettings;

    public ShopSettingsRepository()
    {
        LoadJson();
    }

    private void LoadJson()
    {
        using (StreamReader r = new StreamReader("StationsSettings.json"))
        {
            string json = r.ReadToEnd();
            _stationSettings = JsonConvert.DeserializeObject<StationsSettings>(json);
        }
    }

    public string GetShopName()
    {
        return _stationSettings.ShopName;
    }

    public string GetShopAddress()
    {
        return _stationSettings.ShopAddress;
    }
}
