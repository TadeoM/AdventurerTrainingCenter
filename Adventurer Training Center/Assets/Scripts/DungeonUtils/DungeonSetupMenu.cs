using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DungeonSetupMenu : MonoBehaviour
{
    [SerializeField] private Button readyButton;
    private DungeonMenuSpawnLocation[] dungeonMenuSpawns;
    public Pathfinding pathfindingThing;

    private void Start()
    {
        dungeonMenuSpawns = GetComponentsInChildren<DungeonMenuSpawnLocation>();
        readyButton.onClick.AddListener(ReadyButtonPressed);
    }

    public void ReadyButtonPressed()
    {
        foreach (var dungeonSpawn in dungeonMenuSpawns)
        {
            if(dungeonSpawn.dropdown.value == 0)
            {
                Debug.Log("Not all dungeon spawn have a monster/trap selected");
                return;
            }

            string spawnType = dungeonSpawn.spawnType.ToString();
            string optionSelected = dungeonSpawn.dropdown.options[dungeonSpawn.dropdown.value].text.Replace(" ", "");
            var objectToSpawn = Resources.Load($"Spawnable/{spawnType}/{optionSelected}");
            var spawnedObject = Instantiate(objectToSpawn, dungeonSpawn.GetSpawnLocation(), Quaternion.identity);
        }
        pathfindingThing.SetSpawnedEnemyParents();
        Destroy(gameObject);
    }
}
