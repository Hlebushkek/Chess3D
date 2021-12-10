using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PiecesController : MonoBehaviour
{
    [SerializeField] private PawnPiece pawnPref;
    [SerializeField] private BishopPiece bishopPref;
    [SerializeField] private RookPiece rookPref;
    [SerializeField] private KnightPiece knightPref;
    [SerializeField] private QueenPiece queenPref;
    [SerializeField] private KingPiece kingPref;
    protected List<ChessPieceAbstract> whitePieces = new List<ChessPieceAbstract>();
    protected List<ChessPieceAbstract> blackPieces = new List<ChessPieceAbstract>();
    protected virtual void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            whitePieces.Add(Instantiate(pawnPref, new Vector3(i, 0, 1), Quaternion.identity));
        }

        whitePieces.Add(Instantiate(bishopPref, new Vector3(2, 0, 0), Quaternion.identity));
        whitePieces.Add(Instantiate(bishopPref, new Vector3(5, 0, 0), Quaternion.identity));

        whitePieces.Add(Instantiate(rookPref, new Vector3(0, 0, 0), Quaternion.identity));
        whitePieces.Add(Instantiate(rookPref, new Vector3(7, 0, 0), Quaternion.identity));

        whitePieces.Add(Instantiate(knightPref, new Vector3(1, 0, 0), Quaternion.identity));
        whitePieces.Add(Instantiate(knightPref, new Vector3(6, 0, 0), Quaternion.identity));

        whitePieces.Add(Instantiate(queenPref, new Vector3(3, 0, 0), Quaternion.identity));

        whitePieces.Add(Instantiate(kingPref, new Vector3(4, 0, 0), Quaternion.identity));
    }
    public virtual void MovePiece(Vector3 piecePos)
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
