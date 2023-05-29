using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    //stw�rz zmienn� na synchronizowan� po sieci zmienn� przechowuj�c� pozycj� gracza
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public void Move()
    {
        //je�eli jeste�my serwerem
        if(NetworkManager.Singleton.IsServer)
        {
            //przesu� gracza na nowe losowe miejsce
            transform.position = GetRandomPosition();
            //zapisz jego now� pozycj� do sieciowo synchronizowanej zmiennej
            Position.Value = transform.position;
        }
        else
        {
            //nie jeste�my serwerem - wy�lij pro�b� o zmian� pozycji

        }
    }
    static Vector3 GetRandomPosition()
    {
        float x, y, z;
        //wylosuj wsp�rz�dne mieszcz�ce si� na p�aszczy�nie
        x = Random.Range(-5f, 5f);
        y = 1;
        z = Random.Range(-5f, 5f);
        //zwr�� po�o�enie
        return new Vector3(x, y, z);
    }
}
