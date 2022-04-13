using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : ChessPieceAbstract
{
    protected override void Start()
    {
        moveOffsets = new Vector2[][]{new Vector2[]{new Vector2(0, 1), new Vector2(0, 2)}};
        attackOffsets = null;
    }
    public override void AfterMove()
    {
        base.AfterMove();

        if (this.transform.position.z > 1 && this.transform.position.z != 8)
        {
            moveOffsets = new Vector2[][]{new Vector2[]{new Vector2(0, 1)}};
            attackOffsets = new Vector2[][]{new Vector2[]{new Vector2(-1, 1)}, new Vector2[]{new Vector2(1, 1)}};
        } else if (this.transform.position.z != 8)
        {
            Debug.Log("Change pawn to ...");
        }
    }
}
