using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        moveOffsets = new Vector2[4][];

        for (int i = 0; i < 4; i++)
        {
            moveOffsets[i] = new Vector2[7];
        }

        for (int i = 1; i < 8; i++)
        {
            moveOffsets[0][i-1] = new Vector2(0, i);
            moveOffsets[1][i-1] = new Vector2(0, -i);
            moveOffsets[2][i-1] = new Vector2(i, 0);
            moveOffsets[3][i-1] = new Vector2(-i, 0);
        }
    }
}
