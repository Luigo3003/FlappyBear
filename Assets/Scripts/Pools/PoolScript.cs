using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    private List<GameObject> availableObjectpoolList;
    private List<GameObject> activepoolList;

    [SerializeField] private GameObject PoolPrefab;
    [SerializeField] private int StartingNumberofObjects;


    private void Awake()
    {
        availableObjectpoolList = new List<GameObject>();
        activepoolList = new List<GameObject>();

      
    }
    void Start()
    {
        CreateObject(StartingNumberofObjects);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateObject(int numberOfObjects)
    {
        GameObject TempObject;
        for (int i = 0; i < numberOfObjects; i++)
        {
            TempObject = Instantiate(PoolPrefab, Vector3.zero, Quaternion.identity,transform);
            TempObject.SetActive(false);
            availableObjectpoolList.Add(TempObject);
        }
    }

    public GameObject RequestObject()
    {
        if (availableObjectpoolList.Count != 0)
        {
            return availableObjectpoolList[0];
        }

        else
        {
            return null;
        }
    }
}
