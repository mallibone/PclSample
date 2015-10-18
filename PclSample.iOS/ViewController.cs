using System;
using PclSample.Core.ViewModels;
using UIKit;
using GalaSoft.MvvmLight.Helpers;
using PclSample.Core.Models;

namespace PclSample.iOS
{
	public partial class ViewController : UIViewController
	{
		ObservableTableViewController<Person> _tableViewController;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		private MainViewModel Vm => Application.Locator.MainViewModel;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			_tableViewController = Vm.People.GetController(CreatePersonCell, BindPersonCell);
			_tableViewController.TableView = PeopleTableView;
		}

		public override async void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			await Vm.InitAsync();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		UITableViewCell CreatePersonCell (Foundation.NSString reuseId)
		{
			var cell = new UITableViewCell(UITableViewCellStyle.Default, null);
			return cell;
		}

		void BindPersonCell (UITableViewCell cell, Person person, Foundation.NSIndexPath path)
		{
			cell.TextLabel.Text = person.FullName;
		}
	}
}

