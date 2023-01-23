using System;
using System.Collections.Generic;
using System.Configuration;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;
using WpfApp_TransformEreditarieta.Classi;

namespace WpfApp_TransformEreditarieta
{
    // Programmato da Andrea Maria Castronovo - 4I - Data Inizio: 16/01/2023 - Data Consegna: ?

    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Obiettivo principale: Applicare ed utilizzare correttamente l'ereditarietà


        // Campi di classe

        DispatcherTimer _dt;
        List<OggettoBase> _sprites;

        #region Vecchie variabili
        //double gradi = 0.0;

        //double scalaX = 0.3;
        //double scalaY = 0.3;

        //const int deltaX = 2;
        //const int deltaY = 2;

        //const double deltaScaleX = 0.01;
        //const double deltaScaleY = 0.01;
        #endregion

        // Costruttore
        public MainWindow()
        {
            InitializeComponent();
        }

        // Eventi
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AggiungiOggetti();
            SetupTimer();
        }

        void SetupTimer()
        {
            _dt = new DispatcherTimer();
            _dt.Interval = TimeSpan.FromMilliseconds(1);
            _dt.Tick += new EventHandler(DispatcherTimer_Tick);
            _dt.Start();
        }


        /// <summary>
        /// Aggiungi gli oggetti allo schermo
        /// </summary>
        private void AggiungiOggetti()
        {
            _sprites = new List<OggettoBase>
            { // Equivalente a _sprites.Add(...);
                new OggettoLieveMovimento(
                    new Uri (
                        "/Immagini/bug.png", UriKind.RelativeOrAbsolute
                    ), 
                    cnvForesta,
                    0,
                    0,
                    100
                ),
                new OggettoMovimentoOrizzontale(
                    new Uri("/Immagini/fox.png", UriKind.RelativeOrAbsolute),
                    cnvForesta,
                    0,
                    120,
                    160
                    )
            };
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (OggettoBase sprite in _sprites)
            {
                sprite.Step();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }
        

        #region Vecchia roba
        //void DispatcherTimer_Tick(object sender, EventArgs e)
        //{


        //    // Translate
        //    if (btnTranslateUp.IsPressed)
        //        y -= deltaY;

        //    else if (btnTranslateDown.IsPressed)
        //        y += deltaY;

        //    else if (btnTranslateLeft.IsPressed)
        //    {
        //        x -= deltaX;
        //        destra = false;
        //    }
        //    else if (btnTranslateRight.IsPressed)
        //    {
        //        x += deltaX;
        //        destra = true;
        //    }

        //    // Scale
        //    else if (btnScaleUp.IsPressed)
        //    {
        //        scalaY += deltaScaleY;
        //        scalaX += deltaScaleX;

        //    }
        //    else if (btnScaleDown.IsPressed)
        //    {
        //        scalaY -= deltaScaleY;
        //        scalaX -= deltaScaleX;
        //    }

        //    // Rotate

        //    else if(btnRotateLeft.IsPressed)
        //        gradi -= 1;
        //    else if (btnRotateRight.IsPressed)
        //        gradi += 1;

        //    Aggiorna(image);
        //}



        ///// <summary>
        ///// Aggiornamento dello schermo
        ///// </summary>
        ///// <param name="toRender">Immagine da aggiornare</param>
        //void Aggiorna(Image toRender)
        //{
        //    TransformGroup transformGroup = new TransformGroup();

        //    // CONDIZIONE ? IF_TRUE : IF_FALSE

        //    transformGroup.Children.Add(
        //        new ScaleTransform(
        //            destra ? -scalaX : scalaX, // -scalaX se destra è true in modo da girare lo sprite
        //            scalaY,
        //            x,
        //            y
        //            )
        //        );
        //    transformGroup.Children.Add(
        //        new TranslateTransform(
        //            destra ? x + image.Width * scalaX : x, // Se destra è true, essendo girato sull'asse delle X l'origine si troverà
        //                                                   // a destra e non a sinistra, per cui bisogna aggiungere la Width definita
        //                                                   // alla creazione dell'immagine, moltiplicata per la scala.
        //            y
        //            )
        //        );
        //    transformGroup.Children.Add(
        //        new RotateTransform(
        //            gradi,
        //            destra ? x + (scalaX * image.Width) / 2 : x + (scalaX * image.Width) / 2, // Per ruotare nel centro dell'immagine. Prendo la metà della Width dell'immagine moltiplicata per la scala
        //                                                                                      // e la aggiungo alla X
        //            y + (scalaY * image.Height) / 2
        //            )
        //        );

        //    // Per debug
        //    Console.WriteLine($"Scala: {(destra ? -scalaX : scalaX)}, {scalaY} Coordinate: {(destra ? x + scalaX : x)}, {y} Rotazione: {gradi}° intorno a {x + scalaX / 2}, {y + scalaY / 2}");

        //    // Aggiungo le modifiche effettivamente all'immagine
        //    toRender.RenderTransform = transformGroup;

        //}

        //private void btnReset_Click(object sender, RoutedEventArgs e)
        //{
        //    x = 0;
        //    y = 0;
        //    gradi = 0;
        //    scalaX = 0.3;
        //    scalaY = 0.3;
        //    destra = false;

        //    Aggiorna(image);
        //}
        #endregion
    }
}
