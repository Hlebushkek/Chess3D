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
    
    public override void HighlightCells(ChessPieceAbstract piece, Team team)
    {
        photonView.RPC(nameof(HighlightCellsRPC), RpcTarget.AllBuffered, new object[] {piece.transform.position, piece.GetMoveOffsets(), (byte)team});
    }
    [PunRPC]
    private void HighlightCellsRPC(Vector3 piecePos, Vector2[][] moveOffsets, byte team)
    {
        Debug.LogWarning("PiecePos = " + piecePos);
        ClearHighlight();
        Team t = (Team)team;
        base.Highlight(piecePos, moveOffsets, t);
    }

    public override void MovePiece(Vector3 cellPos)
    {
        photonView.RPC(nameof(MovePieceRPC), RpcTarget.AllBuffered, new object[] {cellPos});
    }
    [PunRPC]
    private void MovePieceRPC(Vector3 cellPos) 
    {
        base.MovePiece(cellPos);
    }
}
