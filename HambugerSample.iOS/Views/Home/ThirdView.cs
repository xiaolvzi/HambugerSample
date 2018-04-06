﻿using Cirrious.FluentLayouts.Touch;
using Foundation;
using HambugerSample.Core.ViewModels.Home;
using HambugerSample.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using UIKit;

namespace HambugerSample.iOS.Views.Home
{
    [Register("ThirdView")]
	[MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PushPanel, true, MvxSplitViewBehaviour.Detail)]
    public class ThirdView : BaseViewController<ThirdViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var viewModel = this.ViewModel;

            var scrollView = new UIScrollView(View.Frame)
            {
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            };
            var label = new UILabel();
            label.Text = "Third View";
            var closeButton = new UIButton();
            closeButton.SetTitle("Submit and Pop to Home", UIControlState.Normal);
            closeButton.BackgroundColor = UIColor.Blue;
            scrollView.AddSubviews( label, closeButton);

            Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                scrollView.AtLeftOf(View),
                scrollView.AtTopOf(View),
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View));
            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<ThirdView, ThirdViewModel>();
            set.Bind(closeButton).To(vm=>vm.SaveAndCloseCommand);
            set.Apply();

            scrollView.AddConstraints(

                label.Below(scrollView).Plus(10),
                label.WithSameWidth(scrollView),
                label.WithSameLeft(scrollView),
                closeButton.Below(label).Plus(10),
                closeButton.WithSameWidth(label),
                closeButton.WithSameLeft(label)
                );          
        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Third View";
            base.ViewWillAppear(animated);
           
        }
    }
}
