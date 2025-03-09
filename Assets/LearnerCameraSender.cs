using UnityEngine;
using Mirror;

public class LearnerCameraSender : MonoBehaviour
{
    public Camera learnerCamera;
    private Texture2D videoTexture;
    private RenderTexture renderTexture;
    // Start is called before the first frame update
    void Start()
    {
        renderTexture = new RenderTexture(1280, 720, 16);
        learnerCamera.targetTexture = renderTexture;
        videoTexture = new Texture2D(1280, 720, TextureFormat.RGB24, false);

        InvokeRepeating(nameof(CaptureAndSendVideo), 0f, 0.1f);
    }
    private void CaptureAndSendVideo()
    {
        // Capture frame dari kamera
        RenderTexture.active = renderTexture;
        videoTexture.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
        videoTexture.Apply();
        RenderTexture.active = null;

        // Kompresi Texture menjadi byte array
        byte[] imageData = videoTexture.EncodeToJPG(); // Bisa pakai PNG untuk kualitas lebih baik
        NetworkGameManager manager = FindObjectOfType<NetworkGameManager>();
        if (manager != null)
        {
            manager.SendVideo(imageData);
        }
    }


}
