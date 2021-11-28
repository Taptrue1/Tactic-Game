using UnityEngine;

public class InformationMover : MonoBehaviour
{
    public UnitData PlayerData;
    public UnitData AIData;
    public float AIAnalizeDelay;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
