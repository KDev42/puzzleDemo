using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] Text levelInd;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject selectLevelPanel;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] ChangeOfArenas ca;

    private int count;

    private void Start()
    {
        InterScriptsSpace iss = InterScriptsSpace.Instance;
        iss.changeLevel += counterOverwrite;
        iss.restartLevel += counterOverwrite;
        iss.wasMove += changeCounter;
        iss.endGame += endGame;
    }

    public void backToMenu()
    {
        startPanel.SetActive(true);
        endGamePanel.SetActive(false);
    }

    public void choiceLevel(int level)
    {
        InterScriptsSpace.Instance.level = level - 2;
        levelInd.text = level.ToString();
        selectLevelPanel.SetActive(false);
    }

    public void levelSelect()
    {
        selectLevelPanel.SetActive(true);
    }

    public void play()
    {
        startPanel.SetActive(false);
        ca.changeArenas();
    }

    public void restart()
    {
        InterScriptsSpace.Instance.shellRestartLevel();
    }

    private void changeCounter()
    {
        count--;
        counter.text = (count).ToString();
    }

    private void counterOverwrite()
    {
        count = InterScriptsSpace.Instance.numberOfMovesLevel[InterScriptsSpace.Instance.level];
        counter.text = count.ToString();
    }

    private void endGame()
    {
        endGamePanel.SetActive(true);
    }
}
