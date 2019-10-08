using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ParcelManager.Domain
{
	[XmlRoot("Container")]
	[Serializable]
	public class Container
	{
		[XmlElement(ElementName = "Id")]
		public int Id { get; set; }

		[XmlElement(ElementName = "ShippingDate")]
		public DateTime ShippingDate { get; set; }

		[XmlArray("parcels")]
		public List<Parcel> Parcels { get; set; }
	}
}
