using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    //When button is clicked, specifies which scene to load by index. 
    //Index can be found in build settings under File Menu
    public void LoadByIndex (int sceneIndex){
        SceneManager.LoadScene (sceneIndex);
    }
}
