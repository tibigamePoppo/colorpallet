using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace title
{
    public class selectMode : MonoBehaviour
    {
        [SerializeField]
        private GameObject selectModePanel;
        private bool isSlectMode;
        void Start()
        {
            selectModePanel.SetActive(false);
            isSlectMode = false;
        }

        public void Onclick()
        {
            if (isSlectMode == false)
            {
                selectModePanel.SetActive(true);
                isSlectMode = true;
            }
            else
            {
                selectModePanel.SetActive(false);
                isSlectMode = false;
            }
        }
    }
}
