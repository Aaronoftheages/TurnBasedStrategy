using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour
{
    List<Tile> selectableTiles = new List<Tile>();
    GameObject[] tiles;

    Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;

    public int move = 5;
    public float jumpHeight = 2;
    public float moveSpeed = 2;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0;

    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = GetComponent<Collider>().bounds.extents.y;
    }
}

