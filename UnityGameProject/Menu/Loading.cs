using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    AsyncOperation ao;
    public GameObject loadingbg;
    public Slider progress;
    public Text loading;
    public Text loadingscene;

    public bool isfakeLoadingBar = false;
    public float fakeincrement = 0f;
    public float faketiming = 0f;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Load()
    {
        loadingbg.SetActive(true);
        progress.gameObject.SetActive(true);
        loading.gameObject.SetActive(true);
        loadingscene.gameObject.SetActive(true);
        loading.text = "Loading....";

        if (!isfakeLoadingBar)
        {
            StartCoroutine(Loadrealprogress());
        }
        else
        {
            StartCoroutine(Loadfakeprogress());
        }
    }

    IEnumerator Loadrealprogress()
    {
        yield return new WaitForSeconds(1);
        ao = SceneManager.LoadSceneAsync(1);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progress.value = ao.progress;

            if (ao.progress == 0.9f)
            {
                progress.value = 1f;
                loading.text = "Presss Space to continue";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ao.allowSceneActivation = true;
                }
            }
            Debug.Log(ao.progress);
            yield return null;
        }
    }

    IEnumerator Loadfakeprogress()
    {
        yield return new WaitForSeconds(1);

        while (progress.value != 1f)
        {
            progress.value += fakeincrement;
            yield return new WaitForSeconds(faketiming);
        }

        while (progress.value == 1f)
        {
            loading.text = "Press Space to Continue";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
            yield return null;
        }
        
    }
}
