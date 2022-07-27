﻿public class BaseOrdersWithFreight : IBaseOrdersWithFreight
{
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public decimal? Freight { get; set; }
}
