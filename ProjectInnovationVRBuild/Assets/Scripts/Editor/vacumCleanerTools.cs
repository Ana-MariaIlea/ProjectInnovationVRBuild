using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(VacumCleanerController))]
public class vacumCleanerTools : Editor
{
    public void OnSceneGUI()
    {

        var t = target as VacumCleanerController;



        for (int i = 0; i < t.positions.Count; i++) {
            Vector3 position = Handles.PositionHandle(t.positions[i], Quaternion.identity);

            t.positions[i] = position;
        }

        Handles.color = Color.green;
        for (int i = 0; i < t.positions.Count-1; i++)
        {
            Handles.DrawLine(t.positions[i], t.positions[i + 1]);
        }
    }

}
