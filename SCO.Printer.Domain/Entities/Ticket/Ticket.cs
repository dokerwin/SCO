namespace SCO.PrinterService.Domain.Entities.Ticket;

public class Ticket
{
    public int Id { get; set; }
    private Header _header;
    private Body _body;
    private EFTSlip _eFTSlip;
    private Footer _footer;

    public void SetHeader(Header header)
    {
        _header = header;
    }
    public void SetBody (Body body)
    {
        _body = body;
    }
    public void SetEFTSlip (EFTSlip eFTSlip )
    {
        _eFTSlip = eFTSlip;
    }
    public void SetFooter(Footer footer)
    {
        _footer = footer;
    }
    
    public Footer Footer { get { return _footer;} }
    public Header Header { get { return _header; } }
    public Body Body { get { return _body; } }
    public EFTSlip EFTSlip { get { return _eFTSlip; } }
}
