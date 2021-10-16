using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int Mass => _mass;
    public ScriptableObject Type => _type;

    private int _mass;
    private ScriptableObject _type;

    public void SendUnits()
    {

    }
}
