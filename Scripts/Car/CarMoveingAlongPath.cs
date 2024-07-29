using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveingAlongPath : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int currentWaypointIndex = 0;

    private void OnEnable()
    {
        this.ResetCurrentWaypointIndex();
    }

    private void Start()
    {
        transform.parent.position = GameCtrl.Instance.RoadSpawner.Prefabs[0].position;
    }

    void Update()
    {
        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        if (GameCtrl.Instance.RoadSpawner.Prefabs == null ||  GameCtrl.Instance.RoadSpawner.Prefabs.Count == 0) return;

        if (currentWaypointIndex >=  GameCtrl.Instance.RoadSpawner.Prefabs.Count) return;

        Transform targetWaypoint = GameCtrl.Instance.RoadSpawner.Prefabs[currentWaypointIndex];
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
        transform.parent.LookAt(targetWaypoint);

        if (Vector3.Distance(transform.parent.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
        }

    }

    protected virtual void ResetCurrentWaypointIndex()
    {
        currentWaypointIndex = 0;
    }
}
