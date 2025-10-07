using System;
using UnityEngine;

public class Frame : MonoBehaviour
{
    private GameObject Cookie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cookie = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCookieAssigned(object sender, CookieAssignedArg e)
    {
        SpriteRenderer spriteRenderer = Cookie.GetComponent<SpriteRenderer>();
        Characters_SO characters_SO = CharacterListManager.Instance.GetCharacterByID(e.characterID);
        spriteRenderer.sprite = characters_SO.sprite;
    }
}
