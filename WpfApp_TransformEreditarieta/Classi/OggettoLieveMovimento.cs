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


        public OggettoLieveMovimento(Uri source, Canvas background, double x, double y) : this(source, background, x, y, 100) { }
        
        public OggettoLieveMovimento(Uri source, Canvas background, double x, double y, double width) : base(source, background, x, y, width)
        {
            _startX = x;
            Destra = true;
        }

        public override void Step()
        {
            if (X >= _startX + 10)
                Destra = false;
            else if (X <= _startX - 10)
                Destra = true;

            if (_destra)
                X += 0.6;
            else
                X -= 0.6;
        }

        private protected bool Destra 
        { 
            get => _destra;
            set
            {
                _destra = value;

                RenderizzaModifiche(
                        new ScaleTransform(value ? -1 : 1, 1)
                    );
            }

        }


    }
}
