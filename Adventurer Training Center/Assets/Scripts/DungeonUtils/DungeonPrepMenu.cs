using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonPrepMenu : MonoBehaviour
{
    public string mapName = "Dungeon";
    public GameObject mapToLoad;
    public GameObject heroListContainer;
    public GameObject listedHeroTemplate;
    public GameObject[] party;

    private void Start()
    {
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
        GameObject map = Instantiate(mapToLoad);
        List<Entity> partyEntities = new List<Entity>();
        foreach (var hero in party)
        {
            Entity heroEntity = hero.GetComponent<Entity>();
            if (heroEntity != null)
            {
                partyEntities.Add(heroEntity);
            }
        }
        FindObjectOfType<Pathfinding>().SpawnHeroes(partyEntities);
        Destroy(gameObject);
    }
}
