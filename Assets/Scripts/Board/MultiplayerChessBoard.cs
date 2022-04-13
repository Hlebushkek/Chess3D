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
        photonView.RPC(nameof(HighlightCellsRPC), RpcTarget.AllBuffered, new object[] {piece.transform.position, piece.GetMoveOffsets(), piece.GetAttackOffsets(), (byte)team});
    }
    [PunRPC]
    private void HighlightCellsRPC(Vector3 piecePos, Vector2[][] moveOffsets, Vector2[][] attackOffsets, byte team)
    {
        ClearHighlight();

        base.Highlight(piecePos, moveOffsets, attackOffsets, (Team)team);
    }

    public override void TryMovePiece(Vector3 cellPos)
    {
        photonView.RPC(nameof(MovePieceRPC), RpcTarget.AllBuffered, new object[] {cellPos});
    }
    [PunRPC]
    private void MovePieceRPC(Vector3 cellPos) 
    {
        base.TryMovePiece(cellPos);
    }

    public override void EndRound(Team team)
    {
        photonView.RPC(nameof(EndRoundRPC), RpcTarget.AllBuffered, new object[] {(byte)team});
    }
    [PunRPC]
    private void EndRoundRPC(byte team)
    {
        base.EndRound((Team)team);
    }
}
