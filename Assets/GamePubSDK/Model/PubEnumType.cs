
namespace GamePub.PubSDK
{
    public enum PubLoginType
    {
        NONE,
        GOOGLE,
        FACEBOOK,
        GUEST,
        APPLE,
    }

    public enum PubAccountServiceType
    {
        NONE,
        ACCOUNT_LOGIN,
        ACCOUNT_CONVERSION,
        ACCOUNT_LINK,
    }

    public enum PubPolicyType
    {
        PRIVACY,
        REFUND,
        SERVICE,
    }

    //ISO Code Base
    public enum PubLanguageCode
    {        
        en, //ENGLISH
        fr, //FRENCH
        de, //GERMAN
        it, //ITALIAN
        ja, //JAPANESE
        ko, //KOREAN
        zh, //CHINESE
        ru, //RUSSIAN
        es, //SPANISH
        th, //THAI
    }

    public enum PubApiResponseCode
    {        
        SUCCESS,
        CANCEL,
        NETWORK_ERROR,
        SERVER_ERROR,
        AUTHENTICATION_AGENT_ERROR,        
        BLOCK_IP_CHECK,
        SERVICE_MAINTENANCE,
        INTERNAL_ERROR,
        PURCHASE_ERROR,
    }

    public enum PubMessageCode
    {
        OK = 200,                   //정상
        MultiStatus = 207,          //중복로그인
        PRECONDITION_FAILED = 412,  //IP차단
        Locked = 423,               //회원제재
        SERVICE_UNAVAILABLE = 503,  //서버점검
    }

    public enum PubAccountStatus
    {
        U, //available
        B, //block
        S, //secession
    }
}