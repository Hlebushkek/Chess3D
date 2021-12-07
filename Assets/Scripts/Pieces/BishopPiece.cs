using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        base.Start();
        
        moveOffsets = new Vector2[4 * 8];
        for (int i = 0; i < 8; i++)
        {
            moveOffsets[4*i+0] = new Vector2(i, i);
            moveOffsets[4*i+1] = new Vector2(-i, i);
            moveOffsets[4*i+2] = new Vector2(i, -i);
            moveOffsets[4*i+3] = new Vector2(-i, -i);
        }
    }
}
