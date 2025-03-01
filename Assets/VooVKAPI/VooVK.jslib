var VooVK = 
{
	VKAsyncInit: function ()//
	{
		window.vkAsyncInit = function ()
		{
			VK.init({
				apiId: window.VKappID
			});
		};

		setTimeout(function ()
		{
			var el = document.createElement("script");
			el.type = "text/javascript";
			el.src = "https://vk.com/js/api/openapi.js?169";
			el.async = true;
			document.getElementsByTagName('head')[0].appendChild(el);
		}, 0);
	},

	VKGetUserPhoto: function(unityObjectName, unityMethodName, user_id)
	{
		var method = "users.get";
		Utf8_unityObject = UTF8ToString(unityObjectName);
		Utf8_unityMethod = UTF8ToString(unityMethodName);
		Utf8_unityUserId = UTF8ToString(user_id);

		var params =
		{
		    user_ids: Utf8_unityUserId, fields: 'photo_max_orig', v: '5.199'
		};


		VK.Api.call(method, params, callback);

		function callback(data) 
		{
			SendMessage(Utf8_unityObject, Utf8_unityMethod, JSON.stringify(data));
		}
	},

	VKCustomMethod: function (unityObjectName, unityMethodName, vkMethodName, params)
	{
		Utf8_unityObject = UTF8ToString(unityObjectName);
		Utf8_unityMethod = UTF8ToString(unityMethodName);

		VK.Api.call(vkMethodName, params, callback)

		function callback(response)
		{
			SendMessage(Utf8_unityObject, Utf8_unityMethod, JSON.stringify(response));
		}
	},

	VKLogin: function (unityObjectName, unityMethodName)//
	{

		Utf8_unityObject = UTF8ToString(unityObjectName);
		Utf8_unityMethod = UTF8ToString(unityMethodName);

		var settings = 1 << 2;

		VK.Auth.login(callback,settings);

		function callback(response) {
			if (response.session) {
				SendMessage(Utf8_unityObject, Utf8_unityMethod, JSON.stringify(response.session));
			}
			else {
				SendMessage(Utf8_unityObject, Utf8_unityMethod, "error");
			}
		}
	},

	VKGetUserFriends: function(unityObjectName, unityMethodName, user_id, count)
	{
		var method = "friends.get";
		Utf8_unityObject = UTF8ToString(unityObjectName);
		Utf8_unityMethod = UTF8ToString(unityMethodName);
		Utf8_unityUserId = UTF8ToString(user_id);

		var params =
		{
			user_id: Utf8_unityUserId, count: count, fields: 'nickname,photo_100,sex', v: '5.199'
		};


		VK.Api.call(method, params, callback);

		function callback(data) 
		{
			SendMessage(Utf8_unityObject, Utf8_unityMethod, JSON.stringify(data));
		}
	}

}





mergeInto(LibraryManager.library, VooVK);