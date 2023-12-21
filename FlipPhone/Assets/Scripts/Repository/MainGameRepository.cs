using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameRepository : MonoBehaviour
{
    [SerializeField] private MessagesVODataStore messageDataStore;
    public MessagesVO[] MessagesVO => messageDataStore.Items.ToArray();
}
