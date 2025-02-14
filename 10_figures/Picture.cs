﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_rect
{
    [Serializable]
    public class Picture
    {
        private ArrayList al = new ArrayList();
        private MyFigure figure;
        public MyFigure Figure { get { return figure; } }

        public Picture()
        {
            figure = null;
        }
        public Picture(Control cntrl)
        {
            figure = null;
        }

        public void Draw(Graphics canvas) {
            foreach (IDrawableC d in al)
                d.Draw(canvas);
        }

        public void Add(MyFigure f)
        {
            al.Add(f);
            if(figure != null) {
                figure.Selected = false;
            }
            figure = f;
            figure.Selected = true;
        }

        public void Delete(MyFigure f) {
            if(al.Contains(f)) {
                if(f == figure) {
                    figure = null;
                }
                al.Remove(f);
            }
        }
        public void Clear()
        {
            al.Clear();
            figure = null;
        }

        public void Deselect() {
            if(figure != null) {
                figure.FixCoordinates();

                figure.Selected = false;
            }

            figure = null;
        }
        public MyFigure Select(int xx, int yy) {
            MyFigure ff = null;
            Deselect();

            foreach(MyFigure f in al) {
                if(f.Touch(xx, yy))
                    ff = f;
            }

            if(ff != null) {
                ff.Selected = true;
                figure = ff;
            }
            return ff;
        }

        public void GreenifyAll() {
            foreach (IDrawableC d in al)
                d.BColor = Color.Green;
        }
    }
}
