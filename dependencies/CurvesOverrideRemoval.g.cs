using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Elements20Sample
{
	/// <summary>
	/// Override metadata for CurvesOverrideRemoval
	/// </summary>
	public partial class CurvesOverrideRemoval : IOverride
	{
        public static string Name = "Curves Removal";
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