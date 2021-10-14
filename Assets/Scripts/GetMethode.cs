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

[Serializable]
public class GetMethode : MonoBehaviour
{
    //private InputField OutputArea;
    //private InputField OutputArea1;

    private string alles_GetToken;
    private string alles_GetRows;
    private string alles_GetItemSellinfo;
    private string alles_GetCurrentlyActiveItem;

    private Light DrehMachinen;
    private Light FräseMaschinen;
    private Light BiegeMaschinen;

    private string data = "";
    private bool firsttime = true;

    [SerializeField] private GameObject bendingPlate;
    [SerializeField] private GameObject bendingTube;

    [SerializeField] private float bendingPlateRotationX;
    [SerializeField] private float bendingTubeRotationX;
    [SerializeField] private float bendingTubePositionY;
    private const float BendingTubeMoveValue = 1.3f;
    private const float BendingRotateValue = -35f;

    [SerializeField] private GameObject doorL;
    [SerializeField] private GameObject doorR;

    private float doorLStartPosX;
    private float doorRStartPosX;
    private const float DoorMoveValue = -0.65f;

    [Header("Milling Machine movement")]
    [SerializeField] private GameObject millingMachine;

    private Vector3 millingMachineStartPos;

    [System.Obsolete]
    private void Start()
    {
        //InvokeRepeating("five_sec", 5, 5);
        //process = new Process();
        //ProcessStartInfo startInfo = new ProcessStartInfo();
        //startInfo.CreateNoWindow = true;
        //startInfo.WorkingDirectory = "T:\\Hafeneger\\SaveFileGenerator V2\\SaveFileGenerator\\bin\\Debug\\net5.0";
        //startInfo.UseShellExecute = false;
        //startInfo.RedirectStandardOutput = true;
        //startInfo.RedirectStandardError = true;
        //startInfo.FileName = "T:\\Hafeneger\\SaveFileGenerator V2\\SaveFileGenerator\\bin\\Debug\\net5.0\\SaveFileGenerator.exe";
        //startInfo.Arguments = Kunde_Daten.API + " " + Kunde_Daten.KEY + " " + Kunde_Daten.Projekt_ID;
        //startInfo.RedirectStandardInput = true;
        //process.StartInfo = startInfo;
        //process.EnableRaisingEvents = true;
        //process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        //{
        //    if (!String.IsNullOrEmpty(e.Data))
        //    {
        //        data += e.Data;
        //    }
        //});

        DrehMachinen = GameObject.FindGameObjectWithTag("DrehMaschine").GetComponent<Light>();
        FräseMaschinen = GameObject.FindGameObjectWithTag("FräseMaschine").GetComponent<Light>();
        BiegeMaschinen = GameObject.FindGameObjectWithTag("BiegeMaschine").GetComponent<Light>();

        doorLStartPosX = doorL.transform.localPosition.x;
        doorRStartPosX = doorR.transform.localPosition.x;

        millingMachineStartPos = millingMachine.transform.localPosition;
        //OutputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        //OutputArea1 = GameObject.Find("OutputArea1").GetComponent<InputField>();

        //InvokeRepeating("GetData", 1, 10);
        //InvokeRepeating("save", 1, 45);
        //process.Start();
        //process.BeginOutputReadLine();
        string[] savefile = File.ReadAllText(Application.dataPath + "/SAVEFILE.txt").Split(' ');
        Kunde_Daten.API = savefile[0];
        Kunde_Daten.KEY = savefile[1];
        Kunde_Daten.Projekt_ID = int.Parse(savefile[2]);
        InvokeRepeating("five_sec", 1, 10);

        //InvokeRepeating("PostData", 5, 30);

        //GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
        //GameObject.Find("PosTButton").GetComponent<Button>().onClick.AddListener(PostData);
    }

    //[System.Obsolete]
    //private void GetData() => StartCoroutine(GetToken());

    //[Obsolete]
    ////private void PostData() => StartCoroutine(GetItemSellinfos());
    ////private void PostData() => StartCoroutine(GetRows());
    //private void PostData() => StartCoroutine(GetRows());

