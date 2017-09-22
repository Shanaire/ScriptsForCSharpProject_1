using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshCombiner))]

public class MeshCombineEditor : Editor
{

    public override void OnInspectorGUI()
    {
        MeshCombiner mc = target as MeshCombiner;

        if (GUILayout.Button("Normal Combine Meshes"))
        {
            mc.CombineMeshes();
        }
        if (GUILayout.Button("Multiple Materials Combination"))
        {
            mc.AdvanceMeshCombine();
        }
    }
}

