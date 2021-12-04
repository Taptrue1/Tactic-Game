using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationMover : MonoBehaviour
{
    public Action<bool> GameOver;
    public UnitData PlayerData;
    public UnitData AIData;
    public float AIAnalizeDelay;

    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(1);
    }
}
