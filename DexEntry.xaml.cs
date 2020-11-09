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
    /// Interaction logic for DexEntry.xaml
    /// </summary>
    public partial class DexEntry : StackPanel
    {
        #region Private members
        // Source pokemon.
        private Pokemon SourcePokemon;

        // Dex entry components.
        private Image sprite;
        private Label pokeName;
        private Label pokeNumber;
        private Image primaryType;
        private Image secondaryType;
        #endregion

        public DexEntry(Pokemon pokemon)
        {
            // Initialize component and set source.
            InitializeComponent();
            SourcePokemon = pokemon;

            // Find components.
            sprite = (Image)FindName("Sprite");
            pokeName = (Label)FindName("PokeName");
            pokeNumber = (Label)FindName("PokeNumber");
            primaryType = (Image)FindName("PrimaryType");
            secondaryType = (Image)FindName("SecondaryType");

            // Initialize pokemon.
            InitializePokemon();
        }

        #region Private methods.
        private void InitializePokemon()
        {
            // Cancel if no source Pokemon exists.
            if (SourcePokemon == null) return;

            // Set info in components.
            sprite.Source = new BitmapImage(new Uri(@"C:\Users\falco\source\repos\CSharpDex\res\sprites\" + SourcePokemon.Name.ToLower() + ".png"));
            pokeName.Content = SourcePokemon.Name;
            pokeNumber.Content = SourcePokemon.Number;
            primaryType.Source = new BitmapImage(new Uri(@"C:\Users\falco\source\repos\CSharpDex\res\types\type_" + SourcePokemon.PrimaryType.ToLower() + ".png"));

            // Secondary type logic.
            if (SourcePokemon.SecondaryType != "")
            {
                secondaryType.Visibility = Visibility.Visible;
                secondaryType.Source = new BitmapImage(new Uri(@"C:\Users\falco\source\repos\CSharpDex\res\types\type_" + SourcePokemon.SecondaryType.ToLower() + ".png"));
            }

            else
            {
                secondaryType.Visibility = Visibility.Hidden;
            }
        }

        private void ShowPokemon(object sender, RoutedEventArgs args)
        {
            PokemonPage pokemonPage = new PokemonPage(SourcePokemon);
            Page currentPage = (Page)Application.Current.MainWindow.Content;
            currentPage.NavigationService.Navigate(pokemonPage);
        }
        #endregion
    }
}
