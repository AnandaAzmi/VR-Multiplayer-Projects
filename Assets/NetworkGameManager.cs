
using UnityEngine;


public class NetworkGameManager : MonoBehaviour
{
    public void SendVideo(byte[] videoData)
    {
        if (NetworkVideoHandler.Instance != null)
        {
            NetworkVideoHandler.Instance.CmdSendVideoData(videoData);
        }
    }
}
