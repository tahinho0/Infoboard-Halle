using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class ALLDATAINFO
{
    [JsonProperty("content")]
    public object content { get; set; }

    [JsonProperty("apiCode")]
    public int apiCode { get; set; }

    [JsonProperty("httpCode")]
    public int httpCode { get; set; }

    [JsonProperty("message")]
    public string message { get; set; }
}