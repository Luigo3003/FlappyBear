using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    private PoolScript CenterWalls;
    private PoolScript UpWalls;
    private PoolScript DownWalls;
    [SerializeField] private Transform PointToSpawnCenter;
    [SerializeField] private Transform PointToSpawnUp;
    [SerializeField] private Transform PointToSpawnDown;
    [SerializeField] private float TimeForSpawn;
    private float Timer = 0;
    int LastTypeOfTube = 0;



    private void Awake()
    {
        CenterWalls = GameObject.Find("TubesCenterSpawner").GetComponent<PoolScript>();
        UpWalls = GameObject.Find("TubesUpSpawner").GetComponent<PoolScript>();
        DownWalls = GameObject.Find("TubesDownSpawner").GetComponent<PoolScript>();   
    }

    void Start()
    {
        
    }

    void Update()
    {
        Timer += Time.deltaTime;


        if (Timer >= TimeForSpawn)
        {
            int TypeOfTube = Random.Range(1, 4);

            GameObject TubeToSpawn = null;
            
            print(TypeOfTube);
            if (LastTypeOfTube == TypeOfTube)
            {
                TypeOfTube = Random.Range(0, 3);
            }

            else
            {
                if (TypeOfTube == 1)
                {
                    TubeToSpawn = CenterWalls.RequestObject();
                    TubeToSpawn.transform.position = PointToSpawnCenter.position;

                }
                if (TypeOfTube == 2)
                {
                    TubeToSpawn = UpWalls.RequestObject();
                    TubeToSpawn.transform.position = PointToSpawnUp.position;
                }
                if (TypeOfTube == 3)
                {
                    TubeToSpawn = DownWalls.RequestObject();
                    TubeToSpawn.transform.position = PointToSpawnDown.position;
                }
                TubeToSpawn.SetActive(true);
                Timer = 0;
                LastTypeOfTube = TypeOfTube;
            }
        }



    }
}
