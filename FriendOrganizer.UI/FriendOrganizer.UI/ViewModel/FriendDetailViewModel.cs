using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System.Threading.Tasks;
using System;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ModelViewBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataServise;

        private IEventAggregator _eventAggregator;

        private Friend _friend;
        public Friend Friend
        {
            get { return _friend; }
            set {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public FriendDetailViewModel(IFriendDataService dataSrvice, IEventAggregator eventAggregator)
        {
            _dataServise = dataSrvice;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
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
