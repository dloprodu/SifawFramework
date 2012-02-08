///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Clase para la gestión de las reglas rotas.
/// 
/// Diseñador:   David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 16/12/2011 : Creación de la clase a partir del framework original
///                     
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections;
using System.Text;


namespace Sifaw.Core
{
	/// <summary>
	/// Tracks the business rules broken within a business object.
	/// </summary>
	[Serializable()]
	public class BrokenRules
	{
		#region Mis

		#region Rule structure

		/// <summary>
		/// Stores details about a specific broken business rule.
		/// </summary>
		[Serializable()]
		public struct Rule : IEquatable<Rule>
		{
			#region Variables

			string _name;
			string _description;
			RuleSeverity _severity;

			#endregion

			#region Propiedades

			/// <summary>
			/// Provides access to the name of the broken rule.
			/// </summary>
			/// <remarks>
			/// This value is actually readonly, not readwrite. Any new
			/// value set into this property is ignored. The property is only
			/// readwrite because that is required to support data binding
			/// within Web Forms.
			/// </remarks>
			/// <value>The name of the rule.</value>
			public string Name
			{
				get { return _name; }
				set
				{
					// the property must be read-write for Web Forms data binding
					// to work, but we really don't want to allow the value to be
					// changed dynamically so we ignore any attempt to set it
				}
			}

			/// <summary>
			/// Provides access to the description of the broken rule.
			/// </summary>
			/// <remarks>
			/// This value is actually readonly, not readwrite. Any new
			/// value set into this property is ignored. The property is only
			/// readwrite because that is required to support data binding
			/// within Web Forms.
			/// </remarks>
			/// <value>The description of the rule.</value>
			public string Description
			{
				get { return _description; }
				set
				{
					// the property must be read-write for Web Forms data binding
					// to work, but we really don't want to allow the value to be
					// changed dynamically so we ignore any attempt to set it
				}
			}

			/// <summary>
			/// Provides access to the severity level of the broken rule.
			/// </summary>
			/// <remarks>
			/// </remarks>
			/// <value>The severity level of the rule.</value>
			public RuleSeverity Severity
			{
				get { return _severity; }
				set
				{
					// the property must be read-write for Web Forms data binding
					// to work, but we really don't want to allow the value to be
					// changed dynamically so we ignore any attempt to set it
				}
			}

			#endregion

			#region Constructor

			internal Rule(string name, string description, RuleSeverity severity)
			{
				_name = name;
				_description = description;
				_severity = severity;
			}

			#endregion

			#region System.Object

			public override string ToString()
			{
				return Name;
			}

			public override bool Equals(object obj)
			{
				if (!(obj is Rule))
					return false;

				return Equals((Rule)obj);
			}

			public override int GetHashCode()
			{
				return Name.GetHashCode();
			}

			#endregion

			#region Miembros de IEquatable<Rule>

			public bool Equals(Rule other)
			{
				return Name.Equals(other.Name);
			}

			#endregion
		}

		#endregion

		#region RulesCollection

		/// <summary>
		/// A collection of currently broken rules.
		/// </summary>
		/// <remarks>
		/// This collection is readonly and can be safely made available
		/// to code outside the business object such as the UI. This allows
		/// external code, such as a UI, to display the list of broken rules
		/// to the user.
		/// </remarks>
		[Serializable()]
		public class RulesCollection : CollectionBase
		{
			#region Variables

			int _errorCount = 0;
			int _warningCount = 0;
			int _infoCount = 0;

			#endregion

			#region Propiedades

			/// <summary>
			/// Returns a <see cref="T:Sifaw.BrokenRules.Rule" /> object
			/// containing details about a specific broken business rule.
			/// </summary>
			public Rule this[int index]
			{
				get { return (Rule)List[index]; }
			}

			public int ErrorCount
			{
				get { return _errorCount; }
			}

			public int WarningCount
			{
				get { return _warningCount; }
			}

			public int InformationCount
			{
				get { return _infoCount; }
			}

			#endregion

			#region Contains

			public bool Contains(string name)
			{
				foreach (Rule rule in this)
					if (rule.Name.Equals(name))
						return true;

				return false;
			}

			#endregion

			#region Constructor

			internal RulesCollection()
			{
			}

			#endregion

			#region Métodos públicos / internos

			internal void Add(string name, string description, RuleSeverity severity)
			{			
				Remove(name);
				Rule rule = new Rule(name, description, severity);
				IncrementCount(rule);
				List.Add(rule);
			}

			internal void Remove(string name)
			{
				for (int index = 0; index < List.Count; index++)
				{
					if (((Rule)List[index]).Name == name)
					{
						DecrementCount((Rule)List[index]);
						List.Remove(List[index]);
						break;
					}
				}
			}
			
			public int IndexOf(string name)
			{
				for (int index = 0; index < List.Count; index++)
					if (((Rule)List[index]).Name == name)
						return index;

				return -1;
			}

			/// <summary>
			/// Returns the text of all broken rule descriptions, each
			/// separated by a <see cref="Environment.NewLine" />.
			/// </summary>
			/// <param name="severity">The severity of rules to
			/// include in the result.</param>
			/// <returns>The text of all broken rule descriptions
			/// matching the specified severtiy.</returns>
			public string ToString(RuleSeverity severity)
			{
				StringBuilder result = new StringBuilder();

				foreach (Rule item in this)
				{
					if (item.Severity == severity)
					{
						if (result.Length != 0)
							result.Append(Environment.NewLine);

						result.Append(item.Description);
					}
				}
				
				return result.ToString();
			}

			public string[] ToArray()
			{
				string[] description = new string[this.Count];

				for (int i = 0; i < this.Count; i++)
				{
					description[i] = this[i].Description;
				}

				return description;
			}

