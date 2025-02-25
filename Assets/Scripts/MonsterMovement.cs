using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public GameObject spawnerOBJ;
    private MonsterSpawner spawner;

    public Vector3[] Lwaypoints = new Vector3[] {
        new (13.5f, -14.5f), new (13.5f, -9.5f), new (3.5f, -9.5f), new (3.5f, -4.5f), new (16.0f, -4.5f)};
    private int index = 0;
    public int moveSpeed = 10;
    public int monsterType;

    void Awake()
    {
        spawnerOBJ = GameObject.Find("MonsterSpawner");
        spawner = spawnerOBJ.GetComponent<MonsterSpawner>();
    }

    void OnEnable()
    {
        index = 0;
    }

    void FixedUpdate()
    {     
        Vector3 target = Lwaypoints[index];   
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (transform.position == target)
        {
            index++; 
            
            if (index >= Lwaypoints.Length)
            {
                if (spawner != null) 
                {
                    Debug.Log(monsterType);
                    spawner.pools[monsterType].Release(this.gameObject);  // 풀로 반환
                }
            }
        }
    }
}
