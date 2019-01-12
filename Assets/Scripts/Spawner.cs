using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Spawner : MonoBehaviour {

    public int CubesToSpawn = 10;

    [SerializeField] private GameObject CollectableItemPrefab;
    [SerializeField] private Transform m_GroundPlane;
    [Range(0f, 10f)]
    [SerializeField] private float spawnOffSetValue = 0f;
    [SerializeField]private float PlaneLength = 10f;
    [SerializeField] private TextAsset CollectableAssets;

    private List<CollectableItemData> Collectables;

    private void Start()
    {
        JsonReader reader = new JsonReader(CollectableAssets.text);
        Collectables = JsonMapper.ToObject<List<CollectableItemData>>(reader);
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < CubesToSpawn; i++)
        {
            CollectableItemData data = Collectables[Random.Range(0, Collectables.Count)];

            Vector3 position = new Vector3(Point(), 2f, Point());
            GameObject collectable = Instantiate(CollectableItemPrefab, position, Quaternion.identity);
            collectable.transform.SetParent(transform);
            collectable.GetComponent<Pickables>().CollectableItem = data;
        }
    }

    float Point()
    {
        return Random.Range(-PlaneLength, PlaneLength);
    }
}

[System.Serializable]
public class CollectableItemData
{
    public string ItemName = string.Empty;
    public int ItemInitialScore = 0;
    public Color ItemColor = Color.white;
}
