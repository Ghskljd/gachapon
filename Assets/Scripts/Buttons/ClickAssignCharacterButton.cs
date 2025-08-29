using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ClickAssignCharacterButton : BuildingButtons
{
    [SerializeField]
    private GameObject AssignCookiePage;
    [SerializeField]
    private GameObject CharacterLayoutGroup;
    [SerializeField]
    private GameObject CharacterDisplayPrefab;
    private List<GameObject> ListOfCharacterDisplay = new List<GameObject>();
    private int commonIndex = 0;
    private int uncommonIndex = 1;
    private int rareIndex = 2;
    private int ultraRareIndex = 3;
    private int unicornRareIndex = 4;
    private int burntRareIndex = 5;
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    void OnMouseDown()
    {
        AssignCookiePage.SetActive(true);
        DisplayCharacters();
    }

    private void DisplayCharacters()
    {
        foreach (KeyValuePair<Characters_SO, int> keyValuePair in CharacterListManager.Instance.PlayerCollection)
        {
            GameObject CreatedCharacterDisplay = Instantiate(CharacterDisplayPrefab);
            UnityEngine.UI.Image spriteRenderer = CreatedCharacterDisplay.GetComponent<UnityEngine.UI.Image>();
            spriteRenderer.sprite = keyValuePair.Key.sprite;
            CreatedCharacterDisplay.transform.SetParent(CharacterLayoutGroup.transform, false);
            FitToViewport(spriteRenderer);
            switch (keyValuePair.Key.rarity)
            {
                default:
                case Rarity.Common:
                    CreatedCharacterDisplay.transform.SetSiblingIndex(commonIndex);
                    commonIndex++;
                    break;
                case Rarity.Uncommon:
                    CreatedCharacterDisplay.transform.SetSiblingIndex(commonIndex + 1);
                    uncommonIndex = commonIndex + 1;
                    break;
                case Rarity.Rare:
                    CreatedCharacterDisplay.transform.SetSiblingIndex(uncommonIndex + 1);
                    rareIndex = uncommonIndex + 1;
                    break;
                case Rarity.UltraRare:
                    CreatedCharacterDisplay.transform.SetSiblingIndex(rareIndex + 1);
                    ultraRareIndex = rareIndex + 1;
                    break;
                case Rarity.UnicornRare:
                    CreatedCharacterDisplay.transform.SetSiblingIndex(ultraRareIndex + 1);
                    unicornRareIndex = ultraRareIndex + 1;
                    break;
                case Rarity.Burnt:
                    CreatedCharacterDisplay.transform.SetSiblingIndex(unicornRareIndex + 1);
                    burntRareIndex = unicornRareIndex + 1;
                    break;
            }

            ListOfCharacterDisplay.Add(CreatedCharacterDisplay);
        }
    }

    public void FitToViewport(UnityEngine.UI.Image image)
    {
        RectTransform rt = image.rectTransform;

        // Get the size of the viewport and the sprite
        float viewportWidth = AssignCookiePage.GetComponent<RectTransform>().rect.width;
        float viewportHeight = AssignCookiePage.GetComponent<RectTransform>().rect.height;

        float spriteWidth = rt.rect.width;
        float spriteHeight = rt.rect.height;

        // Compute the scale factor to fit inside the viewport
        float scaleX = viewportWidth / spriteWidth;
        float scaleY = viewportHeight / spriteHeight;
        float scale = Mathf.Min(scaleX, scaleY); // maintain aspect ratio

        // Apply uniform scale
        rt.localScale = new Vector3(scale, scale, 1f);
    }

    protected override void DisableButton()
    {
        base.DisableButton();
        commonIndex = 0;
        uncommonIndex = 1;
        rareIndex = 2;
        ultraRareIndex = 3;
        unicornRareIndex = 4;
        burntRareIndex = 5;

        foreach (GameObject characterDisplay in ListOfCharacterDisplay)
        {
            Destroy(characterDisplay);
        }

        ListOfCharacterDisplay.Clear();

        AssignCookiePage.SetActive(false);
    }
}
