using UnityEngine;
using Qitz.DataUtil;
using System.Collections.Generic;


[CreateAssetMenu]
public class MessagesVODataStore : BaseDataStore<MessagesVO>
{
    [ContextMenu("サーバーからデータを読み込む")]
    protected override void LoadDataFromServer()
    {
        base.LoadDataFromServer();
    }
}

