using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class TROWDaten
{
    [JsonProperty("id")]
    public string id { get; set; }

    [JsonProperty("Idx")]
    public int Idx { get; set; }

    [JsonProperty("RowName")]
    public string RowName { get; set; }
}