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
    public sealed partial class AjouterEmploye : Page
    {
        public AjouterEmploye()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Employe employe = (Employe)e.Parameter;
                tbMatricule.Text = employe.Matricule;
                tbNom.Text = employe.Nom;
                tbPrenom.Text = employe.Prenom;
            }
        }

        private void btAjout_Click(object sender, RoutedEventArgs e)
        {
            int erreur = 0;

            if (tbMatricule.Text.Trim() == "")
            {
                erreur++;
                tblErreurMatricule.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurMatricule.Visibility = Visibility.Collapsed;

            }

            if (tbNom.Text.Trim() == "")
            {
                erreur++;
                tblErreurNom.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurNom.Visibility = Visibility.Collapsed;
            }

            if (tbPrenom.Text.Trim() == "")
            {
                erreur++;
                tblErreurPrenom.Visibility = Visibility.Visible;
            }
            else
            {
                tblErreurPrenom.Visibility = Visibility.Collapsed;
            }
            if(erreur ==0)
            {
                GestionBD.getInstance().ajouterEmploye(new Employe(tbMatricule.Text, tbNom.Text, tbPrenom.Text));
                this.Frame.Navigate(typeof(AfficherEmploye));
            }
            else
            {
                erreur = 0;
            }

        }
    }
}
