using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public enum ItemName
{
    Potion,
    Food,
}

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI timerUI;
    public float timer = 2000f;

    public GameObject playerPrefab;
    public GameObject warriorPrefab;
    public GameObject wizardPrefab;
    public GameObject elfPrefab;
    public GameObject valkyriePrefab;
    public GameObject treasureBagPrefab;


    private PlayerInputManager inputManager;

    public List<PlayerController> players = new List<PlayerController>();

    public List<Enemy> enemys = new List<Enemy>();

    public override void Awake()
    {
        base.Awake();
        players.Add(PlayerInput.Instantiate(warriorPrefab, controlScheme: "Wasd", pairWithDevice: Keyboard.current).GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(wizardPrefab, controlScheme: "Arrow", pairWithDevice: Keyboard.current).GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(elfPrefab, controlScheme: "Stick").GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(valkyriePrefab, controlScheme: "Stick").GetComponent<PlayerController>());
    }

    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
      //  UpdateTime();
    }

    //public void UpdateTime()
    //{
    //    timer -= Time.deltaTime;
    //    timerUI.text = "Health: " + timer.ToString("F2");
    //}

}
