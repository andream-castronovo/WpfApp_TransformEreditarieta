using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace WpfApp_Transform
{
    class OggettoBase
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
            background.Children.Add(_img);
        }

        public virtual void Step()
        {
            // Animazione per lo step successivo
            // Essendo questo tipo di oggetto statico non deve fare nulla

            // Lo step deve essere breve per consentire fluidità nel movimento
        }
    }
}
