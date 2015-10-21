using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class IncPrice : MonoBehaviour {

    public void Incprice()
    {
        int currentPrice = int.Parse(transform.GetComponentInParent<InputField>().text);
        Debug.Log(currentPrice);
        currentPrice += 10;
        transform.GetComponentInParent<InputField>().text = currentPrice.ToString();
    }
}
