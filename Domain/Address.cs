using System;
using System.Xml.Serialization;

namespace ParcelManager.Domain
{
	[XmlRoot("Address")]
	[Serializable]
	public class Address
	{
		[XmlElement(ElementName = "Street")]
		public string Street { get; set; }

		[XmlElement(ElementName = "HouseNumber")]
		public int HouseNumber { get; set; }

		[XmlElement(ElementName = "PostalCode")]
		public string PostalCode { get; set; }

		[XmlElement(ElementName = "City")]
		public string City { get; set; }
	}
}