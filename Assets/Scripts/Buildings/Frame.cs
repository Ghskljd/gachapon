using System;
using UnityEngine;

public class Frame : MonoBehaviour
{
    private GameObject Cookie;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CookieShops cookieShops = GetComponentInParent<CookieShops>();
        cookieShops.CookieAssigned += OnCookieAssigned;
        cookieShops.CookieRemoved += OnCookieRemoved;
        
        Cookie = transform.GetChild(0).gameObject;
        spriteRenderer = Cookie.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCookieAssigned(object sender, CookieAssignedArg e)
    {
        Characters_SO characters_SO = CharacterListManager.Instance.GetCharacterByID(e.characterID);
        spriteRenderer.sprite = characters_SO.sprite;
    }

    public void OnCookieRemoved(object sender, EventArgs e)
    {
        spriteRenderer.sprite = null;
    }
}
