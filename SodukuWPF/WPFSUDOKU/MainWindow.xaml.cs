using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sudoku;
using System.Diagnostics;
using WPFSUDOKU.ViewModel;

namespace WPFSUDOKU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// View Model for this view
        /// </summary>
        private SudokuViewModel viewModel;

        /// <summary>
        /// Initialize the view model and set the data context
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new SudokuViewModel();
            this.DataContext = viewModel;
        }
    }
}
