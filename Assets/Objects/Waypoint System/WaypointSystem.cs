using UnityEngine;
using System.Collections;
using UnityEditor;

public class WaypointSystem : MonoBehaviour
{
    public GameObject waypointPrefab;
    public bool ShowWaypoints = true;

    public void CreateWaypoint()
    {
        var waypointInstance = (GameObject)Instantiate(waypointPrefab, gameObject.transform.position, Quaternion.identity);
        waypointInstance.transform.SetParent(gameObject.transform);        
    }

    public void ShowHideWaypoints()
    {        
        var waypoints = gameObject.GetComponentsInChildren<MeshRenderer>();        
        foreach (var waypoint in waypoints) waypoint.enabled = ShowWaypoints;
    }
}

[CustomEditor(typeof(WaypointSystem))]
public class WaypointsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var waypointSystem = (WaypointSystem)target;
        if (GUILayout.Button("Create Waypoint")) waypointSystem.CreateWaypoint();
        //GUILayout.Toggle(waypointSystem.ShowWaypoints, "Show Waypoints");

        waypointSystem.ShowHideWaypoints();
    }
}
