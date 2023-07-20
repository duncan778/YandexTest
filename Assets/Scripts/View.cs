using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View : MonoBehaviour
{

    [SerializeField] GameObject startMessage;
    [SerializeField] TextMeshProUGUI counter;

    void Start()
    {
        ShowHint(true);
    }

    public void ShowHint(bool active)
    {
        startMessage.SetActive(active);
    }

    public void UpdateCounter(int count)
    {
        counter.text = count.ToString();
    }
}
