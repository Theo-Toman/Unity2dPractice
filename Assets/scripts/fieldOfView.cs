using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask obstructionLayer;
    //[SerializeField] private float radius = 5f;
    //[SerializeField] private float angle = 45f;

    private bool canSeePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 FieldOfView(float angle, float radius)
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);

        if (rangeCheck.Length > 0)
        {
            Transform playerPos = rangeCheck[0].transform;
            Vector2 directionToPlayer = (playerPos.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToPlayer) < angle / 2)
            {
                Debug.Log("this has run");
                float distanceToPlayer = Vector2.Distance(transform.position, playerPos.position);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstructionLayer);


                if (hit.collider == null)
                {
                    Debug.DrawRay(transform.position, directionToPlayer * distanceToPlayer, Color.blue);
                    return directionToPlayer;
                }
                else
                {
                    return new Vector2(0, 0);
                }
            }
        }
        return new Vector2(0, 0);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
