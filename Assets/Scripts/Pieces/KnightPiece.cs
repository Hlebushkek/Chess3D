using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        moveOffsets = new Vector2[][]
        {
            new Vector2[] {new Vector2(1, 2)},
            new Vector2[] {new Vector2(-1, 2)},
            new Vector2[] {new Vector2(2, 1)},
            new Vector2[] {new Vector2(-2, 1)},
            new Vector2[] {new Vector2(2, -1)},
            new Vector2[] {new Vector2(-2, -1)},
            new Vector2[] {new Vector2(1, -2)},
            new Vector2[] {new Vector2(-1, -2)}
        };
    }
}
