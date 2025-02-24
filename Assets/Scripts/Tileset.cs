using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Tileset : MonoBehaviour
{
    private int i, j;
    public GameObject prefab;

    void Awake()
    {
        for (i=0; i<13; i++)
        {
            for (j=0; j<7; j++)
            {
                GameObject tile = Instantiate(prefab, this.transform);
                tile.transform.position = new Vector3(1+(2.5f*i), -17+(2.5f*j));
            }
        }
    }
}
