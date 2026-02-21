using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager 
{

    private string mainMenuScene = "MainMenu";
    private List<string> levels = new List<string>()
    {
        "TestScene",
        "Level1",
        "Level2"
    };

    private int currentLevelIndex = 0;

    public void LoadLevel(int index)
    {
        if (index < 0 || index >= levels.Count)
        {
            return;
        }
        currentLevelIndex = index;
        SceneManager.LoadScene(levels[index]);
    }

    public void LoadLevel(string scene)
    {
        if (!levels.Contains(scene))
        {
            return;
        }
        LoadLevel(levels.IndexOf(scene));
    }


    public void LoadNextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }



}
