/*
 * Sifaw.WPF.CCL
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 13/03/2012: Creación de la clase.
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
using System.Windows.Controls.Primitives;
using System.ComponentModel;


namespace Sifaw.WPF.CCL
{
    /// <summary>
    /// Se usa en la plantilla de un control <see cref="DataTable"/> para especificar la ubicación en el árbol visual del 
    /// control donde se van a agregar las filas de la tabla.
    /// </summary>
    public class DataTableRowsPresenter : VirtualizingPanel, IScrollInfo
    {
        #region Fields

        private ScrollViewer _owner = null;
        private bool _canHScroll = false;
        private bool _canVScroll = false;
        private Size _extent = Size.Empty;
        private Point _offset = new Point(0, 0);
        private Size _viewport = Size.Empty;

        #endregion

        #region Dependecy Properties

        public static DependencyProperty RowHeightProperty =
           DependencyProperty.Register(
               "RowHeight",
               typeof(double),
               typeof(DataTableRowsPresenter),
               new FrameworkPropertyMetadata(
                     (double)21.0
                   , FrameworkPropertyMetadataOptions.AffectsMeasure
                   | FrameworkPropertyMetadataOptions.AffectsArrange
                   | FrameworkPropertyMetadataOptions.AffectsRender)
               );

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene o establece el texto que se muesta cuando la propiedad Text no tiene valor definido.
        /// </summary>
        [Category("Placeholder")]
        [Bindable(true)]
        public double RowHeight
        {
            get { return (double)GetValue(RowHeightProperty); }
            set { SetValue(RowHeightProperty, value); }
        }

        #endregion

        #region Constructor

        static DataTableRowsPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTableRowsPresenter), new FrameworkPropertyMetadata(typeof(DataTableRowsPresenter)));
        }

        public DataTableRowsPresenter()
        {
        }

        #endregion

        #region Helpers

        private void InvalidateScrollInfo()
        {
            if (_owner != null)
                _owner.InvalidateScrollInfo();
        }

        private void UpdateViewPortAndExtend(Size availableSize)
        {
            bool update = false;
            Size newExtent = new Size(availableSize.Width, InternalChildren.Count * RowHeight);

            if (_extent != newExtent)
            {
                _extent = newExtent;
                update |= true;
            }

            if (_viewport != availableSize)
            {
                _viewport = availableSize;
                update |= true;
            }

            if (update)
                InvalidateScrollInfo();
        }

        /// <summary>
        /// Corrige el error de desplazamiento si se cambia el tamaño del panel
        /// y los items están desplazados.
        /// </summary>
        private void CorrectArrange()
        {
            if (InternalChildren.Count != 0)
            {
                double first = ((0) * RowHeight) - _offset.Y;
                double last = ((InternalChildren.Count - 1) * RowHeight) - _offset.Y;

                if ((first < 0) && ((last + RowHeight) < _viewport.Height))
                {
                    /* Mejorar el arreglo de _offset.Y para no dar saltos bruscos. */
                    _offset.Y = Math.Max(0, /* Completar */);
                    InvalidateScrollInfo();
                }
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Mide el tamaño del diseño necesario para los elementos secundarios y 
        /// determina un tamaño para la clase.
        /// </summary>
        /// <param name="availableSize">
        /// Tamaño disponible que este elemento puede otorgar a los elementos secundarios.Se
        /// puede usar infinito como valor para indicar que el elemento puede ajustarse
        /// a cualquier contenido disponible.
        /// </param>
        /// <returns>
        /// El tamaño que este elemento determina que necesita durante el diseño, según
        /// sus cálculos de tamaño de los elementos secundarios.
        /// </returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            Size desireSize = availableSize;

            if (double.IsInfinity(desireSize.Height))
                desireSize.Height = ActualHeight;

            if (double.IsInfinity(desireSize.Width))
                desireSize.Width = ActualWidth;

            UpdateViewPortAndExtend(desireSize);

            Size availableChildSize = new Size(desireSize.Width, RowHeight);

            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableChildSize);
            }

            return desireSize;
        }

        /// <summary>
        /// Coloca los elementos secundarios y determina un tamaño para la clase.
        /// </summary>
        /// <param name="finalSize">
        /// Área final en el elemento primario que este elemento debe utilizar para organizarse
        /// y para organizar sus elementos secundarios.
        /// </param>
        /// <returns>Tamaño real utilizado.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            Size desireSize = finalSize;

            if (double.IsInfinity(desireSize.Height))
                desireSize.Height = ActualHeight;

            if (double.IsInfinity(desireSize.Width))
                desireSize.Width = ActualWidth;

            UpdateViewPortAndExtend(desireSize);
            CorrectArrange();

            Size availableChildSize = new Size(desireSize.Width, RowHeight);

            for (int row = 0; row < InternalChildren.Count; row++)
            {
                Rect rect = new Rect(
                      -_offset.X
                    , (row * RowHeight) - _offset.Y
                    , availableChildSize.Width
                    , availableChildSize.Height);
                
                // Coloca los elementos secundarios y determina su tamaño.
                InternalChildren[row].Arrange(rect);
            }

            return finalSize;
        }

        #endregion

        #region IScrollInfo members

        #region Properties

        /// <summary>
        /// Obtiene o establece un elemento ScrollViewer que controla el comportamiento del desplazamiento.
        /// </summary>
        public ScrollViewer ScrollOwner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica si es posible el desplazamiento en el eje horizontal.
        /// </summary>
        public bool CanHorizontallyScroll
        {
            get { return _canHScroll; }
            set { _canHScroll = value; }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica si es posible el desplazamiento en el eje vertical.
        /// </summary>
        public bool CanVerticallyScroll
        {
            get { return _canVScroll; }
            set { _canVScroll = value; }
        }

        /// <summary>
        /// Obtiene el tamaño vertical de la extensión.
        /// </summary>
        public double ExtentHeight
        {
            get { return _extent.Height; }
        }

        /// <summary>
        /// Obtiene el tamaño horizontal de la extensión.
        /// </summary>
        public double ExtentWidth
        {
            get { return _extent.Width; }
        }

        /// <summary>
        /// Obtiene el desplazamiento horizontal del contenido desplazado.
        /// </summary>
        public double HorizontalOffset
        {
            get { return _offset.X; }
        }

        /// <summary>
        /// Obtiene el desplazamiento vertical del contenido desplazado.
        /// </summary>
        public double VerticalOffset
        {
            get { return _offset.Y; }
        }

        /// <summary>
        /// Obtiene el tamaño vertical de la ventanilla de este contenido.
        /// </summary>
        public double ViewportHeight
        {
            get { return _viewport.Height; }
        }

        /// <summary>
        /// Obtiene el tamaño horizontal de la ventanilla de este contenido.
        /// </summary>
        public double ViewportWidth
        {
            get { return _viewport.Width; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Se desplaza una unidad lógica hacia abajo en el contenido.
        /// </summary>
        public void LineDown()
        {
            SetVerticalOffset(VerticalOffset + 1);
        }

        /// <summary>
        /// Se desplaza una unidad lógica hacia la izquierda en el contenido.
        /// </summary>
        public void LineLeft()
        {
            SetHorizontalOffset(HorizontalOffset - 1);
        }

        /// <summary>
        /// Se desplaza una unidad lógica hacia la derecha en el contenido.
        /// </summary>
        public void LineRight()
        {
            SetHorizontalOffset(HorizontalOffset + 1);
        }

        /// <summary>
        /// Se desplaza una unidad lógica hacia arriba en el contenido.
        /// </summary>
        public void LineUp()
        {
            SetVerticalOffset(VerticalOffset - 1);
        }

        /// <summary>
        /// Exige que el contenido se desplace hasta que el espacio de la coordenada de un objeto Visual esté visible.
        /// </summary>
        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                if ((Visual)this.InternalChildren[i] == visual)
                {
                    Rect actualPort = new Rect(new Point(HorizontalOffset, VerticalOffset), new Size(ViewportWidth + HorizontalOffset, ViewportHeight + VerticalOffset));

                    if (!rectangle.IntersectsWith(actualPort))
                    {
                        SetVerticalOffset(RowHeight * i);

                        // Child size is always smaller than viewport.
                        return rectangle;
                    }
                }
            }

            return Rect.Empty;
            //throw new ArgumentException("Given visual is not in this Panel");
        }

        /// <summary>
        /// Se desplaza hacia abajo en el contenido cuando un usuario hace clic en el botón de rueda en un mouse.
        /// </summary>
        public void MouseWheelDown()
        {
            SetVerticalOffset(VerticalOffset + 10);
        }

        /// <summary>
        /// Se desplaza hacia la izquierda en el contenido cuando un usuario hace clic en el botón de rueda en un mouse.
        /// </summary>
        public void MouseWheelLeft()
        {
            SetVerticalOffset(HorizontalOffset - 10);
        }

        /// <summary>
        /// Se desplaza hacia la derecha en el contenido cuando un usuario hace clic en el botón de rueda en un mouse.
        /// </summary>
        public void MouseWheelRight()
        {
            SetVerticalOffset(HorizontalOffset + 10);
        }

        /// <summary>
        /// Se desplaza hacia arriba en el contenido cuando un usuario hace clic en el botón de rueda en un mouse.
        /// </summary>
        public void MouseWheelUp()
        {
            SetVerticalOffset(VerticalOffset - 10);
        }

        /// <summary>
        /// Se desplaza una página hacia abajo en el contenido.
        /// </summary>
        public void PageDown()
        {
            SetVerticalOffset(VerticalOffset + RowHeight);
        }

        /// <summary>
        /// Se desplaza una página a la izquierda en el contenido.
        /// </summary>
        public void PageLeft()
        {
            SetHorizontalOffset(HorizontalOffset - 1);
        }

        /// <summary>
        /// Se desplaza una página a la derecha en el contenido.
        /// </summary>
        public void PageRight()
        {
            SetHorizontalOffset(HorizontalOffset + 1);
        }

        /// <summary>
        /// Se desplaza una página en el contenido.
        /// </summary>
        public void PageUp()
        {
            SetVerticalOffset(VerticalOffset - RowHeight);
        }

        public void SetHorizontalOffset(double offset)
        {
            // Si offset < 0 ó la ventana visible es mayor que la ventana que ocupan los elementos hijos.
            if (offset < 0 || _viewport.Width >= _extent.Width)
            {
                offset = 0;
            }
            // Si offset supera la ventana que ocupan los elementos hijos.
            else if (offset + _viewport.Width >= _extent.Width)
            {
                offset = _extent.Width - _viewport.Width;
            }

            _offset.X = offset;

            //InvalidateScrollInfo();
            InvalidateArrange();
        }

        /// <summary>
        /// Establece la longitud del desplazamiento vertical.
        /// </summary>
        public void SetVerticalOffset(double offset)
        {
            // Si offset < 0 ó la ventana visible es mayor que la ventana que ocupan los elementos hijos.
            if (offset < 0 || _viewport.Height >= _extent.Height)
            {
                offset = 0;
            }
            // Si offset supera la ventana que ocupan los elementos hijos.
            else if (offset + _viewport.Height >= _extent.Height)
            {
                offset = _extent.Height - _viewport.Height;
            }

            _offset.Y = offset;

            //InvalidateScrollInfo();
            InvalidateArrange();
        }

        #endregion

        #endregion
    }
}