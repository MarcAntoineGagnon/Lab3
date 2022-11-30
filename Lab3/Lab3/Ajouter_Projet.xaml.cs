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
            tbDebut.SelectedDate = DateTime.Now;
        }
        
 
        private void btAjout_Clicke(object sender, RoutedEventArgs e)
        {
            string num = tbNumero.Text;
            Int32.TryParse(tbNumero.Text, out int numero);

            string date = tbDebut.SelectedDate.Value.ToString("MM/dd/yyyy").Trim();

            string budget = tbBudget.Text;
            int iBudget = 0;
            Int32.TryParse(tbBudget.Text, out iBudget);

            string description = tbDescription.Text;

            string matricule;
            if (cbEmploye.SelectedIndex != -1)
            {
                Employe emp = cbEmploye.SelectedItem as Employe;
                matricule = emp.Matricule;
            }
            else
                matricule = "";

            int erreur = 0;
            
            if (num.Trim() == "" || numero == 0 )
            {
                erreur++;
                tblErreurNumero.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurNumero.Visibility = Visibility.Collapsed;

            }

            if (date.Trim() == "")
            {
                erreur++;
                tblErreurDebut.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurDebut.Visibility = Visibility.Collapsed;
            }

            if(iBudget == 0 || iBudget < 10000 || iBudget > 100000 || budget.Trim() == "")            
            {
                erreur++;
                tblErreurBudget.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurBudget.Visibility = Visibility.Collapsed;
            }
            

            if (description.Trim() == "")
            {
                erreur++;
                tblErreurDescription.Visibility = Visibility.Visible;
            }
            else
            {
                erreur++;
                tblErreurDescription.Visibility = Visibility.Collapsed;
            }

            if (matricule.Trim() == "")
            {
                erreur++;
                tblErreurEmploye.Visibility = Visibility.Visible;
            }
            else
            {
                erreur++;
                tblErreurEmploye.Visibility = Visibility.Collapsed;
            }
            
            if(erreur == 0)
            {
                GestionBD.getInstance().ajouterProjet(new Projet(num, tbDebut.Date.Date, iBudget, description, matricule));
                this.Frame.Navigate(typeof(Afficher_projet));
            }

        }
    }
}

