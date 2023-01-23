using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp_TransformEreditarieta.Classi
{
    class OggettoMovimentoOrizzontale : OggettoLieveMovimento
    {
        // La classe deve permettere un movimento per tutto lo schermo avanti e indietro

        Canvas _schermo; // Per non uscire dallo schermo

        public OggettoMovimentoOrizzontale(Uri source, Canvas background, double x, double y) : this(source, background, x, y, 100) { }

        public OggettoMovimentoOrizzontale (Uri source, Canvas background, double x, double y, double width) : base (source, background, x, y, width)
        {
            _schermo = background;
        }

        public override void Step()
        {
            if (X > _schermo.ActualWidth)
                Destra = false;
            else if (X < 0)
                Destra = true;

            if (Destra)
                X += 2;
            else
                X -= 2;
        }
    }
}
