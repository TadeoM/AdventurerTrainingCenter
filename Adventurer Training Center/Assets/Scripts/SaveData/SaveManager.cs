using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    /* populating map
     * size
     * array of rooms
     */
    public void SaveData(Room room)
    {
        
    }

    public Room StartLoadRoom(string roomName)
    {
        if (!HasFileOnDisk(roomName))
        {
            return null;
        }
        try
        {
            string json = File.ReadAllText(GetPath(roomName));
            JsonUtility.FromJsonOverwrite(json, this);
            // get the JSON "room0: {additionalRooms: [ room1: {additionalRooms:[room3], room2]"
            /*Room room;
            for (int i = 0; i < room.additionalRooms.Count; i++)
            {
                IteratedLoadRoom(room.additionalRooms[i].name);
            }*/
            return null;
        }
        catch
        {
            return null;
        }
    }

    public Room IteratedLoadRoom(string roomName)
    {
        return null;
    }

    private bool HasFileOnDisk(string fileName)
    {
        return File.Exists(GetPath(fileName));
    }

    private string GetPath(string fileName)
    {
        return Join(Application.persistentDataPath, fileName);
    }

    public static string Join(string path1, string path2)
    {
        if (Path.IsPathRooted(path2))
        {
            path2 = path2.TrimStart(Path.DirectorySeparatorChar);
            path2 = path2.TrimStart(Path.AltDirectorySeparatorChar);
        }

        return Path.Combine(path1, path2);
    }
}
