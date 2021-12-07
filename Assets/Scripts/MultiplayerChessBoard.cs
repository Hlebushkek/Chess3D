using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class MultiplayerChessBoard : ChessBoardAbstract
{
    private PhotonView photonView;

    protected override void Awake()
    {
        base.Awake();
        photonView = GetComponent<PhotonView>();
    }
    public override void HighlightCells(Vector3 piecePos, Vector2[] moveOffsets)
    {
        photonView.RPC(nameof(HighlightCellsRPC), RpcTarget.AllBuffered, new object[] {piecePos, moveOffsets});
    }
    
    [PunRPC]
    private void HighlightCellsRPC(Vector3 piecePos, Vector2[] moveOffsets) 
    {
        base.HighlightCells(piecePos, moveOffsets);
    }
}
