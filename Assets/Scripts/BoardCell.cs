using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    [SerializeField] private State state = State.Empty;
    [SerializeField] private Team occupiedTeam = Team.Empty;
    public bool isEmpty()
    {
        if (state == State.Empty) return true;
        return false;
    }
    public bool isOccupied()
    {
        if (state == State.Occupied) return true;
        return false;
    }
    public void setEmpty()
    {
        state = State.Empty;
    }
    public void setOccupied(Team team)
    {
        state = State.Occupied;
        occupiedTeam = team;
    }
    public Team getOccupiedTeam()
    {
        return occupiedTeam;
    }
    enum State
    {
        Empty,
        Occupied
    }
}
