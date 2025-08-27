using System;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D boxCollider2D;
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.BuildingClicked += EnableOrDisableMovement;
        GameManager.Instance.RemoveBuildingIcons += RemoveMovement; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        float x = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
        float y = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);

        Vector3 pos = new Vector3(x, y, 0);

        UnityEngine.Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
        //for now we will have worldpos.z = 0
        //in the future, check the layer this object is part of and change the z value based on the layer
        //this is to prevent overlapping dragging.
        worldPos.z = 0;
        transform.position = worldPos;
    }

    private void EnableOrDisableMovement(object sender, OnClickedArgs args)
    {
        if (GetComponentInChildren<Click>(true) == args.WhoGotClicked)
        {
            EnableMovement();
        }
        else
        {
            DisableMovement();
        }
    }

    private void RemoveMovement(object sender, System.EventArgs e)
    {
        DisableMovement();
    }

    private void EnableMovement()
    {
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
    }

    private void DisableMovement()
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
    }
}
