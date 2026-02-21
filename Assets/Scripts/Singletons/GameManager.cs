using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance {get; private set;}

    # region Secondary Managers
    public LevelManager LevelManager {get; private set;}
    #endregion


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        LevelManager = new LevelManager();
    }
}
