using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveManagerJSON SaveManager;
    public PurchasingData PurchasingData;

    private void Start()
    {
        SaveManager = GetComponent<SaveManagerJSON>();
        try
        {
            LoadGameData();
        }
        catch (Exception exception)
        {
            Debug.LogWarning("Не вдалося завантажити гру. " + exception.Message);
        }
    }

    [ContextMenu("Load Data")]
    public void LoadGameData()
    {
        SaveManager = GetComponent<SaveManagerJSON>();
        PurchasingData = SaveManager.LoadPurchasedObjects<PurchasingData>();

        if (PurchasingData == null)
            PurchasingData = new PurchasingData();
    }

    [ContextMenu("Save Data")]
    public void SaveGameData()
    {
        SaveManager = GetComponent<SaveManagerJSON>();
        SaveManager.SavePurchasedObjects(PurchasingData);
    }
}




