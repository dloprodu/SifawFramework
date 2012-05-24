using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Sifaw.Views;


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
			AbstractUIProviderManager<AbstractUIProvider>.SetUIElementLinker(new WPFProvider());
            
            // (new MainWindow()).Show();			
			
			//(new UIGroupFiltersTestViewController()).Start();
			//(new UIAssistantTestViewController()).Start();
			(new UITabHostTestViewController()).Start();
			//(new UITableTestViewController()).Start();
		}

		#endregion
	}
}