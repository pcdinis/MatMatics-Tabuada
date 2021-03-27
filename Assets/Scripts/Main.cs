using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] public RefreshButton btRefresh;

    // Start is called before the first frame update
    void Start()
    {
        btRefresh.Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
