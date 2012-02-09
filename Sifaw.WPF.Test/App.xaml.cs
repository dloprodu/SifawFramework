using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Sifaw.Controllers;
using Sifaw.Controllers.Components;
using Sifaw.Controllers.Test;


namespace Sifaw.WPF.Test
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		#region Constructor

		public App()
			: base()
		{
			AbstractUIProviderManager<AbstractUIProvider>.SetUIElementLinker(new WPFProvider());

			//(new MainWindow()).Show();			
			
			//UIBackgroundWorkerViewController workerController = new UIBackgroundWorkerViewController(null);
			//workerController.UISettings.AllowCancel = true;
			//workerController.Start(new UIBackgroundWorkerViewController.Input(new BackgroundWorkerPack(TestBackGroundWorker, null)));

			UIAssistantTestViewController assistantTest = new UIAssistantTestViewController();
			assistantTest.Start();
		}

		#endregion

		#region Métodos auxiliares

		public static object TestBackGroundWorker(BackgroundWorkerCommunicator com, object[] args)
		{
			int count = 1000;
			com.ChangeMaxProgress(count);

			for (int i = 0; i < count; i++)
			{
				com.Progress(i, "Procesando iteración " + i.ToString() + " ...");
				System.Threading.Thread.Sleep(100);

				if (com.CancellationPending)
					return "Cancelled";
			}

			return "Finished";
		}

		#endregion
	}
}