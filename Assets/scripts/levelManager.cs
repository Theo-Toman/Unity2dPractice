using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class levelManager : MonoBehaviour
{
    public static levelManager Instance;

    [SerializeField] private GameObject _loaderCanvas;
    //[SerializeField] private Image _progressBar;
    // Start is called before the first frame update


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

         do {
              await Task.Delay(100);
         } while (scene.progress < 0.9f);

         scene.allowSceneActivation = true;
         _loaderCanvas.SetActive(false);
    }
}
