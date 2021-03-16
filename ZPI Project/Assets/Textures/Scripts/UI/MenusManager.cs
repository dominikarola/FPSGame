using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[System.Serializable]
public struct Menu
{
    public string name;
    public Transform transform;
    public bool alwaysVisible;
}

public class MenusManager : MonoBehaviour {

    public List<Menu> menus;
    public string actualVisible;

    // Use this for initialization
    void Start() {
        startupActive();

        Menu menu;
        if (findMenu(actualVisible, out menu))
        {
            show(menu.transform);
        }
    }

    private bool findMenu(string name, out Menu menu)
    {
        menu = new Menu();
        foreach (Menu m in menus)
        {
            if (m.name == name)
            {
                menu = m;
                return true;
            }
        }
        return false;
    }

    private void startupActive()
    {
        foreach (Menu m in menus)
        {
            if (m.alwaysVisible)
            {
                show(m.transform);
            }
            else
            {
                hide(m.transform);
            }
        }
    }

    private void hideAll()
    {
        foreach (Menu m in menus)
        {
            hide(m.transform);
        }
    }

    private void show(Transform transform)
    {
        if (transform)
        {
            transform.gameObject.SetActive(true);
        }
    }

    private void hide(Transform transform)
    {
        if (transform)
        {
            transform.gameObject.SetActive(false);
        }
    }
	
    public void newActive(string panelName)
    {
        Menu m;
        if (findMenu(panelName, out m))
        {
            if (panelName == actualVisible)
            {
                if (isMenuActive(m.transform)) {
                    hide(m.transform); 
                }
                else
                {
                    show(m.transform);
                }
                return;
            }

            show(m.transform);

            if (panelName != actualVisible && findMenu(actualVisible, out m))
            {
                if (!m.alwaysVisible)
                {
                    hide(m.transform);
                }
            }

            actualVisible = panelName;
        }
    }

    private bool isMenuActive(Transform tran)
    {
        return tran.gameObject.activeInHierarchy;
    }
}
