using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    void Awake()
    {

    }

    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector2 mousePos2D = new Vector2(mouseWorld.x, mouseWorld.y);

        Collider2D hit = Physics2D.OverlapPoint(mousePos2D);
        if (hit != null && (hit.gameObject == gameObject || hit.gameObject.transform.IsChildOf(transform)))
        {
            SetChildrenActive(true);
        }
        else
        {
            SetChildrenActive(false);
        }
    }

    void SetChildrenActive(bool active)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.layer == LayerMask.NameToLayer("Ignore Hover"))
            {
                continue;
            }
            child.gameObject.SetActive(active);
        }
    }
}
