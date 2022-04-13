using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieceAbstract : MonoBehaviour
{
    private Material standardMaterial, highlightMaterial;
    protected Vector2[][] moveOffsets, attackOffsets;
    protected Team team;
    protected virtual void Start()
    {
        attackOffsets = moveOffsets;
    }
    public virtual void AfterMove()
    {
        
    }
    public virtual void OnDeath()
    {

    }
    public Vector2[][] GetMoveOffsets() {
        return moveOffsets;
    }
    public Vector2[][] GetAttackOffsets() {
        return attackOffsets;
    }
    public void InitPiece(Material standardM, Material highlightM, Team t)
    {
        standardMaterial = standardM;
        highlightMaterial = highlightM;
        team = t;
    }
    public Team getTeam()
    {
        return team;
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
