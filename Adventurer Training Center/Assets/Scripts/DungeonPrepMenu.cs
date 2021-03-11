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
    public TMP_Dropdown[] heroDropdownList;
    public Image[] heroDropdownImages;
    public Entity[] party;

    private void Start()
    {
        List<TMP_Dropdown.OptionData> dataOptions = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < PlayerHandler.Instance.heroPopulation.Count; i++)
        {
            Hero currentHero = PlayerHandler.Instance.heroPopulation[i];
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = $"{currentHero.name}: LVL{currentHero.level} {currentHero.heroClass.ToString()}";
            dataOptions.Add(newData);
        }
        for (int y = 0; y < heroDropdownList.Length; y++)
        {
            //heroDropdownImages.sprite = newData.image;
            //newData.image = Resources.LoadAll<Sprite>("OrangeKnight")[0];
            heroDropdownList[y].AddOptions(dataOptions);
        }
    }


    public void ChooseRegularMap()
    {
        mapToLoad = Resources.Load<GameObject>($"Maps/{mapName}");
        Instantiate(mapToLoad);
        Destroy(gameObject);
    }
}
