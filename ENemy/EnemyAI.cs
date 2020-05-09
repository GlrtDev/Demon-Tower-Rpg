using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public Transform enemyGfx;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float searchRange = 15f;
    public float searchRefreshTime = 1f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    //private bool shouldStartFollowing = false;
    private Seeker seeker;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().transform;
        StartCoroutine("SearchForPlayer");
        StartCoroutine("UpdatePath");
        
    }

    IEnumerator UpdatePath()
    {
        yield return new WaitForSeconds(searchRefreshTime);
        if (Vector2.Distance(target.position, transform.position) < searchRange)
            if (seeker.IsDone())
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
                Debug.Log("serching path...");
                
            }
        StartCoroutine("UpdatePath");
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            //Debug.Log("direction: " + direction);
            //Debug.Log("force: " + force);
            //Debug.Log("distance: " + distance);

            if (distance > 0.5f) // prevent sprite flickering
            {
                if (force.x >= 0.01f)
                {
                    enemyGfx.localScale = new Vector3(1f, 1f, 1f);
                }
                else if (force.x <= -0.01f)
                {
                    enemyGfx.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
        }
    }

    IEnumerator SearchForPlayer()
    {
        yield return new WaitForSeconds(0.3f);
        target = FindObjectOfType<Player>().transform;
        Debug.Log(target);
        if (target == null)
            StartCoroutine("SearchForPlayer");
    }
}
