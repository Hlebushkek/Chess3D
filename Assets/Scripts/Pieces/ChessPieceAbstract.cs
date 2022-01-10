using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieceAbstract : MonoBehaviour
{
    protected Vector2[][] moveOffsets;
    protected Team team;
    protected abstract void Start();
    public Vector2[][] GetMoveOffsets() {
        return moveOffsets;
    }
    public Team getTeam()
    {
        return team;
    }
    public void setTeam(Team t)
    {
        team = t;
    }
}
