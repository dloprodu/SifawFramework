﻿/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que permite definir una shell personalizada.
	/// </summary>
	public partial class DataListIntValueControl : UserControl, DataListComponent<int>
	{
		#region Constructors

        public DataListIntValueControl()
		{
			InitializeComponent();
		}

        #endregion

        #region Events

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnSelectedIndexChanged(new Core.SFIntEventArgs(listView.SelectedIndex));
            OnSelectedValueChanged((listView.SelectedItem == null)
                ? new Core.SFValueEventArgs<int>(default(int))
                : new Core.SFValueEventArgs<int>(((IListable<int>)listView.SelectedItem).ValueItem));
        }

        #endregion

        #region DataListComponent

        #region Properties

        public bool MultiSelection
        {
            get
            {
                return (listView.SelectionMode != SelectionMode.Single);
            }
            set
            {
                listView.SelectionMode = (value)
                    ? SelectionMode.Extended
                    : SelectionMode.Single;
            }
        }

        #endregion

        #region Methods

        public void SetDataList(IList<IListable<int>> list)
        {
            InitializeComponent();

            listView.ItemsSource = list;
            listView.SelectedValuePath = "ValueItem";

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("GroupKey");

            if (view != null)
                view.GroupDescriptions.Add(groupDescription);
        }

        public void SelectListableItem(int value)
        {
            listView.SelectedValue = value;

            if ((listView.SelectedIndex < 0) && (listView.HasItems))
                listView.SelectedIndex = 0;
        }

        public IList<int> GetSelection()
        {
            List<int> selection = new List<int>();

            foreach (object item in listView.SelectedItems)
                selection.Add(((IListable<int>)item).ValueItem);

            return selection;
        }

        public void ClearSelection()
        {
            listView.SelectedItems.Clear();
        }

        #endregion

        #region Events

        public event Core.SFIntEventHandler SelectedIndexChanged;
        private void OnSelectedIndexChanged(Core.SFIntEventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this as DataListComponent<int>, e);
        }

        public event Core.SFValueEventHandler<int> SelectedValueChanged;
        private void OnSelectedValueChanged(Core.SFValueEventArgs<int> e)
        {
            if (SelectedValueChanged != null)
                SelectedValueChanged(this as DataListComponent<int>, e);
        }

        #endregion

        #endregion

        #region UIElement Members

        public void Refresh()
		{
			/* Empty */
		}

		public void Reset()
		{
            listView.ItemsSource = new List<int>();
		}

		public void SetLikeActive()
		{
			grid.Focus();
		}

		#endregion

        #region UISettings

        private ComponentSettings _uiSettings = null;
        public ComponentSettings UISettings
        {
            get
            {
                if (_uiSettings == null)
                    _uiSettings = new ControlSettings(this);

                return _uiSettings;
            }
        }

        UISettings Views.UIElement.UISettings
        {
            get { return UISettings; }
        }

        #endregion
    }
}