using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // added
using UnityEngine.UI; // added

public class RestartLevelX : MonoBehaviour
{
   public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
