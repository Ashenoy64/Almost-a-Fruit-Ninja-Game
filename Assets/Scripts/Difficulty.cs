using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Difficulty : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        if(gameObject.name == "Easy")
            gameManager.StartGame(1);

        else if (gameObject.name == "Hard")
            gameManager.StartGame(3);

        else
            gameManager.StartGame(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
