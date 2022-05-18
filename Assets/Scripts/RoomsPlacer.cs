using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomsPlacer : MonoBehaviour
{
    public Room[] RoomPrefabs;
    public Room StartRoom;
    public Room[,] spawnedRooms;
    // Start is called before the first frame update
    void Start()
    {
       
        spawnedRooms = new Room[11, 11];
        spawnedRooms[5, 5] = StartRoom;
        for (int i = 0; i <= 12; i++)
        {
            PlaceOneRoom();
        }
    }

   private void PlaceOneRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        // Эту строчку можно заменить на выбор комнаты с учётом её вероятности, вроде как в ChunksPlacer.GetRandomChunk()
        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);
        Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
        newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 115; 
        spawnedRooms[position.x, position.y] = newRoom;
    }
    /*
     * 115
    int limit = 500;
        while (limit-- > 0)
        {
            // Эту строчку можно заменить на выбор положения комнаты с учётом того насколько он далеко/близко от центра,
            // или сколько у него соседей, чтобы генерировать более плотные, или наоборот, растянутые данжи
            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));

            newRoom.transform.position = new Vector3(position.x - 15, 0, position.y - 15) * 12;
            spawnedRooms[position.x, position.y] = newRoom;
        }
    */
            // Destroy(newRoom.gameObject);
        }


//}
