using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] WaypointScript waypoints;
    [SerializeField] float move__speed = 5f;
    [SerializeField] float dis_threshold = 0.1f;
    [SerializeField] float detection_threshold = 5;
    public bool moving;
    public bool player_reached;
    public bool leader_stoped = false;
    public LayerMask player_mask;
    Transform current__waypoint;
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints == null)
        { return; }
        else
        {
            current__waypoint = waypoints.get_next_waypoint(current__waypoint);
            transform.position = current__waypoint.position;

            //set next waypoint
            current__waypoint = waypoints.get_next_waypoint(current__waypoint);
            transform.LookAt(current__waypoint);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints != null)
        {
            if (Physics.CheckSphere(transform.position, detection_threshold, player_mask, QueryTriggerInteraction.UseGlobal))
            {
                Debug.Log("Player reached");
                moving = true;
                if (waypoints.end == true)
                {
                    leader_stoped = true;
                    //objective completed...do something 
                }
            }
            if(moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, current__waypoint.position, move__speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, current__waypoint.position) < dis_threshold)
                {
                    current__waypoint = waypoints.get_next_waypoint(current__waypoint);
                    transform.LookAt(current__waypoint);
                    moving = false;

                }
            }
            //if(Vector3.Distance)
           
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detection_threshold);
    }
}
