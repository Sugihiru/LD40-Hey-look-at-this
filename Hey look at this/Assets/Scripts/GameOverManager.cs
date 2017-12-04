using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameOverManager
{
    public static string GameOverText { get; set; }

    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene(2);
    }
}
