using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuWeb.Models
{
    public class SudokuSingleton
    {
        private Sudoku.Controller c;
        private static SudokuSingleton single;

        private SudokuSingleton()
        {
            c = new Sudoku.Controller();
        }

        public Sudoku.Controller controller
        {
            get { return c; }
        }

        public static SudokuSingleton GetController()
        {
            if (single == null)
                single = new SudokuSingleton();

            return single;
        }
    }
}