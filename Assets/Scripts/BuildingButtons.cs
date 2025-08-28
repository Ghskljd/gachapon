using UnityEngine;

public class BuildingButtons : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    [SerializeField]
    protected Collider2D Collider;
    [SerializeField]
    protected ClickBuilding clickBuildingScript;

    protected virtual void Awake()
    {
        Collider.enabled = false;
        spriteRenderer.enabled = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        GameManager.Instance.BuildingClicked += EnableOrDisableButton;
        GameManager.Instance.RemoveBuildingIcons += RemoveButton;
    }

    protected virtual void OnDestroy()
    {
        GameManager.Instance.BuildingClicked -= EnableOrDisableButton;
        GameManager.Instance.RemoveBuildingIcons -= RemoveButton;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void EnableOrDisableButton(object sender, OnClickedArgs args)
    {
        if (clickBuildingScript == args.WhoGotClicked)
        {
            EnableButton();
        }
        else
        {
            DisableButton();
        }
    }

    private void RemoveButton(object sender, System.EventArgs e)
    {
        DisableButton();
    }

    private void EnableButton()
    {
        spriteRenderer.enabled = true;
        Collider.enabled = true;
    }

    private void DisableButton()
    {
        spriteRenderer.enabled = false;
        Collider.enabled = false;
    }
}
