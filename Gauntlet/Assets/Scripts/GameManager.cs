using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI timerUI;
    public float timer = 2000f;

    public GameObject playerPrefab;

    private PlayerInputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.Instantiate(playerPrefab, controlScheme: "Wasd", pairWithDevice: Keyboard.current);
        PlayerInput.Instantiate(playerPrefab, controlScheme: "Arrow", pairWithDevice: Keyboard.current);
        PlayerInput.Instantiate(playerPrefab, controlScheme: "Stick");
        PlayerInput.Instantiate(playerPrefab, controlScheme: "Stick");

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        timer -= Time.deltaTime;
        timerUI.text = "Health: " + timer.ToString("F2");
    }

}
