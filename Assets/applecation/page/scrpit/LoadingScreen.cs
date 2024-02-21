using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider progressBar;

    public void Sceneloader(int sceneIndex)
    {
        StartCoroutine(Loadingscreenloader(sceneIndex));
    }

    IEnumerator Loadingscreenloader(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = operation.progress;
            progressBar.value = progress;

            yield return null;
        }
    }
}

