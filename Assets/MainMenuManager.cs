using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField ipInputField;
    public void StartAsCoach()
    {
        if (!NetworkManager.singleton.isNetworkActive)
        {
            NetworkManager.singleton.StartHost();
            SceneManager.LoadScene("CoachScene");
        }
    }

    public void StartAsLearner()
    {
        if (!NetworkManager.singleton.isNetworkActive)
        {
            // Ambil IP yang dimasukkan di InputField, default ke "localhost" jika kosong
            string ipAddress = string.IsNullOrEmpty(ipInputField.text) ? "localhost" : ipInputField.text;

            NetworkManager.singleton.networkAddress = ipAddress; // Set IP tujuan
            NetworkManager.singleton.StartClient();
            SceneManager.LoadScene("HelloCardboard");
        }
    }
}
