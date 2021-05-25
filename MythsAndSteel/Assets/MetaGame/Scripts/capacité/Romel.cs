using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Romel : Capacity
{

    GameObject usine;
    [SerializeField] Unit_SO TransformationRomel;

    public override void StartCpty()
    {
        List<GameObject> tilelist = new List<GameObject>();
        if (GameManager.Instance.IsPlayerRedTurn)
        {
            foreach (GameObject gam in TilesManager.Instance.TileList)
            {
                if (gam.GetComponent<TileScript>().TerrainEffectList.Contains(MYthsAndSteel_Enum.TerrainType.UsineRouge))
                {
                    usine = gam;
                    break;
                }
            }
        }
        else
        {
            foreach (GameObject gam in TilesManager.Instance.TileList)
            {
                if (gam.GetComponent<TileScript>().TerrainEffectList.Contains(MYthsAndSteel_Enum.TerrainType.UsineBleu))
                {
                    usine = gam;
                    break;
                }
            }
        }

        List<int> unitNeigh = PlayerStatic.GetNeighbourDiag(usine.GetComponent<TileScript>().TileId, TilesManager.Instance.TileList[usine.GetComponent<TileScript>().TileId].GetComponent<TileScript>().Line, false);
        foreach (int i in unitNeigh)
        {
            if (GetComponent<UnitScript>().ActualTiledId == i)
            {
                Debug.Log("wsh wsh");
                UIInstance.Instance.ShowValidationPanel(Capacity1Name, "Êtes-vous sûr de vouloir utiliser la transformation de Romel ?");
                GameManager.Instance._eventCall += EndCpty;
            }
            //tilelist.Add(TilesManager.Instance.TileList[i]);
        }

    }

    public override void EndCpty()
    {
        Debug.Log("CA MARCHEEEEEEEEEE");
        //GetComponent<UnitScript>().UnitSO = TransformationRomel;
        if (TransformationRomel != null) GetComponent<UnitScript>().UnitSO = TransformationRomel;
        else Debug.Log("debug");
        //GetComponent<UnitScript>().UpdateUnitStat();
    }

    public override void StopCpty()
    {

    }
}
