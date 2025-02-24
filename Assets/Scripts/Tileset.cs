using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Tileset : MonoBehaviour
{
    public GameObject prefab;

    void Awake()
    {
        HashSet<(int, int)> excludedTiles = new HashSet<(int, int)>
        {
            (2,6), (3,6), (4,6), (5,6), (6,6), (7,6), (8,6), (9,6), (10,6), (11,6), (12,6),
            (2,5), (12,5),
            (2,4), (3,4), (4,4), (5,4), (6,4), (8,4), (9,4), (10,4), (11,4), (12,4),
            (6,3), (8,3),
            (1,2), (2,2), (3,2), (4,2), (5,2), (6,2), (8,2), (9,2), (10,2), (11,2), (12,2), (13,2)

        }; //이제부터 왼쪽 아래 타일이 (1,1)입니다. ㅅㄱ

        for (int i = 1; i <= 13; i++)
        {
            for (int j = 1; j <= 7; j++)
            {
                if (excludedTiles.Contains((i, j)))
                    continue;

                GameObject tile = Instantiate(prefab, this.transform);
                tile.transform.position = new Vector3(1 + (2.5f * (i - 1)), -17 + (2.5f * (j - 1)));
            }
        }
    }
}
