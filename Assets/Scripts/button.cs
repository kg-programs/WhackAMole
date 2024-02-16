using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    gameManager player;
    public Button mole;
    bool scorePossible = true;
    [SerializeField] int amount;
    float destroyTime = 1.0f;
    float elapsed = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = FindObjectOfType<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= destroyTime)
        {
            player.updateLives();
            Destroy(gameObject);
        }
        Button btn = mole.GetComponent<Button>();
        btn.onClick.AddListener(click);
    }
    private void click()
    {
        if (scorePossible)
        {
            scorePossible = false;
            player.updateScore(amount);
            Destroy(gameObject);
        }
    }
}
