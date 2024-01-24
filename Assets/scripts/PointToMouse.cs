using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectCamera;
    private Camera otherCamera;

    private float direction;
    private Vector3 difference;
    // Start is called before the first frame update
    void Start()
    {
        otherCamera = gameObjectCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        difference = otherCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        direction = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, direction - 90);
        
    }
}
