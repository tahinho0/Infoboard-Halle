using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class TROWContent
{
    [JsonProperty("Content")]
    public List<TROWDaten> Content { get; set; }
}