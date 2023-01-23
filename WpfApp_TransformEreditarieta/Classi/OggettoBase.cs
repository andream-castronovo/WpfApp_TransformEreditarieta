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
        TransformGroup _tg;
        

        public OggettoBase(Uri source, Canvas background, double x, double y) : this (source, background, x, y, 100) { }

        public OggettoBase(Uri source, Canvas background, double x, double y, double width)
        {
            _x = x;
            _y = y;

            BitmapImage btm = new BitmapImage(source);

            _img = new Image();
            _img.Source = btm;
            _img.Width = width;

            background.Children.Add(_img);

            _tg = new TransformGroup();

        }

        public virtual void Step()
        {
            // Animazione per lo step successivo
            // Essendo questo tipo di oggetto statico non deve fare nulla

            // Lo step deve essere breve per consentire fluidità nel movimento
        }

        public void RenderizzaModifiche(Transform t)
        {
            // Questo oggetto statico non deve renderizzare nessuna modifica

            if (t.GetType() != typeof(TransformGroup))
            {
                for (int i = 0; i < _tg.Children.Count; i++)
                {
                    if (_tg.Children[i].GetType() == t.GetType())
                    {
                        _tg.Children.RemoveAt(i);
                    }

                }
                _tg.Children.Add(t);
            }
            else
                _tg = t as TransformGroup;


            _img.RenderTransform = _tg;
        }

        public double X 
        { 
            get => _x;
            set
            {
                _x = value;
                RenderizzaModifiche(new TranslateTransform(value, Y));
            }
        }
        
        public double Y 
        { 
            get => _y;
            set
            {
                _y = value;
                RenderizzaModifiche(new TranslateTransform(X, value));
            }
        }

        public double Width
        {
            get => _img.ActualWidth;
        }

        public double Height
        {
            get => _img.ActualHeight;
        }

        public Transform RenderInfos
        {
            get => _img.RenderTransform;
        }
    }
}
