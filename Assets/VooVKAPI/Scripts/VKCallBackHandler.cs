using System;
using UnityEngine;

public class VKCallBackHandler : MonoBehaviour
{
    public Action<string> OnHandle;

    public void Handle(string rawData)
    {
        OnHandle?.Invoke(rawData);
    }
}
