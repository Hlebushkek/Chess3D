using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class MultiplayerPiecesController : PiecesController
{
    private PhotonView photonView;
    protected override void Start()
    {
        base.Start();
        photonView = GetComponent<PhotonView>();
    }
    public override void MovePiece(Vector3 piecePos)
    {
        photonView.RPC(nameof(MovePieceRPC), RpcTarget.AllBuffered, new object[] {piecePos});
    }
    [PunRPC]
    private void MovePieceRPC(Vector3 piecePos)
    {
        foreach (ChessPieceAbstract piece in whitePieces)
        {
            if(piece.transform.position == piecePos)
            {
                Debug.Log("Multiplayer move");
                piece.transform.position += new Vector3(0, 0, 2);
                return;
            }
        }
    }
}
