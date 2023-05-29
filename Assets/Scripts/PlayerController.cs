using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    //stwórz zmienn¹ na synchronizowan¹ po sieci zmienn¹ przechowuj¹c¹ pozycjê gracza
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public void Move()
    {
        //je¿eli jesteœmy serwerem
        if(NetworkManager.Singleton.IsServer)
        {
            //przesuñ gracza na nowe losowe miejsce
            transform.position = GetRandomPosition();
            //zapisz jego now¹ pozycjê do sieciowo synchronizowanej zmiennej
            Position.Value = transform.position;
        }
        else
        {
            //nie jesteœmy serwerem - wyœlij proœbê o zmianê pozycji

        }
    }
    static Vector3 GetRandomPosition()
    {
        float x, y, z;
        //wylosuj wspó³rzêdne mieszcz¹ce siê na p³aszczyŸnie
        x = Random.Range(-5f, 5f);
        y = 1;
        z = Random.Range(-5f, 5f);
        //zwróæ po³o¿enie
        return new Vector3(x, y, z);
    }
}
