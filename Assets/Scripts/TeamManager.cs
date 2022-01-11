using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TeamManager
{
    private static Team team = Team.White;
    public static void NextTurn()
    {
        if (team == Team.White) team = Team.Black;
        else if (team == Team.Black) team = Team.White;
    }
    public static Team GetCurrentTurnTeam()
    {
        return team;
    }
}
