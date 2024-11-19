using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                
                if (instance == null)
                {
                    GameObject obj = new GameObject(nameof(GameManager));
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
            SetGameState(GameState.Start);
            Debug.Log($"current state : {currentState}");
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }
    #endregion
    public GameState currentState; 

    public void SetGameState(GameState newState)
    {
        currentState = newState;
    }
    public GameState GetGameState()
    {
        return currentState;
    }
}