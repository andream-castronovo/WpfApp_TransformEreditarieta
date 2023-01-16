using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp_TransformEreditarieta.Enum;

namespace WpfApp_TransformEreditarieta.Classi
{
    public class OggettoBase
    {
        Image _img;
        double _x;
        double _y;

        Direzione d;
        

        public OggettoBase(Uri source, Canvas background, double x, double y) 
        {
            _x = x;
            _y = y;

            BitmapImage btm = new BitmapImage(source);

            _img = new Image();
            _img.Source = btm;
            _img.Margin = new Thickness(x, y, 0, 0);
            background.Children.Add(_img);

            d = Direzione.Destra;
        }

        public virtual void Step()
        {
            // Animazione per lo step successivo
            // Essendo questo tipo di oggetto statico non deve fare nulla

            // Lo step deve essere breve per consentire fluidità nel movimento
        }

        public void Renderizza(Canvas background)
        {
            TransformGroup transformGroup = new TransformGroup();

            // CONDIZIONE ? IF_TRUE : IF_FALSE
            bool destra = d == Direzione.Destra;

            transformGroup.Children.Add(
                new ScaleTransform(
                    destra ? -scalaX : scalaX, // -scalaX se destra è true in modo da girare lo sprite
                    scalaY,
                    x,
                    y
                    )
                );
            transformGroup.Children.Add(
                new TranslateTransform(
                    destra ? x + image.Width * scalaX : x, // Se destra è true, essendo girato sull'asse delle X l'origine si troverà
                                                           // a destra e non a sinistra, per cui bisogna aggiungere la Width definita
                                                           // alla creazione dell'immagine, moltiplicata per la scala.
                    y
                    )
                );
            transformGroup.Children.Add(
                new RotateTransform(
                    gradi,
                    destra ? x + (scalaX * image.Width) / 2 : x + (scalaX * image.Width) / 2, // Per ruotare nel centro dell'immagine. Prendo la metà della Width dell'immagine moltiplicata per la scala
                                                                                              // e la aggiungo alla X
                    y + (scalaY * image.Height) / 2
                    )
                );

            // Per debug
            Console.WriteLine($"Scala: {(destra ? -scalaX : scalaX)}, {scalaY} Coordinate: {(destra ? x + scalaX : x)}, {y} Rotazione: {gradi}° intorno a {x + scalaX / 2}, {y + scalaY / 2}");

            // Aggiungo le modifiche effettivamente all'immagine
            toRender.RenderTransform = transformGroup;
        }

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
    }
}
