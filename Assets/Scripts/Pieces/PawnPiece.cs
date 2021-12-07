using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        base.Start();
        moveOffsets = new Vector2[2] {new Vector2(0, 1), new Vector2(0, 2)};
    }
}
