using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToLogin()
    {
        Application.OpenURL("https://portal.livetree.com/login");
    }

    public void GoToSignUp()
    {
        Application.OpenURL("https://www.livetree.com/get-app");
    }

    public void DownloadApp()
    {
        Application.OpenURL("https://livetree.page.link/download");
    }

    public void CreateContinue()
    {
        SceneManager.LoadScene(1);
    }
}
