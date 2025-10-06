using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //this textmeshpro variable is just for testing purpose
    [SerializeField]
    private TMP_Text textMeshProGui;
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one GameManager instance!");
        }

        Instance = this;
    }

    void Update()
    {

    }

    public void OnPullClicked(int rate, int pulls)
    {
        //check if they have enough currency first
        if (!CurrencyManager.Instance.RemoveFromCurrency(rate)) return;

        List<Characters_SO> pulledCharacters = GachaManager.Instance.OnPullClicked(pulls);

        foreach (Characters_SO character in pulledCharacters)
        {
            CharacterListManager.Instance.AddToPlayerCollection(character);
        }
    }
}
