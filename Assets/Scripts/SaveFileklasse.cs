using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class SaveFileklasse : MonoBehaviour
{
    //[JsonProperty("i")]
    //public string id { get; set; }

    [JsonProperty("IsActive")]
    public bool IsActive { get; set; }

    [JsonProperty("RowName")]
    public string RowName { get; set; }
}