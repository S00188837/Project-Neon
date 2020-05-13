using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : NavMeshMover
{
    public string tagToTrack = "Player";
    GameObject trackPlayer;
    public float trackingDistance = 2;

    public AudioSource walkingSound;
    
    public bool playsound;

    bool trackingPlayer;
    
    public override void Start()
    {
        walkingSound = GetComponent<AudioSource>();
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

                if (!trackingPlayer)
                {
                    walkingSound.Play();
                }

                trackingPlayer = true;
            }
            else
            {
                Stop();
                trackingPlayer = false;
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
