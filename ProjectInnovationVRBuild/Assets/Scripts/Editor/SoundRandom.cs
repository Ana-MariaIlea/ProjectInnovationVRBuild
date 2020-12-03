using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SoundsPosition))]
public class SoundRandom : Editor
{
    public void OnSceneGUI()
    {

        var t = (target as SoundsPosition);


        //DrawGizmo.

        //Gizmos.DrawCube(t.transform.position, t.start);


        //EditorGUI.BeginChangeCheck();
        //Vector3 pos = Handles.PositionHandle(t.lookAtPoint, Quaternion.identity);
        //if (EditorGUI.EndChangeCheck())
        //{
        //    Undo.RecordObject(target, "Move point");
        //    t.lookAtPoint = pos;
        //    t.Update();
        //}
    }

}
