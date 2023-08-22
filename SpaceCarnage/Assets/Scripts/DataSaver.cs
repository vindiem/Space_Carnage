using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    

    public void saveInt(int id)
    {
        PlayerPrefs.SetInt("character", id);
    }
}
