using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneratorPractice : MonoBehaviour
{
    [Header("Verts")]
    private Vector3[] Vertices;
    private int[] Triangles;

    [Header("Numbers")]
    public int XSize = 20;
    public int YSize = 20;
    public int ZSize = 20;

    [Header("Components")]
    public Mesh Mesh;

    void Start()
    {
        CreateTarrain();
        UpdateMesh();
    }
    void Awake()
    {
        Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = Mesh;
    }

    void Update()
    {

    }

    public void CreateTarrain()
    {

        Vertices  = new Vector3[(XSize +1) * (YSize + 1)];

        int i = 0;

        for (int z = 0; z <= ZSize; z++)
        {
            for (int x = 0; x <= XSize; x++)
            {
                Vertices[i] = new Vector3(x , 0  , z);
                i++;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (Vertices == null) return;

        for (int i = 0; i < Vertices.Length; i++)
        {
            Gizmos.DrawSphere(Vertices[i], .1f);
        }


    }
    private void UpdateMesh()
    {
        Mesh.Clear();

        Mesh.vertices = Vertices;   
        Mesh.triangles = Triangles; 

        Mesh.RecalculateNormals();  
    }
}
