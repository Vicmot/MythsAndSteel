using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blitzkrieg : Capacity
{
    public override void StartCpty()
    {

        int ressourcePlayer = PlayerScript.Instance.RedPlayerInfos.Ressource;
        if (ressourcePlayer >= Capacity1Cost)
        {
            PlayerScript.Instance.RedPlayerInfos.ActivationLeft += 2;
        }
        base.StartCpty();

        GameManager.Instance._eventCall += EndCpty;
        GameManager.Instance._eventCallCancel += StopCpty;
    }

    public override void StopCpty()
    {
        GameManager.Instance.StopEventModeTile();
        GameManager.Instance.TileChooseList.Clear();
        GetComponent<UnitScript>().StopCapacity(true);
        base.StopCpty();
    }

    public override void EndCpty()
    {
        PlayerScript.Instance.BluePlayerInfos.Ressource -= Capacity1Cost;

        GameManager.Instance._eventCall -= EndCpty;
        GetComponent<UnitScript>().EndCapacity();
        base.EndCpty();
        GameManager.Instance.TileChooseList.Clear();
    }
}

