using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private int rowCount = 5;
    [SerializeField]
    private int columnCount = 5;
    [SerializeField]
    private float spaceing = 1.2f;

    private List<GameObject> platforms;

    void OnEnable()
    {
        float offsetX = (rowCount-1) * spaceing / 2.0f;
        float offsetZ = (columnCount-1) * spaceing / 2.0f;

        platforms = new List<GameObject>();
        for (int z = 0; z < columnCount; z++)
        {
            for (int x = 0; x < rowCount; x++)
            {
                var pos = new Vector3(x * spaceing - offsetX, 0, z * spaceing - offsetZ);
                var instance = Instantiate(platform, pos, Quaternion.identity);
            }
        }
    }

    // void OnDisable()
    // {
    //     foreach(GameObject go in platforms)
    //     {
    //         Destroy(go);
    //     }
    // }
}
