
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
    
    public enum PubLanguageCode
    {
        KOREAN,     //KOREAN
        ENGLISH,    //ENGLISH
        JAPANESE,   //JAPANESE
        ZH_CN,      //CHINESE(간체)
        ZH_TW,      //CHINESE(번체)
        THAI,       //THAI
        VIETNAMESE, //VIETNAM
        SPANISH,    //SPANISH
        PORTUGAL,   //PORTUGAL
        FRENCH,     //FRENCH
    }

    public enum PubApiResponseCode
    {        
        SUCCESS = 1000,
        CANCEL,
        NETWORK_ERROR,
        SERVER_ERROR,
        AUTHENTICATION_AGENT_ERROR,
        USER_IP_BLOCK,
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

    public enum PubBlockReason
    {
        NORMAL = 0,               //정상
        ADMIN = 100,              //관리자 차단
        LOGIN_VERIFY_ERR = 200,   //로그인검증 오류
        REFUND = 300,             //환불자 차단
    }
}