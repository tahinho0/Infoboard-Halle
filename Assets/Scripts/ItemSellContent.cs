using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class ItemSellContent
{
    [JsonProperty("Content")]
    public List<ItemSell_ID_RowID> Content { get; set; }
}