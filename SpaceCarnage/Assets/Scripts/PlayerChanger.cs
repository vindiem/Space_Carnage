using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChanger : MonoBehaviour
{
    public List<GameObject> character;
    private int characterId;

    public  Vector3 SpawnPos;


    private void Awake()
    {
        characterId = PlayerPrefs.GetInt("character");
        Instantiate(character[characterId], SpawnPos, Quaternion.identity);
    }
}
