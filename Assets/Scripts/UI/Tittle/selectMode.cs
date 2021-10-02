using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace title
{
    public class selectMode : MonoBehaviour
    {
        [SerializeField]
        private GameObject selectModePanel = null;
        void Start()
        {
            selectModePanel.SetActive(false);
        }

        public void Onclick()
        {
            selectModePanel.SetActive(true);
        }
    }
}
