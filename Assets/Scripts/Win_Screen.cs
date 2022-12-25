using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Screen : MonoBehaviour
{
    public void ReplayLevel(){
        SceneManager.LoadSceneAsync(SceneIDS.levelSceneID);
   }

   public void ReturnToMap(){
        SceneManager.LoadSceneAsync(SceneIDS.mapSceneID);
   }

   public void ApplicationExit(){
       Application.Quit();
   }
}
