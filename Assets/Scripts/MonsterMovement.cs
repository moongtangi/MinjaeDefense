using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public List<Transform> waypoints;  // ���Ͱ� ���� ���(��������Ʈ��)
    private int currentWaypointIndex = 0;  // ���� ��ǥ ��������Ʈ �ε���

    public float moveSpeed = 2f;  // �̵� �ӵ�

    void Update()
    {
        if (waypoints.Count == 0)
            return;

        // ��ǥ ��������Ʈ�� �ִٸ� �۷簩�ϴ�
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // ���͸� ��ǥ ��������Ʈ �������� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // ��ǥ ��������Ʈ�� �����ϸ� ���� ��������Ʈ��
        if (transform.position == targetWaypoint.position)
        {
            currentWaypointIndex++; 

            // ��� ��������Ʈ�� ������ ���� ����
            if (currentWaypointIndex >= waypoints.Count)
            {
                Destroy(gameObject);  // kill
            }
        }
    }

    // ���Ϳ� ��θ� ����
    public void SetWaypoints(List<Transform> newWaypoints)
    {
        waypoints = newWaypoints;
    }
}
