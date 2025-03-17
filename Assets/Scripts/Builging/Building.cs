using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [field: SerializeField] public int PrefabID {  get; private set; }

    private Material _baseMaterial;

    [field: SerializeField] public Vector2Int Size {  get; private set; }

    [field: SerializeField] public BuildingType BuildingType { get; private set; }

    private void Awake()
    {
        _baseMaterial = _renderer.sharedMaterial;
    }

    public void SetID(int id)
    {
        PrefabID = id;
    }

    public void ChangePositionAndRenderer(float xPosition, float zPosition, bool available)
    {
        transform.position = new Vector3(xPosition, 0, zPosition);
        SetRenderer(available);
    }

    private void SetRenderer(bool available)
    {
        if (available)
            _renderer.material.color = Color.green;
        else
            _renderer.material.color = Color.red;
    }

    public void SetBaseRenderer() => _renderer.sharedMaterial = _baseMaterial;

    [ExecuteInEditMode]
    private void OnDrawGizmos()
    {
        int evenNubmer = 2;
        float yPosition = 0;
        float cellSize = 1;

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % evenNubmer == 0) 
                    Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else 
                    Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                Gizmos.DrawCube(transform.position + new Vector3(x, yPosition, y), new Vector3(cellSize, 0.1f, cellSize));
            }
        }
    }
}

public enum BuildingType
{
    Hospital, FireStation, PoliceStation
}
