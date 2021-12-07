using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private NetworkManager networkMngr;
    public void ConnectToMultiplayer() {
        networkMngr.Connect();
    }
}
