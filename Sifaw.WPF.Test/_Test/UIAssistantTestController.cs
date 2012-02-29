using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers.Components;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.WPF.Test
{
	public class UIAssistantTestController : UIAssistantController
		< UIAssistantTestController.Input
		, UIAssistantTestController.Output
		, UIAssistantTestController.UISettingsContainer
		, UIComponent>
	{
		#region Input / Output

		[Serializable]
		public new class Input : UIAssistantController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.Input
		{
			public Input()
				: base()
			{
			}
		}

		[Serializable]
		public new class Output : UIAssistantController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.Output
		{
			public Output()
				: base()
			{
			}
		}

		#endregion

		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIAssistantController{TInput, TOutput, TUISettings, TGuest}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIAssistantController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput, TUISettings, TGuest}.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Inclusions

		private UIBackgroundWorkerController _controller1 = null;
		private UIBackgroundWorkerController Controller1
		{
			get
			{
				if (_controller1 == null)
				{
					_controller1 = new UIBackgroundWorkerController();
				}

				return _controller1;
			}
		}

		private UIBackgroundWorkerController _controller2 = null;
		private UIBackgroundWorkerController Controller2
		{
			get
			{
				if (_controller2 == null)
				{
					_controller2 = new UIBackgroundWorkerController();
				}

				return _controller2;
			}
		}

		private UIBackgroundWorkerController _controller3 = null;
		private UIBackgroundWorkerController Controller3
		{
			get
			{
				if (_controller3 == null)
				{
					_controller3 = new UIBackgroundWorkerController();
				}

				return _controller3;
			}
		}

		#endregion

		#region Constructors

		public UIAssistantTestController()
			: base()
		{
		}

		public UIAssistantTestController(AbstractUILinker<AssistantComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default Input / Output

		public override UIAssistantTestController.Input GetDefaultInput()
		{
			return new Input();			
		}

		public override UIAssistantTestController.Input GetResetInput()
		{
			return null;
		}

		protected override UIAssistantTestController.Output GetDefaultOutput()
		{
			return new Output();
		}

		#endregion

		#region UIAssistente Methods

		protected override string[] GetDescriptors()
		{
			return new string[] 
			{
				  Controller1.GetUIComponent().Denomination
				, Controller2.GetUIComponent().Denomination
				, Controller3.GetUIComponent().Denomination
			};
		}

		protected override UIComponent GetGuestAt(int key)
		{
			switch (key)
			{
				case 0:
					return Controller1.GetUIComponent();

				case 1:
					return Controller2.GetUIComponent();

				case 2:
					return Controller3.GetUIComponent();

				default:
					return null;
			}
		}

		protected override void OnBeforeUpdateAssistant(out bool allowCancel, out bool allowPrevious)
		{
			allowCancel = true;
			allowPrevious = true;
		}

		protected override void OnBeforeCancel(out bool finish, out Output output)
		{
			output = new Output();
			finish = true;
		}

		protected override void OnBeforeAccept(out bool finish, out Output output)
		{
			output = new Output();
			finish = true;
		}

        #endregion

        #region Public Methods

        public void RunWorker()
		{
			this.Controller1.RunWorker();
			this.Controller2.RunWorker();
			this.Controller3.RunWorker();
		}

        #endregion

        #region Start Methods

        protected override void StartController()
		{
			Controller1.UISettings.Denomination = "Vista 1...";
			Controller1.UISettings.Description = "Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1...";
			Controller1.UISettings.Apply();
			Controller1.Start(new UIBackgroundWorkerController.Input(new BackgroundWorkerPack(TestBackGroundWorker, null)));
			
			Controller2.UISettings.Denomination = "Vista 2...";
			Controller2.UISettings.Description = "Descripción Vista 2...";
			Controller2.UISettings.Apply();
			Controller2.Start(new UIBackgroundWorkerController.Input(new BackgroundWorkerPack(TestBackGroundWorker, null)));

			Controller3.UISettings.Denomination = "Vista 3...";
			Controller3.UISettings.Description = "Descripción Vista 3...";
			Controller3.UISettings.Apply();
			Controller3.Start(new UIBackgroundWorkerController.Input(new BackgroundWorkerPack(TestBackGroundWorker, null)));
		}

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