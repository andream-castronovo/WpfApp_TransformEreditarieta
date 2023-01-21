using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp_TransformEreditarieta.Enum;

namespace WpfApp_TransformEreditarieta.Classi
{
    class OggettoLieveMovimento : OggettoBase
    {
        double _startX;
        bool _destra;

        public OggettoLieveMovimento(Uri source, Canvas background, double x, double y) : base(source, background, x, y)
        {
            _startX = x;
            _destra = true;
        }

        public override void Step()
        {
            if (X >= _startX + 10)
                _destra = false;
            else if (X <= _startX - 10)
                _destra = true;

            TranslateTransform tt = new TranslateTransform(_destra ? X += 0.6 : X -= 0.6, 0);
            RenderizzaModifiche(tt);

        }
    }
}
