using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform thing;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = thing.position;
    }
}
