using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
	public class Logging
	{
		public static void Write(string text, string controller = null, string action = null)
		{
			try
			{
				// D:\C#\DoAnCoSo\DoAnCoSo\Logging\Log\Log.txt
				string filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\DoAnCoSo\\Logging\\Log\\Log.txt";
				FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None);
				StreamWriter writer = new StreamWriter(fileStream);
				writer.WriteLine(controller??"" + "/" + action??"" + "    " + text + "    " + DateTime.Now);
				writer.Close();
				fileStream.Close();
			}
			catch
			{
				return;
			}
		}
	}
}
