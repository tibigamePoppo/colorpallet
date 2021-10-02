using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionSystem : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void Onclick()
    {
        this.gameObject.SetActive(true);
    }
}