    //private void PostData() => StartCoroutine(GetCurrentlyActiveItem());

    //[System.Obsolete]
    //private IEnumerator GetToken()
    //{
    //    //OutputArea.text = "Loading ..........";
    //    //Debug.Log("Get Token Start");
    //    string uri = "https://intern.infoboard.biz:501/api/Authentication/CreateAPIToken";
    //    string Key = "e1c8fd3879bd33281eee6f2a435e9ba9f35ede9fe66c27ed3f7333613c11e682";
    //    using (UnityWebRequest request = UnityWebRequest.Put(uri, $"\"{Key}\""))
    //    {
    //        request.method = "POST";
    //        request.SetRequestHeader("Content-Type", "application/json");

    //        yield return request.SendWebRequest();
    //        if (request.isNetworkError || request.isHttpError)
    //        {
    //            OutputArea.text = request.error;
    //        }
    //        else
    //        {
    //            OutputArea.text = request.downloadHandler.text;
    //            //Debug.Log(OutputArea.text);
    //            alles_GetToken = request.downloadHandler.text;
    //            ApiResponse daten = JsonConvert.DeserializeObject<ApiResponse>(alles_GetToken);

    //            OutputArea.text = ("content  :     " + daten.Content + "                             apiCode :" + daten.ApiCode.ToString() + "              httpCode :" + daten.HTTP.ToString() + "                message  :" + daten.Message);
    //            ;
    //            if (ApiCodeCheck(daten.ApiCode) == false)
    //            {
    //                Debug.Log("API CODE IS DEAD");
    //            }
    //            Token_Static.Token = (string)daten.Content;
    //            //mystatclass.HTTP = daten.httpCode.ToString();
    //            //mystatclass.ApiCode = daten.apiCode;
    //        }
    //    }
    //}

    //[Obsolete]
    //private IEnumerator GetRows()
    //{
    //    string url = "https://intern.infoboard.biz:501/api/Row/Project?projectId=1&args=RowName,Idx";

    //    using (UnityWebRequest request2 = UnityWebRequest.Get(url))
    //    {
    //        request2.SetRequestHeader("Authorization", "Bearer " + Token_Static.Token);

    //        yield return request2.SendWebRequest();
    //        if (request2.isNetworkError || request2.isHttpError)
    //        {
    //            //OutputArea1.text = request2.error;
    //            GetData();
    //        }
    //        else
    //        {
    //            alles_GetRows = request2.downloadHandler.text;
    //            ApiResponse daten2 = JsonConvert.DeserializeObject<ApiResponse>(alles_GetRows);
    //            //var daten3 = (JsonToken)daten2.Content;

    //            OutputArea1.text = alles_GetRows;
    //            //string uno = daten2.Content.ToString();
    //            //TROWContent dos = JsonConvert.DeserializeObject<TROWContent>(alles_GetRows);

    //            //OutputArea1.text = /*daten2.Content.ToString() + */Environment.NewLine + rows1.ToString();
    //            //int code = daten2.ApiCode;
    //            //OutputArea1.text = alles_GetRows;

    //            //for (int i = 0; i < dos.Content.Count; i++)
    //            //{
    //            //    int IDX = dos.Content[i].Idx;
    //            //    OutputArea1.text += "Calling ActiveItem on " + IDX + Environment.NewLine;
    //            //    GetCurrentlyActiveItem(IDX);
    //            //    //    //Debug.Log("Result   _:  " + GetCurrentlyActiveItem(IDX));
    //            //    //    //string Id = rows[i].id;
    //            //    //    //string Rowname = rows[i].RowName;
    //            //    //    //OutputArea1.text = ("ID 5 :" + Id + "       ROW 5 : " + Rowname);
    //            //    //    //OutputArea1.text = item.ToString();
    //            //}

    //            //string JSFile = daten2.Content.ToString();
    //            //File.WriteAllText(Application.dataPath + "/Text.txt", JSFile);
    //            //string ALLDATA = (JSFile.ToString());
    //        }
    //    }
    //}

