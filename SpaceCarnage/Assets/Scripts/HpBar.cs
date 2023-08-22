using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image Bar;
    public float fill;

    private void Start()
    {
        fill = 1f;
    }

    private void Update()
    {
        Bar.fillAmount = fill;
    }
}
