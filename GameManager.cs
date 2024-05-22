using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    
    // Start is called before the first frame update
    void Start()
    {   
        
    }
    public void GameOver(){
       gameOverText.gameObject.SetActive(true);
       restartButton.gameObject.SetActive(true);
        
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
IEnumerator SpawnTarget(){
        
            while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
            
          
        }
    }
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void StartGame(int difficulty){
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        spawnRate /= difficulty;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        
    }

    
}