    //[Obsolete]
    //private IEnumerator GetItemSellinfos()
    //{
    //    string url_itemsell = "https://intern.infoboard.biz:501/api/ItemSealInfo/Project?projectId=1&args=RowId,CurrentSealingItem,Idx,OriginalStart";
    //    using (UnityWebRequest request3 = UnityWebRequest.Get(url_itemsell))
    //    {
    //        request3.SetRequestHeader("Authorization", "Bearer " + mystatclass.Token);

    //        yield return request3.SendWebRequest();
    //        if (request3.isNetworkError || request3.isHttpError || ApiCodeCheck() == false)
    //        {
    //            OutputArea1.text = request3.error;
    //            GetData();
    //        }
    //        else
    //        {
    //            alles_GetItemSellinfo = request3.downloadHandler.text;
    //            //OutputArea1.text = alles2;

    //            ItemSellContent daten3 = JsonConvert.DeserializeObject<ItemSellContent>(alles_GetItemSellinfo);

    //            //string JSFile_ItemSell = daten3.Content.ToString();
    //            for (int i = 0; i < daten3.Content.Count; i++)
    //            {
    //                int ID = daten3.Content[i].ID;
    //                int ROW = daten3.Content[i].RowID;
    //                DateTime Timeit = daten3.Content[i].OriginalStart;
    //                //OutputArea1.text = ("ID 5 :" + ID + "       ROW 5 : " + ROW + "      OriginalStart :" + Timeit);
    //                Debug.Log("ID " + i + " : " + ID + "       ROW " + i + " : " + ROW + "       OriginalStart" + i + " : " + Timeit);
    //            }

    //            //foreach (var ID in daten3.Content)
    //            //{
    //            //    int i = 0;
    //            //    int zahl = daten3.Content[i].ID;
    //            //    int ROW = daten3.Content[i].RowID;
    //            //    Debug.Log(zahl + "   " + ROW);
    //            //    i++;
    //            //}
    //            //int ID1 = daten3.Content[0].ID;
    //            //int ROW1 = daten3.Content[0].RowID;

    //            //ItemSell_ID_RowID daten4 = JsonConvert.DeserializeObject<ItemSell_ID_RowID>(JSFile_ItemSell);
    //            //string JSFile_ID = daten4.ID.ToString();
    //            //string JSFile_RowID = daten4.RowID.ToString();

    //            //OutputArea1.text = ("ID    :" + JSFile_ID + "     ROWID :" + JSFile_RowID);
    //        }
    //    }
    //}

    //[Obsolete]
    //private IEnumerator GetCurrentlyActiveItem(int rowId)
    //{
    //    string url_CurrentlyactiveItem = $"https://intern.infoboard.biz:501/api/Row/ActiveItem?rowId={rowId}";
    //    using (UnityWebRequest request4 = UnityWebRequest.Get(url_CurrentlyactiveItem))
    //    {
    //        request4.SetRequestHeader("Authorization", "Bearer " + Token_Static.Token);

    //        yield return request4.SendWebRequest();
    //        if (request4.isNetworkError || request4.isHttpError)
    //        {
    //            OutputArea1.text = request4.error;
    //            GetData();
    //        }
    //        else
    //        {
    //            alles_GetCurrentlyActiveItem = request4.downloadHandler.text;
    //            //OutputArea1.text = alles2;

    //            //ItemSellContent daten4 = JsonConvert.DeserializeObject<ItemSellContent>(alles_GetCurrentlyActiveItem);

    //            //string JSFile_ItemGroup = daten4.ToString();

    //            OutputArea1.text += "Result: " + alles_GetCurrentlyActiveItem + Environment.NewLine;

    //            //foreach (var ID in daten3.Content)
    //            //{
    //            //    int i = 0;
    //            //    int zahl = daten3.Content[i].ID;
    //            //    int ROW = daten3.Content[i].RowID;
    //            //    Debug.Log(zahl + "   " + ROW);
    //            //    i++;
    //            //}
    //            //int ID1 = daten3.Content[0].ID;
    //            //int ROW1 = daten3.Content[0].RowID;

