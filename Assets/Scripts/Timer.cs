using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   

    public float delayBeforeChange = 15f;

    public string sceneNameToChangeTo;

    private float timeElapsed;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeChange)
        {
            SceneManager.LoadScene(sceneNameToChangeTo);

        }
    }


}

