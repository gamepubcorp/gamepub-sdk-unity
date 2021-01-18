using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubUnit
    {
        [SerializeField]
        private int code = 0;
        [SerializeField]
        private string msg = "";

        public int      Code { get { return code; } }
        public string   Msg { get { return msg; } }
    }
}