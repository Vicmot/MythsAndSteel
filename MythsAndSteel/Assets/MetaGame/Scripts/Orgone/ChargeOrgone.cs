using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Orgone/Basic Orgone Power")]
public class ChargeOrgone : MonoBehaviour
{
    public bool DoingOrgoneCharge = false;
    //Est ce que les charges d'orgone appartient au joueur rouge
    [SerializeField] private bool _isRedOrgonePower = false;

    /// <summary>
    /// Fonction qui permet de créer une charge d'orgone
    /// </summary>
    /// <param name="cost"></param>
    public virtual void ChargeOrgone1(int cost)
    {
        Debug.Log("Charge 1");
        if (!MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(cost, _isRedOrgonePower ? 1 : 2)) return;
    }

    /// <summary>
    /// Fonction qui permet de créer une deuxième charge d'orgone
    /// </summary>
    /// <param name="cost"></param>
    /*public virtual void ChargeOrgone2(int cost){
        Debug.Log("Charge 2");
        if(!MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(cost, _isRedOrgonePower ? 1 : 2)) return;
    }*/

    /// <summary>
    /// Fonction qui permet de créer une troisième charge d'orgone
    /// </summary>
    /// <param name="cost"></param>
    public virtual void ChargeOrgone3(int cost)
    {
        Debug.Log("Charge 3");
        if (!MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(cost, _isRedOrgonePower ? 1 : 2)) return;
    }

    /// <summary>
    /// Fonction qui permet de créer une quatrième charge d'orgone
    /// </summary>
    /// <param name="cost"></param>
    /*public virtual void ChargeOrgone4(int cost){
        Debug.Log("Charge 4");
        if(!MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(cost, _isRedOrgonePower ? 1 : 2)) return;
    }*/

    /// <summary>
    /// Fonction qui permet de créer une cinquième charge d'orgone
    /// </summary>
    /// <param name="cost"></param>
    public virtual void ChargeOrgone5(int cost)
    {
        Debug.Log("Charge 5");
        if (!MythsAndSteel.Orgone.OrgoneCheck.CanUseOrgonePower(cost, _isRedOrgonePower ? 1 : 2)) return;
    }

    public void EndOrgoneUpdate(int Charge, int Player)
    {
        if (Player == 1)
        {
            if (PlayerScript.Instance.RedPlayerInfos.OrgoneValue >= Charge)
            {
                PlayerScript.Instance.RedPlayerInfos.OrgoneValue -= Charge;
            }
            else
            {
                PlayerScript.Instance.RedPlayerInfos.OrgoneValue = 0;

            }
            PlayerScript.Instance.RedPlayerInfos.UpdateOrgoneUI(Player);
        }
        else if (Player == 2)
        {
            if (PlayerScript.Instance.BluePlayerInfos.OrgoneValue >= Charge)
            {
                PlayerScript.Instance.BluePlayerInfos.OrgoneValue -= Charge;
            }
            else
            {
                PlayerScript.Instance.BluePlayerInfos.OrgoneValue = 0;

            }
            PlayerScript.Instance.BluePlayerInfos.UpdateOrgoneUI(Player);
        }
    }
}
