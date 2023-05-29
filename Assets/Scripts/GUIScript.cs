using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if(GUILayout.Button("Serwer dedykowany"))
        {
            //wci�ni�to guzik dla serwera dedykowanego
            NetworkManager.Singleton.StartServer();
        }
        if(GUILayout.Button("Host"))
            NetworkManager.Singleton.StartHost();
        if(GUILayout.Button("Klient"))
            NetworkManager.Singleton.StartClient();
        if (NetworkManager.Singleton.IsHost)
            GUILayout.Label("Pracuje jako host");
        if (NetworkManager.Singleton.IsServer)
            GUILayout.Label("Pracuje jako serwer");
        if (NetworkManager.Singleton.IsClient)
            GUILayout.Label("Pracuje jako klient");
        GUILayout.Label("Metoda po��czenia: " + NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
        if (NetworkManager.Singleton.IsClient || NetworkManager.Singleton.IsHost)
        {
            if(GUILayout.Button("Przesu� si�"))
            {
                //znajdz obecnego gracza 
                NetworkObject player = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
                //wywolaj dla niego funkcje move
                player.GetComponent<PlayerController>().Move();
            }
        }
        
        GUILayout.EndArea();
    }
}
