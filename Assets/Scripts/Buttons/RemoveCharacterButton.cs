using System;
using UnityEngine;

public class RemoveCharacterButton : BuildingButtonsUI
{
    private CookieShops cookieShops;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        
    }

    protected override void Start()
    {
        base.Start();
        if (cookieShops == null)
        {
            cookieShops = GetComponentInParent<CookieShops>();
            Debug.Log("I worked");
        }

        cookieShops.CookieAssigned += OnCookieSet;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnMouseDown()
    {
        cookieShops.RemoveCookie();
        gameObject.layer = LayerMask.NameToLayer("Ignore Hover");
        base.OnMouseDown();
        gameObject.SetActive(false);
    }

    private void OnCookieSet(object sender, CookieAssignedArg e)
    {
        gameObject.SetActive(true);
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

}
