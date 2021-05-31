using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonAssign : MonoBehaviour
{
    [SerializeField] bool isArmy1;
    [SerializeField] GameObject Army1;
    [SerializeField] GameObject Army2;
    [SerializeField] GameObject informationPanel;
    [SerializeField] GameObject homePanel;

    [SerializeField] Unit_SO UnitShown;
    [SerializeField] TextMeshProUGUI UnitName;
    [SerializeField] TextMeshProUGUI UnitLore;
    [SerializeField] GameObject UnitImage;
    [SerializeField] TextMeshProUGUI UnitLife;
    [SerializeField] TextMeshProUGUI UnitRange;
    [SerializeField] TextMeshProUGUI UnitMovement;
    [SerializeField] TextMeshProUGUI UnitType;

    public void showArmy1()
    {
        if (!isArmy1)
        {
            Army1.SetActive(true);
            Army2.SetActive(false);
        }
    }

    public void showArmy2()
    {
        if (isArmy1)
        {
            Army1.SetActive(false);
            Army2.SetActive(true);
        }
    }

    public void UnitButton()
    {
        /*if (informationPanel != null)
        {
            informationPanel.SetActive(false);
        }*/
        //informationPanel = EventSystem.current.currentSelectedGameObject.transform.GetChild(1).gameObject;
        informationPanel.SetActive(true);
        homePanel.SetActive(false);

        UnitShown = EventSystem.current.currentSelectedGameObject.GetComponent<Encyclopedie_Unit>().AssociatedUnit;
        UnitName.SetText(UnitShown.UnitName);
        UnitLore.SetText(UnitShown.Description);
        UnitImage.GetComponent<Image>().sprite = UnitShown.Sprite;
        UnitLife.SetText(UnitShown.LifeMax.ToString());
        UnitRange.SetText(UnitShown.AttackRange.ToString());
        UnitMovement.SetText(UnitShown.MoveSpeed.ToString());
        UnitType.SetText(UnitShown.typeUnite.ToString());

    }


    public void OnEnable()
    {
        homePanel.SetActive(true);
        informationPanel.SetActive(false);
    }
}
