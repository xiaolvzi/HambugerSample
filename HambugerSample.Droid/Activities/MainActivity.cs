﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.InputMethodServices;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using HambugerSample.Core.ViewModels.Base;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;

namespace HambugerSample.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(
         Label = "Main Activity",
         Theme = "@style/AppTheme",
         LaunchMode = LaunchMode.SingleTop,
         Name = "hambugersample.droid.activities.MainActivity"
     )]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        public DrawerLayout DrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
                ViewModel.ShowMenu();

            RunOnUiThread(() => {
                if (!IsFinishing) {
                    //to call the show method
                }
            });
            
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Log.Error("lv====","12121212121212121212121212");
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    //NavUtils.NavigateUpFromSameTask(this);
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;


            }



            return base.OnOptionsItemSelected(item);
        }

        public void ShowDrawLayout() {
            DrawerLayout.OpenDrawer(GravityCompat.Start);
        }
        private void ShowBackButton()
        {
            //TODO Tell the toggle to set the indicator off
            //this.DrawerToggle.DrawerIndicatorEnabled = false;

            //Block the menu slide gesture
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
        }

        private void ShowHamburguerMenu()
        {
            //TODO set toggle indicator as enabled 
            //this.DrawerToggle.DrawerIndicatorEnabled = true;

            //Unlock the menu sliding gesture
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }

        public override Resources Resources {
            get
            {
                Resources res = base.Resources;
                Configuration config = new Configuration();
                config.SetToDefaults();
                res.UpdateConfiguration(config, res.DisplayMetrics);
                return res;
            }
           
        }
    }
}