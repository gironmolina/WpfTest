using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfTest.Model;

namespace WpfTest.Services
{
	public class PrcSstService : IPrcSstService
	{
		private const string XML_PATH = ".\\TestXML.xml";

		public async Task<PrcSst> LoadPrcSstXml()
		{
			var prcSstReadTask = new Task<PrcSst>(() =>
			{
				var xmlSerializer = new XmlSerializer(typeof(PrcSst));
				using var fileStream = new FileStream(XML_PATH, FileMode.Open);
				var prcSst = (PrcSst)xmlSerializer.Deserialize(fileStream);
				return prcSst;
			});

			prcSstReadTask.Start();
			return await prcSstReadTask;
		}
	}
}
