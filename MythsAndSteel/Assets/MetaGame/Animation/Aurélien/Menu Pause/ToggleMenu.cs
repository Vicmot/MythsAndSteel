using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    [SerializeField] private GameObject Grille;
    public void Toggle_Change(bool Value)
    {
        if (Value == false)
        {
            Grille.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        }
        if (Value == true)
        {
            Grille.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 50);
        }
    }
}
