using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBluePlayer : ChargeOrgone
{


    public override void ChargeOrgone1(int cost)
    {
        if (MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(1, 2))
        {
            List<GameObject> unitList = new List<GameObject>();

            unitList.AddRange(PlayerScript.Instance.UnitRef.UnitListBluePlayer);

            GameManager.Instance.StartEventModeUnit(1, true, unitList, "Charge d'orgone 1", "Êtes-vous sur de vouloir augmenter d'1 les dégâts de cete unité?");
            GameManager.Instance._eventCall += UseChargeOrgone1;

        }
    }

    void UseChargeOrgone1()
    {
        UIInstance.Instance.ActivateNextPhaseButton();


        GameManager.Instance.UnitChooseList[0].GetComponent<UnitScript>().AddDamageToUnit(1);
        GameManager.Instance.UnitChooseList[0].GetComponent<UnitScript>().DoingCharg1Blue = true;


        GameManager.Instance.UnitChooseList.Clear();
        EndOrgoneUpdate(1, 2);
    }

    public override void ChargeOrgone3(int cost)
    {
        if (MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(3, 2))
        {
            List<GameObject> tileList = new List<GameObject>();
            tileList.AddRange(TilesManager.Instance.ResourcesList);

            GameManager.Instance.StartEventModeTiles(1, true, tileList, "Charge d'orgone 3", "Êtes-vous sur de vouloir voler une Ressources sur cette case?");
            GameManager.Instance._eventCall += UseChargeOrgone3;
        }
    }
    void UseChargeOrgone3()
    {
        UIInstance.Instance.ActivateNextPhaseButton();

        foreach (GameObject gam in GameManager.Instance.TileChooseList)
        {
            gam.GetComponent<TileScript>().RemoveRessources(1, 2);
        }
        GameManager.Instance.TileChooseList.Clear();
        EndOrgoneUpdate(3, 2);
    }

    #region Charge 5 D'orgone
    public override void ChargeOrgone5(int cost)
    {
        if (MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(4, 2))
        {
            List<GameObject> unitList = new List<GameObject>();

            unitList.AddRange(PlayerScript.Instance.UnitRef.UnitListBluePlayer);

            GameManager.Instance.StartEventModeUnit(1, false, unitList, "Bombardement Aérien", "Êtes-vous sur de vouloir séléctionner cette unité?");
            GameManager.Instance._eventCall += MoveChargeOrgone5;
            unitList.Clear();
        }
    }

    void MoveChargeOrgone5()
    {
        List<GameObject> SelectTileList = new List<GameObject>();

        foreach (GameObject gam in TilesManager.Instance.TileList)
        {
            TileScript tilescript = gam.GetComponent<TileScript>();
            Debug.Log(tilescript.TileId);
            if (tilescript.Unit == null)
            {
                Debug.Log("Unit est null");
                foreach (MYthsAndSteel_Enum.TerrainType i in tilescript.TerrainEffectList)
                {
                    if (i != MYthsAndSteel_Enum.TerrainType.Point_de_ressource && i != MYthsAndSteel_Enum.TerrainType.Point_Objectif && i != MYthsAndSteel_Enum.TerrainType.UsineBleu && i != MYthsAndSteel_Enum.TerrainType.UsineRouge)
                    {
                        SelectTileList.Add(gam);
                        Debug.Log("break");
                        break;
                    }
                }
            }

            GameManager.Instance.StartEventModeTiles(1, false, SelectTileList, "Bombardement Aérien", "Êtes-vous sur de vouloir déplacer l'unité sur cette case?");
            GameManager.Instance._eventCall += DoneMoveChargeOrgone5;

        }
    }
    void DoneMoveChargeOrgone5()
    {
        GameManager.Instance.TileChooseList[0].GetComponent<TileScript>().AddUnitToTile(GameManager.Instance.UnitChooseList[0].gameObject);
        //GameManager.Instance.UnitChooseList[0].GetComponent<UnitScript>().ActualTiledId = GameManager.Instance.TileChooseList[0].GetComponent<TileScript>().TileId;
    }
    #endregion

}
