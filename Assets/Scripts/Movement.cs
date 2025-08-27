using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        worldPos.z = 0;
        transform.position = worldPos;
    }
}
