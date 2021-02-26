using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class Error
    {        
        [SerializeField]
        private int code;
        [SerializeField]
        private string message;               

        public int Code { get { return code; } }

        public string Message { get { return message; } }

        public Error(int code, string message)
        {            
            this.code = code;
            this.message = message;
        }
    }
}