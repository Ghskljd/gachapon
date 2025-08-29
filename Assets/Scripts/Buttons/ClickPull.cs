using System;
using UnityEngine;

public class ClickPull : BuildingButtons
{
    public event EventHandler PullClicked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        PullClicked += GameManager.Instance.OnPullClicked;
    }

    protected override void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        base.OnDestroy();
        PullClicked -= GameManager.Instance.OnPullClicked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        PullClicked?.Invoke(this, EventArgs.Empty);
    }
}
