using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    /* populating map
     * size
     * array of rooms
     */

    public void SaveData()
    {
        
    }

    public void LoadData(Room room)
    {
        for (int i = 0; i < room.additionalRooms.Count; i++)
        {
            LoadData(room.additionalRooms[i]);
        }
    }
}
