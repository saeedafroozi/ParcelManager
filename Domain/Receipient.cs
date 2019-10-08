using System;
using System.Xml.Serialization;

namespace ParcelManager.Domain
{
	[XmlRoot("Receipient")]
	[Serializable]
	public class Receipient
	{
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Address")]
		public Address Address { get; set; }
	}
}
