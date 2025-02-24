using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;  // ���� ������
    public Transform spawnPoint;      // ���� ���� ��ġ (Transform Ÿ��)
    public List<Transform> waypoints;  // ���Ͱ� ���� ��������Ʈ ����Ʈ

    void Start()
    {
        if (monsterPrefab == null)
        {
            Debug.LogError("���� �������� ������� �ʾҽ��ϴ�!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("���� ����Ʈ�� �������� �ʾҽ��ϴ�!");
            return;
        }

        if (waypoints.Count == 0)
        {
            Debug.LogError("��������Ʈ�� �������� �ʾҽ��ϴ�!");
            return;
        }

        // 1�� �������� ���� ����
        InvokeRepeating("SpawnMonster", 0f, 1f);
    }

    void SpawnMonster()
    {
        if (monsterPrefab != null && spawnPoint != null && waypoints.Count > 0)
        {
            GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);  // ���� ����

            // ���Ϳ� ��� ����
            MonsterMovement movementScript = monster.GetComponent<MonsterMovement>();
            if (movementScript != null)
            {
                movementScript.SetWaypoints(waypoints);
            }
            else
            {
                Debug.LogError("MonsterMovement �����վ���");
            }
        }
    }
}
