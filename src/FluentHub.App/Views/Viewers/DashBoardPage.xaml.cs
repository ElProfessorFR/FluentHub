// Copyright (c) FluentHub
// Licensed under the MIT License. See the LICENSE.

using FluentHub.App.ViewModels.Viewers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace FluentHub.App.Views.Viewers
{
	public sealed partial class DashBoardPage : LocatablePage
	{
		private readonly DashBoardViewModel ViewModel;

		private readonly INavigationService _navigation;

		public DashBoardPage()
			: base(NavigationPageKind.None, NavigationPageKey.None)
		{
			InitializeComponent();

			// Dependency injection
			ViewModel = Ioc.Default.GetRequiredService<DashBoardViewModel>();
			_navigation = Ioc.Default.GetRequiredService<INavigationService>();
			_pageLoadCommand = ViewModel.LoadUserHomePageCommand;

			_navigation.TabView.SelectedItem.NavigationHistory.CurrentItem.Context =
				_navigation.TabView.SelectedItem.NavigationBar.Context = new()
			{
				PrimaryText = "Dashboard"
			};
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var command = ViewModel.LoadUserHomePageCommand;
			if (command.CanExecute(null))
				command.Execute(null);
		}
	}
}
