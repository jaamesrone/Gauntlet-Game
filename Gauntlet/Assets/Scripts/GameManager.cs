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

    public List<Enemy> enemys;

    public override void Awake()
    {
        base.Awake();
        players.Add(PlayerInput.Instantiate(warriorPrefab, controlScheme: "Wasd", pairWithDevice: Keyboard.current).GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(wizardPrefab, controlScheme: "Arrow", pairWithDevice: Keyboard.current).GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(elfPrefab, controlScheme: "Stick").GetComponent<PlayerController>());
        players.Add(PlayerInput.Instantiate(valkyriePrefab, controlScheme: "Stick").GetComponent<PlayerController>());
    }

    private void Start()
    {
        InitScene();
    }

    public void InitScene()
    {
        enemys = new List<Enemy>();
        Death[] ds = GameObject.Find("Deaths").GetComponentsInChildren<Death>();
        for (int i = 0; i < ds.Length; i++)
        {
            enemys.Add(ds[i]);
        }
    }

}
