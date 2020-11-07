#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
#endregion

namespace CSharpDex.Data
{
    /// <summary>
    /// Stores information on a single Pokemon after querying the database.
    /// </summary>
    public class Pokemon
    {
        // Private members.
        #region Public Members
        public string Number { get; set; }
        public string Name { get; set; }
        public string PrimaryType { get; set; }
        public string SecondaryType { get; set; }
        public int BaseHp { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseSpd { get; set; }
        public int BaseSpAtk { get; set; }
        public int BaseSpDef { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
        #endregion

        /// Constructors.
        public Pokemon()
        {

        }

        /// Public methods.
        public bool Complete()
        {
            // Check for null values only SecondaryType is allowed to be null.
            if (Number == null) return false;
            if (Name == null) return false;
            if (PrimaryType == null) return false;
            if (BaseHp == 0) return false;
            if (BaseAtk == 0) return false;
            if (BaseDef == 0) return false;
            if (BaseSpd == 0) return false;
            if (BaseSpAtk == 0) return false;
            if (BaseSpDef == 0) return false;
            if (Height == null) return false;
            if (Weight == null) return false;
            if (Species == null) return false;
            if (Description == null) return false;

            return true;
        }
    }
}
