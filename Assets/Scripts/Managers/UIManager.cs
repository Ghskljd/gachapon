using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ERROR: More than one UIManager");
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnWindowChange(object sender, EventArgs e)
    {
        WindowUI[] windows = GameObject.FindObjectsByType<WindowUI>(FindObjectsSortMode.None);
        foreach (WindowUI window in windows)
        {
            window.Exit();
        }
    }
}
