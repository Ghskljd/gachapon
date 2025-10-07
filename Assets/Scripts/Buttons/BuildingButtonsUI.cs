using System;
using UnityEngine;

public class BuildingButtonsUI : MonoBehaviour
{
    public event EventHandler OnButtonClicked;
    protected virtual void Awake()
    {
        gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        OnButtonClicked += UIManager.Instance.OnWindowChange;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void OnMouseDown()
    {
        OnButtonClicked?.Invoke(this, EventArgs.Empty);
    }
}
