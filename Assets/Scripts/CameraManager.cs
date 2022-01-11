using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static Team selfTeam = Team.Spectator;
    public void SetTeam(Team t)
    {
        selfTeam = t;

        if (selfTeam == Team.Black)
        {
            this.transform.position += new Vector3(0, 0, 14);
            this.transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
    public static Team getTeam()
    {
        return selfTeam;
    }
}
