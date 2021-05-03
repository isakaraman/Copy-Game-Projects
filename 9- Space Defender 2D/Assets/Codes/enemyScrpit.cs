using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScrpit : MonoBehaviour
{
    

    List<Transform> pathList;

    float moveSpeed;

    waveConfig waveConfigg;

    int wayPointIndex = 0;

    void Start()
    {
       pathList = waveConfigg.GetPathPrefab();
       transform.position = pathList[wayPointIndex].position;
    }

    
    void Update()
    {
        Move();    
    }
    public void SetWaveConfig(waveConfig configWave)
    {
        waveConfigg = configWave;
        moveSpeed = configWave.GetMoveSpeed();
    }
        void Move()
    {
        if (wayPointIndex<=pathList.Count-1)
        {
            var targetPosition = pathList[wayPointIndex].position;
            var movementThisFrame = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position==targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
