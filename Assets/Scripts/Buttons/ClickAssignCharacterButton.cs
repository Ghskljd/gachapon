using System.Collections.Generic;
using System.Linq;
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
        List<Characters_SO> keys = CharacterListManager.Instance.PlayerCollection.Keys.ToList(); //Get all the character_so in player collection
        keys.Sort(); //sort the character_so by rarity
        for (int i = 0; i < keys.Count; i++)
        {
            if (!keys[i].unlocked) continue; //if the player hasn't unlocked dont display

            //code below to create character display and set it in the correct order in the layout
            GameObject CreatedCharacterDisplay = Instantiate(CharacterDisplayPrefab);
            UnityEngine.UI.Image spriteRenderer = CreatedCharacterDisplay.GetComponent<UnityEngine.UI.Image>();
            spriteRenderer.sprite = keys[i].sprite;
            CreatedCharacterDisplay.transform.SetParent(CharacterLayoutGroup.transform, false);
            CreatedCharacterDisplay.transform.SetSiblingIndex(i);

            //add to list of character display
            ListOfCharacterDisplay.Add(CreatedCharacterDisplay);
        }
    }

    protected override void DisableButton()
    {
        base.DisableButton();

        foreach (GameObject characterDisplay in ListOfCharacterDisplay)
        {
            Destroy(characterDisplay);
        }

        ListOfCharacterDisplay.Clear();

        AssignCookiePage.SetActive(false);
    }
}
