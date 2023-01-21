using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp_TransformEreditarieta.Classi
{
    class OggettoMovimentoOrizzontale : OggettoLieveMovimento
    {
        // La classe deve permettere un movimento per tutto lo schermo avanti e indietro

        Canvas _schermo;
        public OggettoMovimentoOrizzontale (Uri source, Canvas background, double x, double y) : base (source, background, x, y)
        {
            _schermo = background;
        }

        public override void Step()
        {
            // Cercare un modo per usare _destra qui
            //if (X > _schermo.Width)
                
        }
    }
}
