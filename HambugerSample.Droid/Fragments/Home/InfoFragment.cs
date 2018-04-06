using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using HambugerSample.Core.ViewModels.Base;
using HambugerSample.Core.ViewModels.Home;
using HambugerSample.Droid.Activities;
using HambugerSample.Droid.Fragments.Base;
using MvvmCross.Droid.Views.Attributes;

namespace HambugerSample.Droid.Fragments.Home
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("hambugersample.droid.fragments.InfoFragment")]
    public class InfoFragment : BaseFragment<InfoViewModel>,View.IOnClickListener
    {
        string oldTitle;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            oldTitle = ((MainActivity)Activity).Title;
            ((MainActivity)Activity).Title = "Info Fragment";
            View view=inflater.Inflate(Resource.Layout.fragment_info,null);
            
            //int count=toolbar.ChildCount;
            //Android.Widget.ImageButton button=(ImageButton)toolbar.GetChildAt(0);
            //((MainActivity)Activity).SetSupportActionBar(toolbar);
           // ((MainActivity)Activity).SupportActionBar.SetHomeButtonEnabled(false);
            //((MainActivity)Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            //toolbar.SetNavigationOnClickListener(this);
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

    
        public override void OnDestroyView()
        {
            ((MainActivity)Activity).Title = oldTitle;
            base.OnDestroyView();
        }

        public void OnClick(View v)
        {
            Log.Error("lv","1111111111");
        }

        protected override int FragmentId
        {
            get
            {
                return Resource.Layout.fragment_info;
            }
        }

        
    }
}