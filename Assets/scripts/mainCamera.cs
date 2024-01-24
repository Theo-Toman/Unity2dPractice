using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mainCamera : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float enemyVisionRange = 5f;
    [SerializeField] private float pullBackBy;
    [SerializeField] private float cameraSpeed;

    private float zPosition = -10f;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, enemyVisionRange, playerMask);

        if (hitEnemies.Length > 0)
        {
            if (transform.position.z > pullBackBy)
            {
                zPosition -= cameraSpeed;
            }
        }
        else
        {
            if (transform.position.z < -10f)
            {
                zPosition += cameraSpeed / 2;
            }
        }

        transform.position = new Vector3(player.position.x, player.position.y, zPosition);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, enemyVisionRange);
    }
}
