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

			//(new MainWindow()).Show();			

			//UIBackgroundWorkerViewController workerController = new UIBackgroundWorkerViewController(null);
			//workerController.UISettings.AllowCancel = true;
			//workerController.Start(new UIBackgroundWorkerViewController.Input(new BackgroundWorkerPack(TestBackGroundWorker, null)));

			//UIGroupFiltersTestViewController groupFiltersTest = new UIGroupFiltersTestViewController();
			//groupFiltersTest.Start();

			UIAssistantTestViewController assistantTest = new UIAssistantTestViewController();
			assistantTest.Start();
		}

		#endregion
	}
}