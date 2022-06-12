using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3controller : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private GameObject colorchanger;
    [SerializeField]
    private GameObject finishline;
    private GameObject prev;
    int cnt;
    float y = 2f;
    float gap = 7f;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        spawner(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawner(bool firsttime = false)
    {
        if (firsttime == false)
        {
            Destroy(prev);
        }
        else
        {
            firsttime = false;
        }
        int ri = Random.Range(0, obstacles.Length);
        prev = Instantiate(obstacles[ri], new Vector3(0, y, 0), Quaternion.identity);
        y += gap;
        if (cnt == 3)
        {
            cnt = 0;
            Instantiate(finishline, new Vector3(0, y, 1), Quaternion.identity);
        }
        else
        {
            cnt++;
            Instantiate(colorchanger, new Vector3(0, y, 1), Quaternion.identity);
            y += gap;
        }
    }
}
