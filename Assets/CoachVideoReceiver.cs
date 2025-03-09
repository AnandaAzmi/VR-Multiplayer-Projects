
using UnityEngine;
using UnityEngine.UI;

public class CoachVideoReceiver : MonoBehaviour
{
    public RawImage display;
    private Texture2D receivedTexture;

    
    private void Awake()
    {
        
        receivedTexture = new Texture2D(256, 256, TextureFormat.RGB24, false);
    }
    private void OnEnable()
    {
        VideoStreamEvent.OnVideoStreamReceived += ReceiveVideo;
    }

    private void OnDisable()
    {
        VideoStreamEvent.OnVideoStreamReceived -= ReceiveVideo;
    }
    public void ReceiveVideo(byte[] imageData)
    {
        receivedTexture.LoadImage(imageData); // Decode byte array jadi Texture
        display.texture = receivedTexture; // Tampilkan di UI
    }
}
