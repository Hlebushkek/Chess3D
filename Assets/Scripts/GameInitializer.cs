using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameInitializer : MonoBehaviour
{
    [Header("Game depended pref")]
    [SerializeField] private PiecesController piecesController;
    [SerializeField] private MultiplayerChessBoard multiplayerBoardPref;

    [SerializeField] private NetworkManager networkMngr;
    private void Awake()
    {
        CreateMultiplayerBoard();
    }
    public void CreateMultiplayerBoard()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            PhotonNetwork.Instantiate(multiplayerBoardPref.name, new Vector3(0, 0, 0), Quaternion.identity);
            PhotonNetwork.Instantiate(piecesController.name, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}