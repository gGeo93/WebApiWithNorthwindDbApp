public interface IShipInformation
{
    int? ShipVia { get; set; }
    string CompanyName { get; set; }
    string? ShipName { get; set; }
    string? ShipAddress { get; set; }
    string? ShipCity { get; set; }
    string? ShipRegion { get; set; }
    string? ShipPostalCode { get; set; }
    string? ShipCountry { get; set; }
}
