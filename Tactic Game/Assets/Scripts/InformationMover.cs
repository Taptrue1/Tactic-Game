using UnityEngine;

public class InformationMover : MonoBehaviour
{
    public UnitData PlayerData;
    public UnitData AIData;
    public float AIAnalizeDelay;
    public bool IsWin;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
