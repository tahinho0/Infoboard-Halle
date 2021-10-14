using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menü : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject menü;

    private void Start()
    {
        menü.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            menü.SetActive(!menü.activeSelf);
            if (menü.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
    }

    public void exitgame()
    {
        Application.Quit();
    }

    [System.Obsolete]
    public void einstellung()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}