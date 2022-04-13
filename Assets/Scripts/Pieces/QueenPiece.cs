using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        moveOffsets = new Vector2[8][];

        for (int i = 0; i < 8; i++)
        {
            moveOffsets[i] = new Vector2[8];
        }

        for (int i = 1; i < 8; i++)
        {
            moveOffsets[0][i-1] = new Vector2(0, i);
            moveOffsets[1][i-1] = new Vector2(0, -i);
            moveOffsets[2][i-1] = new Vector2(i, 0);
            moveOffsets[3][i-1] = new Vector2(-i, 0);
            moveOffsets[4][i-1] = new Vector2(i, i);
            moveOffsets[5][i-1] = new Vector2(-i, i);
            moveOffsets[6][i-1] = new Vector2(i, -i);
            moveOffsets[7][i-1] = new Vector2(-i, -i);
        }
        
        base.Start();
    }
}
