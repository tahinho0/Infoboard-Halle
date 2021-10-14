using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private InputField API;
    [SerializeField] private InputField API_KEY;
    [SerializeField] private InputField Project_ID;
    [SerializeField] public Text fehler_m;

    public void LoadnextScene()
    {
        try
        {
            string[] savefile = File.ReadAllText(Application.dataPath + "/SAVEFILE.txt").Split(' ');
            Kunde_Daten.API = savefile[0];
            Kunde_Daten.KEY = savefile[1];
            Kunde_Daten.Projekt_ID = int.Parse(savefile[2]);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Single);
        }
        catch (IOException e)
        {
            // Datei nicht gefundden
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
    }

    private void Start()
    {
        Showerror();
    }

    public void setErrorMessage(string msg)
    {
        fehler_m.text = msg;
    }

    public void Simulation()
    {
        if (API.text.Length != 0 && API.text[API.text.Length - 1] != '/')
        {
            Kunde_Daten.API = API.text;

            if (API_KEY.text.Length != 0)
            {
                Kunde_Daten.KEY = API_KEY.text;

                if (Project_ID.text.Length != 0 && int.TryParse(Project_ID.text, out int n))
                {
                    Kunde_Daten.Projekt_ID = int.Parse(Project_ID.text);

                    string SAVEFILE = Kunde_Daten.API + " " + Kunde_Daten.KEY + " " + Kunde_Daten.Projekt_ID;
                    File.WriteAllText(Application.dataPath + "/SAVEFILE.txt", SAVEFILE);

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
                    ErrorMessageRepeat.showErrorMessageRepeat = false;
                }
                else
                {
                    fehler_m.text = "Bitte Projekt ID eingeben";
                }
            }
            else
            {
                fehler_m.text = "Bitte API Schlüssel eingeben";
            }
        }
        else
        {
            fehler_m.text = "Ungültige API";
        }
    }

    public void Showerror()
    {
        if (ErrorMessageRepeat.showErrorMessageRepeat)
        {
            fehler_m.text = "UNGÜLTIGE EINGABE";
        }
    }
}