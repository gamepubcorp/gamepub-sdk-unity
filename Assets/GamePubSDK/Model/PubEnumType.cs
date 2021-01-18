
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
        ALREADY_LOGGED_IN,
        ALREADY_ACCOUNT_USE,
        BLOCK_IP_CHECK,
        SERVICE_MAINTENANCE,
        INTERNAL_ERROR,
        PURCHASE_ERROR,
    }
}