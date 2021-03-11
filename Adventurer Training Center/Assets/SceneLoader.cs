using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public const string MainFacility = "MainFacility";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        LoadScene(MainFacility);
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
