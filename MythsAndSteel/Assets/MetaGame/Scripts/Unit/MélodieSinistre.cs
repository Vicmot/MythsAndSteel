using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MélodieSinistre : Capacity
{




    public override void StartCpty()
    {
   
        
            List<GameObject> unit = new List<GameObject>();

            foreach (GameObject T in gameObject.GetComponent<UnitScript>().UnitSO.IsInRedArmy ? PlayerScript.Instance.UnitRef.UnitListBluePlayer : PlayerScript.Instance.UnitRef.UnitListRedPlayer)
            {
                if (T.GetComponent<UnitScript>().UnitSO.typeUnite == MYthsAndSteel_Enum.TypeUnite.Infanterie || T.GetComponent<UnitScript>().UnitSO.typeUnite == MYthsAndSteel_Enum.TypeUnite.Leader || T.GetComponent<UnitScript>().UnitSO.typeUnite == MYthsAndSteel_Enum.TypeUnite.Artillerie)
                {
                    unit.Add(T);
                }
            }


            GameManager.Instance._eventCall += EndCpty;
            GameManager.Instance._eventCallCancel += StopCpty;
            GameManager.Instance.StartEventModeUnit(1, GetComponent<UnitScript>().UnitSO.IsInRedArmy, unit, "Mélodie Sinistre", "Voulez vous activer une unité adverse de type Leader, Infanterie ou Artillerie durant un tour ?");

        

        base.StartCpty();
    }

    public override void StopCpty()
    {
        GameManager.Instance.StopEventModeUnit();
        GameManager.Instance.UnitChooseList.Clear();
        GetComponent<UnitScript>().StopCapacity(true);
        base.StopCpty();
    }

    public override void EndCpty()
    {

        GetComponent<UnitScript>().EndCapacity();
        foreach (GameObject unit in GameManager.Instance.UnitChooseList)
        {
            unit.GetComponent<UnitScript>().AddStatutToUnit(MYthsAndSteel_Enum.UnitStatut.Possédé);
            unit.GetComponent<UnitScript>().MélodieSinistre = true;
        }
        GameManager.Instance.possesion = true;
  
        base.EndCpty();
        GameManager.Instance.UnitChooseList.Clear();
        GameManager.Instance._eventCall -= EndCpty;
    }
}
