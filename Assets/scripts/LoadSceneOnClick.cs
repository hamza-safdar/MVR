using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class LoadSceneOnClick : MonoBehaviour {

    void Start()
    {
        
    }

    public void LoadByIndex(int sceneIndex)
    {
        //VRSettings.enabled = true;
        
        SceneManager.LoadScene(sceneIndex);
    }

}
