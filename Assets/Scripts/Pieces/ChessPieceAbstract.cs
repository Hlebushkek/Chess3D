using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceAbstract : MonoBehaviour
{
    protected ChessBoard board;
    protected Vector2[] moveOffsets;
    virtual protected void Awake()
    {
        board = FindObjectOfType<ChessBoard>();
    }
    private void HighlightPossibleMove()
    {
        board.HighlightCells(transform.position, moveOffsets);
    }
    private void MakeMove()
    {

    }
    private void OnMouseDown() {
        Debug.Log("Click");
        HighlightPossibleMove();
    }
}
