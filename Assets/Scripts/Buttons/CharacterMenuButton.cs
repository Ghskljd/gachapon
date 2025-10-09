using System.Net;
using UnityEngine;

public class CharacterMenuButton : BuildingButtonsUI
{
    [SerializeField]
    private Transform CharacterMenuWindow;
    private CookieShops cookieShops;
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        if (cookieShops == null)
        {
            cookieShops = transform.parent.GetComponent<CookieShops>();
        }

        CharacterMenuWindow = GameManager.Instance.CharacterMenu;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        CharacterMenu characterMenu = CharacterMenuWindow.GetComponent<CharacterMenu>();
        characterMenu.setCurrentCookieShop(cookieShops);
        CharacterMenuWindow.gameObject.SetActive(true);
    }
}
