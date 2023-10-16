using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRemove : MonoBehaviour
{
    public GameObject Pannel;
    public void ShowRemove()
    {
        bool isActive = Pannel.activeSelf;
        if (Pannel != null)
        {
            Pannel.SetActive(!isActive);
        }
    }
}
