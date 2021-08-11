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

PUB_SDK_EXTERNC void pub_sdk_setup(const char* identifier,
                                   const char* projectId)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    NSString *nsProjectId = PubSDKMakeNSString(projectId);
    [[PubSDKWrapper sharedInstance] setupSDK:nsIdentifier
                                   projectId:nsProjectId];
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

PUB_SDK_EXTERNC void pub_sdk_logout(const char* identifier)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] logout:nsIdentifier];
}

PUB_SDK_EXTERNC void pub_sdk_userInfoUpdate(const char* identifier,
                                            int languageCode,
                                            bool push,
                                            bool pushNight,
                                            bool pushAd);
void pub_sdk_userInfoUpdate(const char* identifier,
                            int languageCode,
                            bool push,
                            bool pushNight,
                            bool pushAd)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] userInfoUpdate:nsIdentifier
                                      languageCode:languageCode
                                              push:push
                                         pushNight:pushNight
                                            pushAd:pushAd];
}

PUB_SDK_EXTERNC const char* pub_sdk_getLoginType();
const char* pub_sdk_getLoginType()
{
    NSString *result = [[PubSDKWrapper sharedInstance] getLoginType];
    return PubSDKMakeCString(result);
}

PUB_SDK_EXTERNC const char* pub_sdk_getLanguageList();
const char* pub_sdk_getLanguageList()
{
    NSString *result = [[PubSDKWrapper sharedInstance] getLanguageList];
    return PubSDKMakeCString(result);
}

PUB_SDK_EXTERNC const char* pub_sdk_getProductList();
const char* pub_sdk_getProductList()
{
    NSString *result = [[PubSDKWrapper sharedInstance] getProductList];
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

//PUB_SDK_EXTERNC void pub_sdk_imageBanner(const char* identifier,
//                                         const char* ratioWidth,
//                                         const char* ratioHeight);
//void pub_sdk_imageBanner(const char* identifier,
//                         const char* ratioWidth,
//                         const char* ratioHeight)
//{
//    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
//    NSString *nsRatioWidth = PubSDKMakeNSString(ratioWidth);
//    NSString *nsRatioHeight = PubSDKMakeNSString(ratioHeight);
//    [[PubSDKWrapper sharedInstance] imageBanner:nsIdentifier
//                                     ratioWidth:nsRatioWidth
//                                    ratioHeight:nsRatioHeight];
//}

PUB_SDK_EXTERNC void pub_sdk_getImageBanner(const char* identifier) {
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] getImageBanner:nsIdentifier];
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

PUB_SDK_EXTERNC void pub_sdk_userRefundListSearch(const char* identifier,
                                                  const char* accountId,
                                                  const char* loginType,
                                                  const char* channelId)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    NSString *nsAccountId = PubSDKMakeNSString(accountId);
    NSString *nsLoginType = PubSDKMakeNSString(loginType);
    NSString *nsChannelId = PubSDKMakeNSString(channelId);
    [[PubSDKWrapper sharedInstance] userRefundListSearch:nsIdentifier
                                               accountId:nsAccountId
                                               loginType:nsLoginType
                                               channelId:nsChannelId];
}

PUB_SDK_EXTERNC void pub_sdk_userRefundRepurchase(const char* identifier,
                                                  const char* accountId,
                                                  const char* loginType,
                                                  const char* channelId,
                                                  const char* pid,
                                                  const char* serverId,
                                                  const char* playerId,
                                                  const char* etc,
                                                  const char* voidedTid);
void pub_sdk_userRefundRepurchase(const char* identifier,
                                  const char* accountId,
                                  const char* loginType,
                                  const char* channelId,
                                  const char* pid,
                                  const char* serverId,
                                  const char* playerId,
                                  const char* etc,
                                  const char* voidedTid)
{
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    NSString *nsAccountId = PubSDKMakeNSString(accountId);
    NSString *nsLoginType = PubSDKMakeNSString(loginType);
    NSString *nsChannelId = PubSDKMakeNSString(channelId);
    NSString *nsPid = PubSDKMakeNSString(pid);
    NSString *nsServerId = PubSDKMakeNSString(serverId);
    NSString *nsPlayerId = PubSDKMakeNSString(playerId);
    NSString *nsEtc = PubSDKMakeNSString(etc);
    NSString *nsVoidedTid = PubSDKMakeNSString(voidedTid);
    [[PubSDKWrapper sharedInstance] userRefundRepurchase:nsIdentifier
                                               accountId:nsAccountId
                                               loginType:nsLoginType
                                               channelId:nsChannelId
                                                     pid:nsPid
                                                serverId:nsServerId
                                                playerId:nsPlayerId
                                                     etc:nsEtc
                                               voidedTid:nsVoidedTid];
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

PUB_SDK_EXTERNC void pub_sdk_syncRemoteConfig(const char* identifier){
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] syncRemoteConfig:nsIdentifier];
}

PUB_SDK_EXTERNC const char* pub_sdk_getRemoteConfigValue(const char* key)
{
    NSString *nsKey = PubSDKMakeNSString(key);
    NSString *result = [[PubSDKWrapper sharedInstance] getRemoteConfigValue:nsKey];
    return PubSDKMakeCString(result);
}

PUB_SDK_EXTERNC void pub_sdk_ping(const char* identifier){
    NSString *nsIdentifier = PubSDKMakeNSString(identifier);
    [[PubSDKWrapper sharedInstance] ping:nsIdentifier];
}

PUB_SDK_EXTERNC void pub_sdk_startPing(){
    [[PubSDKWrapper sharedInstance] startPing];
}

PUB_SDK_EXTERNC void pub_sdk_stopPing(){
    [[PubSDKWrapper sharedInstance] stopPing];
}
