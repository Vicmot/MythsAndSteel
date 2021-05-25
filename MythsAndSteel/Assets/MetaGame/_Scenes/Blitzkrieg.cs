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
            List<GameObject> tile = new List<GameObject>();


            Debug.Log("oui");
            GameManager.Instance._eventCall += EndCpty;
            GameManager.Instance._eventCallCancel += StopCpty;
            Debug.Log("oui");
            GameManager.Instance.StartEventModeTiles(0, GetComponent<UnitScript>().UnitSO.IsInRedArmy, tile, "Blitzkrieg!", "Voulez-vous vraiment acquerir deux activations supplémentaire ce tour ?");
            Debug.Log("oui");
        }
        base.StartCpty();

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
        Debug.Log("oui");
        PlayerScript.Instance.RedPlayerInfos.Ressource -= Capacity1Cost;
        PlayerScript.Instance.RedPlayerInfos.ActivationLeft += 2;
        UIInstance.Instance.UpdateRessourceLeft();
        UIInstance.Instance.UpdateActivationLeft();
        Debug.Log("Inchallah");
        GameManager.Instance._eventCall -= EndCpty;
        GetComponent<UnitScript>().EndCapacity();
        base.EndCpty();
        GameManager.Instance.TileChooseList.Clear();
    }
}

