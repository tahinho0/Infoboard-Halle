using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class Machines_Data : MonoBehaviour
{
    // Start is called before the first frame update
    [JsonProperty("RowExternalId")]
    public string RowExternalId { get; set; }

    [JsonProperty("ItemName")]
    public string ItemName { get; set; }

    [JsonProperty("RowName")]
    public string RowName { get; set; }

    [JsonProperty("GroupName")]
    public string GroupName { get; set; }

    [JsonProperty("IsActive")]
    public bool IsActive { get; set; }

    [JsonProperty("Start")]
    public DateTime? Start { get; set; }

    [JsonProperty("End")]
    public DateTime? End { get; set; }

    [JsonProperty("SplitEnd")]
    public DateTime? SplitEnd { get; set; }
}