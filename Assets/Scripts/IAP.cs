using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;
    private static string VIPpayID = "vip";
    private static string AlcPayID = "theme_alc";
    private static string PayID18 = "theme_18";

    private bool isVIP = false;
    private bool hasAlc = false;
    private bool has18 = false;

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
        if (PlayerPrefs.HasKey("ThemeAlc"))
        {
            hasAlc = true;
        }
        else
        {
            hasAlc = false;
        }
        if (PlayerPrefs.HasKey("Theme18"))
        {
            has18 = true;
        }
        else
        {
            has18 = false;
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
        builder.AddProduct(VIPpayID, ProductType.NonConsumable);
        builder.AddProduct(AlcPayID, ProductType.NonConsumable);
        builder.AddProduct(PayID18, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);        
    }

    public void BuyVIP()
    {
        if (storeController != null && extensionProvider != null)
        {
            Product product = storeController.products.WithID(VIPpayID);
            if (product != null && product.availableToPurchase) 
            {
                storeController.InitiatePurchase(product);
            }
        }
    }

    public void BuyAlc()
    {
        if (storeController != null && extensionProvider != null)
        {
            Product product = storeController.products.WithID(AlcPayID);
            if (product != null && product.availableToPurchase)
            {
                storeController.InitiatePurchase(product);
            }
        }
    }

    public void Buy18()
    {
        if (storeController != null && extensionProvider != null)
        {
            Product product = storeController.products.WithID(PayID18);
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
        if (String.Equals(purchaseEvent.purchasedProduct.definition.id, VIPpayID, StringComparison.Ordinal))
        {
            if (!PlayerPrefs.HasKey("VIP"))
            {
                PlayerPrefs.SetInt("VIP", 0);
                isVIP = true;
                foreach (var item in GetComponent<InitializeThemes>().VIPButtons)
                {
                    Destroy(item);
                }
                GetComponent<MenuNavigation>().CloseVIP();
            }
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, AlcPayID, StringComparison.Ordinal))
        {
            if (!PlayerPrefs.HasKey("ThemeAlc"))
            {
                PlayerPrefs.SetInt("ThemeAlc", 0);
                hasAlc = true;
                GetComponent<MenuNavigation>().CloseDescription();
            }
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, PayID18, StringComparison.Ordinal))
        {
            if (!PlayerPrefs.HasKey("Theme18"))
            {
                PlayerPrefs.SetInt("Theme18", 0);
                has18 = true;
                GetComponent<MenuNavigation>().CloseDescription();
            }
        }
        return PurchaseProcessingResult.Complete;
    }

    public bool GetVIPStatus()
    {
        return isVIP;
    }

    public bool GetAlcStatus()
    {
        return hasAlc;
    }

    public bool Get18Status()
    {
        return has18;
    }
}