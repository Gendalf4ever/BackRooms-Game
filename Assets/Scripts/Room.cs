using UnityEngine;

public class Room : MonoBehaviour
{
    public Mesh[] BlockMeshes;
    // Start is called before the first frame update
    private void Start()
    {
        /*
        foreach (var filter in GetComponentsInChildren<MeshFilter>())
        {
            if (filter.sharedMesh == BlockMeshes[0])
            {
                filter.sharedMesh = BlockMeshes[Random.Range(0, BlockMeshes.Length)];
                filter.transform.rotation = Quaternion.Euler(0, 90, 0 * Random.Range(0, 4));
            }
        }
        */
    }

    public void RotateRoom()
    {
        int count = Random.Range(0,4);
        for (int i = 0; i < count; i++)
        {
            transform.Rotate(0, 90, 0);
        }
    }
}
