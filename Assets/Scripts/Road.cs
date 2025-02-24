using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Transform> waypoints; // 대충 꺾이는 점 리스트인듯

    void OnDrawGizmos()
    {
        // 에디터에서 경로를 시각적으로 표시
        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}

