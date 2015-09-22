using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudokuWeb.Controllers
{
    public class SudokuController : Controller
    {
        Sudoku.Controller gameController;
        Models.Game model;
        //
        // GET: /Sudoku/

        public SudokuController()
        {
            if (Session["sudoku van bert"] == null)
            {
                // maak sudokucontroller aan en wijs toe aan sessie
                // Session["sudoku van bert"] = new SudoukController();
            }
            // gameController = (..)Session["sudoku van bert"];

            gameController = Models.SudokuSingleton.GetController().controller;
            model = new Models.Game(gameController.FieldSize, gameController);
            initField();
        }

        public void initField()
        {
            short[,] field = new short[gameController.FieldSize, gameController.FieldSize];

            for (int i = 0; i < gameController.FieldSize; i++)
            {
                for (int j = 0; j < gameController.FieldSize; j++)
                {
                    field[i, j] = (short)gameController.GetSquare(i, j);
                }
            }

            model.initField(field);
        }

        public ActionResult SaveGame()
        {
            gameController.SaveGame();

            return RedirectToAction("Game");
        }

        public ActionResult LoadGame()
        {
            gameController.LoadGame();
            initField();

            return RedirectToAction("Game");
        }

        public ActionResult NewGame()
        {
            gameController.NewGame();
            initField();

            return RedirectToAction("Game");
        }

        [HttpPost]
        public ActionResult Verify(List<string> IntField)
        {
            //Waarom komt ie niet in de for-loop? Omdat ListField leeg is.
            //Waarom kan Henk geen auto rijden? Henk is een steen.
            for (int i = 0; i < IntField.Count; i++)
            {
                int Getal;

                if (!model.ListField[i].Validated && Int32.TryParse(IntField[i], out Getal) && Getal > 0)
                {
                    if (gameController.Verify(i/9, i%9, Getal))
                    {
                        model.IntField[i] = IntField[i];
                        model.ListField[i].Value = IntField[i];
                        model.ListField[i].Validated = true;
                    }
                }
            }

            return RedirectToAction("Game");
        }

        public ActionResult Hint()
        {
            short x;
            short y;
            short value;

            gameController.GiveHint(out x, out y, out value);

            return RedirectToAction("Game");
        }

        public ActionResult Cheat()
        {
            gameController.Cheat();

            return RedirectToAction("Game");
        }

        public ActionResult Game()
        {

            return View(model);
        }

    }
}
