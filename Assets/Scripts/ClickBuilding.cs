using System;
using UnityEngine;

public class ClickBuilding : MonoBehaviour
{
    private static ClickBuilding clickable = null;

    public event EventHandler<OnClickedArgs> OnClicked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnClicked += GameManager.Instance.OnClickedBuilding;
    }

    void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        OnClicked -= GameManager.Instance.OnClickedBuilding;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (clickable == null)
        {
            clickable = this;
            OnClicked?.Invoke(this, new OnClickedArgs
            {
                WhoGotClicked = this
            });
        }
    }

    void OnMouseUp()
    {
        if (clickable == this)
        {
            clickable = null;
        }
    }
}

public class OnClickedArgs : EventArgs
{
    public ClickBuilding WhoGotClicked;
}
