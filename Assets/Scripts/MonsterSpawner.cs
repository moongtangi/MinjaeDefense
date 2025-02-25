using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefab;
    public ObjectPool<GameObject>[] pools;

    void Awake()
    {
        pools = new ObjectPool<GameObject>[monsterPrefab.Length];
        for (int i = 0; i < monsterPrefab.Length; i++)
        {
            int index = i;
            // 내가 미안해 버그 고치느라 새벽 5시 15분이 돼서 주석 남길시간이 없어 :(
            pools[index] = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(monsterPrefab[index]),
                actionOnGet: obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: obj => Destroy(obj),
                collectionCheck: false
            );
        }

        Debug.Log(pools.Length);
    }

    void Start()
    {
        InvokeRepeating("a", 1f, 1f);
    }

    void a() // 실험용용
    {
        SpawnMonster(0);
    }

    void SpawnMonster(int x=0)
    {
        if (monsterPrefab != null)
        {
            GameObject mob = pools[x].Get();
            mob.transform.position = new Vector2 (-0.5f, -14.5f);
            mob.GetComponent<MonsterMovement>().monsterType = x;
        }
    }
}
