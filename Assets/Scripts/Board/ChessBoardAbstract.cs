using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using System.Linq;

public abstract class ChessBoardAbstract : MonoBehaviour
{
    [Header("Cells Prop")]
    [SerializeField] private GameObject boardCellPref;
    [SerializeField] protected Material blackM, whiteM;
    [SerializeField] protected Material highlightM;

    protected PiecesController piecesController;
    protected Transform[,] boardCells = new Transform[8, 8];
    protected List<Vector2Int> highlightedCells = new List<Vector2Int>();

    protected virtual void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                boardCells[i,j] = Instantiate(boardCellPref).transform;
                boardCells[i,j].localPosition = new Vector3(i, 0, j);
                boardCells[i,j].GetComponent<MeshRenderer>().material = (i%8+j) % 2 == 0? blackM : whiteM;
            }
        }
    }
    protected void Start()
    {
        piecesController = FindObjectOfType<PiecesController>();
    }
    public virtual void HighlightCells(ChessPieceAbstract piece)
    {
        ClearHighlight();
        Highlight(piece.transform.position, piece.GetMoveOffsets());
    }
    protected void Highlight(Vector3 piecePos, Vector2[] moveOffsets)
    {
        piecesController = FindObjectOfType<PiecesController>();
        piecesController.SelectPiece(piecePos);
        
        foreach (Vector2 offset in moveOffsets)
        {
            int x = (int)(piecePos.x + offset.x);
            int z = (int)(piecePos.z + offset.y);

            if (x >= 0 && z >= 0 && x < 8 && z < 8)
            {
                boardCells[x, z].GetComponent<MeshRenderer>().material = highlightM;
                highlightedCells.Add(new Vector2Int(x, z));
            }
        }
    }
    public virtual void MovePiece(Vector3 cellPos)
    {
        if (isHighlighted(cellPos))
        {
            piecesController.StartMovingPiece(cellPos);
            ClearHighlight();
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
}
