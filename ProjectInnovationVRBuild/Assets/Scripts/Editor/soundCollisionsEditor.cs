using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundsCollision))]
public class soundCollisionsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var soundCollision = target as SoundsCollision;
        DrawDefaultInspector();

        if (GUILayout.Button("Build Object"))
        {
            soundCollision.GenerateRandomPositions();
        }
    }
}
