using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        moveOffsets = new Vector2[][]
        {
            new Vector2[] {new Vector2(-1, 1)}, new Vector2[] {new Vector2(0, 1)}, new Vector2[] {new Vector2(1, 1)},
            new Vector2[] {new Vector2(-1, 0)},                                    new Vector2[] {new Vector2(1, 0)},
            new Vector2[] {new Vector2(-1,-1)}, new Vector2[] {new Vector2(0,-1)}, new Vector2[] {new Vector2(1,-1)}
        };

        base.Start();
    }
    public override void OnDeath()
    {
        base.OnDeath();

        FindObjectOfType<ChessBoardAbstract>().EndRound(team);
    }
}
