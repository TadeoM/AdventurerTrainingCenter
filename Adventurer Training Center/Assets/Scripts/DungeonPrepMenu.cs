using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonPrepMenu : MonoBehaviour
{
    // need to choose map
        // load the map chosen
            // a map should have slots to be filled with either a trap, or an enemy/enemy cluster
            // Create 
                // an array of [custom class] that has the following:
                    // Vector3 location
                    // Gameobject to spawn
                    // number of gameobject to spawn

    public string mapName = "Dungeon";
    public GameObject mapToLoad;
    public GameObject heroListContainer;
    public GameObject listedHeroTemplate;
    public GameObject[] party;

    private void Start()
    {
        List<TMP_Dropdown.OptionData> dataOptions = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < PlayerHandler.Instance.heroPopulation.Count; i++)
        {
            GameObject newListedHero = Instantiate(listedHeroTemplate);
            newListedHero.transform.SetParent(heroListContainer.transform);
            Entity currentHero = newListedHero.AddComponent<Entity>();
            currentHero.Init(PlayerHandler.Instance.heroPopulation[i]);
            newListedHero.GetComponent<ListedHero>().Init(currentHero);
            newListedHero.GetComponent<Button>().onClick.AddListener(() => SelectedHero(currentHero));
        }
    }

    public void SelectedHero(Entity currentHero)
    {
        for (int i = 0; i < party.Length; i++)
        {
            SelectedHero heroDisplay = party[i].GetComponent<SelectedHero>();
            if (heroDisplay.heroImage.sprite == null)
            {
                heroDisplay.Init(currentHero);
                Entity heroEntity = heroDisplay.gameObject.AddComponent<Entity>();
                heroEntity.Init(currentHero);
                Destroy(currentHero.gameObject);
                break;
            }
            if (i == party.Length - 1)
            {
                Debug.Log("Party is full");
            }
        }
    }

    public void ChooseRegularMap()
    {
        mapToLoad = Resources.Load<GameObject>($"Maps/{mapName}");
        Instantiate(mapToLoad);
        Destroy(gameObject);
    }
}
