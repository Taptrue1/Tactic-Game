using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int Mass => _mass;

    private int _mass;
    private ScriptableObject _type;
}
