using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku;
using System.Collections.ObjectModel;
using WPFSUDOKU.Foundation;
using System.Diagnostics;

namespace WPFSUDOKU.Models
{
    public class Bord : BasePropertyChanged
    {
        /// <summary>
        /// Sudoku game instance
        /// </summary>
        private IGame sudoEngine;

        /// <summary>
        /// Alle vakken
        /// </summary>
        private ObservableCollection<Vak> vakken;

        /// <summary>
        /// Initialize the game
        /// </summary>
        public Bord()
        {
            sudoEngine = new Game();
        }

        /// <summary>
        /// Initialize the vakken list
        /// </summary>
        public void initialize()
        {
            Vakken = new ObservableCollection<Vak>();
            sudoEngine.create();

            for (int y = 1; y <= 9; y++)
            {
                for (int x = 1; x <= 9; x++)
                {
                    short vakValue;
                    bool startVak;

                    sudoEngine.get(Convert.ToInt16(x), Convert.ToInt16(y), out vakValue);

                    startVak = (vakValue == 0) ? true : false;
                    
                    Vak newVak = new Vak((y - 1), (x - 1), Convert.ToInt32(vakValue), startVak);
                    Vakken.Add(newVak);

                    Debug.WriteLine("NEW VAK : (" + y.ToString() + "," + x.ToString() + ") = " + vakValue.ToString());
                }
            }
        }

        /// <summary>
        /// Verkrijg of zet de vakken
        /// </summary>
        public ObservableCollection<Vak> Vakken 
        {
            get
            {
                return vakken;
            }
            set
            {
                vakken = value;
                RaisePropertyChanged(() => Vakken);
            }
        }


    }
}
