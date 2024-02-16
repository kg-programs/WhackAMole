using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public TMP_Text sendMessageText;
    int score;
    [SerializeField] GameObject molePrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] Button restart;
    float timeRandom =0.0f;
    float elapsed = 0;
    float x;
    float y;
    int difficultyLevel;
    int lives;
    
    // Start is called before the first frame update
    public void Start()
    {
        restart.gameObject.SetActive(false);
        lives = 3;
        score = 0;
        difficultyLevel = 1;
        Spawn();
        timeRandom = Random.Range(-0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {            
        sendMessageText.text = "Score: " + score.ToString() + " Lives: " + lives.ToString();
        if(lives > 0) { 

            elapsed += Time.deltaTime;
            if (elapsed >= (timeBetweenSpawns + timeRandom))
            {
                Spawn();
                elapsed = 0;
            }
            if (score > difficultyLevel * 20)
            {
                difficultyLevel++;
                if (difficultyLevel < 5)
                {
                    timeBetweenSpawns = timeBetweenSpawns - 0.1f;
                }
            }
        }
        else
        {
            restart.gameObject.SetActive(true);
        }
    }

    public void updateScore(int amount)
    {
        score+=amount;
        timeRandom = Random.Range(-0.5f, 0.5f);
    }

    public void updateLives()
    {
        lives--;
    }

    private void Spawn()
    {
        GameObject mole = Instantiate(molePrefab, transform);
        x = Random.Range(0, GetComponent<RectTransform>().rect.width);
        y = Random.Range(0, GetComponent<RectTransform>().rect.height);
        mole.transform.position = new Vector3(x, y);
    }

}
