using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System.Threading.Tasks;
using System;
using Prism.Commands;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ModelViewBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataServise;

        private IEventAggregator _eventAggregator;

        public DelegateCommand SaveCommand { get; }

        private Friend _friend;
        public Friend Friend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public FriendDetailViewModel(IFriendDataService dataSrvice, IEventAggregator eventAggregator)
        {
            _dataServise = dataSrvice;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, CanExecuteSave);
        }

        private bool CanExecuteSave()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            await _dataServise.SaveAsync(Friend);
            _eventAggregator.GetEvent<AfterFriendSavedEvent>()
                .Publish(new AfterFriendDetailSaveEventArgs { Id = Friend.Id, DisplayMember = $"{Friend.FirstName} {Friend.LastName}" });
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await _dataServise.GetByIdAsync(friendId);
        }
    }
}
