using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateValue : MonoBehaviour
{
    public Text text;

    public void UpdateText(float f)
    {
        text.text = f.ToString();
    }
}
