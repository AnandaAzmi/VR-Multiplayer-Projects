
using UnityEngine;
using Mirror;

public class NetworkVideoHandler : NetworkBehaviour
{
    public static NetworkVideoHandler Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public delegate void VideoReceivedDelegate(byte[] videoData);
    public static event VideoReceivedDelegate OnVideoReceived;

    [Command(requiresAuthority = false)]
    public void CmdSendVideoData(byte[] videoData)
    {
        RpcReceiveVideoData(videoData);
    }

    [ClientRpc]
    private void RpcReceiveVideoData(byte[] videoData)
    {
        OnVideoReceived?.Invoke(videoData);

        VideoStreamEvent.InvokeVideoReceived(videoData);
    }
}
