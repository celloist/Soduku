using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuWeb.Models
{
    public class Square
    {
        private int waarde;
        private bool validated;

        public Square(short waarde)
        {
            this.waarde = waarde;

            validated = waarde > 0;
        }

        public bool Validated 
        {
            get
            { return validated; }
            set
            { validated = value; }
        }

        public string Value
        {
            get 
            {
                if (waarde > 0)
                    return waarde.ToString();
                else
                    return "";
            }
            set
            {
                int temp;
                if (Int32.TryParse(value, out temp) && temp > 0 && temp < 10)
                    waarde = temp;
            }
        }
    }
}