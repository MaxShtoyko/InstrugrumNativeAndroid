﻿using System;
using MvvmCross.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class NewsView : MvxViewController
    {
        public NewsView() : base("NewsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

