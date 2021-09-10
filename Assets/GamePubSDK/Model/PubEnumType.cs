
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
        KOREAN,     //한글
        ENGLISH,    //영어
        JAPANESE,   //일본
        ZH_CN,      //중국(간체)
        ZH_TW,      //대만(번체)
        THAI,       //태국
        VIETNAMESE, //베트남
        SPANISH,    //스페인
        PORTUGAL,   //포르투갈
        FRENCH,     //프랑스
        GERMAN,     //독일
        RUSSIAN,    //러시아
    }

    public enum PubApiResponseCode
    {        
        SUCCESS = 1000,
        CANCEL,                     //사용자 취소
        NETWORK_ERROR,              //네트워크 연결 상태 에러.
        SERVER_ERROR,               //서버 에러
        AUTHENTICATION_AGENT_ERROR, //로그인 인증 에러
        USER_IP_BLOCK,              //유저 IP 차단
        SERVICE_MAINTENANCE,        //서버 점검
        INTERNAL_ERROR,
        PURCHASE_ERROR,             //결제 에러
    }

    public enum PubMessageCode
    {
        OK = 200,                   //정상
        MultiStatus = 207,          //중복로그인
        Forbidden = 403,            //회원탈퇴
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