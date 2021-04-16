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

PUB_SDK_EXTERNC void pub_sdk_setup(const char* identifier) {
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
    [[PubSDKWrapper sharedInstance] login:nsIdentifier
                                     type:loginType
                              serviceType:serviceType];
}

PUB_SDK_EXTERNC void pub_sdk_logout(const char* identifier) {
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] logout:nsIdentifier];
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
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    NSString *nsLanguageCode = PubSDKMakeNSString(languageCode);
    [[PubSDKWrapper sharedInstance] userInfoUpdate:nsIdentifier
                                      languageCode:nsLanguageCode
                                              push:push
                                         pushNight:pushNight
                                            pushAd:pushAd];
}

PUB_SDK_EXTERNC const char* pub_sdk_authenticationState();
const char* pub_sdk_authenticationState()
{
    NSString *result = [[PubSDKWrapper sharedInstance] currentLoginType];
    return PubSDKMakeCString(result);
}

PUB_SDK_EXTERNC void pub_sdk_secede(const char* identifier) {
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);    
    [[PubSDKWrapper sharedInstance] secede:nsIdentifier];
}

PUB_SDK_EXTERNC void pub_sdk_secedeCancel(const char* identifier, int loginType);
void pub_sdk_secedeCancel(const char* identifier, int loginType)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] secedeCancel:nsIdentifier
                                       loginType:loginType];
}

PUB_SDK_EXTERNC void pub_sdk_openPolicyLink(const char* identifier, int policyType);
void pub_sdk_openPolicyLink(const char* identifier, int policyType)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] openPolicyLink:nsIdentifier
                                        policyType:policyType];
}

PUB_SDK_EXTERNC void pub_sdk_imageBanner(const char* identifier,
                                         const char* ratioWidth,
                                         const char* ratioHeight);
void pub_sdk_imageBanner(const char* identifier,
                         const char* ratioWidth,
                         const char* ratioHeight)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    NSString *nsRatioWidth = PubSDKMakeNSString(ratioWidth);
    NSString *nsRatioHeight = PubSDKMakeNSString(ratioHeight);
    [[PubSDKWrapper sharedInstance] imageBanner:nsIdentifier
                                     ratioWidth:nsRatioWidth
                                    ratioHeight:nsRatioHeight];
}

PUB_SDK_EXTERNC void pub_sdk_purchaseInit(const char* identifier) {
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] purchaseInit:nsIdentifier];
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
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    NSString *nsPid = PubSDKMakeNSString(pid);
    NSString *nsServerId = PubSDKMakeNSString(serverId);
    NSString *nsPlayerId = PubSDKMakeNSString(playerId);
    NSString *nsEtc = PubSDKMakeNSString(etc);
    [[PubSDKWrapper sharedInstance] purchaseLaunch:nsIdentifier
                                               pid:nsPid
                                          serverId:nsServerId
                                          playerId:nsPlayerId
                                               etc:nsEtc];
}

PUB_SDK_EXTERNC void pub_sdk_versionCheck(const char* identifier) {
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] versionCheck:nsIdentifier];
}

PUB_SDK_EXTERNC void pub_sdk_openNotice(const char* identifier) {
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] openNotice:nsIdentifier];
}

PUB_SDK_EXTERNC void pub_sdk_openHelpURL(const char* identifier) {
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] openHelpURL:nsIdentifier];
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
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    NSString *nsKey = PubSDKMakeNSString(key);
    NSString *nsServerId = PubSDKMakeNSString(serverId);
    NSString *nsPlayerId = PubSDKMakeNSString(playerId);
    NSString *nsEtc = PubSDKMakeNSString(etc);
    [[PubSDKWrapper sharedInstance] couponUse:nsIdentifier
                                          key:nsKey
                                     serverId:nsServerId
                                     playerId:nsPlayerId
                                          etc:nsEtc];
}

PUB_SDK_EXTERNC void pub_sdk_ping(const char* identifier){
}

PUB_SDK_EXTERNC void pub_sdk_startPing(){
}

PUB_SDK_EXTERNC void pub_sdk_stopPing(){
}