    //            //ItemSell_ID_RowID daten4 = JsonConvert.DeserializeObject<ItemSell_ID_RowID>(JSFile_ItemSell);
    //            //string JSFile_ID = daten4.ID.ToString();
    //            //string JSFile_RowID = daten4.RowID.ToString();

    //            //OutputArea1.text = ("ID    :" + JSFile_ID + "     ROWID :" + JSFile_RowID);
    //        }
    //    }
    //}
    //public void save()
    //{
    //    string saveit = "T:\\Hafeneger\\SaveFileGenerator\\SaveFileGenerator\\bin\\Debug\\net5.0\\SaveFiles\\SaveFile.json";
    //    StreamReader reader = new StreamReader(saveit);
    //    //OutputArea1.text = reader.ReadToEnd();
    //    List<SaveFileklasse> daten_save = JsonConvert.DeserializeObject<List<SaveFileklasse>>(reader.ReadToEnd());
    //    for (int i = 0; i < daten_save.Count; i++)
    //    {
    //        string rowname = daten_save[i].RowName;
    //        bool Isaktive = daten_save[i].IsActive;

    //        //OutputArea1.text += "ROWNAME :     " + rowname + "      IsAktive?  :   " + Isaktive + Environment.NewLine + "\\n" + "\\n";

    //        if (daten_save[i].RowName == "DrehMaschine" && daten_save[i].IsActive == true)
    //        {
    //            DrehMachinen.color = Color.green;
    //        }
    //        else if (daten_save[i].RowName == "DrehMaschine" && daten_save[i].IsActive == false)
    //            DrehMachinen.color = Color.red;
    //        if (daten_save[i].RowName == "FräseMaschine" && daten_save[i].IsActive == true)
    //        {
    //            FräseMaschinen.color = Color.green;
    //        }
    //        else if (daten_save[i].RowName == "FräseMaschine" && daten_save[i].IsActive == false)
    //        {
    //            FräseMaschinen.color = Color.red;
    //        }

    //        if (daten_save[i].RowName == "BiegeMaschine" && daten_save[i].IsActive == true)
    //        {
    //            BiegeMaschinen.color = Color.green;
    //        }
    //        else if (daten_save[i].RowName == "BiegeMaschine" && daten_save[i].IsActive == false)
    //            BiegeMaschinen.color = Color.red;
    //    }
    //}

    public bool ApiCodeCheck(int code)
    {
        if (code == 0)
        {
            return true;
        }
        else return false;
    }

