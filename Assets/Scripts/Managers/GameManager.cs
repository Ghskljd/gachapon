using System;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //this textmeshpro variable is just for testing purpose
    [SerializeField]
    private TMP_Text textMeshProGui;
    [SerializeField]
    public Transform CharacterMenu;
    [SerializeField]
    public Transform BuildingMenu;
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

    public void OnAssignCharacter(string characterID, CookieShops cookieShop)
    {
        if (cookieShop == null) return;

        Characters_SO characters_SO = CharacterListManager.Instance.GetCharacterByID(characterID);
        if (CharacterListManager.Instance.RemoveFromPlayerCollection(characters_SO))
        {
            if (!cookieShop.SetCookie(characters_SO))
            {
                CharacterListManager.Instance.AddToPlayerCollection(characters_SO);
            }
        }
    }

    public void OnBuyBuilding(string buildingID)
    {
        BuildingSO buildingSO = BuildingsManager.Instance.GetBuildingByID(buildingID);
        if (CurrencyManager.Instance.RemoveFromCurrency(buildingSO.cost))
        {
            BuildingsManager.Instance.InstantiateBuildings(buildingID);
        }
    }
}
