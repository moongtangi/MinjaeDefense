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
    public int monsterType, monsterLorR;
    public Vector3 target;

    void Awake()
    {
        spawnerOBJ = GameObject.Find("MonsterSpawner");
        spawner = spawnerOBJ.GetComponent<MonsterSpawner>();
    }

    public void SettingOnEnable()
    {
        index = 0;
        if (monsterLorR == 0)
            target = Lwaypoints[index];
        else
            target = new Vector3 (32-Lwaypoints[index].x, Lwaypoints[index].y);
        
        Debug.Log($"Monster {monsterType} is spawned at {target}, mosterLorR: {monsterLorR}");
    }

    void FixedUpdate()
    {     
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (transform.position == target)
        {
            index++;
            if (index >= Lwaypoints.Length)
            {
                if (spawner != null) 
                {
                    int poolIndex = 2 * monsterType + monsterLorR;
                    Debug.Log($"Releasing monster to pool index: {poolIndex}");
                    spawner.pools[poolIndex].Release(this.gameObject);  // 풀로 반환
                    spawner.pooledObjects[poolIndex].Remove(this.gameObject); // 활성화 목록에서 제거
                }
            }
            else
            {
                if (monsterLorR == 0)
                    target = Lwaypoints[index];
                else
                    target = new Vector3 (32-Lwaypoints[index].x, Lwaypoints[index].y);
            }
        }
    }
}
