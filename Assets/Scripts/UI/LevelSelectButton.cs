using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public string scene;


    public void onClick()
    {
        GameManager.Instance.LevelManager.LoadLevel(scene);
    }
}
