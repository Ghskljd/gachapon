using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : WindowUI
{
    [SerializeField]
    private Transform CharacterDisplayUIPrefab;
    [SerializeField]
    private Transform ContentArea;
    private CookieShops currentCookieShop;
    void Awake()
    {
        gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        DisplayCharacters(CharacterListManager.Instance.PlayerCollection);
    }

    private void DisplayCharacters(Dictionary<Characters_SO, int> Characters)
    {
        List<Characters_SO> characters_SOs = Characters.Keys.ToList();
        characters_SOs.Sort();
        for (int i = 0; i < characters_SOs.Count; i++)
        {
            Characters_SO character = characters_SOs[i];
            Transform CreatedCharacterDisplay = Instantiate(CharacterDisplayUIPrefab);

            UnityEngine.UI.Image imageSprite = CreatedCharacterDisplay.GetComponent<UnityEngine.UI.Image>();
            TMP_Text text = CreatedCharacterDisplay.GetComponentInChildren<TMP_Text>();
            CharacterDisplay characterDisplay = CreatedCharacterDisplay.GetComponent<CharacterDisplay>();

            imageSprite.sprite = character.sprite;
            text.text = Characters[character].ToString();
            characterDisplay.setCharacter_so(character);
            characterDisplay.setCookieShop(currentCookieShop);

            CreatedCharacterDisplay.transform.SetParent(ContentArea);
            CreatedCharacterDisplay.transform.SetSiblingIndex(i);
        }
    }

    public override void Exit()
    {
        foreach (Transform child in ContentArea.transform)
        {
            Destroy(child.gameObject);
        }

        currentCookieShop = null;
        base.Exit();
    }

    public void setCurrentCookieShop(CookieShops shop)
    {
        currentCookieShop = shop;
    }
}
