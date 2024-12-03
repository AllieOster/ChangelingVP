using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region GameState
    public GameState currentState;

    public void SetGameState(GameState newState)
    {
        currentState = newState;
    }

    public GameState GetGameState()
    {
        return currentState;
    }
    #endregion
}
