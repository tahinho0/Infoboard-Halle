using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class TInfoBoardItem
{
    [JsonProperty("ItemText")]
    public string ItemText { get; set; }

    [JsonProperty("ItemGroup")]
    public TItemGroup ItemGroup { get; set; }
}