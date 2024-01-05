using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anode : MonoBehaviour
{
    public bool isWalkAble;
    public Vector3 worldPos;
    // Start is called before the first frame update
    public Anode(bool nWalkable, Vector3 nWorldPos)
    {
        isWalkAble = nWalkable;
        worldPos = nWorldPos;
    }
}
