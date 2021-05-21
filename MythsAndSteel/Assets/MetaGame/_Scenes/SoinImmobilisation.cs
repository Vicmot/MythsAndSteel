using System.Collections.Generic;
using UnityEngine;

public class SoinImmobilisation : Capacity
{
    public override void StartCpty()
    {
        int tileId = RaycastManager.Instance.ActualUnitSelected.GetComponent<UnitScript>().ActualTiledId;
        List<GameObject> tile = new List<GameObject>();

        foreach (int T in PlayerStatic.GetNeighbourDiag(tileId, TilesManager.Instance.TileList[tileId].GetComponent<TileScript>().Line, false))
        {
            if (TilesManager.Instance.TileList[T] != null)
            {
                if (TilesManager.Instance.TileList[T].GetComponent<TileScript>().Unit != RaycastManager.Instance.ActualUnitSelected)
                {
                    tile.Add(TilesManager.Instance.TileList[T]);
                }
            }
        }


        GameManager.Instance._eventCall += EndCpty;
        GameManager.Instance._eventCallCancel += StopCpty;
        GameManager.Instance.StartEventModeTiles(1, GetComponent<UnitScript>().UnitSO.IsInRedArmy, tile, "Soin/Immobilisation", "Voulez-vous vraiment soigner/immobiliser cette unitée ?");
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
        GameObject TileChoose = GameManager.Instance.TileChooseList[0];
        if (TileChoose.GetComponent<TileScript>().Unit.GetComponent<UnitScript>().UnitSO.IsInRedArmy == true)
        {
            TileChoose.GetComponent<TileScript>().Unit.GetComponent<UnitScript>().AddStatutToUnit(MYthsAndSteel_Enum.UnitStatut.Immobilisation);
        }
        else
        {
            TileChoose.GetComponent<TileScript>().Unit.GetComponent<UnitScript>().Life += 2;
        }
        GetComponent<UnitScript>().EndCapacity();
        base.EndCpty();
    }
}
