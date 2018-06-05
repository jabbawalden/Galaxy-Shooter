using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {


    [SerializeField]
    private GameObject _player;
    private UIManager _uiManager;

    public bool gameOver;

    private void Start()
    {
        gameOver = true;
        _uiManager = GameObject.Find("UI").GetComponent<UIManager>();

    }
    // Update is called once per frame
    void Update ()
    {
        PlayerInput();
        GameState();
        
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameOver)
        {
            Instantiate(_player, transform.position, Quaternion.identity);
            
            gameOver = false;
        }

    }

    private void GameState()
    {
        if (gameOver)
        {
            _uiManager.HideUI();
        }
        else if (!gameOver)
        {
            _uiManager.ShowUI();
        }
    }


}
