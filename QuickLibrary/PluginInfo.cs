﻿using Utf8Json;

namespace QuickLibrary
{
	public class PluginInfo
	{
		#region STRUCTS

		public struct Author
		{
			public string name;
			public string link;
		}

		public struct MultilangString
		{
			public string en;
			public string ru;
			public string es;

			public string Get(string langCode)
			{
				string value;
				switch (langCode)
				{
					case "ru":
						value = ru;
						break;
					case "es":
						value = es;
						break;
					default:
						value = en;
						break;
				}
				return value;
			}
		}

		public struct Function
		{
			public string name;
			public MultilangString title;
			public string type; // tool, effect
			public bool configurable;
			public bool inputRequired; // for type = tool
		}

		#endregion

		#region VARIABLES

		public string name;
		public string version;
		public string title;
		public MultilangString description;
		public string link;
		public Author[] authors;
		public int apiVer; // 2
		public string inputType; // bitmap
		public string dllType; // csharp, cpp
		public Function[] functions;

		#endregion

		#region STATIC METHODS

		public static PluginInfo FromJson(string json)
		{
			return JsonSerializer.Deserialize<PluginInfo>(json);
		}

		#endregion

		#region CONSTRUCTOR

		public PluginInfo()
		{

		}

		#endregion
	}
}
