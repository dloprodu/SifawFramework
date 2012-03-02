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
		private string _caption = string.Empty;
		
		private UITableSectionCollection _header;
		private UITableSectionCollection _body;
        private UITableSectionCollection _footer;

		// Agrupacíón semántica de columnas para aplicar estilos comunes
		//private UITableCellCollection _colGroup;

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
		/// Obtiene el título de la tabla.
		/// </summary>
		public string Caption
		{
			get { return _caption; }
			set { _caption = value; }
		}

		/// <summary>
		/// Obtiene la cabecera de la tabla.
		/// </summary>
		public UITableSectionCollection Header
        {
            get
            {
                if (_header == null)
					_header = new UITableSectionCollection(this);

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
		public UITableSectionCollection Footer
        {
            get
            {
                if (_footer == null)
					_footer = new UITableSectionCollection(this);

                return _footer;
            }
        }

        #endregion

        #region Constructros

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITable"/>, estableciendo un valor
		/// en la propiedad <see cref="Name"/>.
		/// </summary>
		/// <param name="name">Nombre de la tabla.</param>
        public UITable(string name)
		{
			this._name = name;
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
			return Name.GetHashCode();
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
			/// <param name="section"> Objeto <see cref="UITableSection"/> que se va a agregar a la colección.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(UITableSection section)
			{
				return (List.Add(section));
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
