using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class ApiResponse
{
    [JsonProperty("httpCode")]
    public string HTTP { get; set; }

    [JsonProperty("apiCode")]
    public int ApiCode { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("content")]
    public object Content { get; set; }
}