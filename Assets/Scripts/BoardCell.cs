using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    private State state = State.Empty;
    public bool isEmpty()
    {
        if (state == State.Empty) return true;
        return false;
    }
    public void setEmpty()
    {
        state = State.Empty;
    }
    public void setOccupied()
    {
        state = State.Occupied;
    }
    enum State
    {
        Empty,
        Occupied
    }
}
