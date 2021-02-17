using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSaveData
{
    public string fileName;
    public List<string> mainRooms;
    public List<string> additionalRooms; // naming convention = roomName:attachedTo
    public string[] npcs;
}
