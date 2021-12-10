using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        moveOffsets = new Vector2[8 * 7];
        for (int i = 1; i < 8; i++)
        {
            moveOffsets[8*(i-1)+0] = new Vector2(0, i);
            moveOffsets[8*(i-1)+1] = new Vector2(0, -i);
            moveOffsets[8*(i-1)+2] = new Vector2(i, 0);
            moveOffsets[8*(i-1)+3] = new Vector2(-i, 0);

            moveOffsets[8*(i-1)+4] = new Vector2(i, i);
            moveOffsets[8*(i-1)+5] = new Vector2(-i, i);
            moveOffsets[8*(i-1)+6] = new Vector2(i, -i);
            moveOffsets[8*(i-1)+7] = new Vector2(-i, -i);
        }
    }
}
