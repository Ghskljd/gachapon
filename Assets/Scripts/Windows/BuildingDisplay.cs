using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingDisplay : MonoBehaviour, IPointerClickHandler
{
    private string ID;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.OnBuyBuilding(ID);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetID(string ID)
    {
        this.ID = ID;
    }

}
