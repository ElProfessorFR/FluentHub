// Copyright (c) FluentHub
// Licensed under the MIT License. See the LICENSE.

using FluentHub.Octokit.Queries.Users;
using FluentHub.App.Helpers;
using FluentHub.App.Models;
using FluentHub.App.Services;
using FluentHub.App.ViewModels.UserControls.Overview;
using FluentHub.App.ViewModels.UserControls.BlockButtons;
using FluentHub.App.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;

namespace FluentHub.App.ViewModels.Users
{
	public class FollowersViewModel : BaseViewModel
	{
		private User _user;
		public User User { get => _user; set => SetProperty(ref _user, value); }

		private UserProfileOverviewViewModel _userProfileOverviewViewModel;
		public UserProfileOverviewViewModel UserProfileOverviewViewModel { get => _userProfileOverviewViewModel; set => SetProperty(ref _userProfileOverviewViewModel, value); }

		private bool _displayTitle;
		public bool DisplayTitle { get => _displayTitle; set => SetProperty(ref _displayTitle, value); }

		private readonly ObservableCollection<UserBlockButtonViewModel> _followersItems;
		public ReadOnlyObservableCollection<UserBlockButtonViewModel> FollowersItems { get; }

		public IAsyncRelayCommand LoadUserFollowersPageCommand { get; }
		public IAsyncRelayCommand LoadFurtherUserFollowersPageCommand { get; }

		public FollowersViewModel() : base()
		{
			var parameter = _navigation.TabView.SelectedItem.NavigationBar.Context;
			Login = parameter.PrimaryText;
			if (parameter.AsViewer)
			{
				var currentTabItem = _navigation.TabView.SelectedItem;
				currentTabItem.NavigationBar.PageKind = NavigationPageKind.None;

				DisplayTitle = true;
			}

			_followersItems = new();
			FollowersItems = new(_followersItems);

			LoadUserFollowersPageCommand = new AsyncRelayCommand(LoadUserFollowersPageAsync);
			LoadFurtherUserFollowersPageCommand = new AsyncRelayCommand(LoadFurtherUserFollowersPageAsync);
		}

		private async Task LoadUserFollowersPageAsync()
		{
			SetTabInformation("Followers", "Followers", "Accounts");

			_messenger?.Send(new TaskStateMessaging(TaskStatusType.IsStarted));
			IsTaskFaulted = false;

			string _currentTaskingMethodName = nameof(LoadUserFollowersPageAsync);

			try
			{
				_currentTaskingMethodName = nameof(LoadUserAsync);
				await LoadUserAsync(Login);

				_currentTaskingMethodName = nameof(LoadUserFollowersAsync);
				await LoadUserFollowersAsync(Login);

				SetTabInformation("Followers", "Followers", "Accounts");
			}
			catch (Exception ex)
			{
				TaskException = ex;
				IsTaskFaulted = true;

				_logger?.Error(_currentTaskingMethodName, ex);
			}
			finally
			{
				_messenger?.Send(new TaskStateMessaging(IsTaskFaulted ? TaskStatusType.IsFaulted : TaskStatusType.IsCompletedSuccessfully));
			}
		}

		private async Task LoadUserFollowersAsync(string login)
		{
			FollowersQueries queries = new();

			var result = await queries.GetAllAsync(login, 20);
			if (result.Response is null || result.PageInfo is null)
				return;

			_lastPageInfo = result.PageInfo;
			var items = (List<User>)result.Response;

			_followersItems.Clear();
			foreach (var item in items)
			{
				UserBlockButtonViewModel viewModel = new()
				{
					User = item,
				};

				_followersItems.Add(viewModel);
			}
		}

		private async Task LoadUserAsync(string login)
		{
			UserQueries queries = new();
			var response = await queries.GetAsync(login);

			User = response ?? new();

			UserProfileOverviewViewModel = new()
			{
				User = User,
				SelectedTag = "followers",
			};

			if (string.IsNullOrEmpty(User.WebsiteUrl) is false)
			{
				UserProfileOverviewViewModel.BuiltWebsiteUrl = new UriBuilder(User.WebsiteUrl).Uri;
			}
		}

		private async Task LoadFurtherUserFollowersPageAsync()
		{
			if (!_lastPageInfo.HasNextPage)
				return;

			_messenger?.Send(new TaskStateMessaging(TaskStatusType.IsStarted));
			IsTaskFaulted = false;

			try
			{
				if (_loadedToTheEnd)
					return;

				FollowersQueries queries = new();

				var result = await queries.GetAllAsync(Login, 20, _lastPageInfo.EndCursor);
				if (result.Response is null || result.PageInfo is null)
					return;

				_lastPageInfo = result.PageInfo;
				var items = (List<User>)result.Response;

				foreach (var item in items)
				{
					UserBlockButtonViewModel viewmodel = new()
					{
						User = item,
					};

					_followersItems.Add(viewmodel);
				}
			}
			catch (Exception ex)
			{
				TaskException = ex;
				IsTaskFaulted = true;

				_logger?.Error(nameof(LoadFurtherUserFollowersPageAsync), ex);
			}
			finally
			{
				_messenger?.Send(new TaskStateMessaging(IsTaskFaulted ? TaskStatusType.IsFaulted : TaskStatusType.IsCompletedSuccessfully));
			}
		}
	}
}
