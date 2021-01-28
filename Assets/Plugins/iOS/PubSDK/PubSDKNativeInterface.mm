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

PUB_SDK_EXTERNC void pub_sdk_login(const char* identifier);
void pub_sdk_login(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_logout(const char* identifier);
void pub_sdk_logout(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_userInfoUpdate(const char* identifier);
void pub_sdk_userInfoUpdate(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_autoLogin(const char* identifier);
void pub_sdk_autoLogin(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_authenticationState(const char* identifier);
void pub_sdk_authenticationState(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_openPolicyLink(const char* identifier);
void pub_sdk_openPolicyLink(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_imageBanner(const char* identifier);
void pub_sdk_imageBanner(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_inAppPurchase(const char* identifier);
void pub_sdk_inAppPurchase(const char* identifier)
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

PUB_SDK_EXTERNC void pub_sdk_couponUse(const char* identifier);
void pub_sdk_couponUse(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_ping(const char* identifier);
void pub_sdk_ping(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_startPing(const char* identifier);
void pub_sdk_startPing(const char* identifier)
{
}

PUB_SDK_EXTERNC void pub_sdk_stopPing(const char* identifier);
void pub_sdk_stopPing(const char* identifier)
{
}
