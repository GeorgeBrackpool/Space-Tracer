using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
     WaveConfig waveConfig;
     List<Transform> waypoints;
     
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     Move();
    }
    
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;//this refers to the class and specifically the variable at the top. It equals the waveconfig when someone calls setwaveconfig and passes to us the wave config in brackets.
    }
    void Move()// Move's enemy ship to waypoints.
    {
           if(waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetmoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards
            (transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
