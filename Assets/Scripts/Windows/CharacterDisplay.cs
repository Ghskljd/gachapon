using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterDisplay : MonoBehaviour, IPointerClickHandler
{
    private Characters_SO characters_SO;
    private CookieShops cookieShop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        
    }

    public void setCharacter_so(Characters_SO character)
    {
        characters_SO = character;
    }

    public void setCookieShop(CookieShops shop)
    {
        cookieShop = shop;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("i got hit");
        GameManager.Instance.OnAssignCharacter(characters_SO.ID, cookieShop);
    }
}
