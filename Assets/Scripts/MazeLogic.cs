using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using Unity.AI.Navigation;

public class MapLocation
{
    public int x;
    public int z;

    public MapLocation(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
}

public class MazeLogic : MonoBehaviour
{
    public int width = 30; //xleght kedalaman 
    public int depth = 30; //zlenght lebar
    public int scale = 1;
    public GameObject Character;
    public GameObject Enemy;
    public int EnemyCount = 3;
    public int RoomCount = 3;
    public int RoomMinSize = 3;
    public int RoomMaxSize = 4;
    // public NavMeshSurface surface;
    public List <GameObject> Cube; //maze Wall
    public byte[,] map;
    GameObject[,] BuildingList;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialiseMap();
        GenerateMaps();
	    AddRooms(RoomCount, RoomMinSize, RoomMaxSize);
        DrawMaps();
        PlaceCharacter();
        PlaceEnemy();
        // surface.BuildNavMesh();
    }
    
    public virtual void AddRooms(int count, int minSize, int maxSize)
    {
	    for (int c = 0; c < count; c++)
	    {
	        int startX = Random.Range(3, width - 3);
	        int startZ = Random.Range(3, depth - 3);
	        int roomWidth = Random.Range(minSize, maxSize);
	        int roomDepth = Random.Range(minSize, maxSize);

	        for (int x = startX; x < width - 3 && x < startX + roomWidth; x++)
	        {
	            for (int z = startZ; z < depth - 3 && z < startZ + roomDepth; z++)
	            {
	                map [x, z] = 2;
                }
            }
        }
    }


    public virtual void PlaceEnemy()
    {
        int EnemySet = 0; 
        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int x = Random.Range(0, width);
                int z = Random.Range(0, depth);
                if (map[x, z] == 2 && EnemySet != EnemyCount)
                {
                    Debug.Log("placing Enemy");
                    EnemySet++;
                    Instantiate(Enemy, new Vector3(x * scale, 0, z * scale), Quaternion.identity);
                }
                else if (EnemySet == EnemyCount)
                {
                    Debug.Log("already Placing All the Enemy");
                    return;
                }
            }
        }
    }

    void InitialiseMap() //initialise all maps with 1
    {
        map = new byte[width, depth];
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
        {
            map[x, z] = 1; // 1 =wall 0 = corridor
        }
    }

    public virtual void GenerateMaps() //initialise some corridors with randomness
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (Random.Range(0, 100) < 50)
                    map[x, z] = 0; //1 = wall 0 = corridor
            }
    }

    void DrawMaps() // Draw All Value With GameObject
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = Instantiate(Cube[Random.Range(0, Cube.Count)], pos, Quaternion.identity);
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                }
            }
    }

    public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width -1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x - 1, z] == 0) count++;
        if (map[x + 1, z] == 0) count++;
        if (map[x, z + 1] == 0) count++;
        if (map[x, z - 1] == 0) count++;
        return count;
    }

    public virtual void PlaceCharacter()
    {
        bool PlayerSet = false;
        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < depth; j++)
            {
            int x = Random.Range(0, width);
            int z = Random.Range(0, width);
            if (map[x, z] == 0 && !PlayerSet)
            {
                Debug.Log("placing chaeacter");
                PlayerSet = true;
                Character.transform.position = new Vector3(x * scale, 0, z * scale);
            }
            else if (PlayerSet)
            {
                Debug.Log("already Placing character");
                return;
            }
            }
        }
    }   
}