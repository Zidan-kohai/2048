using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private float speed;
    private bool hasCombined;
    public int value;



    public void changeValue(int value)
    {
        this.value = value;
        text.text = value.ToString();
    }

    private void Update()
    {
        if(transform.localPosition != Vector3.zero)
        {
            hasCombined = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if (hasCombined == false)
        {
            if(transform.parent.GetChild(0) != this.transform) 
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            hasCombined = true;
        }
    }

    public void Double()
    {
        value *= 2;
        text.text = value.ToString();
    }
}
