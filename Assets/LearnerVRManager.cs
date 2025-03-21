
using UnityEngine;
using UnityEngine.XR.Management;


public class LearnerVRManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems(); // Aktifkan VR Mode
        }
        else
        {
            Debug.LogError("Failed to initialize XR Loader");
        }
    }

    
    

   
}
