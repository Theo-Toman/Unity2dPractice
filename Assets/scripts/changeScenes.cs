using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScenes : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Debug.Log("going to next scene");
        levelManager.Instance.LoadScene(sceneName);
    }
}
