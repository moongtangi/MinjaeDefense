using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterSpawner : MonoBehaviour
{
    // 몬스터 Prefab을 저장할 배열
    public GameObject[] monsterPrefab;
    // pool들을 저장할 배열
    public ObjectPool<GameObject>[] pools;
    // pool에서 활성화 된 GameObject들을 저장할 리스트
    public List<List<GameObject>> pooledObjects = new List<List<GameObject>>();

    void Awake()
    {
        if (monsterPrefab == null)
        {
            Debug.LogError("monsterPrefab is null or empty");
            return;
        }

        // pool 초기화
        // monsterPrefab의 개수 * 2 만큼 pool을 생성(왼쪽, 오른쪽)
        pools = new ObjectPool<GameObject>[monsterPrefab.Length * 2];
        for (int index = 0; index < monsterPrefab.Length * 2; index++)
        {
            int realIndex = index / 2; // 실제 생성될 몬스터 타입
            // pooledObjects에 리스트 추가(풀에서 활성화 된 몬스터들을 저장할 리스트)
            pooledObjects.Add(new List<GameObject>());

            // pool 생성
            // pool.Get()으로 오브젝트 생성, pool.Release()로 오브젝트 반환 정도만 알아도 됨됨
            pools[index] = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(monsterPrefab[realIndex]),
                actionOnGet: obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: obj => Destroy(obj),
                collectionCheck: false
            );
        }
    }
    
    void Start()
    {
        InvokeRepeating("A", 1f, 1f);
    }

    void A() // 실험용
    {
        SpawnMonster(0, 'L');
        SpawnMonster(0, 'R');
    }

    void SpawnMonster(int x=0, char LorR='R')
    {
        int numLorR = 0;
        if (LorR == 'R')
            numLorR = 1;

        int poolIndex = 2*x+numLorR;

        if (poolIndex >= pools.Length)
        {
            Debug.LogError($"poolIndex: {poolIndex}, pools.Length: {pools.Length}"); // 디버그
            return;
        }
        
        if (monsterPrefab != null && poolIndex < pools.Length)
        {
            GameObject mob = pools[poolIndex].Get();
            pooledObjects[poolIndex].Add(mob);

            if (numLorR == 1)
                mob.transform.position = new Vector2 (32.5f, -14.5f);
            else
                mob.transform.position = new Vector2 (-0.5f, -14.5f);
            mob.GetComponent<MonsterMovement>().monsterType = x;
            mob.GetComponent<MonsterMovement>().monsterLorR = numLorR;
            mob.GetComponent<MonsterMovement>().SettingOnEnable();
        }
        else
        {
            Debug.LogError("Index out of range or monsterPrefab is null"); // 디버그
        }
    }
}
