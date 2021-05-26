using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerison : Capacity
{
    public override void StartCpty()
    {
        int tileId = RaycastManager.Instance.ActualUnitSelected.GetComponent<UnitScript>().ActualTiledId;
        List<GameObject> tile = new List<GameObject>();

        int ressourcePlayer = GetComponent<UnitScript>().UnitSO.IsInRedArmy ? PlayerScript.Instance.RedPlayerInfos.Ressource : PlayerScript.Instance.BluePlayerInfos.Ressource;

        if (ressourcePlayer >= Capacity1Cost)
        {
           
            foreach (int T in PlayerStatic.GetNeighbourDiag(tileId, TilesManager.Instance.TileList[tileId].GetComponent<TileScript>().Line, false))
            {
               
                if (TilesManager.Instance.TileList[T] != null)
                {
          
                    if (TilesManager.Instance.TileList[T].GetComponent<TileScript>().Unit != RaycastManager.Instance.ActualUnitSelected && TilesManager.Instance.TileList[T].GetComponent<TileScript>().Unit != null)

                    {
                     
                        if (TilesManager.Instance.TileList[T].GetComponent<TileScript>().Unit.GetComponent<UnitScript>().UnitSO == GameManager.Instance.IsPlayerRedTurn)
                        {
                         
                        tile.Add(TilesManager.Instance.TileList[T]);
                        }
                    }
                }
            }

            GameManager.Instance._eventCall += EndCpty;
            GameManager.Instance._eventCallCancel += StopCpty;
            GameManager.Instance.StartEventModeTiles(1, false, tile, "Guérison", "Voulez-vous vraiment soigner cette unité ?");
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

      Player player = GameManager.Instance.IsPlayerRedTurn? PlayerScript.Instance.RedPlayerInfos : PlayerScript.Instance.BluePlayerInfos;
        GameManager.Instance.TileChooseList[0].GetComponent<TileScript>().Unit.GetComponent<UnitScript>().GiveLife(2);
            player.Ressource -= Capacity1Cost;
       
        GameManager.Instance._eventCall -= EndCpty;
        GetComponent<UnitScript>().EndCapacity();
        GameManager.Instance.TileChooseList.Clear();
    }
}
