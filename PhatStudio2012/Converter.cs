using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PhatStudio
{

	/// <summary>
	/// Stupid little class to translate icon from a managed Image to an OLE IPictureDisp to hand off to set the tool window tab icon.
	/// </summary>
	[System.ComponentModel.DesignerCategory("")]    // disable "view designer" option from deciding to show up in IDE and cause mayhem
	public class ImageToPictureDispConverter : System.Windows.Forms.AxHost
	{
		public ImageToPictureDispConverter()
			: base("{63109182-966B-4e3c-A8B2-8BC4A88D221C}") { }

		public stdole.IPictureDisp GetIPictureDispFromImage(System.Drawing.Image image)
		{
			return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
		}
	}

	/// <summary>Used to create a new AboutIconData in PhatStudio.AddIn</summary>
	class IconExtractor
	{
		static void ConvertIcoToBinaryString()
		{
			OpenFileDialog fd = new OpenFileDialog();
			if (fd.ShowDialog() == DialogResult.OK)
			{
				string textName = Path.ChangeExtension(fd.FileName, ".txt");
				using (StreamWriter sw = new StreamWriter(textName))
				{
					byte[] data = File.ReadAllBytes(fd.FileName);
					for (int i = 0; i < data.Length; i++)
						sw.Write(data[i].ToString("X2"));
					sw.Close();
				}
			}
		}
	}
}
