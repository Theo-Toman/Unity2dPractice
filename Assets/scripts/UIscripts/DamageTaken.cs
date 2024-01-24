using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageTaken : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;

    private RectTransform rTransform;
    private bool startUpdating = false;
    private Vector2 direction;

    private float duration = 0.5f;

    private float startTime;

    // Start is called before the first frame update

    private void Start()
    {
        rTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startUpdating)
        {
            rTransform.position += new Vector3(direction.x, direction.y, 0f) * Time.deltaTime * 8f;
            if (Time.time - startTime > duration)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartFunctions(int damage, Vector2 direction2)
    {        
        Text.text = damage.ToString();
        direction = direction2;
        startTime = Time.time;
        startUpdating = true;
    }
}
