using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Menu, Bag, Shop, controls}

public class GameController : MonoBehaviour
{
    #region Variables

    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] GameObject PauseUI;
    MainMenu PauseMenuUI;


    GameState state;
    GameState prevState;

    MenuController menuController;

    public static GameController Instance { get; private set; }

    #endregion

    #region Methods
    private void Awake()
    {
        Instance = this;
        PauseMenuUI = GetComponent<MainMenu>();
        menuController = GetComponent<MenuController>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            prevState = state;
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = prevState;
        };

        menuController.onBack += () =>
        {
            state = GameState.FreeRoam;
        };

        menuController.onMenuSelected += OnMenuSelected;

        ShopController.i.OnStart += () => state = GameState.Shop;
        ShopController.i.OnFinish += () => state = GameState.FreeRoam;
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                menuController.OpenMenu();
                state = GameState.Menu;
            }
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Menu)
        {
            menuController.HandleUpdate();
        }
        else if (state == GameState.Bag)
        {
            Action onBack = () =>
            {
                inventoryUI.gameObject.SetActive(false);
                state = GameState.FreeRoam;
            };

            inventoryUI.HandleUpdate(onBack);
        }
        else if (state == GameState.Shop)
        {
            ShopController.i.HandleUpdate();
        }
    }

    void OnMenuSelected(int selectedItem)
    {
        if (selectedItem == 0)
        {  
            //Bag
            inventoryUI.gameObject.SetActive(true);
            state = GameState.Bag;
        }
        else if (selectedItem == 1)
        {
            //Menu
            PauseUI.SetActive(true);
            Time.timeScale = 0f;
            state = GameState.controls;
            
        }
        else if (selectedItem == 2)
        {
            //Menu
            PauseMenuUI.Back();
        }
        else if (selectedItem == 3)
        {
            //Quit
            PauseMenuUI.Quit();
        }
    }

    public void Out()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        menuController.OpenMenu();
        state = GameState.Menu;
    }
    public GameState State => state;

    #endregion

}
