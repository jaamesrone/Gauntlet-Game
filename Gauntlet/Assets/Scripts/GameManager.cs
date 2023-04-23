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
    public GameObject warriorPrefab;

    private PlayerInputManager inputManager;

    public List<PlayerController> players = new List<PlayerController>();

    public override void Awake()
    {
        base.Awake();
        players.Add(PlayerInput.Instantiate(warriorPrefab, controlScheme: "Wasd", pairWithDevice: Keyboard.current).GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(playerPrefab, controlScheme: "Arrow", pairWithDevice: Keyboard.current).GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(playerPrefab, controlScheme: "Stick").GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(playerPrefab, controlScheme: "Stick").GetComponent<PlayerController>());
    }

    // Start is called before the first frame update
    void Start()
    {
    

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
