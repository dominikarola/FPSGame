using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelectScript : MonoBehaviour {

    public Transform buttonPref;

    public Transform mapContent;
    public Transform levelContent;

    public List<MapInfo> maps;

    int mapSelected = -1;

    // Use this for initialization
    void Start () {
        int i = 0;
		foreach (MapInfo mp in maps)
        {
            var obj = Instantiate(buttonPref);
            obj.SetParent(mapContent);
            buttonInfoSet(obj, mp, true);

            addListnersToMapButton(obj, i);

            i++;
        }

         selectMap(LevelData.mapNumber);
    }


    void buttonInfoSet(Transform obj, ButtonInfo info, bool active)
    {
        var textComp = obj.GetComponentInChildren<Text>();
        textComp.text = info.displayName;

        var button = obj.GetComponent<Button>();

        button.interactable = active;
    }


    void addListnersToMapButton(Transform mapButton, int nr)
    {
        var button = mapButton.GetComponent<Button>();
        button.onClick.AddListener(() => buttonClickSelectMap(nr));
    }

    void addListnersToLevelButton(Transform levelButton, LevelInfo lv)
    {
        var button = levelButton.GetComponent<Button>();
        button.onClick.AddListener(() => buttonClickedStartLevel(lv));
    }


    public void buttonClickSelectMap(int nr)
    {
        if (nr >= 0)
            selectMap(nr);
    }

    public void selectMap(int nr)
    {
        mapSelected = nr;
        updateListOfLevels(nr);
    }

    void updateListOfLevels(int newMapIndex)
    {
        destroyChildren(levelContent);

        var levels = maps[newMapIndex].levels;
        for ( int i=0; i<levels.Count; i++)
        {
            var obj = Instantiate(buttonPref);
            obj.SetParent(levelContent);

            addListnersToLevelButton(obj, levels[i]);

            //if (i > 0)
            //{
            //    buttonInfoSet(obj, levels[i], GameStatsData.levelFinished(newMapIndex, i-1));
            //    obj.GetChild(1).gameObject.SetActive(true);
            //}
            //else
            {
                buttonInfoSet(obj, levels[i], levels[i].finished);
            }
        }

    }

    void destroyChildren(Transform obj)
    {
        for (int i= obj.childCount-1; i >= 0; i--)
        {
            var child = obj.GetChild(i);
            child.SetParent(null);
            Destroy( child.gameObject );
        }
    }


    public void buttonClickedStartLevel(LevelInfo info)
    {
        SceneManager.LoadScene(info.levelName);
    }

}
