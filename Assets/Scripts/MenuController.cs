using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject shopMenu;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button shopMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(OpenMainMenu);
        shopMenuButton.onClick.AddListener(OpenShopMenu);
        mainMenu.SetActive(false);
        shopMenu.SetActive(false);

    }

    void OpenMainMenu()
    {
        if (mainMenu.activeSelf)
        {
            mainMenu.SetActive(false);
        }
        else
        {
            mainMenu.SetActive(true);
            shopMenu.SetActive(false);
        }
    }

    void OpenShopMenu()
    {
        if (shopMenu.activeSelf)
        {
            shopMenu.SetActive(false);
        }
        else
        {
            shopMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

}
