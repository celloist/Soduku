﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFSUDOKU.Foundation
{

    /// <summary>
    /// A templated implemention of ICommand allowing for actions of varying types
    /// </summary>
    /// <typeparam name="T">The type of parameter the action should take</typeparam>
    public class DelegateCommand<T> : ICommand
    {

        /// <summary>
        /// A predicate returning true if the command can execute
        /// </summary>
        private Predicate<T> canExecuteDelegate = null;

        /// <summary>
        /// The action the command is to take
        /// </summary>
        private Action<T> commandDelegate = null;

        /// <summary>
        /// Initializes a new instance of the DelegateCommand class
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <param name="canExecute">The predicate defining whether the command can execute</param>
        public DelegateCommand(Action<T> command, Predicate<T> canExecute = null)
        {
            commandDelegate = command;
            canExecuteDelegate = canExecute;
        }

        /// <summary>
        /// An event indicating that the CanExecute predicate needs to be re-evaluated
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Executes the command with a given parameter. Will not execute if the parameter does not conform to the templated class.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        public void Execute(object parameter)
        {
            if (commandDelegate != null && CanExecute(parameter))
            {
                if (parameter == null || parameter is T)
                {
                    T commandParam = parameter == null ? default(T) : (T)parameter;
                    commandDelegate(commandParam);
                }
                else
                {
                    Debug.WriteLine(string.Format("Delegate CanExecute unable to execute: Expected parameter of type: {0}, received parameter of type {1}", typeof(T), parameter.GetType()));
                }
            }
        }

        /// <summary>
        /// Evaluates whether the command can execute
        /// </summary>
        /// <param name="parameter">The parameter to be passed to the CanExecuteDelegate</param>
        /// <returns>Whether the command can execute</returns>
        public bool CanExecute(object parameter)
        {
            bool canExecute = true;
            if (canExecuteDelegate != null)
            {
                if (parameter == null || parameter is T)
                {
                    T commandParam = parameter == null ? default(T) : (T)parameter;
                    canExecute = canExecuteDelegate(commandParam);
                }
                else
                {
                    Debug.WriteLine(string.Format("Delegate CanExecute unable to execute: Expected parameter of type: {0}, received parameter of type {1}", typeof(T), parameter.GetType()));
                }
            }

            return canExecute;
        }

        /// <summary>
        /// Raises the event indicating that CanExecute needs to be re-evaluated
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
