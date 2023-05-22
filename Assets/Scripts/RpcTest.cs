using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class RpcTest : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {

    }

    [ClientRpc]
    void TestClientRpc(int value, ulong sourceNetworkObjectId)
    {
        Debug.Log("Klient otrzyma� RPC numer " + value + " przypisan� do obiektu o ID: " + sourceNetworkObjectId);
        if(IsOwner)
        {
            TestServerRpc(value + 1, sourceNetworkObjectId);
        }
    }
    [ServerRpc]
    void TestServerRpc(int value, ulong sourceNetworkObjectId)
    {
        Debug.Log("Server otrzyma� RPC numer " + value + " przypisan� do obiektu o ID: " + sourceNetworkObjectId);
        TestClientRpc(value, sourceNetworkObjectId);
    }
}
