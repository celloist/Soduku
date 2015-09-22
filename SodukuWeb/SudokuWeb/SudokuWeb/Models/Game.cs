using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SudokuWeb.Models
{
    public class Game
    {
        //private TextBox[,] field;
        private int fieldSize;
        private List<string> intField;
        private List<Models.Square> listField;
        public Sudoku.Controller game;

        public Game(int fieldSize, Sudoku.Controller game)
        {
            this.game = game;
            this.fieldSize = fieldSize;
            intField = new List<string>();
            //field = new TextBox[fieldSize, fieldSize];
            //intField = new short[fieldSize, fieldSize];
            listField = new List<Models.Square>();
        }

        public List<Models.Square> ListField { get { return listField; } set { listField = value; } }

        public List<string> IntField 
        { 
            get { return intField; } 
            set { intField = value; } 
        }

        public int FieldSize { get { return fieldSize; } set { fieldSize = value; } }

        public void initField(short[,] Field)
        {
            //this.intField = intField;
            listField = TranslateField(Field);
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (Field[i, j] > 0)
                        IntField.Add(Field[i, j].ToString());
                    else
                        IntField.Add("");
                }
            }
        }

        public List<Models.Square> TranslateField(short[,] Field)
        {
            List<Models.Square> lijst = new List<Models.Square>();

            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    lijst.Add(new Models.Square(Field[i, j]));
                }
            }

            return lijst;
        }
    }
}