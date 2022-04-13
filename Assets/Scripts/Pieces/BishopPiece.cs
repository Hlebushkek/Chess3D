using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : ChessPieceAbstract
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
            moveOffsets[0][i-1] = new Vector2(i, i);
            moveOffsets[1][i-1] = new Vector2(-i, i);
            moveOffsets[2][i-1] = new Vector2(i, -i);
            moveOffsets[3][i-1] = new Vector2(-i, -i);
        }

        base.Start();
    }
}
