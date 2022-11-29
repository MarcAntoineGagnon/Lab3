// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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
    public sealed partial class Ajouter_Projet : Page
    {
        public Ajouter_Projet()
        {
            this.InitializeComponent();
            cbEmploye.ItemsSource = GestionBD.getInstance().getEmploye();
        }
        
 
        private void btAjout_Clicke(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(tbNumero.Text, out int numero);
            if (tbNumero.Text.Trim() == "" && numero != 0 )
            {
                tblErreurNumero.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurNumero.Visibility = Visibility.Collapsed;

            }

            if (tbDebut.SelectedDate.Value.ToString("MM/dd/yyyy").Trim() == "")
            {
                tblErreurDebut.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurDebut.Visibility = Visibility.Collapsed;
            }
            int Budget = 0;
            Int32.TryParse(tbBudget.Text, out  Budget);
            if(Budget > 10000 && Budget < 100000 && tbBudget.Text.Trim() == "")            
            {
                tblErreurBudget.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurBudget.Visibility = Visibility.Collapsed;
            }
            

            if (tbDescription.Text.Trim() == "")
            {
                tblErreurDescription.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurDescription.Visibility = Visibility.Collapsed;
            }
            Employe emp = cbEmploye.SelectedItem as Employe;
            if (emp.Matricule == "")
            {
                tblErreurEmploye.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurEmploye.Visibility = Visibility.Collapsed;
            }
            
            GestionBD.getInstance().ajouterProjet(new Projet(tbNumero.Text, tbDebut.Date.Date, Budget, tbDescription.Text, emp.Matricule));
            this.Frame.Navigate(typeof(Afficher_projet));
        }
    }
}

