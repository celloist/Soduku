using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSUDOKU.Foundation;
using WPFSUDOKU.Models;

namespace WPFSUDOKU.ViewModel
{
    class SudokuViewModel : BasePropertyChanged
    {
        /// <summary>
        /// Sudoku game bord
        /// </summary>
        public Bord gameBord;
        public Bord GameBord
        {
            get
            {
                return gameBord;
            }
            set
            {
                if (value != gameBord)
                {
                    gameBord = value;
                    RaisePropertyChanged(() => GameBord);
                }
            }
        }

        /// <summary>
        /// INitialize the bord
        /// </summary>
        public SudokuViewModel()
        {
            GameBord = new Bord();
        }

        /// <summary>
        /// Start een nieuw spel
        /// </summary>
        /// <param name="parameter"></param>
        public void NewGame(object parameter = null)
        {
            Debug.WriteLine("Nieuw spel");

            GameBord.initialize();
            
        }

        /// <summary>
        /// Vul een vak
        /// </summary>
        /// <param name="v"></param>
        public void VulVak(Vak v)
        {
            v.Val = 5;
        }

        /// <summary>
        /// Laad een spel
        /// </summary>
        /// <param name="parameter"></param>
        public void LoadGame(object parameter = null)
        {
            Debug.WriteLine("Laad spel");

        }

        /// <summary>
        /// Sla spel op
        /// </summary>
        /// <param name="parameter"></param>
        public void SaveGame(object parameter = null)
        {
            Debug.WriteLine("Sla spel op");

        }

        /// <summary>
        /// Doe een cheat
        /// </summary>
        /// <param name="parameter"></param>
        public void Cheat(object parameter = null)
        {

        }

        /// <summary>
        /// Verifieer de zet
        /// </summary>
        /// <param name="paramter"></param>
        public void Verify(object paramter = null)
        {

        }

        /// <summary>
        /// Geef een hint
        /// </summary>
        /// <param name="parameter"></param>
        public void Hint(object parameter = null)
        {

        }



        #region commands

        private DelegateCommand<object> newGameCommand;
        private DelegateCommand<object> loadGameCommand;
        private DelegateCommand<object> saveGameCommand;
        private DelegateCommand<object> cheatCommand;
        private DelegateCommand<object> verifyCommand;
        private DelegateCommand<object> hintCommand;
        private DelegateCommand<Vak> vulVakCommand;

        public DelegateCommand<Vak> VulVakCommand
        {
            get
            {
                if (vulVakCommand == null)
                {
                    vulVakCommand = new DelegateCommand<Vak>(VulVak);
                }
                return vulVakCommand;
            }
        }
       

        public DelegateCommand<object> NewGameCommand
        {
            get
            {
                if (newGameCommand == null)
                {
                    newGameCommand = new DelegateCommand<object>(NewGame);
                }

                return newGameCommand;
            }
        }
        public DelegateCommand<object> LoadGameCommand
        {
            get
            {
                if (loadGameCommand == null)
                {
                    loadGameCommand = new DelegateCommand<object>(LoadGame);
                }

                return loadGameCommand;
            }
        }
        public DelegateCommand<object> SaveGameCommand
        {
            get
            {
                if (saveGameCommand == null)
                {
                    saveGameCommand = new DelegateCommand<object>(SaveGame);
                }

                return saveGameCommand;
            }
        }



        #endregion


    }
}
