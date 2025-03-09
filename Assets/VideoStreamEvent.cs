using System;
using UnityEngine;

public class VideoStreamEvent : MonoBehaviour
{
    public static event Action<byte[]> OnVideoStreamReceived;

    private void OnEnable()
    {
        NetworkVideoHandler.OnVideoReceived += InvokeVideoReceived;
    }
    private void OnDisable()
    {
        NetworkVideoHandler.OnVideoReceived -= InvokeVideoReceived;
    }
    public static void InvokeVideoReceived(byte[] videoData)
    {
        OnVideoStreamReceived?.Invoke(videoData);
    }
}
