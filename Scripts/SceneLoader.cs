using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

        public GameObject D_options_Canvas;
        public GameObject D_Canvas;
        private bool IsOptions_Canvas_true;

        public void ActivateObj()
        {
            if (D_options_Canvas != null)
            {
                D_options_Canvas.SetActive(true);
                IsOptions_Canvas_true = true;
                if (IsOptions_Canvas_true == true)
                {
                D_Canvas.SetActive(false);
                }
            }
        }
        public void DisableObj()
        {
            if (D_options_Canvas != null)
            {
                D_options_Canvas.SetActive(false);
                IsOptions_Canvas_true = false;
                if (IsOptions_Canvas_true == false)
                {
                    D_Canvas.SetActive(true);
                }
            }
        }
}