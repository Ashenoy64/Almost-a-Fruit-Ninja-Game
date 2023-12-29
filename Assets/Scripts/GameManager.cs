using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI strike;
    private float spawnRate = 1.0f;
    public bool isGameActive = false;
    public GameObject titleScreen;
    public bool test;
    private int strikeCount = 0;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        gameOver.gameObject.SetActive(true);
    }
    public void StartGame(int difficluty)
    {
        spawnRate /= difficluty;
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        gameOver.gameObject.SetActive(false);
    }
    
    public void UpdateStrike()
    {
        if(isGameActive)
        {
            strikeCount += 1;
            strike.text = strike.text + "X";
            if(strikeCount>=3 )
                GameOver();

        }
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
