using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class AipManager : MonoBehaviour
{
    private string removeAds = "com.tisi.arihockey.removeads";
    public GameObject restoreButton;
    private void Awake()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restoreButton.SetActive(false);
        }
    }

    public void OnPurchaseCompulete(Product product)
    {
        if(product.definition.id == removeAds)
        {
            Debug.Log("all ads remove");
        }
    }
    public void OnPruchseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + "failed becase" + failureReason);
    }
}
