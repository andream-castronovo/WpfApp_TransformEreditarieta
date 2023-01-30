using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using WpfApp_TransformEreditarieta.Enum;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp_TransformEreditarieta.Classi
{
    class OggettoMovimentoBordi : OggettoLieveMovimento
    {
        // La classe deve permettere un movimento per tutto lo schermo avanti e indietro

        public OggettoMovimentoBordi(Uri source, Canvas background, double x, double y) : this(source, background, x, y, 100, Orientamento.Orizzontale) { }

        public OggettoMovimentoBordi(Uri source, Canvas background, double x, double y, double width, Orientamento o) : base(source, background, x, y, width, o) { }

        public override void Step()
        {

            if (Orientamento == Orientamento.Orizzontale)
            {
                if (X > Schermo.ActualWidth)
                    Destra = false;
                else if (X < 0)
                    Destra = true;

                if (Destra)
                    X += 2;
                else
                    X -= 2;
            }
            else
            {
                if (Y > Schermo.ActualHeight - Height)
                    Basso = false;
                else if (Y < 0)
                    Basso = true;

                if (Basso)
                    Y += 2;
                else
                    Y -= 2;
            }
        }
    }
}
