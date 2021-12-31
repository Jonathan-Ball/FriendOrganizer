using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public interface IFriendDetailViewModel
    {
        bool HasChanges { get; }
        Task LoadAsync(int friendId);
    }
}