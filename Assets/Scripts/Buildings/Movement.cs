using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
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
}
