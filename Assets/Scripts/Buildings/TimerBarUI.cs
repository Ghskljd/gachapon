using System.Net;
using UnityEngine;

public class TimerBarUI : MonoBehaviour
{
    private float initialScaleX;
    private CookieShops cookieShops;
    void Awake()
    {
        initialScaleX = transform.localScale.x;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookieShops = GetComponentInParent<CookieShops>();
        if (cookieShops == null)
        {
            Debug.LogError("CANT FIND COOKIESHOP");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        float t = cookieShops.remainingTime / cookieShops.originalTime;
        Vector3 scale = transform.localScale;
        scale.x = initialScaleX * t;
        transform.localScale = scale;
    }
}
