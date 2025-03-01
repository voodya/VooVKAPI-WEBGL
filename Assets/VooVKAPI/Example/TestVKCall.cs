using UnityEngine;
using UnityEngine.UI;

public class TestVKCall : MonoBehaviour
{
    [SerializeField] private Button _btnPhoto;
    [SerializeField] private Button _btnFriends;
    [SerializeField] private Button _btnLogin;

    private string UserId;

    private void Awake()
    {
        VKAPI.AsyncInit();
        _btnLogin.onClick.AddListener(() => VKAPI.Login(OnLogin));
        _btnPhoto.onClick.AddListener(() => VKAPI.GetUserPhoto(UserId, HandlePhotoData));
        _btnFriends.onClick.AddListener(() => VKAPI.GetFriendsData(UserId, 10, HandleFriendsData));
    }

    private void HandleFriendsData(string rawData)
    {
        FriendsData data = VKAPI.ParseFriends(rawData);
    }

    private void HandlePhotoData(string rawData)
    {
        UserPhotoData data = VKAPI.ParseUserPhoto(rawData);
    }
    private void OnLogin(string rawData)
    {
        UserData data = VKAPI.ParseUser(rawData);
        UserId = data.User.Id.ToString();
    }
}

