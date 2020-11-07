#region Namespaces
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PokemonPage.xaml
    /// </summary>
    public partial class PokemonPage : Page
    {
        /// Private members.
        private Pokemon SourcePokemon;

        /// Constructors.
        public PokemonPage(Pokemon sourcePokemon)
        {
            InitializeComponent();
            SourcePokemon = sourcePokemon;
        }
    }
}
