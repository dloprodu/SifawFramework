using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Drawing;
using System.IO;

using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.WPF.Test
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		#region Constructors

		public App()
			: base()
		{
			UILinkersManager.SetUIElementLinker(new WPFLinkers());

            Bitmap ico = Resource.SffIco128x128;
            //byte[] buffer = null;

            //using (MemoryStream mStream = new MemoryStream())
            //{
            //    ico.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
            //    buffer = mStream.GetBuffer();
            //}

            UIImage image = null;
            using (MemoryStream mStream = new MemoryStream())
            {
                ico.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
                image = new UIImage(mStream);
            }

            // (new MainWindow()).Show();			
			
			//(new UIGroupFiltersTestViewController()).Start();
            //(new UIAssistantTestViewController()).Start();
            //(new UITabHostTestViewController()).Start();

            UIAssistantTestViewController test = new UIAssistantTestViewController();
            test.UISettings.Thumbnail = image;// new UIImage(buffer);
            test.Start();            
		}

		#endregion
	}
}