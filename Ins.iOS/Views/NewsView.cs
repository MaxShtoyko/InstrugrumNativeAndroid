﻿using System;
using Ins.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
	public partial class NewsView : BaseView
	{
		private MvxSimpleTableViewSource _newsTableViewSource;

		public NewsView() : base("NewsView", null)
		{
		}

		public override void ViewDidLoad()
		{
			_newsTableViewSource = new MvxSimpleTableViewSource(NewsTableView, PhotoCell.Key, PhotoCell.Key);

			NewsTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            
            NewsTableView.RowHeight = UITableView.AutomaticDimension;
            NewsTableView.EstimatedRowHeight = new nfloat(120.0);

			NewsTableView.Source = _newsTableViewSource;
            NewsTableView.ReloadData();

			base.ViewDidLoad();
		}

		protected override void CreateBindings()
		{
			base.CreateBindings();

			var set = this.CreateBindingSet<NewsView, NewsViewModel>();

			set.Bind(_newsTableViewSource).To(vm => vm.Photos);

			set.Apply();
		}

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

			//NewsViewModel.ReloadDataCommand.Execute();

			NewsTableView.AllowsSelection = false;

            //NewsTableView.DeselectRow( NewsTableView.IndexPathForSelectedRow, true);
        }
    }
}