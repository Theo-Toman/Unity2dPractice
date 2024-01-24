using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    private RectTransform thing;
    // Start is called before the first frame update
    void Start()
    {
        thing = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        thing.position = new Vector2(thing.position.x + .1f,thing.position.y + .1f);
    }
}
