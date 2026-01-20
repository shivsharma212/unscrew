using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;
    private int boltsRemoved = 0;
    private int totalBolts;

    private void Awake() { Instance = this; }

    public void RegisterBolt() { totalBolts++; }

    public void OnBoltRemoved()
    {
        boltsRemoved++;
        if (boltsRemoved >= totalBolts) LevelComplete();
    }

    public void Fail()
    {
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("Fail State Triggered!");
    }

    public void LevelComplete()
    {
        Debug.Log("Level Complete!");
        isGameOver = true;
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}