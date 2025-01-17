using ProceduralToolkit;
using ProceduralToolkit.FastNoiseLib;
using ProceduralToolkit.Samples;
using UnityEngine;
using UnityEngine.Serialization;

public class ProceduralTerrain : ConfiguratorBase
{
    [Header("Terrain")]
    public MeshFilter terrainMeshFilter;
    public MeshCollider terrainMeshCollider;
    public bool constantSeed = false;
    
    [Header("Editor")]
    public bool generateWhenStarting;
    public bool generateObjects;
    
    [Header("Prefabs")]
    public GameObject[] prefabsToGenerate;
    public int prefabsCount = 100;
    
    [Header("Config")]
    public LowPolyTerrainGenerator.Config config = new LowPolyTerrainGenerator.Config();

    private Mesh terrainMesh;
    private GameObject prefabs;
    
    private void Awake()
    {
        if (generateObjects)
        {
            prefabs = new GameObject("Generated Prefabs");
            prefabs.transform.parent = this.gameObject.transform;
        }
        
        if (generateWhenStarting)
        {
            Generate();
        }
    }
    
    public void Generate()
    {

        if (constantSeed)
        {
            Random.InitState(0);
        }

        var draft = LowPolyTerrainGenerator.TerrainDraft(config);
        draft.Move(Vector3.left*config.terrainSize.x/2 + Vector3.back*config.terrainSize.z/2);
        AssignDraftToMeshFilter(draft, terrainMeshFilter, ref terrainMesh);
        terrainMeshCollider.sharedMesh = terrainMesh;

        if (generateObjects)
        {
            GeneratePrefabs();
        }
    }

    public void RemovePreviousObjects()
    {
        DestroyImmediate(prefabs);
        
        if (generateObjects)
        {
            prefabs = new GameObject("Generated Prefabs");
            prefabs.transform.parent = this.gameObject.transform;
        }
    }

    private void GeneratePrefabs()
    {
        for (int i = 0; i < prefabsCount; i++)
        {
            var randomPrefab = prefabsToGenerate[Random.Range(0, prefabsToGenerate.Length)];

            Vector3 position = transform.position;
            position.x = Random.Range(-config.GetTerrainSize() / 2 + 1, config.GetTerrainSize() / 2 - 1);
            position.z = Random.Range(-config.GetTerrainSize() / 2 + 1, config.GetTerrainSize() / 2 - 1);
            
            // raycast
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(position.x, 100, position.z), Vector3.down, out hit))
            {
                position = hit.point;
            }
            
            position.y += (randomPrefab.transform.position.y / 2);
            
            var obj = Instantiate(randomPrefab, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            obj.transform.parent = prefabs.gameObject.transform;
        }
    }
}
