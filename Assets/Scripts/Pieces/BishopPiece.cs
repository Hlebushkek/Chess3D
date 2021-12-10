using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        moveOffsets = new Vector2[4 * 7];
        for (int i = 1; i < 8; i++)
        {
            moveOffsets[4*(i-1)+0] = new Vector2(i, i);
            moveOffsets[4*(i-1)+1] = new Vector2(-i, i);
            moveOffsets[4*(i-1)+2] = new Vector2(i, -i);
            moveOffsets[4*(i-1)+3] = new Vector2(-i, -i);
        }
    }
}
