using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    private int currency;

    [SerializeField]
    private TMP_Text textMeshProGui;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Currency Manager instance!");
        }

        Instance = this;

        currency = SaveSystem.loadCurrency() ?? 1600;
    }

    void Update()
    {
        textMeshProGui.text = currency.ToString();
    }

    public void AddToCurrency(int rate)
    {
        currency += rate;
    }

    public void RemoveFromCurrency(int rate)
    {
        if (currency >= rate)
        {
            currency -= rate;
        }
    }

    public void OnApplicationQuit()
    {
        SaveSystem.SaveCurrency(currency);
    }
}
