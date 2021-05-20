using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoinImmobilisation : Capacity
{
    public override void StartCpty()
    {
        

            GameManager.Instance._eventCall += EndCpty;
            GameManager.Instance._eventCallCancel += StopCpty;
            GameManager.Instance.StartEventModeTiles(1, GetComponent<UnitScript>().UnitSO.IsInRedArmy, tile, "Embrasement!", "Voulez-vous vraiment embraser cette case ?");

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
        
    }
}
