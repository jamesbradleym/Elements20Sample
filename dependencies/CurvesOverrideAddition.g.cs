using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Elements20Sample
{
	/// <summary>
	/// Override metadata for CurvesOverrideAddition
	/// </summary>
	public partial class CurvesOverrideAddition : IOverride
	{
        public static string Name = "Curves Addition";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.Curvework]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}

}