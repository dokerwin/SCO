using Newtonsoft.Json;
using SCO.ConfigurationService.Domain.Entities;

namespace SCO.ConfigurationService.Infrastructure.Respositories;

public class PrinterSettingsRepository
{
    private PrinterSettings _printerSettings;
    public PrinterSettingsRepository()
    {
        LoadJson();
    }

    private void LoadJson()
    {
        using (StreamReader r = new StreamReader("PrinterSettings.json"))
        {
            string json = r.ReadToEnd();
            _printerSettings = JsonConvert.DeserializeObject<PrinterSettings>(json);
        }
    }

    public bool IsPrinterEnabled()
    {
        return _printerSettings.PrinterEnabled;
    }
}