			public string[] ToArray(RuleSeverity severity)
			{
				string[] description = null;
				int count = 0;

				switch (severity)
				{
					case RuleSeverity.Error:
						count = this.ErrorCount;
						break;

					case RuleSeverity.Warning:
						count = this.WarningCount;
						break;

					case RuleSeverity.Information:
						count = this.InformationCount;
						break;
				}

				description = new string[count];
				count = 0;

				foreach (Rule rule in this)
				{
					if (rule.Severity == severity)
						description[count++] = rule.Description;
				}

				return description;
			}

			#endregion

			#region Métodos auxiliares

			private void IncrementCount(Rule rule)
			{
				switch (rule.Severity)
				{
					case RuleSeverity.Error:
						_errorCount++;
						break;

					case RuleSeverity.Warning:
						_warningCount++;
						break;

					case RuleSeverity.Information:
						_infoCount++;
						break;
				}
			}

			private void DecrementCount(Rule rule)
			{
				switch (rule.Severity)
				{
					case RuleSeverity.Error:
						_errorCount--;
						break;

					case RuleSeverity.Warning:
						_warningCount--;
						break;

					case RuleSeverity.Information:
						_infoCount--;
						break;
				}
			}

			#endregion

			#region System.Object

			/// <summary>
			/// Returns the text of all broken rule descriptions, each
			/// separated by cr/lf.
			/// </summary>
			/// <returns>The text of all broken rule descriptions.</returns>
			public override string ToString()
			{
				StringBuilder obj = new StringBuilder();

				foreach (Rule item in this)
				{
					if (obj.Length != 0)
						obj.Append(Environment.NewLine);
					
					obj.Append(item.Description);
				}

				return obj.ToString();
			}

			#endregion
		}

		#endregion

		#endregion

		#region Variables

		RulesCollection _rules = new RulesCollection();

		#endregion

		#region Propiedades

		/// <summary>
		/// Returns a value indicating whether there are any broken rules
		/// at this time. If there are broken rules, the business object
		/// is assumed to be invalid and False is returned. If there are no
		/// broken business rules True is returned.
		/// </summary>
		/// <returns>A value indicating whether any rules are broken.</returns>
		public bool IsValid
		{
			get { return (_rules.ErrorCount == 0); }
		}

		/// <summary>
		/// Returns a reference to the readonly collection of broken
		/// business rules.
		/// </summary>
		/// <remarks>
		/// The reference returned points to the actual collection object.
		/// This means that as rules are marked broken or unbroken over time,
		/// the underlying data will change. Because of this, the UI developer
		/// can bind a display directly to this collection to get a dynamic
		/// display of the broken rules at all times.
		/// </remarks>
		/// <returns>A reference to the collection of broken rules.</returns>
		public RulesCollection BrokenRulesCollection
		{
			get { return _rules; }
		}

		#endregion

		#region Métodos públicos

		/// <summary>
		/// This method is called by business logic within a business class to
		/// indicate whether a business rule is broken.
		/// </summary>
		/// <remarks>
		/// Rules are identified by their names. The description field is merely a 
		/// comment that is used for display to the end user. When a rule is marked as
		/// broken, it is recorded under the rule name value. To mark the rule as not
		/// broken, the same rule name must be used.
		/// </remarks>
		/// <param name="Rule">The name of the business rule.</param>
		/// <param name="Description">The description of the business rule.</param>
		/// <param name="IsBroken">True if the value is broken, False if it is not broken.</param>
		public void Assert(string name, string description, bool isBroken)
		{
			if (isBroken)
				_rules.Add(name, description, RuleSeverity.Error);
			else
				_rules.Remove(name);
		}

		/// <summary>
		/// This method is called by business logic within a business class to
		/// indicate whether a business rule is broken.
		/// </summary>
		/// <remarks>
		/// Rules are identified by their names. The description field is merely a 
		/// comment that is used for display to the end user. When a rule is marked as
		/// broken, it is recorded under the rule name value. To mark the rule as not
		/// broken, the same rule name must be used.
		/// </remarks>
		/// <param name="Rule">The name of the business rule.</param>
		/// <param name="Description">The description of the business rule.</param>
		/// <param name="IsBroken">True if the value is broken, False if it is not broken.</param>
		/// <param name="RuleSeverity">It specifies the severity level.</param>
		public void Assert(string name, string description, bool isBroken, RuleSeverity severity)
		{
			if (isBroken)
				_rules.Add(name, description, severity);
			else
				_rules.Remove(name);
		}

		/// <summary>
		/// Returns a value indicating whether a particular business rule
		/// is currently broken.
		/// </summary>
		/// <param name="Rule">The name of the rule to check.</param>
		/// <returns>A value indicating whether the rule is currently broken.</returns>
		public bool IsBroken(string name)
		{
			// Sólo se interpretarán como rotas aquellas reglas con gravedad tipo Error.
			int index = _rules.IndexOf(name);
			return ((index > -1) && (_rules[index].Severity == RuleSeverity.Error));
		}

		#endregion
	}

	#region Miscelanea

	/// <summary>
	/// Values for validation rule severities.
	/// </summary>
	public enum RuleSeverity
	{
		/// <summary>
		/// Represents a serious
		/// business rule violation that
		/// should cause an object to
		/// be considered invalid.
		/// </summary>
		Error,

		/// <summary>
		/// Represents a business rule
		/// violation that should be
		/// displayed to the user, but which
		/// should not make an object be
		/// invalid.
		/// </summary>
		Warning,

		/// <summary>
		/// Represents a business rule
		/// result that should be displayed
		/// to the user, but which is less
		/// severe than a warning.
		/// </summary>
		Information
	}

	#endregion
}