using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject scorePoints;
    [SerializeField] GameObject prefab;
    public int numb;
    int lenlist;
    GameObject ring;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        lenlist = scorePoints.transform.GetChildCount();
       for (int i = 0; i< numb; i++)
       {
            Vector3 position = scorePoints.transform.GetChild(Random.Range(0,lenlist)).transform.position;
            ring = Instantiate(prefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
