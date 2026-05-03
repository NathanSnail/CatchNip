using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFeatures : MonoBehaviour
{
    [SerializeField] SceneAsset game_scene;
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        String name = game_scene.name;
        Debug.Log(name);
        SceneManager.LoadScene(name);
    }
}