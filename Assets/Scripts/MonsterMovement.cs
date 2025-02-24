using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public List<Transform> waypoints;  // 몬스터가 따라갈 경로(웨이포인트들)
    private int currentWaypointIndex = 0;  // 현재 목표 웨이포인트 인덱스

    public float moveSpeed = 2f;  // 이동 속도

    void Update()
    {
        if (waypoints.Count == 0)
            return;

        // 목표 웨이포인트가 있다면 글루갑니다
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // 몬스터를 목표 웨이포인트 방향으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // 목표 웨이포인트에 도달하면 다음 웨이포인트로
        if (transform.position == targetWaypoint.position)
        {
            currentWaypointIndex++; 

            // 모든 웨이포인트를 지나면 몬스터 삭제
            if (currentWaypointIndex >= waypoints.Count)
            {
                Destroy(gameObject);  // kill
            }
        }
    }

    // 몬스터에 경로를 설정
    public void SetWaypoints(List<Transform> newWaypoints)
    {
        waypoints = newWaypoints;
    }
}
