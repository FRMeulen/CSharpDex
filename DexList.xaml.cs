#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSharpDex.Data;
#endregion

namespace CSharpDex
{
    /// <summary>
    /// Interaction logic for DexList.xaml
    /// </summary>
    public partial class DexList : Page
    {
        #region Private members
        private StackPanel pokeList;
        private List<DexEntry> entries;
        #endregion

        public DexList()
        {
            // Initialize and find list.
            InitializeComponent();
            pokeList = (StackPanel)FindName("PokeList");

            // Create entries list and dex connection.
            entries = new List<DexEntry>();

            // Populate list with Pokemon.
            PopulateEntries();
        }

        #region Private methods.
        private void PopulateEntries()
        {
            // Query all pokemon and create pokemon objects of them.
            DataTable allPokemon = DexConnector.Instance.Query("SELECT * FROM pokemon;", "pokemon");

            // Create Pokemon objects for every record.
            foreach (DataRow row in allPokemon.Rows)
            {
                // Create Pokemon object.
                Pokemon pokemon = new Pokemon();

                // Fill Pokemon members with data from columns.
                foreach (DataColumn col in allPokemon.Columns)
                {
                    // Switch fields to fill based on column name.
                    switch (col.ColumnName)
                    {
                        case "number":
                            pokemon.Number = row[col].ToString();
                            break;
                        case "name":
                            pokemon.Name = row[col].ToString();
                            break;
                        case "primary_type":
                            pokemon.PrimaryType = row[col].ToString();
                            break;
                        case "secondary_type":
                            pokemon.SecondaryType = row[col].ToString();
                            break;
                        case "base_hp":
                            pokemon.BaseHp = Int32.Parse(row[col].ToString());
                            break;
                        case "base_atk":
                            pokemon.BaseAtk = Int32.Parse(row[col].ToString());
                            break;
                        case "base_def":
                            pokemon.BaseDef = Int32.Parse(row[col].ToString());
                            break;
                        case "base_spd":
                            pokemon.BaseSpd = Int32.Parse(row[col].ToString());
                            break;
                        case "base_sp_atk":
                            pokemon.BaseSpAtk = Int32.Parse(row[col].ToString());
                            break;
                        case "base_sp_def":
                            pokemon.BaseSpDef = Int32.Parse(row[col].ToString());
                            break;
                        case "height":
                            pokemon.Height = row[col].ToString();
                            break;
                        case "weight":
                            pokemon.Weight = row[col].ToString();
                            break;
                        case "species":
                            pokemon.Species = row[col].ToString();
                            break;
                        case "description":
                            pokemon.Description = row[col].ToString();
                            break;
                    }
                }

                // Create dex entry based on source Pokemon.
                DexEntry entry = new DexEntry(pokemon);
                entry.Margin = new Thickness(5, 5, 5, 5);
                entries.Add(entry);
                pokeList.Children.Add(entry);
            }
        }
        #endregion
    }
}