    private void five_sec()
    {
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();

        startInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
        //OutputArea1.text += Kunde_Daten.API + " " + Kunde_Daten.KEY + " " + Kunde_Daten.Projekt_ID;

        startInfo.CreateNoWindow = true;

        startInfo.WorkingDirectory = "T:\\Hafeneger\\SaveFileGenerator V2\\SaveFileGenerator\\bin\\Debug\\net5.0";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.FileName = "T:\\Hafeneger\\SaveFileGenerator V2\\SaveFileGenerator\\bin\\Debug\\net5.0\\SaveFileGenerator.exe";
        startInfo.Arguments = Kunde_Daten.API + " " + Kunde_Daten.KEY + " " + Kunde_Daten.Projekt_ID;
        startInfo.RedirectStandardInput = true;
        process.StartInfo = startInfo;
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                data += e.Data;
            }
        });

        process.Start();
        process.BeginOutputReadLine();

        process.WaitForExit();
        //OutputArea1.text += data;

        List<SaveFileklasse> daten_save = JsonConvert.DeserializeObject<List<SaveFileklasse>>(data);

        if (daten_save != null)
        {
            for (int i = 0; i < daten_save.Count; i++)
            {
                string rowname = daten_save[i].RowName;
                bool Isaktive = daten_save[i].IsActive;

                //OutputArea1.text += "ROWNAME :     " + rowname + "      IsAktive?  :   " + Isaktive + Environment.NewLine + "\n";

                if (daten_save[i].RowName == "DrehMaschine" && daten_save[i].IsActive == true)
                {
                    DrehMachinen.color = Color.green;
                }
                else if (daten_save[i].RowName == "DrehMaschine" && daten_save[i].IsActive == false)
                {
                    DrehMachinen.color = Color.red;
                }

                if (daten_save[i].RowName == "FräseMaschine" && daten_save[i].IsActive == true)
                {
                    FräseMaschinen.color = Color.green;
                    Doors_Close();
                    Milling_Maschine_WorkAnimation();
                }
                else if (daten_save[i].RowName == "FräseMaschine" && daten_save[i].IsActive == false)
                {
                    FräseMaschinen.color = Color.red;
                    Doors_Open();
                    Milling_Maschine_IdleAnimation();
                }

                if (daten_save[i].RowName == "BiegeMaschine" && daten_save[i].IsActive == true)
                {
                    BiegeMaschinen.color = Color.green;
                    Bending_Maschine_WorkAnimnation();
                }
                else if (daten_save[i].RowName == "BiegeMaschine" && daten_save[i].IsActive == false)
                {
                    BiegeMaschinen.color = Color.red;
                    Bending_Maschine_IdleAnimnation();
                }
            }
            data = "";
            process.Close();
        }
    }

    private void Bending_Maschine_WorkAnimnation()
    {
        LeanTween.moveLocalY(bendingTube, bendingTubePositionY + BendingTubeMoveValue, 3f)
                .setEaseInOutCubic();
        LeanTween.rotateX(bendingPlate, bendingPlateRotationX + BendingRotateValue, 3f)
            .setDelay(1f)
            .setEaseInOutElastic()
            .setLoopPingPong(1);
        LeanTween.rotateX(bendingTube, bendingTubeRotationX + BendingRotateValue, 3f)
            .setDelay(1f)
            .setEaseInOutElastic()
            .setLoopPingPong(1);
        LeanTween.moveLocalY(bendingTube, 1.3f, 3f)
            .setDelay(1f + 1f * 2)
            ;
    }

    private void Bending_Maschine_IdleAnimnation()
    {
        LeanTween.cancel(bendingPlate);
        LeanTween.cancel(bendingTube);

        LeanTween.moveLocalY(bendingTube, 1.7f, 2f);
        LeanTween.rotateX(bendingTube, bendingTubeRotationX, 2f);
        LeanTween.rotateX(bendingPlate, bendingPlateRotationX, 2f);
    }

    private void Milling_Maschine_WorkAnimation()
    {
        LeanTween.moveLocalX(millingMachine, millingMachineStartPos.x + -0.8f, 1f)
               .setEaseInOutCubic()
               .setDelay(1f);
        LeanTween.moveLocalX(millingMachine, millingMachineStartPos.x + 0.6f, 1f)
            .setDelay(1f + 1f)
            .setEaseInOutCubic()
            .setLoopPingPong();
    }

    private void Milling_Maschine_IdleAnimation()
    {
        LeanTween.cancel(millingMachine);

        LeanTween.moveLocal(millingMachine, millingMachineStartPos, 1f)
            .setEaseInOutCubic();
    }

    private void Doors_Open()
    {
        LeanTween.moveLocalX(doorL, doorLStartPosX, 1f)
                 .setEaseInOutCubic()
                 .setDelay(1f);
        LeanTween.moveLocalX(doorR, doorRStartPosX, 1f)
            .setEaseInOutCubic().
            setDelay(1f);
    }

    private void Doors_Close()
    {
        LeanTween.cancel(doorL);
        LeanTween.cancel(doorR);

        LeanTween.moveLocalX(doorL, doorLStartPosX + DoorMoveValue, 1f)
            .setEaseInOutCubic();
        LeanTween.moveLocalX(doorR, doorRStartPosX - DoorMoveValue, 1f)
            .setEaseInOutCubic();
    }
}