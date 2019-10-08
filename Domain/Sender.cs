using System;
using System.Xml.Serialization;

namespace ParcelManager.Domain
{
	[XmlRoot("Sender")]
	[Serializable]
	[XmlInclude(typeof(Company))]
	public class Sender
	{
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Address")]
		public Address Address { get; set; }

		[XmlElement(IsNullable = true)]
		public long? CcNumber { get; set; }
	}
}