using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [Header("Cells Prop")]
    [SerializeField] private GameObject boardCellPref;
    [SerializeField] private Material blackM, whiteM;
    [SerializeField] private Material highlightM;

    private Transform[,] boardCells = new Transform[8, 8];
    private List<Vector2Int> highlightedCells = new List<Vector2Int>();

    private void Awake()
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
    public void HighlightCells(Vector3 piecePos, Vector2[] moveOffsets)
    {
        ClearHighlight();

        foreach (Vector2 offset in moveOffsets)
        {
            int x = (int)(piecePos.x + offset.x);
            int z = (int)(piecePos.z + offset.y);
            boardCells[x, z].GetComponent<MeshRenderer>().material = highlightM;
            highlightedCells.Add(new Vector2Int(x, z));
        }
    }
    private void ClearHighlight()
    {
        foreach (Vector2Int cellPos in highlightedCells)
        {
            boardCells[cellPos.x, cellPos.y].GetComponent<MeshRenderer>().material = (cellPos.x%8+cellPos.y) % 2 == 0? blackM : whiteM;;
        }
        highlightedCells.Clear();
    }
}
