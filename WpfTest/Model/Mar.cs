using System.Xml.Serialization;

namespace WpfTest.Model
{
	public class Mar
	{
		[XmlElement(ElementName = "NAM")]
		public string Nam { get; set; }

		[XmlElement(ElementName = "UNT")]
		public string Unt { get; set; }

		[XmlElement(ElementName = "VAL")]
		public decimal Val { get; set; }
    }
}
