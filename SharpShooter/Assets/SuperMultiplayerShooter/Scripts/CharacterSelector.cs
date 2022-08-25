using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visyde
{
    /// <summary>
    /// Character Selector
    /// - displays a list of characters for the character selection screen
    /// </summary>

    public class CharacterSelector : MonoBehaviour
    {
        public CharacterSelectorItem itemPrefab;
        public CharacterData[] characters;
        public Transform content;
        public Connector connector;
        public SampleMainMenu mainMenu;

        public GameObject[] total_Characters;

        void Start()
        {
            Debug.Log($"this is characterSlection {characters}");
            DataCarrier.characters = characters;

            Debug.Log($"this is characterSlection {DataCarrier.characters}");
        }

        /// <summary>
        /// Refresh the character selection window.
        /// </summary>
        public void Refresh()
        {
            // Clear items:
            foreach (Transform t in content)
            {
                Destroy(t.gameObject);
            }

            // Repopulate items:
            for (int i = 0; i < characters.Length; i++)
            {
                CharacterSelectorItem item = Instantiate(itemPrefab, content);
                item.data = characters[i];
                item.cs = this;
            }
        }

        // Character selection:
        public void SelectCharacter(CharacterData data)
        {
            // Close the character selection panel:
            mainMenu.characterSelectionPanel.SetActive(false);

            // ...then set the "character using" in the DataCarrier:
            for (int i = 0; i < characters.Length; i++)
            {
                if (data == characters[i])
                {
                    DataCarrier.chosenCharacter = i;
                }
            }

            mainMenu.characterIconPresenter.sprite = data.icon;
        }

        public void OnButtonSelect(int id)
        {
            for (int i = 0; i < total_Characters.Length; i++)
            {
                if (id == i)
                {
                    total_Characters[i].GetComponentInChildren<CharacterButtonSelection>().enableImage.gameObject.SetActive(true);
                    total_Characters[i].GetComponentInChildren<CharacterButtonSelection>().disableImage.gameObject.SetActive(false);
                }
                else
                {
                    total_Characters[i].GetComponentInChildren<CharacterButtonSelection>().enableImage.gameObject.SetActive(false);
                    total_Characters[i].GetComponentInChildren<CharacterButtonSelection>().disableImage.gameObject.SetActive(true);
                }
            }
        }
    }
}
