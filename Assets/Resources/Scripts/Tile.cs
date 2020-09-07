using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Tile : MonoBehaviour
{
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool Selectable = false;

    public List<Tile> adjacencyList = new List<Tile>();

    #region BFS
    public bool visited = false;
    public Tile Parent = null;
    public int distance = 0;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TileID();
    }


    void TileID()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Selectable)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

    }

    public void Reset()
    {
        adjacencyList.Clear();

        walkable = true;
        current = false;
        target = false;
        Selectable = false;
        visited = false;
        Parent = null;
        distance = 0;
    }

    public void FindNeighbors(float jumpHeight)
    {
        Reset();

        CheckTile(Vector3.forward, jumpHeight);
        CheckTile(-Vector3.forward, jumpHeight);
        CheckTile(Vector3.right, jumpHeight);
        CheckTile(-Vector3.right, jumpHeight);
    }


    public void CheckTile(Vector3 direction, float jumpHeight)
    {
        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                RaycastHit hit;

                if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    adjacencyList.Add(tile);
                }
            }
        }
    }
}
