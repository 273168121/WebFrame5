using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

using LinqToDB.DataProvider;

namespace LinqToDB.Configuration
{
	public sealed class DataProviderElement : ElementBase, IDataProviderSettings
	{
		static readonly ConfigurationProperty _propTypeName = new ConfigurationProperty("type",    typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
		static readonly ConfigurationProperty _propName     = new ConfigurationProperty("name",    typeof(string), string.Empty, ConfigurationPropertyOptions.None);
		static readonly ConfigurationProperty _propDefault  = new ConfigurationProperty("default", typeof(bool),   false,        ConfigurationPropertyOptions.None);

		public DataProviderElement()
		{
			Properties.Add(_propTypeName);
			Properties.Add(_propName);
			Properties.Add(_propDefault);
		}

		/// <summary>
		/// Gets or sets an assembly qualified type name of this data provider.
		/// </summary>
		public string TypeName
		{
			get { return (string)base[_propTypeName]; }
		}

		/// <summary>
		/// Gets or sets a name of this data provider.
		/// If not set, <see cref="DataProviderBase.Name"/> is used.
		/// </summary>
		public string Name
		{
			get { return (string)base[_propName]; }
		}

		/// <summary>
		/// Gets a value indicating whether the provider is default.
		/// </summary>
		public bool Default
		{
			get { return (bool)base[_propDefault]; }
		}

		IEnumerable<NamedValue> IDataProviderSettings.Attributes
		{
			get { return Attributes.AllKeys.Select(e => new NamedValue() {Name = e, Value = Attributes[e]}); }
		}
	}
}
