using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using log4net;
using WpfTest.Model;

namespace WpfTest.Services
{
	public class PrcSstService : IPrcSstService
	{
		private const string XML_PATH = ".\\Resources\\TestXML.xml";
		private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

		public async Task<PrcSst> LoadPrcSstXml()
		{
			var prcSstReadTask = new Task<PrcSst>(() =>
			{
				var xmlSerializer = new XmlSerializer(typeof(PrcSst));
				try
				{
					using var fileStream = new FileStream(XML_PATH, FileMode.Open);
					var prcSst = (PrcSst)xmlSerializer.Deserialize(fileStream);
					return prcSst;
				}
				catch (Exception exception)
				{
					Logger.Error("Failed trying to read PrcSst", exception);
					return null;
				}
			});

			prcSstReadTask.Start();
			return await prcSstReadTask;
		}
	}
}
