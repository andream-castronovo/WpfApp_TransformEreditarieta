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
        
        public OggettoBase(Uri source, Canvas background, double x, double y) 
        {
            _x = x;
            _y = y;

            BitmapImage btm = new BitmapImage(source);

            _img = new Image();
            _img.Source = btm;
            _img.Margin = new Thickness(x, y, 0, 0);

            _img.Width = 100;

            background.Children.Add(_img);
        }

        public virtual void Step()
        {
            // Animazione per lo step successivo
            // Essendo questo tipo di oggetto statico non deve fare nulla

            // Lo step deve essere breve per consentire fluidità nel movimento
        }

        public virtual void RenderizzaModifiche(Transform t)
        {
            // Questo oggetto statico non deve renderizzare nessuna modifica

            _img.RenderTransform = t;
        }

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
    }
}
