using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class Hinze_NewScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Maschinen;
    private string data = "";
    private string error = "";

    private List<Machines_Data> daten_save;

    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Task_name;
    [SerializeField] private GameObject InfoBox;
    [SerializeField] private Slider slider;

    private bool isFinished = false;

    private float timer = 5, cooldown = 5;

    private Process process = new Process();
    private ProcessStartInfo startInfo = new ProcessStartInfo();

    private void Start()
    {
        string[] savefile = File.ReadAllText(Application.dataPath + "/SAVEFILE.txt").Split(' ');
        Kunde_Daten.API = savefile[0];
        Kunde_Daten.KEY = savefile[1];
        Kunde_Daten.Projekt_ID = int.Parse(savefile[2]);

        InvokeRepeating("APIRequest", 0, 5f);
    }

    public void showInfo(string name)
    {
        for (int i = 0; i < Maschinen.Count; i++)
        {
            //Debug.Log("Maschine   :" + Maschinen[i].name + " daten_save  :" + daten_save + "    daten_save[i]   :   " + daten_save[i] + "     daten_save.count  :  " + daten_save.Count);
            if (Maschinen[i].name == name && daten_save != null && daten_save[i] != null && daten_save.Count > 0)
            {
                Debug.Log("in der if");
                Name.text = daten_save[i].RowName;
                Task_name.text = daten_save[i].ItemName;
                //TimeSpan time = (TimeSpan)(daten_save[i].End - daten_save[i].Start);
                //TimeSpan jetzt = ((TimeSpan)(DateTime.Now - daten_save[i].Start));
                //slider.value = jetzt.Seconds / time.Seconds;
                InfoBox.SetActive(true);
                break;
            }
        }
    }

    public void hideInfoBox()
    {
        InfoBox.SetActive(false);
    }

    public void APIRequest()
    {
        process = new Process();
        startInfo = new ProcessStartInfo();
        startInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
        data = "";

        error = "";
        startInfo.CreateNoWindow = true;

        startInfo.WorkingDirectory = "T:\\Hafeneger\\SaveFileGenerator V3\\SaveFileGenerator\\bin\\Debug\\net5.0";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.FileName = "T:\\Hafeneger\\SaveFileGenerator V3\\SaveFileGenerator\\bin\\Debug\\net5.0\\SaveFileGenerator.exe";
        startInfo.Arguments = Kunde_Daten.API + " " + Kunde_Daten.KEY + " " + Kunde_Daten.Projekt_ID;
        startInfo.RedirectStandardInput = true;
        process.StartInfo = startInfo;
        process.EnableRaisingEvents = true;
        process.Exited += new EventHandler(OnExit);
        process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                data += e.Data;
            }
        });

        process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                error += e.Data;
            }
        });
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
    }

    private void OnExit(object sender, EventArgs e)
    {
        isFinished = true;
    }

    private void Update()
    {
        if (isFinished)
        {
            setMachines();
            isFinished = false;
        }
    }

    private void setMachines()
    {
        if (data == "ERROR" || error.Length > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            ErrorMessageRepeat.showErrorMessageRepeat = true;
        }
        else
        {
        }

        daten_save = JsonConvert.DeserializeObject<List<Machines_Data>>(data);

        for (int i = 0; i < Maschinen.Count; i++)
        {
            if (daten_save != null && i < daten_save.Count)
            {
                bool Isaktive = daten_save[i].IsActive;

                Maschinen[i].SetActive(true);
                Light Machine = Maschinen[i].GetComponentInChildren<Light>();

                var biege = Maschinen[i].GetComponent<BiegeAnimation>();
                var fräs = Maschinen[i].GetComponent<FräsAnimation>();

                if (Isaktive)
                {
                    Machine.color = Color.green;
                    //if (biege != null)
                    //{
                    //    biege.Bending_Maschine_WorkAnimnation();
                    //}

                    //if (fräs != null)
                    //{
                    //    fräs.Doors_Close();
                    //    fräs.Milling_Maschine_WorkAnimation();
                    //}
                }
                else
                {
                    Machine.color = Color.red;

                    //if (biege != null)
                    //{
                    //    biege.Bending_Maschine_IdleAnimnation();
                    //}

                    //if (fräs != null)
                    //{
                    //    fräs.Doors_Open();
                    //    fräs.Milling_Maschine_IdleAnimation();
                    //}
                }
            }
            else
            {
                Maschinen[i].SetActive(false);
            }
        }
        data = "";
        error = "";
        process.Close();
    }
}