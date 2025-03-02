using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using UnityEngine;


namespace Voo.VKAPI
{
    public static class VKAPI
    {
        [DllImport("__Internal")]
        private static extern void VKAsyncInit();

        [DllImport("__Internal")]
        private static extern void VKLogin(string unityObjectName, string unityMethodName);

        [DllImport("__Internal")]
        private static extern void VKCustomMethod(string unityObjectName, string unityMethodName, string vkMethodName, string vkParams);

        [DllImport("__Internal")]
        private static extern void VKGetUserPhoto(string unityObjectName, string unityMethodName, string userId);

        [DllImport("__Internal")]
        private static extern void VKGetUserFriends(string unityObjectName, string unityMethodName, string userId, int count);

        private static VKCallBackHandler _handler;
        private static bool _initedHandler;
        private static bool _initedApi;

        public static void AsyncInit()
        {
            if (!_initedHandler) Initiate();
#if !UNITY_EDITOR
        VKAsyncInit();
#else
            Debug.Log("Just async init");
#endif
            _initedApi = true;
        }

        public static void Login(Action<string> callback)
        {
            if (!_initedHandler) Initiate();
            if (!_initedApi)
                throw new Exception("Not inited vk api");
#if !UNITY_EDITOR
        _handler.OnHandle = null;
        _handler.OnHandle += callback;
        VKLogin(_handler.gameObject.name, "Handle");
#else
            callback?.Invoke("Fake login");
#endif
        }

        public static void GetUserPhoto(string userId, Action<string> callback)
        {
            if (!_initedHandler) Initiate();
            if (!_initedApi)
                throw new Exception("Not inited vk api");
#if !UNITY_EDITOR
        _handler.OnHandle = null;
        _handler.OnHandle += callback;
        VKGetUserPhoto(_handler.gameObject.name, "Handle", userId);
#else
            callback?.Invoke("User photo data");
#endif
        }

        public static void GetFriendsData(string userId, int count, Action<string> callback)
        {
            if (!_initedHandler) Initiate();
            if (!_initedApi)
                throw new Exception("Not inited vk api");
#if !UNITY_EDITOR
        _handler.OnHandle = null;
        _handler.OnHandle += callback;
        VKGetUserFriends(_handler.gameObject.name, "Handle", userId, count);
#else
            callback?.Invoke("User friends data");
#endif
        }

        private static void Initiate()
        {
            _handler = MonoBehaviour.Instantiate(Resources.Load<GameObject>("VKIDHANDLER")).GetComponent<VKCallBackHandler>();
            _initedHandler = true;
        }

        public static FriendsData ParseFriends(string rawData)
        {
            return JsonConvert.DeserializeObject<FriendsData>(rawData);
        }

        public static UserData ParseUser(string rawData)
        {
            return JsonConvert.DeserializeObject<UserData>(rawData);
        }
        public static UserPhotoData ParseUserPhoto(string rawData)
        {
            return JsonConvert.DeserializeObject<UserPhotoData>(rawData);
        }
    }
}



