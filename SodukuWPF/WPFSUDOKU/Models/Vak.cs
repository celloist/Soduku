using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFSUDOKU.Foundation;

namespace WPFSUDOKU.Models
{
    public class Vak : BasePropertyChanged
    {
        private int row;
        private int col;
        private int val;
        private String stringVal;
        private Point coord;
        private bool isBeginVak;

        public Vak(int r, int c, int v, bool s)
        {
            Row = r;
            Col = c;
            Val = v;
            IsBeginVak = s;
            
        }

        public bool IsBeginVak
        {
            get
            {
                return isBeginVak;
            }
            set
            {
                isBeginVak = value;
                RaisePropertyChanged(() => IsBeginVak);
            }
        }

        public Point Coord
        {
            get
            {
                return new Point(Col, Row);
            }
        }


        public String StringVal
        {
            get
            {
                return (val == 0) ? " " : val.ToString();
            }
            set
            {
                stringVal = value;
                RaisePropertyChanged(() => StringVal);
            }
        }

        public int Row 
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
                RaisePropertyChanged(() => Row);
            }
        }

        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                col = value;
                RaisePropertyChanged(() => Col);
            }
        }

        public int Val
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
                StringVal = val.ToString();
                RaisePropertyChanged(() => Val);
            }
        }
    }
}
