using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp_TransformEreditarieta.Enum;

namespace WpfApp_TransformEreditarieta.Classi
{
    class OggettoLieveMovimento : OggettoBase
    {
        double _start;
        bool _destra;
        bool _basso;

        const double _maxX = 30;
        const double _maxY = 30;

        const double _deltaX = 0.6;
        const double _deltaY = 0.6;


        public OggettoLieveMovimento(Uri source, Canvas background, double x, double y) : this(source, background, x, y, 100, Orientamento.Orizzontale) { }
        
        public OggettoLieveMovimento(Uri source, Canvas background, double x, double y, double width, Orientamento o) : base(source, background, x, y, width)
        {
            if (o == Orientamento.Orizzontale)
                _start = x;
            else
                _start = y;
            
            Destra = false;
            Basso = true;

            Orientamento = o;
            Schermo = background;

        }

        public override void Step()
        {
            if (Orientamento == Orientamento.Orizzontale)
            {
                if (
                    X > _start + _maxX + Width // Non andare oltre il limite
                    ||
                    X > Schermo.ActualWidth // E neanche oltre il bordo dello schermo
                    )
                    Destra = false;
                else if (
                    X < _start - _maxX // Stessa cosa
                    ||
                    X < 0
                    )
                    Destra = true;

                if (_destra) // Se devi andare a destra aggiungi, altrimenti sottrai
                    X += _deltaX;
                else
                    X -= _deltaX;
            }
            else
            {
                if (
                    Y > _start + _maxY // Stesso ragionamento di prima
                    ||
                    Y > Schermo.ActualHeight
                    )
                    Basso = false;
                else if (
                    Y < _start - _maxY
                    ||
                    Y < 0
                    )
                    Basso = true;

                if (_basso)
                    Y += _deltaY;
                else
                    Y -= _deltaY;

            }

        }

        private protected bool Destra 
        { 
            get => _destra;
            set
            {
                _destra = value;

                // Renderizzo il cambio di scala per far specchiare lo sprite
                RenderizzaModifiche(
                        new ScaleTransform(value ? -1 : 1, 1)
                    );

                // Per far specchiare lo sprite sul suo asse
                X += value ? Width : -Width;

            }

        }

        public Orientamento Orientamento { get; set; }

        private protected bool Basso
        {
            get => _basso;
            set => _basso = value;
            // Qui non serve nessun codice nel set perché non cambio sprite
            // quando cambia direzione verticale
        }

        private protected Canvas Schermo { get; set; }

    }

}
