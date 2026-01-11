using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    //Play again.
    public void LoadByIndex (int sceneIndex){
        SceneManager.LoadScene (sceneIndex);
    }
}
