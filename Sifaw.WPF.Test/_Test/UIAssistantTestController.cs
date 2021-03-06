﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;

using Sifaw.Controllers.Components;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.WPF.Test
{
	public class UIAssistantTestController : UIAssistantController
		< UIAssistantTestController.Input
		, UIAssistantTestController.Output
		, UIComponent>
	{
		#region Input / Output

		[Serializable]
		public new class Input : UIAssistantController
			< Input
			, Output
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
			, UIComponent>.Output
		{
			public Output()
				: base()
			{
			}
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

		public UIAssistantTestController(UILinker<AssistantComponent> linker)
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
				  Controller1.GetUIComponent().UISettings.Denomination
				, Controller2.GetUIComponent().UISettings.Denomination
				, Controller3.GetUIComponent().UISettings.Denomination
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
            Controller1.UISettings.WithControl = false;
            Controller1.UISettings.AllowCancel = false;
            Controller1.UISettings.Denomination = "Vista 1...";
            Controller1.UISettings.Description = "Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1 Descripción Vista 1...";
            Controller1.Start(new UIBackgroundWorkerController.Input(new BackgroundWorkerPack(TestBackGroundWorker1, null), false));

            Controller2.UISettings.WithControl = false;
            Controller2.UISettings.Denomination = "Vista 2...";
            Controller2.UISettings.Description = "Descripción Vista 2...";
            Controller2.Start(new UIBackgroundWorkerController.Input(new BackgroundWorkerPack(TestBackGroundWorker2, null), false));

            Controller3.UISettings.WithControl = false;
            Controller3.UISettings.Denomination = "Vista 3...";
            Controller3.UISettings.Description = "Descripción Vista 3...";
            Controller3.Start(new UIBackgroundWorkerController.Input(new BackgroundWorkerPack(TestBackGroundWorker3, null), false));
		}

		private static object TestBackGroundWorker1(BackgroundWorkerCommunicator com, object[] args)
		{
			int count = 300;

            if (com != null)
            {
                com.ChangeWithControl(false);
            }

            System.Threading.Thread.Sleep(6000);

            if (com != null)
            {
                com.ChangeWithControl(true);
            }

            com.ChangeMaxProgress(count);

			for (int i = 0; i < count; i++)
			{
                com.Increment("Procesando iteración " + i.ToString() + " ...");
				System.Threading.Thread.Sleep(100);

				if (com.CancellationPending)
					return "Cancelled";
			}

			return "Finished";
		}

        private static object TestBackGroundWorker2(BackgroundWorkerCommunicator com, object[] args)
        {
            /* Empty */
            return null;
        }

        private static object TestBackGroundWorker3(BackgroundWorkerCommunicator com, object[] args)
        {
            /* Empty */
            return null;
        }

		#endregion
	}
}