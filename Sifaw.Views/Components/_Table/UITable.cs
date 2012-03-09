/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 29/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa una tabla de datos permitiendo definiir una cabecera, un cuerpo y un pie de tabla.
	/// </summary>
	/// <remarks>
	/// El cuerpo de la tabla puede estar formado por una o varias secciones de filas.
	/// </remarks>
	[Serializable]
	public class UITable : IEquatable<UITable>
	{
		#region Fields

		private string _name = string.Empty;

		private UITableRowCollection _header;
		private UITableSectionCollection _body;
		private UITableRowCollection _footer;

		private UISettings _settings;

		#endregion

        #region Properties

		/// <summary>
		/// Obtiene el nombre de la tabla.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Obtiene la cabecera de la tabla.
		/// </summary>
		public UITableRowCollection Header
        {
            get
            {
                if (_header == null)
					_header = new UITableRowCollection(this);

                return _header;
            }
        }

		/// <summary>
		/// Obtiene el cuerpo de la tabla.
		/// </summary>
		public UITableSectionCollection Body
        {
            get
            {
                if (_body == null)
					_body = new UITableSectionCollection(this);
							
                return _body;
            }
        }

		/// <summary>
		/// Obtiene el pie de la tabla.
		/// </summary>
		public UITableRowCollection Footer
        {
            get
            {
                if (_footer == null)
					_footer = new UITableRowCollection(this);

                return _footer;
            }
        }

		/// <summary>
		/// Obtiene o establece los ajustes de la sección de tabla.
		/// </summary>
		public UISettings Settings
		{
			get { return _settings; }
			set { _settings = value; }
		}

        #endregion

        #region Constructros

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITable"/>, estableciendo un valor
		/// en la propiedad <see cref="Name"/>.
		/// </summary>
		/// <param name="name">Nombre de la tabla.</param>
        public UITable(string name)
			: this(name, UISettings.Default)
		{			
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITable"/>, estableciendo valores
		/// en la propiedades <see cref="Name"/> y <see cref="Settings"/>.
		/// </summary>
		/// <param name="name">Nombre de la tabla.</param>
		/// <param name="settings">Estilo visual de la tabla.</param>
		public UITable(string name, UISettings settings)
		{
			this._name = name;
			this._settings = settings;
		}

		#endregion

		#region Override Methods

		/// <summary>
		/// Devuelve la representación de cadena de un objeto <see cref="UITable"/>.
		/// </summary>
		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// Determina si un objeto <see cref="UITable"/> proporcionado es equivalente al objeto <see cref="UITable"/> actual.
		/// </summary>
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj);
		}

		/// <summary>
		/// Obtiene un código hash de este objeto <see cref="UITable"/>.
		/// </summary>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion

		#region IEquatable<UITable> Members

		/// <summary>
		/// Determina si un objeto <see cref="UITable"/> proporcionado es equivalente al objeto <see cref="UITable"/> actual.
		/// </summary>
		public bool Equals(UITable other)
		{
			return ReferenceEquals(this, other);
		}

		#endregion

		#region Miscellany

		/// <summary>
		/// Provee un conjunto de propiedades que permiten modificar la apariencia
		/// de la tabla.
		/// </summary>
		public struct UISettings
		{
			/// <summary>
			/// Obtiene un <see cref="UISettings"/> con unos valores por defecto.
			/// </summary>
			public static readonly UISettings Default;

			#region Fields

			/// <summary>
			/// Obtiene o establece el pincel que describe el fondo del elemento.
			/// </summ
			public UIBrush Background;

			/// <summary>
			/// Obtiene o establece el grosor del borde del componente.
			/// </summary>
			public UIFrame Border;

			/// <summary>
			/// Obtiene o establece un pincel que describe el fondo del borde del componente.
			/// </summary>
			public UIFrameBrush BorderBrush;

			/// <summary>
			/// Obtiene o establece el alto de la filas.
			/// </summary>
			public double RowHeight;

			#endregion

			#region Constructor

			static UISettings()
			{
				Default = new UISettings(
					  background: new UISolidBrush(UIColors.WhiteColors.White)
					, border: new UIFrame(1)
					, borderBrush: new UIFrameBrush(new UISolidBrush(UIColors.BlueColors.RoyalBlue))
					, rowHeight: 18);
			}

			/// <summary>
			/// Inicializa una nueva instancia de la estructura <see cref="UISettings"/>.
			/// </summary>
			public UISettings(UIBrush background, UIFrame border, UIFrameBrush borderBrush, double rowHeight)
			{
				Background = background;
				Border = border;
				BorderBrush = borderBrush;
				RowHeight = rowHeight;
			}

			#endregion
		}

		/// <summary>
		/// Representa la colección de secciones que definen la cabecera, cuerpo y pie de un objeto <see cref="UITable"/>.
		/// </summary>
		[Serializable]
		public class UITableRowCollection : CollectionBase
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly UITable Owner;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene la fila en el índice especificado de la colección.
			/// </summary>
			/// <param name="index">Índice de la fila que se va a recuperar de la colección.</param>
			/// <returns>
			/// <see cref="UITableRow"/> que representa la fila
			/// ubicada en el índice especificado de la colección
			/// </returns>
			public UITableRow this[int index]
			{
				get { return ((UITableRow)List[index]); }
			}

			/// <summary>
			/// Obtiene de la colección la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a recuperar de la colección.</param>
			/// <returns>Objeto <see cref="UITableRow"/> con la clave especificada.</returns>
			public UITableRow this[string key]
			{
				get
				{
					foreach (UITableRow obj in List)
						if (obj.Name.Equals(key))
							return obj;

					return null;
				}
			}

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableSectionCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="UITable"/> que posee esta colección.</param>
			public UITableRowCollection(UITable owner)
			{
				this.Owner = owner;
			}

			#endregion

			#region Public Methods

			/// <summary>
			/// Agrega un objeto <see cref="UITableRow"/> existente a la colección.
			/// </summary>
			/// <param name="name">Nombre de la fila.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(string name)
			{
				if (ContainsKey(name))
					throw new ArgumentException("Ya existe una sección con igual nombre.", "name");

				return (List.Add(new UITableRow(name)));
			}

			/// <summary>
			/// Agrega un objeto <see cref="UITableRow"/> existente a la colección.
			/// </summary>
			/// <param name="name">Nombre de la fila.</param>
			/// <param name="cells">Configuración de celdas de la fila.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(string name, UITableCell[] cells)
			{
				if (ContainsKey(name))
					throw new ArgumentException("Ya existe una sección con igual nombre.", "name");

				return (List.Add(new UITableRow(name, cells)));
			}

			/// <summary>
			/// Devuelve el índice de la fila especificada incluida en la colección.
			/// </summary>
			/// <param name="section"><see cref="UITableRow"/> que representa la fila que se va a buscar en la colección.</param>
			/// <returns>
			/// Índice de base cero de la ubicación de la fila en la colección.
			/// Si la fila no se encuentra en la colección, el valor devuelto
			/// es -1.
			/// </returns>
			public int IndexOf(UITableRow section)
			{
				return (List.IndexOf(section));
			}

			/// <summary>
			/// Determina el índice de la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila cuyo índice se va a recuperar.</param>
			/// <returns>
			/// Índice de base cero de la primera aparición de la fila con el nombre especificado,
			/// si se encuentra; de lo contrario, -1.
			/// </returns>
			public int IndexOfKey(string key)
			{
				for (int i = 0; i < List.Count; i++)
					if (this[i].Name.Equals(key))
						return i;

				return -1;
			}

			/// <summary>
			/// Inserta una sección existente en la colección, en el índice
			/// especificado.
			/// </summary>
			/// <param name="index">Posición de índice de base cero donde se inserta la fila.</param>
			/// <param name="section">Objeto <see cref="UITableRow"/> que se va a insertar en la colección.</param>
			public void Insert(int index, UITableRow section)
			{
				List.Insert(index, section);
			}

			/// <summary>
			/// Quita la fila especificado de la colección.
			/// </summary>
			/// <param name="section">
			/// <see cref="UITableRow"/> que representa la fila
			/// que se va a quitar de la colección.
			/// </param>
			public void Remove(UITableRow section)
			{
				List.Remove(section);
			}

			/// <summary>
			/// Quita de la colección la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a quitar de la colección.</param>
			public void RemoveByKey(string key)
			{
				UITableRow obj = this[key];

				if (obj != null)
					Remove(obj);
			}

			/// <summary>
			/// Determina si la fila especificado se encuentra en la colección.
			/// </summary>
			/// <param name="section">
			/// <see cref="UITableRow"/> que representa la fila 
			/// que se va a buscar en la colección.
			/// </param>
			/// <returns>
			/// true si la colección contiene la fila; en caso contrario, false.
			/// </returns>
			public bool Contains(UITableRow section)
			{
				return (List.Contains(section));
			}

			/// <summary>
			/// Determina si una seccón con la clave especificada está incluida en la colección.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a buscar.</param>
			/// <returns>
			/// true si la fila con el nombre especificado está incluida en la colección;
			/// en caso contrario, false.
			/// </returns>
			public bool ContainsKey(string key)
			{
				return (this[key] != null);
			}

			#endregion
		}

		/// <summary>
		/// Representa la colección de secciones que definen la cabecera, cuerpo y pie de un objeto <see cref="UITable"/>.
		/// </summary>
		[Serializable]
		public class UITableSectionCollection : CollectionBase
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly UITable Owner;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene la sección en el índice especificado de la colección.
			/// </summary>
			/// <param name="index">Índice de la sección que se va a recuperar de la colección.</param>
			/// <returns>
			/// <see cref="UITableSection"/> que representa la sección
			/// ubicada en el índice especificado de la colección
			/// </returns>
			public UITableSection this[int index]
			{
				get { return ((UITableSection)List[index]); }
			}

			/// <summary>
			/// Obtiene de la colección la sección con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la sección que se va a recuperar de la colección.</param>
			/// <returns>Objeto <see cref="UITableSection"/> con la clave especificada.</returns>
			public UITableSection this[string key]
			{
				get
				{
					foreach (UITableSection obj in List)
						if (obj.Name.Equals(key))
							return obj;

					return null;
				}
			}

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableSectionCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="UITable"/> que posee esta colección.</param>
			public UITableSectionCollection(UITable owner)
			{
				this.Owner = owner;
			}

			#endregion

			#region Public Methods

			/// <summary>
			/// Agrega un objeto <see cref="UITableSection"/> existente a la colección.
			/// </summary>
			/// <param name="name"> Nombre de la sección.</param>
			/// <param name="caption">Título de sección.</param>
			/// <param name="detail">Detalle de sección.</param>
			/// <param name="settings">Estilo visual de la sección.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(string name, string caption, string detail, UITableSection.UISettings settings)
			{
				if (ContainsKey(name))
					throw new ArgumentException("Ya existe una sección con igual nombre.", "name");

				return (List.Add(new UITableSection(name, caption, detail, settings)));
			}

			/// <summary>
			/// Devuelve el índice de la sección especificada incluida en la colección.
			/// </summary>
			/// <param name="section"><see cref="UITableSection"/> que representa la sección que se va a buscar en la colección.</param>
			/// <returns>
			/// Índice de base cero de la ubicación de la sección en la colección.
			/// Si la sección no se encuentra en la colección, el valor devuelto
			/// es -1.
			/// </returns>
			public int IndexOf(UITableSection section)
			{
				return (List.IndexOf(section));
			}

			/// <summary>
			/// Determina el índice de la sección con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la sección cuyo índice se va a recuperar.</param>
			/// <returns>
			/// Índice de base cero de la primera aparición de la sección con el nombre especificado,
			/// si se encuentra; de lo contrario, -1.
			/// </returns>
			public int IndexOfKey(string key)
			{
				for (int i = 0; i < List.Count; i++)
					if (this[i].Name.Equals(key))
						return i;

				return -1;
			}

			/// <summary>
			/// Inserta una sección existente en la colección, en el índice
			/// especificado.
			/// </summary>
			/// <param name="index">Posición de índice de base cero donde se inserta la sección.</param>
			/// <param name="section">Objeto <see cref="UITableSection"/> que se va a insertar en la colección.</param>
			public void Insert(int index, UITableSection section)
			{
				List.Insert(index, section);
			}

			/// <summary>
			/// Quita la sección especificado de la colección.
			/// </summary>
			/// <param name="section">
			/// <see cref="UITableSection"/> que representa la sección
			/// que se va a quitar de la colección.
			/// </param>
			public void Remove(UITableSection section)
			{
				List.Remove(section);				
			}

			/// <summary>
			/// Quita de la colección la sección con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la sección que se va a quitar de la colección.</param>
			public void RemoveByKey(string key)
			{
				UITableSection obj = this[key];

				if (obj != null)
					Remove(obj);
			}

			/// <summary>
			/// Determina si la sección especificado se encuentra en la colección.
			/// </summary>
			/// <param name="section">
			/// <see cref="UITableSection"/> que representa la sección 
			/// que se va a buscar en la colección.
			/// </param>
			/// <returns>
			/// true si la colección contiene la sección; en caso contrario, false.
			/// </returns>
			public bool Contains(UITableSection section)
			{
				return (List.Contains(section));
			}

			/// <summary>
			/// Determina si una seccón con la clave especificada está incluida en la colección.
			/// </summary>
			/// <param name="key">Nombre de la sección que se va a buscar.</param>
			/// <returns>
			/// true si la sección con el nombre especificado está incluida en la colección;
			/// en caso contrario, false.
			/// </returns>
			public bool ContainsKey(string key)
			{
				return (this[key] != null);
			}

			#endregion
		}

		#endregion
	}
}