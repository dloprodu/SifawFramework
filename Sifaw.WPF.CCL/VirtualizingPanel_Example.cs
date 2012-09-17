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
using System.Collections.Specialized;


namespace Sifaw.WPF.CCL
{
    /// <summary>
    /// Se usa en la plantilla de un control <see cref="DataTable"/> para especificar la ubicación en el árbol visual del 
    /// control donde se van a agregar las filas de la tabla.
    /// </summary>
    public class VirtualizingPanel_Example : VirtualizingPanel, IScrollInfo
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
               typeof(VirtualizingPanel_Example),
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

        public new IItemContainerGenerator ItemContainerGenerator
        {
            get
            {
                if (base.ItemContainerGenerator == null)
                    if (InternalChildren != null)
                    {
                        /* Al acceder a InternalChildren ItemContainerGenerator se carga. */
                    }

                return base.ItemContainerGenerator;
            }
        }

        #endregion

        #region Constructor

        static VirtualizingPanel_Example()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VirtualizingPanel_Example), new FrameworkPropertyMetadata(typeof(VirtualizingPanel_Example)));
        }

        public VirtualizingPanel_Example()
        {
        }

        #endregion

        #region Helpers

        private void InvalidateScrollInfo()
        {
            if (_owner != null)
                _owner.InvalidateScrollInfo();
        }

        private int GetNumElements()
        {
            ItemsControl itemsControl = ItemsControl.GetItemsOwner(this);
            return (itemsControl == null) ? InternalChildren.Count : (itemsControl.HasItems ? itemsControl.Items.Count : 0);
        }

        private void UpdateScrollInfo(Size availableSize)
        {
            bool update = false;
            Size newExtent = new Size(availableSize.Width, GetNumElements() * RowHeight);

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
        /// Este es un arreglo específico para el DataTableRowsPresenter
        /// para que las filas que son colapsadas muestren su contenido correctamente.
        /// </summary>
        private void ApplyDataTableCriteria(UIElement child, int zIndex)
        {
            if (child is Panel)
            {
                (child as Panel).SetValue(Panel.ClipToBoundsProperty, false);
                (child as Panel).SetValue(Panel.ZIndexProperty, zIndex);
            }
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
                double last = ((GetNumElements() - 1) * RowHeight) - _offset.Y;

                if ((first < 0) && ((last + RowHeight) < _viewport.Height))
                {
                    SetVerticalOffset(double.PositiveInfinity);
                }
            }
        }

        /// <summary>
        /// En caso de que el panel esté como plantilla de un ItemsControl 
        /// obtiene el rango de items visibles.
        /// </summary>
        /// <param name="first">Índice del primer item visible.</param>
        /// <param name="last">Índice del último item visible.</param>
        private void GetVisibleRange(out int first, out int last)
        {
            first = -1;
            last = -1;

            ItemsControl itemsControl = ItemsControl.GetItemsOwner(this);

            if (itemsControl != null)
            {
                /* Se calculan los índices que deben estar visibles. */
                first = (int)Math.Floor(VerticalOffset / RowHeight);
                last = (int)Math.Ceiling((VerticalOffset + ViewportHeight - RowHeight) / RowHeight);

                /* Se normaliza con los items existentes. */
                if (itemsControl.HasItems)
                {
                    first = Math.Min(first, itemsControl.Items.Count - 1);
                    last = Math.Min(last, itemsControl.Items.Count - 1);
                }
                else
                {
                    first = -1;
                    last = -1;
                }
            }
        }

        /// <summary>
        /// Revirtualiza los items que ya no son visibles.
        /// </summary>
        /// <param name="first">Índice del primer item visible.</param>
        /// <param name="last">Índice del último item visible.</param>
        private void CleanUpItems(int first, int last)
        {
            IItemContainerGenerator generator = this.ItemContainerGenerator;

            for (int i = InternalChildren.Count - 1; i >= 0; i--)
            {
                GeneratorPosition childGeneratorPos = new GeneratorPosition(i, 0);

                int index = generator.IndexFromGeneratorPosition(childGeneratorPos);

                if (index < first || index > last)
                {
                    generator.Remove(childGeneratorPos, 1);
                    RemoveInternalChildRange(i, 1);
                }
            }
        }

        /// <summary>
        /// // Coloca el elemento secundario y determina su tamaño.
        /// </summary>
        private void ArrangeChild(int itemIndex, UIElement child, Size childSize)
        {
            Rect rect = new Rect(
                  -_offset.X
                , (itemIndex * childSize.Height) - _offset.Y
                , childSize.Width
                , childSize.Height);

            child.Arrange(rect);
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

            Size childSize = new Size(desireSize.Width, RowHeight);

            UpdateScrollInfo(desireSize);

            if (ItemsControl.GetItemsOwner(this) == null)
            {
                /*
                 * Comportamiento por defecto. El panel no está asociado a un ItemsControl
                 * por lo que los elementos no son virtualizados.
                 */
                foreach (UIElement child in InternalChildren)
                    child.Measure(childSize);
            }
            else
            {
                /*
                 * El panel está asociado a un ItemsControl por lo que los elementos serán
                 * virtualizados.
                 */
                int first, last;
                GetVisibleRange(out first, out last);

                IItemContainerGenerator generator = this.ItemContainerGenerator;

                // Get the generator position of the first visible data item.
                GeneratorPosition startPos = generator.GeneratorPositionFromIndex(first);

                // Get index where we'd insert the child for this position. If the item is realized
                // (position.Offset == 0), it's just position.Index, otherwise we have to add one to
                // insert after the corresponding child
                if (startPos.Index >= 0)
                {
                    int childIndex = (startPos.Offset == 0) ? startPos.Index : startPos.Index + 1;
                    int zIndex = last;

                    using (generator.StartAt(startPos, GeneratorDirection.Forward, true))
                    {
                        for (int index = first; index <= last; ++index, ++childIndex, --zIndex)
                        {
                            bool isNew;

                            // Get or create the child
                            UIElement child = generator.GenerateNext(out isNew) as UIElement;

                            if (isNew)
                            {
                                generator.PrepareItemContainer(child);

                                if (childIndex >= InternalChildren.Count)
                                    base.AddInternalChild(child);
                                else
                                    base.InsertInternalChild(childIndex, child);
                            }

                            child.Measure(childSize);

                            ApplyDataTableCriteria(child, zIndex);
                        }
                    }
                }

                CleanUpItems(first, last);
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

            Size childSize = new Size(desireSize.Width, RowHeight);

            UpdateScrollInfo(desireSize);
            CorrectArrange();

            if (ItemsControl.GetItemsOwner(this) == null)
            {
                /*
                 * Comportamiento por defecto. El panel no está asociado a un ItemsControl
                 * por lo que los elementos no son virtualizados.
                 */
                for (int row = 0; row < InternalChildren.Count; row++)
                    ArrangeChild(row, InternalChildren[row], childSize);
            }
            else
            {
                /*
                 * El panel está asociado a un ItemsControl por lo que los elementos serán
                 * virtualizados.
                 */
                IItemContainerGenerator generator = this.ItemContainerGenerator;

                for (int i = InternalChildren.Count - 1; i >= 0; i--)
                {
                    UIElement child = InternalChildren[i];

                    // Map the child offset to an item offset
                    int itemIndex = generator.IndexFromGeneratorPosition(new GeneratorPosition(i, 0));

                    ArrangeChild(itemIndex, child, childSize);
                }
            }

            return finalSize;
        }

        protected override void OnItemsChanged(object sender, ItemsChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    RemoveInternalChildRange(args.Position.Index, args.ItemUICount);
                    break;
            }
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

            InvalidateMeasure();
            //InvalidateArrange();
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

            InvalidateMeasure();
            //InvalidateArrange();
        }

        #endregion

        #endregion
    }
}