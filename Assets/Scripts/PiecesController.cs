using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PiecesController : MonoBehaviour
{
    [SerializeField] private PawnPiece pawnPref;
    [SerializeField] private BishopPiece bishopPref;
    protected List<ChessPieceAbstract> whitePieces = new List<ChessPieceAbstract>();
    protected List<ChessPieceAbstract> blackPieces = new List<ChessPieceAbstract>();
    protected virtual void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            whitePieces.Add(Instantiate(pawnPref, new Vector3(i*2, 0, 0), Quaternion.identity));
            whitePieces.Add(Instantiate(bishopPref, new Vector3(i*2+1, 0, 1), Quaternion.identity));
        }
    }
    public
    virtual void MovePiece(Vector3 piecePos)
    {
        foreach (ChessPieceAbstract piece in whitePieces)
        {
            if(piece.transform.position == piecePos)
            {
                piece.transform.position += new Vector3(0, 0, 2);
                return;
            }
        }
    }
}
