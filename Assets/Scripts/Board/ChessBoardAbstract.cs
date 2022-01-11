using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using System.Linq;

public abstract class ChessBoardAbstract : MonoBehaviour
{
    [Header("Cells Prop")]
    [SerializeField] private BoardCell boardCell;
    [SerializeField] protected Material blackM, whiteM;
    [SerializeField] protected Material highlightM;

    protected PiecesController piecesController;
    protected BoardCell[,] boardCells = new BoardCell[8, 8];
    protected List<Vector2Int> highlightedCells = new List<Vector2Int>();

    protected virtual void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                boardCells[i,j] = Instantiate(boardCell);
                boardCells[i,j].transform.localPosition = new Vector3(i, 0, j);
                boardCells[i,j].GetComponent<MeshRenderer>().material = (i%8+j) % 2 == 0? blackM : whiteM;
                boardCells[i,j].transform.SetParent(this.transform);
            }
        }
    }
    protected void Start()
    {
        piecesController = FindObjectOfType<PiecesController>();
    }
    public virtual void HighlightCells(ChessPieceAbstract piece, Team team)
    {
        ClearHighlight();
        Highlight(piece.transform.position, piece.GetMoveOffsets(), team);
    }
    protected void Highlight(Vector3 piecePos, Vector2[][] moveOffsets, Team team)
    {
        piecesController = FindObjectOfType<PiecesController>();
        piecesController.SelectPiece(piecePos);
        
        foreach (Vector2[] offsetsLine in moveOffsets)
        {
            foreach (Vector2 offset in offsetsLine)
            {
                int x = 0;
                int z = 0;

                if (team == Team.White)
                {
                    x = (int)(piecePos.x + offset.x);
                    z = (int)(piecePos.z + offset.y);
                }
                else if (team == Team.Black)
                {
                    x = (int)(piecePos.x - offset.x);
                    z = (int)(piecePos.z - offset.y);
                }

                if (x >= 0 && z >= 0 && x < 8 && z < 8)
                {
                    //Debug.Log(x +";"+ z + "   " + boardCells[x,z].isEmpty());
                    if (boardCells[x,z].isOccupied() && boardCells[x,z].getOccupiedTeam() == team) break;

                    boardCells[x, z].GetComponent<MeshRenderer>().material = highlightM;
                    highlightedCells.Add(new Vector2Int(x, z));

                    if (!boardCells[x,z].isEmpty()) break;
                }
            }
        }
    }
    public virtual void TryMovePiece(Vector3 cellPos)
    {
        int x = (int)cellPos.x;
        int z = (int)cellPos.z;

        if (isHighlighted(cellPos))
        {
            if (isEmpty(x, z))
            {
                piecesController.StartMovingPiece(cellPos);
                ClearHighlight();
            }
            else if (isOccupied(x, z))
            {
                Debug.LogWarning("TakePIECE");
                piecesController.TakePiece(cellPos);
                piecesController.StartMovingPiece(cellPos);
                ClearHighlight();
            }
        }
    }
    protected void ClearHighlight()
    {
        if (highlightedCells.Count < 1) return;

        foreach (Vector2Int cellPos in highlightedCells)
        {
            boardCells[cellPos.x, cellPos.y].GetComponent<MeshRenderer>().material = (cellPos.x%8+cellPos.y) % 2 == 0? blackM : whiteM;;
        }
        highlightedCells.Clear();

        piecesController.ClearHighlight();
    }
    public bool isHighlighted(Vector3 cell)
    {
        if (highlightedCells.Contains(new Vector2Int((int)cell.x, (int)cell.z))) return true;
        return false;
    }
    public void setEmpty(int x, int z)
    {
        boardCells[x, z].setEmpty();
    }
    public void setOccupied(int x, int z, Team team)
    {
        boardCells[x, z].setOccupied(team);
    }
    public bool isEmpty(int x, int z)
    {
        return boardCells[x, z].isEmpty();
    }
    public bool isOccupied(int x, int z)
    {
        return boardCells[x, z].isOccupied();
    }
}

public enum Team: byte 
{
    Empty,
    White,
    Black,
    Spectator
}