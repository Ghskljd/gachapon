using UnityEngine;

public class CharacterMenuButton : BuildingButtonsUI
{
    [SerializeField]
    private Transform CharacterMenuWindow;
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        CharacterMenuWindow.gameObject.SetActive(true);
    }
}
