using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class Error
    {
        [SerializeField]
        private int responseCode;
        [SerializeField]
        private int errorCode;
        [SerializeField]
        private string message;
        
        public int ResponseCode { get { return responseCode; } }

        public int ErrorCode { get { return errorCode; } }

        public string Message { get { return message; } }

        public Error(int responseCode, int errorCode, string message)
        {
            this.responseCode = responseCode;
            this.errorCode = errorCode;
            this.message = message;
        }
    }
}