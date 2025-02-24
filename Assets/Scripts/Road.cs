using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Transform> waypoints; // ���� ���̴� �� ����Ʈ�ε�

    void OnDrawGizmos()
    {
        // �����Ϳ��� ��θ� �ð������� ǥ��
        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}

