//
//  PubSDKNativeInterface.m
//  PubSDKUnityBridge
//
//  Created by gamepub on 2021/01/22.
//  Copyright © 2021 gamepub. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "PubSDKWrapper.h"

#define PUB_SDK_EXTERNC extern "C"

// MARK: - Helpers

NSString* PubSDKMakeNSString(const char* string)
{
    if(string) {
        return [NSString stringWithUTF8String:string];
    }else{
        return [NSString stringWithUTF8String:""];
    }
}

char* PubSDKMakeCString(NSString *str)
{
    const char* string = [str UTF8String];
    if(string == NULL) {
        return NULL;
    }
    
    char *buffer = (char*)malloc(strlen(string)+1);
    strcpy(buffer, string);
    return buffer;
}

PUB_SDK_EXTERNC void pub_sdk_UnitySendMessage(const char *name, const char *method, NSString *params) {
    UnitySendMessage(name, method, PubSDKMakeCString(params));
}

// MARK: - Extern APIs

PUB_SDK_EXTERNC void pub_sdk_setup(const char* identifier);
void pub_sdk_setup(const char* identifier)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] setupSDK:nsIdentifier];
}

PUB_SDK_EXTERNC void pub_sdk_login(const char* identifier,
                                   int loginType,
                                   int serviceType);
void pub_sdk_login(const char* identifier,
                   int loginType,
                   int serviceType)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] loginWithGamepub:nsIdentifier loginType:loginType accountServiceType:serviceType];
}

PUB_SDK_EXTERNC void pub_sdk_logout(const char* identifier, int loginType);
void pub_sdk_logout(const char* identifier, int loginType)
{
}

PUB_SDK_EXTERNC void pub_sdk_userInfoUpdate(const char* identifier,
                                            const char* languageCode,
                                            bool push,
                                            bool pushNight,
                                            bool pushAd);
void pub_sdk_userInfoUpdate(const char* identifier,
                            const char* languageCode,
                            bool push,
                            bool pushNight,
                            bool pushAd)
{
}

PUB_SDK_EXTERNC void pub_sdk_autoLogin(const char* identifier);
void pub_sdk_autoLogin(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_authenticationState();
void pub_sdk_authenticationState()
{
}

PUB_SDK_EXTERNC void pub_sdk_openPolicyLink(const char* identifier, int policyType);
void pub_sdk_openPolicyLink(const char* identifier, int policyType)
{
}

PUB_SDK_EXTERNC void pub_sdk_imageBanner(const char* identifier,
                                         const char* ratioWidth,
                                         const char* ratioHeight);
void pub_sdk_imageBanner(const char* identifier,
                         const char* ratioWidth,
                         const char* ratioHeight)
{
}

PUB_SDK_EXTERNC void pub_sdk_inAppPurchase(const char* identifier,
                                           const char* pid,
                                           const char* serverId,
                                           const char* playerId,
                                           const char* etc);
void pub_sdk_inAppPurchase(const char* identifier,
                           const char* pid,
                           const char* serverId,
                           const char* playerId,
                           const char* etc)
{
}

PUB_SDK_EXTERNC void pub_sdk_versionCheck(const char* identifier);
void pub_sdk_versionCheck(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_openNotice(const char* identifier);
void pub_sdk_openNotice(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_openHelpURL(const char* identifier);
void pub_sdk_openHelpURL(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_couponUse(const char* identifier,
                                       const char* key,
                                       const char* serverId,
                                       const char* playerId,
                                       const char* etc);
void pub_sdk_couponUse(const char* identifier,
                       const char* key,
                       const char* serverId,
                       const char* playerId,
                       const char* etc)
{
}

PUB_SDK_EXTERNC void pub_sdk_ping(const char* identifier);
void pub_sdk_ping(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_startPing();
void pub_sdk_startPing()
{
}

PUB_SDK_EXTERNC void pub_sdk_stopPing();
void pub_sdk_stopPing()
{
}
