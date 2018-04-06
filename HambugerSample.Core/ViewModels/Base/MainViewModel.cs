﻿using System;
using System.Collections.Generic;
using System.Text;
using HambugerSample.Core.ViewModels.Home;
using HambugerSample.Core.ViewModels.Menu;

namespace HambugerSample.Core.ViewModels.Base
{
    public class MainViewModel : BaseViewModel
    {
        public void ShowMenu()
        {
            ShowViewModel<HomeViewModel>();
            ShowViewModel<MenuViewModel>();
        }

        public void ShowHome()
        {
            ShowViewModel<HomeViewModel>();
        }

        public void Init(object hint)
        {
            // Can perform Vm data retrival here based on any
            // data passed in the hint object

            // ShowViewModel<SomeViewModel>(new { derp: "herp", durr: "derrrrrr" });
            // public class SomeViewModel : MvxViewModel
            // {
            //     public void Init(string derp, string durr)
            //     {
            //     }
            // }
        }

        public override void Start()
        {
            //base.Start();
        }
    }
}
