using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieceAbstract : MonoBehaviour
{
    private Material standardMaterial, highlightMaterial;
    protected Vector2[][] moveOffsets;
    protected Team team;
    protected abstract void Start();
    public Vector2[][] GetMoveOffsets() {
        return moveOffsets;
    }
    public void SetMaterials(Material standardM, Material highlightM)
    {
        standardMaterial = standardM;
        highlightMaterial = highlightM;
    }
    public Team getTeam()
    {
        return team;
    }
    public void setTeam(Team t)
    {
        team = t;
    }
    public void selectSelf() 
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<MeshRenderer>().material = highlightMaterial;
        }
    }
    public void deselectSelf()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<MeshRenderer>().material = standardMaterial;
        }
    }
}
