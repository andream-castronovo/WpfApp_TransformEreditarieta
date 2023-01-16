using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace WpfApp_TransformEreditarieta.Classi
{
    class OggettoLieveMovimento : OggettoBase
    {
        double _startX;
        double _startY;
        bool destra;

        public OggettoLieveMovimento(Uri source, Canvas background, double x, double y) : base (source, background, x, y)
        { 
            _startX = x;
            _startY = y;

            destra = true;
        }

        public override void Step()
        {
            if (X == _startX + 10)
                destra = false;
            else if (X == _startX - 10)
                destra = true;

            X = destra ? X++ : X--;
        }
    }
}
