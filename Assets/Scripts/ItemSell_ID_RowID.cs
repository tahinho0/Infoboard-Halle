using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class ItemSell_ID_RowID
{
    [JsonProperty("id")]
    public int ID { get; set; }

    [JsonProperty("RowId")]
    public int RowID { get; set; }

    [JsonProperty("OriginalStart")]
    public DateTime OriginalStart { get; set; }
}