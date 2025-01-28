using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProceduralTerrain))]
public class TerrainEditor : Editor
{
    private ProceduralTerrain generator;

    private void OnEnable()
    {
        generator = (ProceduralTerrain) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();
        if (GUILayout.Button("Generate mesh"))
        {
            Undo.RecordObjects(new Object[]
            {
                generator,
                generator.terrainMeshFilter,
            }, "Generate terrain");
            generator.RemovePreviousObjects();
            generator.Generate();
        }
    }
}
