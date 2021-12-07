using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceAbstract : MonoBehaviour
{
    protected ChessBoardAbstract board;
    protected Vector2[] moveOffsets;
    protected virtual void Start()
    {
        board = FindObjectOfType<ChessBoardAbstract>();
    }
    public void HighlightPossibleMoves()
    {
        board.HighlightCells(transform.position, moveOffsets);
    }
    private void OnMouseDown() {
        Debug.Log("Click");
        HighlightPossibleMoves();
    }
}
