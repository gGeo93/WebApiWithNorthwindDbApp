﻿public class BaseOrderShipInformation : IBaseOrderShipInformation
{
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public ShipBasedOrder ShipBasedOrder { get; set; } = new();
    public int? ShipVia { get; set; }
    public string? ShipName { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipRegion { get; set; }
    public string? ShipPostalCode { get; set; }
    public string? ShipCountry { get; set; }
}
