using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PiecesController : MonoBehaviour
{
    [Header("Pieces")]
    [SerializeField] protected PawnPiece pawnPref;
    [SerializeField] protected BishopPiece bishopPref;
    [SerializeField] protected RookPiece rookPref;
    [SerializeField] protected KnightPiece knightPref;
    [SerializeField] protected QueenPiece queenPref;
    [SerializeField] protected KingPiece kingPref;
    [Header("Materials")]
    [SerializeField] protected Material whitePieceM;
    [SerializeField] protected Material blackPieceM;
    [SerializeField] protected Material highlightM;

    protected List<ChessPieceAbstract> whitePieces = new List<ChessPieceAbstract>();
    protected List<ChessPieceAbstract> blackPieces = new List<ChessPieceAbstract>();
    protected ChessPieceAbstract selectedPiece;
    protected ChessBoardAbstract board;
    protected virtual void Awake()
    {
        board = GameObject.FindObjectOfType<ChessBoardAbstract>();

        for (int i = 0; i < 8; i++)
        {
            InstantiatePiece(pawnPref, new Vector3(i, 0, 1), Team.White);
            InstantiatePiece(pawnPref, new Vector3(i, 0, 1), Team.Black);
        }
        
        InstantiatePiece(bishopPref, new Vector3(2, 0, 0), Team.White);
        InstantiatePiece(bishopPref, new Vector3(5, 0, 0), Team.White);
        InstantiatePiece(bishopPref, new Vector3(2, 0, 0), Team.Black);
        InstantiatePiece(bishopPref, new Vector3(5, 0, 0), Team.Black);

        InstantiatePiece(rookPref, new Vector3(0, 0, 0), Team.White);
        InstantiatePiece(rookPref, new Vector3(7, 0, 0), Team.White);
        InstantiatePiece(rookPref, new Vector3(0, 0, 0), Team.Black);
        InstantiatePiece(rookPref, new Vector3(7, 0, 0), Team.Black);

        InstantiatePiece(knightPref, new Vector3(1, 0, 0), Team.White);
        InstantiatePiece(knightPref, new Vector3(6, 0, 0), Team.White);
        InstantiatePiece(knightPref, new Vector3(1, 0, 0), Team.Black);
        InstantiatePiece(knightPref, new Vector3(6, 0, 0), Team.Black);

        InstantiatePiece(queenPref, new Vector3(4, 0, 0), Team.White);
        InstantiatePiece(queenPref, new Vector3(4, 0, 0), Team.Black);

        InstantiatePiece(kingPref, new Vector3(3, 0, 0), Team.White);
        InstantiatePiece(kingPref, new Vector3(3, 0, 0), Team.Black);
    }
    private void InstantiatePiece(ChessPieceAbstract piece, Vector3 position, Team team)
    {
        var obj = Instantiate(piece);

        if (team == Team.White)
        {
            obj.InitPiece(whitePieceM, highlightM, team);
            obj.transform.SetParent(this.transform.GetChild(0));
            whitePieces.Add(obj);
        }
        else if (team == Team.Black)
        {
            obj.InitPiece(blackPieceM, highlightM, team);
            obj.transform.SetParent(this.transform.GetChild(1));
            blackPieces.Add(obj);
        }

        obj.deselectSelf();

        obj.transform.localPosition = position;

        board.setOccupied((int)obj.transform.position.x, (int)obj.transform.position.z, team);
    }
    public virtual void SelectPiece(ChessPieceAbstract piece)
    {
        selectedPiece = piece;
        piece.selectSelf();
    }
    public virtual void SelectPiece(Vector3 piecePos)
    {
        //Debug.LogWarning("Count = " + whitePieces.Count);
        List<ChessPieceAbstract> piecesSet = null;

        if (TeamManager.GetCurrentTurnTeam() == Team.White) piecesSet = whitePieces;
        else if (TeamManager.GetCurrentTurnTeam() == Team.Black) piecesSet = blackPieces;

        foreach (ChessPieceAbstract piece in piecesSet)
        {
            //Debug.LogWarning(piece.transform.position + "  ?  " + piecePos);
            if (piece.transform.position == piecePos)
            {
                selectedPiece = piece;
                piece.selectSelf();
                return;
            }
        }
        Debug.LogWarning("Cant find piece to select");
    }
    public void ClearHighlight()
    {
        if (selectedPiece == null) return;
        
        selectedPiece.deselectSelf();
        selectedPiece = null;
    }
    public virtual void TakePiece(Vector3 piecePos)
    {
        List<ChessPieceAbstract> listToSearch = null;
        if (TeamManager.GetCurrentTurnTeam() == Team.White) listToSearch = blackPieces;
        else if (TeamManager.GetCurrentTurnTeam() == Team.Black) listToSearch = whitePieces;

        foreach(ChessPieceAbstract piece in listToSearch)
        {
            Debug.Log(piece.transform.position + "   " + piecePos);
            if (piece.transform.position == piecePos)
            {
                piece.OnDeath();
                listToSearch.Remove(piece);
                Destroy(piece.gameObject);
                return;
            }
        }
    }
    public virtual void StartMovingPiece(Vector3 cellPos)
    {
        if (selectedPiece == null)
        {
            Debug.LogWarning("Piece is NULL");
            return;
        }

        board.setEmpty((int)selectedPiece.transform.position.x, (int)selectedPiece.transform.position.z);
        selectedPiece.transform.position = cellPos;
        board.setOccupied((int)cellPos.x, (int)cellPos.z, TeamManager.GetCurrentTurnTeam());

        selectedPiece.AfterMove();

        TeamManager.NextTurn();
    }
}
