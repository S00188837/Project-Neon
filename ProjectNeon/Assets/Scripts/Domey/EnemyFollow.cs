using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : NavMeshMover
{
    public string tagToTrack = "Player";
    GameObject trackPlayer;
    public float trackingDistance = 2;

    
    public override void Start()
    {
        trackPlayer = GameObject.FindGameObjectWithTag(tagToTrack);
        base.Start();
    }

    
    void Update()
    {
        if (trackPlayer != null)
        {
            if (Vector3.Distance(transform.position, trackPlayer.transform.position) <= trackingDistance)
            {
                Resume();
                MoveTo(trackPlayer);
            }
            else
            {
                Stop();
            }
        }
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = DebugLineColor;
        Gizmos.DrawWireSphere(transform.position, trackingDistance);
        base.OnDrawGizmos();
    }
}
