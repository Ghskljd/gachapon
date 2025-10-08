using System;
using System.Collections;
using UnityEngine;

public class CookieShops : MonoBehaviour
{
    public float originalTime { get; private set; } = 50f;
    public float reduceTime { get;  private set; } = 0;
    public float remainingTime { get; private set; } = 50f;
    private int rate = 1;
    private Characters_SO cookie;
    private Frame frame;
    public event EventHandler<CookieAssignedArg> CookieAssigned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frame = GetComponentInChildren<Frame>();
        CharacterListManager.Instance.CharacterListManagerApplicationQuit += ApplicationQuit;
        CookieAssigned += UIManager.Instance.OnWindowChange;
        CookieAssigned += frame.OnCookieAssigned;
        StartCoroutine(RunTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTimeRate(float time, int rate)
    {
        originalTime = time;
        remainingTime = originalTime;
        this.rate = rate;
    }

    IEnumerator RunTimer()
    {
        while (true)
        {
            while (remainingTime > 0)
            {
                yield return null;
                remainingTime -= Time.unscaledDeltaTime;
            }

            AddCurrency();
            remainingTime = originalTime - reduceTime;
        }
    }

    public bool SetCookie(Characters_SO characters_SO)
    {
        if (cookie != null) return false;
        cookie = characters_SO;
        switch (cookie.rarity)
        {
            default:
            case Rarity.Common:
                break;
            case Rarity.Uncommon:
                reduceTime = originalTime / 8f;
                break;
            case Rarity.Rare:
                reduceTime = originalTime / 4f;
                break;
            case Rarity.UltraRare:
            case Rarity.UnicornRare:
            case Rarity.Burnt:
                reduceTime = originalTime / 2f;
                break;
        }

        remainingTime -= reduceTime;
        CookieAssigned?.Invoke(this, new CookieAssignedArg
        {
            characterID = characters_SO.ID
        });
        Debug.Log("set this shop with " + cookie.name);
        return true;
    }

    public void RemoveCookie()
    {
        if(cookie != null) CharacterListManager.Instance.AddToPlayerCollection(cookie);
        cookie = null;
        remainingTime += reduceTime;
        reduceTime = 0f;
    }

    private void AddCurrency()
    {
        CurrencyManager.Instance.AddToCurrency(rate);
    }

    private void ApplicationQuit(object sender, EventArgs e)
    {
        CharacterListManager.Instance.CharacterListManagerApplicationQuit -= ApplicationQuit;
        RemoveCookie();
    }
}

public class CookieAssignedArg : EventArgs
{
    public string characterID;
}