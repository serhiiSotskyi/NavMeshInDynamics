using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerating : MonoBehaviour
{

    public NavMeshSurface surface;
    public int width = 20;
    public int height = 20;

    public GameObject wall;
    public GameObject player;

    private bool playerSpawned = false;
    void Start()
    {
        
        GenerateLevel();

        surface.BuildNavMesh();
    }

    void GenerateLevel()
    {
        for(int x = 0; x < width; x += 2)
        {
            for(int y = 0; y < height; y += 2)
            {
                if(Random.value > .7f)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);

                }
                else if (!playerSpawned)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1.5f, y - height / 2f);
                    Instantiate(player, pos, Quaternion.identity);
                    playerSpawned = true;
                }
            }
        }
    }


}
