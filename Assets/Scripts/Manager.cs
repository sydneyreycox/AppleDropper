using UnityEngine;
using TMPro;
using System.Collections;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public GameObject[] lifeMarkers;
    public float treeSpeed = 5f;
    public float appleSpeed = 1f;
    public float playerSpeed = 4f;
    public float appleRotationSpeed = 180f; 
    private int points = 0;
    private int lives = 3;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public TMP_Text increasingSpeedText;
    public float appleSpawnRate = 0f;
    public int increaseThreshold = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("Starting Manager");
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GainPoint()
    {
        Debug.Log("Adding Point");
        scoreText.text = "SCORE: " + ++points;
        if(appleSpawnRate!=2 && points % increaseThreshold == 0) IncreaseDifficulty();
    }

    public void IncreaseDifficulty()
    {
        Debug.Log("Increasing Difficulty");
        appleSpawnRate+=0.5f;
        StartCoroutine(FlashSpeedText());
    }

    IEnumerator FlashSpeedText()
    {
        for(int i = 0; i < 3; i++)
        {
            increasingSpeedText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            increasingSpeedText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
        increasingSpeedText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        increasingSpeedText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
    public void LoseLife()
    {
        --lives;
        if (lives > 0)
        {
            lifeMarkers[lives-1].SetActive(false);
            Debug.Log("Losing 1 life");
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Ending Game");
        Time.timeScale = 0f;
        gameOverText.text = "Game Over!\nScore: " + points;
        gameOverText.gameObject.SetActive(true);
    }
}