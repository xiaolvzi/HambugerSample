﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using HambugerSample.Droid.Activities;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace HambugerSample.Droid.Fragments.Base
{
    public abstract class BaseFragment : MvxFragment
    {
        protected Toolbar Toolbar { get; private set; }
        protected MvxActionBarDrawerToggle DrawerToggle { get; private set; }
        /// <summary>
        /// If true show the hamburger menu
        /// </summary>
        protected bool ShowHamburgerMenu { get; set; } = false;

        protected BaseFragment()
        {
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            Toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                var mainActivity = Activity as MainActivity;
                if (mainActivity == null) return view;

                mainActivity.SetSupportActionBar(Toolbar);
                mainActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
                DrawerToggle = new MvxActionBarDrawerToggle(
                    Activity,                               // host Activity
                    mainActivity.DrawerLayout,  // DrawerLayout object
                    Toolbar,                               // nav drawer icon to replace 'Up' caret
                    Resource.String.drawer_open,            // "open drawer" description
                    Resource.String.drawer_close            // "close drawer" description
                );

                if (ShowHamburgerMenu)
                {
                    DrawerToggle.DrawerOpened += (sender, e) =>
                    {
                        mainActivity?.HideSoftKeyboard();
                    };
                    mainActivity.DrawerLayout.AddDrawerListener(DrawerToggle);
                }

                DrawerToggle.DrawerIndicatorEnabled = ShowHamburgerMenu;
                Toolbar.NavigationClick += Toolbar_NavigationClick;
            }
            return view;
        }
        private void Toolbar_NavigationClick(object sender, Android.Support.V7.Widget.Toolbar.NavigationClickEventArgs e)
        {
            var mainActivity = Activity as MainActivity;
            if (!mainActivity.Title.Equals("Main Activity"))
            {
                mainActivity?.OnBackPressed();
            }
            else {
                mainActivity.ShowDrawLayout();
            }
        }

        protected abstract int FragmentId { get; }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (Toolbar != null)
            {
                DrawerToggle?.OnConfigurationChanged(newConfig);
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (Toolbar != null)
            {
                DrawerToggle?.SyncState();
            }
        }
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}