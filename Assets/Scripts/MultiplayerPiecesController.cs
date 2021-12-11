using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class MultiplayerPiecesController : PiecesController
{
    private PhotonView photonView;
    protected override void Awake()
    {
        base.Awake();
        photonView = GetComponent<PhotonView>();
    }
    public override void StartMovingPiece(Vector3 cellPos)
    {
        photonView = GetComponent<PhotonView>();
        photonView.RPC(nameof(StartMovingPieceRPC), RpcTarget.AllBuffered, new object[] {cellPos});
    }
    [PunRPC]
    private void StartMovingPieceRPC(Vector3 cellPos)
    {
        Debug.LogWarning("Move to" + cellPos);
        base.StartMovingPiece(cellPos);
    }
}