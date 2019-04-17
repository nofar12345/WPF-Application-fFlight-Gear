﻿using Ex2.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ex2
{
    public class SwitchWindowsViewModel: BaseNotify
    {
        private ICommand switchToJoystick;
        private ICommand switchToAuto;
        private object currentView;
        private object joystick;
        private object autoPilot;
        public SwitchWindowsViewModel()
        {
            this.joystick = new Joystick();
            this.autoPilot = new AutoP();
            currentViewP = this.joystick;
        }
        public object currentViewP
        {
            set
            {
                currentView = value;
                NotifyPropertyChanged("currentViewP");
            }
            get
            {
                return this.currentView;
            }
        }
        public ICommand GoToJoystick
        {
            get
            {
                if (switchToJoystick == null)
                {
                    switchToJoystick = new CommandHandler(() => { currentViewP = this.joystick; });
                }
                switchToJoystick.Execute(this);
                return this.switchToJoystick;
            }
        }
        public ICommand GoToAutoPilot
        {
            get
            {
                if (switchToAuto == null)
                {
                    switchToAuto = new CommandHandler(() => { currentViewP = this.autoPilot; });
                }
                switchToAuto.Execute(this);
                return this.switchToAuto;
            }
        }
    }
}
