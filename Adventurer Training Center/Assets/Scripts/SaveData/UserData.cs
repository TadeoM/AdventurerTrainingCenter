using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : Singleton<UserData>
{
    public Room trainingCenter;
    public int gold;

    private void Start()
    {
        //TODO: SaveManager.Instance.LoadData()
    }

    public void InitializeTrainingCenter()
    {
        
    }
}
