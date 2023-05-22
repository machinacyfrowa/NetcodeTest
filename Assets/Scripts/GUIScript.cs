using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (NetworkManager.Singleton.IsHost)
            GUILayout.Label("Pracuje jako host");
        if (NetworkManager.Singleton.IsServer)
            GUILayout.Label("Pracuje jako serwer");
        if (NetworkManager.Singleton.IsClient)
            GUILayout.Label("Pracuje jako klient");
        GUILayout.Label("Metoda po³¹czenia: " + NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
        GUILayout.EndArea();
    }
}
