using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private float spawnRate = 1;
    public bool isGameActive;

    void Start()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = true;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

   
    void Update()
    {
        if(score<0)
        {
            GameOver();
        }
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {   
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        while (isGameActive)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;

        }
    }
    public void GameOver()
    {
        
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
