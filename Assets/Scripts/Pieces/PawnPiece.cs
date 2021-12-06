using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : ChessPieceAbstract
{
    protected override void Awake()
    {
        base.Awake();

        moveOffsets = new Vector2[2] {new Vector2(0, 1),new Vector2(0, 2)};
    }
}
