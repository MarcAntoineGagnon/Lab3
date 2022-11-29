using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Lab3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public sealed partial class MainWindow : Window
    {
        private static ObservableCollection<Employe> employe = GestionBD.getInstance().getEmploye();


        //internal static ObservableCollection<Employe> Liste = new ObservableCollection<Employe>()
        //{ };
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(Afficher_projet));
            mainFrame.Navigate(typeof(AfficherEmploye));
            mainFrame.Navigate(typeof(Afficher_Recherche));

        }

        private void autoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

            autoSuggestBox.ItemsSource = GestionBD.getInstance().getEmployeRecherche(autoSuggestBox.Text);

        }

        private void autoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Employe emp = args.SelectedItem as Employe;
            mainFrame.Navigate(typeof(AjouterEmploye), emp);
        }

        private void mAjouter_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(AjouterEmploye));

        }

        private void mAjouter_projet_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Ajouter_Projet));

        }

        private void mListe_projet_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Afficher_projet));

        }

        private void mAcceuil_Click_1(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoBack)
            {
                mainFrame.GoBack();
            }
        }

        private void mListe_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(AfficherEmploye));
        }

        private void mRecherche_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Afficher_Recherche));
        }

        private void mAcceuil_Click()
        {

        }
    }
}
