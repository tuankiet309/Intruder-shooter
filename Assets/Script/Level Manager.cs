using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float sceneLoadDelay = 1f;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {

    }
    public void LoadGame()
    {
        
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("Over", sceneLoadDelay));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }    
}
