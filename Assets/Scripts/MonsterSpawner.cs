using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;  // 몬스터 프리팹
    public Transform spawnPoint;      // 몬스터 생성 위치 (Transform 타입)
    public List<Transform> waypoints;  // 몬스터가 따라갈 웨이포인트 리스트

    void Start()
    {
        if (monsterPrefab == null)
        {
            Debug.LogError("몬스터 프리팹이 연결되지 않았습니다!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("스폰 포인트가 설정되지 않았습니다!");
            return;
        }

        if (waypoints.Count == 0)
        {
            Debug.LogError("웨이포인트가 설정되지 않았습니다!");
            return;
        }

        // 1초 간격으로 몬스터 생성
        InvokeRepeating("SpawnMonster", 0f, 1f);
    }

    void SpawnMonster()
    {
        if (monsterPrefab != null && spawnPoint != null && waypoints.Count > 0)
        {
            GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);  // 몬스터 생성

            // 몬스터에 경로 설정
            MonsterMovement movementScript = monster.GetComponent<MonsterMovement>();
            if (movementScript != null)
            {
                movementScript.SetWaypoints(waypoints);
            }
            else
            {
                Debug.LogError("MonsterMovement 프리팹엄슴");
            }
        }
    }
}
