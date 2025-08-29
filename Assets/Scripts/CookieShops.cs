using System.Collections;
using UnityEngine;

public class CookieShops : MonoBehaviour
{
    private float originalTime = 300f;
    private float reduceTime = 0f;
    private float remainingTime = 300f;
    private int rate = 1;
    private Characters_SO cookie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void SetCookie(Characters_SO characters_SO)
    {
        if (cookie != null) return;
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
    }

    public void RemoveCookie()
    {
        cookie = null;
        remainingTime += reduceTime;
        reduceTime = 0f;
    }

    private void AddCurrency()
    {
        CurrencyManager.Instance.AddToCurrency(rate);
    }
}
