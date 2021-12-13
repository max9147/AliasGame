using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour, IStoreListener
{
    public GameObject VIPButtonDuel;
    public GameObject VIPButtonTeam;

    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;
    private static string payID = "VIP";

    private bool isVIP = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("VIP"))
        {
            isVIP = true;
        }
        else
        {
            isVIP = false;
        }
    }

    private void Start()
    {
        if (storeController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (storeController != null && extensionProvider != null)
        {
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(payID, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyVIP()
    {
        if (storeController != null && extensionProvider != null)
        {
            Product product = storeController.products.WithID(payID);
            if (product != null && product.availableToPurchase) 
            {
                storeController.InitiatePurchase(product);
            }
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        extensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        if (!PlayerPrefs.HasKey("VIP"))
        {
            PlayerPrefs.SetInt("VIP", 0);
            isVIP = true;
            GameObject[] VIPS = GameObject.FindGameObjectsWithTag("VIP");
            foreach (var item in VIPS)
            {
                Destroy(item);
            }
            GetComponent<MenuNavigation>().CloseVIP();
        }
        return PurchaseProcessingResult.Complete;
    }

    public bool GetVIPStatus()
    {
        return isVIP;
    }

    public void RemoveVIP()
    {
        isVIP = false;
        PlayerPrefs.DeleteAll();
    }
}