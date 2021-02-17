using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    public RoomSaveData trainingCenter;
    public Room roomToSave;

    private void Start()
    {
        LoadRoomSaveData("TrainingCenter");
    }

    public void SaveRoomData(Room room)
    {
        if(trainingCenter == null)
        {
            trainingCenter = new RoomSaveData();
        }
        trainingCenter.fileName = room.roomName;
        trainingCenter.mainRooms = new List<string>();
        trainingCenter.additionalRooms = new List<string>();

        for (int a = 0; a < room.unlockedRooms.Count; a++)
        {
            trainingCenter.mainRooms.Add(room.unlockedRooms[a].name);
            
            for (int b = 0; b < room.unlockedRooms[a].unlockedRooms.Count; b++)
            {
                trainingCenter.additionalRooms.Add($"{room.unlockedRooms[a].unlockedRooms[b].name}:{room.unlockedRooms[a].name}");
            }
        }

        // same thing for trainers once we have that data in-game
        string json = JsonUtility.ToJson(trainingCenter);
        File.WriteAllText(GetPath(trainingCenter.fileName), json);
    }

    public RoomSaveData LoadRoomSaveData(string roomName)
    {
        trainingCenter = new RoomSaveData();
        if (!HasFileOnDisk(roomName))
        {
            return null;
        }
        
        try
        {   
            string json = File.ReadAllText(GetPath(roomName));
            JsonUtility.FromJsonOverwrite(json, trainingCenter);
            return trainingCenter;
        }
        catch
        {
            return null;
        }
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
