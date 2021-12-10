using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieceAbstract : MonoBehaviour
{
    protected Vector2[] moveOffsets;
    protected abstract void Start();
    public Vector2[] GetMoveOffsets() {
        return moveOffsets;
    }
}
