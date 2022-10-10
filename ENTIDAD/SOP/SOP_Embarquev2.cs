using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD.SOP
{
    public class SOP_Embarquev2
    {

        public ShipmentTracking ShipmentTracking { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Destination
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string CountryCode { get; set; }
    }

    public class MessageHeader
    {
        public string Version { get; set; }
        public string MessageID { get; set; }
        public DateTime CreationDateTime { get; set; }
    }

    public class Origin
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string CountryCode { get; set; }
    }

    public class PlaceOfAcceptance
    {
        public string LocationName { get; set; }
    }

    public class PlaceOfDelivery
    {
        public string LocationName { get; set; }
    }

    public class PortOfLoading
    {
        public string LocationName { get; set; }
    }

    public class PortOfUnloading
    {
        public string LocationName { get; set; }
    }

    public class Root
    {
        //public ShipmentTracking ShipmentTracking { get; set; }
    }

    public class Route
    {
        public string VesselName { get; set; }
        public string VoyageFlightNumber { get; set; }
        public DateTime EstimatedDepartureDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public PlaceOfAcceptance PlaceOfAcceptance { get; set; }
        public PortOfLoading PortOfLoading { get; set; }
        public PortOfUnloading PortOfUnloading { get; set; }
        public PlaceOfDelivery PlaceOfDelivery { get; set; }
    }

    public class Routes
    {
        public List<Route> Route { get; set; }
    }

    public class Shipment
    {
        public string HousebillNumber { get; set; }
        public Origin Origin { get; set; }
        public Destination Destination { get; set; }
        public string ProductType { get; set; }
        public string TotalPackages { get; set; }
        public TotalWeight TotalWeight { get; set; }
        public TotalVolume TotalVolume { get; set; }
        public string ExpressBOLFlag { get; set; }
        public string ServiceProduct { get; set; }
        public TransportUnits TransportUnits { get; set; }
        public Routes Routes { get; set; }
        public Timestamps Timestamps { get; set; }
    }

    public class ShipmentTracking
    {
        public MessageHeader MessageHeader { get; set; }
        public Shipment Shipment { get; set; }
    }

    public class Timestamp
    {
        public string TimestampCode { get; set; }
        public string TimestampDescription { get; set; }
        public DateTime TimestampDateTime { get; set; }
    }

    public class Timestamps
    {
        public List<Timestamp> Timestamp { get; set; }
    }

    public class TotalVolume
    {
        [JsonProperty("*body")]
        public string Body { get; set; }

        [JsonProperty("@uom")]
        public string Uom { get; set; }
    }

    public class TotalWeight
    {
        [JsonProperty("*body")]
        public string Body { get; set; }

        [JsonProperty("@uom")]
        public string Uom { get; set; }
    }

    public class TransportUnits
    {
        public List<string> TransportUnitID { get; set; }
    }

}
