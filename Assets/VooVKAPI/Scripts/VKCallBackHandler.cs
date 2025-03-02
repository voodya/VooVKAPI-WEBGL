using System;
using UnityEngine;

namespace Voo.VKAPI
{
    public class VKCallBackHandler : MonoBehaviour
    {
        public Action<string> OnHandle;

        public void Handle(string rawData)
        {
            OnHandle?.Invoke(rawData);
        }
    }
}
