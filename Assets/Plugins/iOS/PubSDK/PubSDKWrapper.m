//
//  PubSDKWrapper.m
//  PubSDKUnityBridge
//
//  Created by gamepub on 2021/01/25.
//  Copyright © 2021 gamepub. All rights reserved.
//

#import "PubSDKWrapper.h"
#import "PubSDKCallbackMessageForUnity.h"

@import PubSDK;

@interface PubSDKWrapper()

@property (nonatomic, assign) BOOL setup;

@end

@implementation PubSDKWrapper

+ (instancetype)sharedInstance
{
    static PubSDKWrapper *sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[PubSDKWrapper alloc] init];
    });
    return sharedInstance;
}

- (void)setupSDK:(NSString *)identifier
       projectId:(NSString *)projectId
       domainURL:(NSString *)domainURL
{
    if(self.setup) {
        return;
    }
    self.setup = YES;
    
    [[PubApiClient getInstance] setupSDK:projectId
                               domainURL:domainURL
                              completion:^(NSString * _Nullable unitResult,
                                           NSError * _Nullable error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
    
    [[PubWebviewController GetInstance] InitializeWithParentUIView:UnityGetGLViewController().view pubDelegate:nil];
}

- (void)login:(NSString *)identifier
         type:(int)loginType
  serviceType:(int)accountServiceType
{
    [[PubApiClient getInstance]loginWithGamepub:(LoginType)loginType
                                    serviceType:(AccountServiceType)accountServiceType
                                 viewController:UnityGetGLViewController()
                                     completion:^(NSString * _Nullable loginResult, NSError * _Nullable error)
    {
       if(error)
       {
           PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
           [callbackMsg sendMessageError];
       }else{
           PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:loginResult];
           [callbackMsg sendMessageOK];
       }
    }];
}

- (void)logout:(NSString *)identifier
{
    [[PubApiClient getInstance] logout:^(NSString * _Nullable unitResult, NSError * _Nullable error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)userInfoUpdate:(NSString *)identifier
          languageCode:(int)languageCode
                  push:(BOOL)push
             pushNight:(BOOL)pushNight
                pushAd:(BOOL)pushAd
{
    [[PubApiClient getInstance] userInfoUpdate:(PubLanguageCode)languageCode
                                          push:push
                                     pushNight:pushNight
                                        pushAd:pushAd
                                    completion:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (NSString *)getLoginType
{
    return [[PubApiClient getInstance] getLastLoginType];
}

- (NSString *)getLanguageList
{
    return [[PubApiClient getInstance] getLanguageList];
}

- (NSString *)getProductList
{
    return [[PubApiClient getInstance] getProductList];
}

- (void)secede:(NSString *)identifier
{
    [[PubApiClient getInstance] secede:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)secedeCancel:(NSString *)identifier
           loginType:(int)loginType
{
    [[PubApiClient getInstance] secedeCancel:loginType
                                  completion:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)openPolicyLink:(NSString *)identifier
            policyType:(int)policyType

{
    [[PubApiClient getInstance] openPolicyLinkSafariView:UnityGetGLViewController()
                                              policyType:policyType
                                              completion:^(NSString * _Nullable unitResult,
                                                           NSError * _Nullable error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)imageBanner:(NSString *)identifier
         ratioWidth:(NSString *)ratioWidth
        ratioHeight:(NSString *)ratioHeight
{
    [[PubApiClient getInstance] imageBanner:ratioWidth
                                ratioHeight:ratioHeight
                                 completion:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)getImageBanner:(NSString *)identifier
{
    [[PubApiClient getInstance] getImageBanner:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)purchaseLaunch:(NSString *)identifier
                   pid:(NSString *)pid
              serverId:(NSString *)serverId
              playerId:(NSString *)playerId
                   etc:(NSString *)etc
{
    [[PubApiClient getInstance] purchaseLaunch:pid
                                      serverId:serverId
                                      playerId:playerId
                                           etc:etc
                                    completion:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)versionCheck:(NSString *)identifier
{
    [[PubApiClient getInstance] versionCheck:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)openNotice:(NSString *)identifier
{
    [[PubApiClient getInstance] openNotice:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)openHelpURL:(NSString *)identifier
{
    [[PubApiClient getInstance] openHelpURL:UnityGetGLViewController()
                                 completion:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)couponUse:(NSString *)identifier
              key:(NSString *)key
         serverId:(NSString *)serverId
         playerId:(NSString *)playerId
              etc:(NSString *)etc
{
    [[PubApiClient getInstance] couponUse:key
                                 serverId:serverId
                                 playerId:playerId
                                      etc:etc
                               completion:^(NSString *unitResult, NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)syncRemoteConfig:(NSString *)identifier
{
    [[PubApiClient getInstance] syncRemoteConfig:^(NSString * _Nullable unitResult,
                                                   NSError * _Nullable error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageOK];
        }
    }];
}

- (NSString *)getRemoteConfigValue:(NSString *)key
{
    return [[PubApiClient getInstance] getRemoteConfigValue:key];
}

- (void)ping:(NSString *)identifier
{
    [[PubApiClient getInstance] pingListener:^(NSString * _Nullable unitResult,
                                               NSError * _Nullable error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:unitResult];
            [callbackMsg sendMessageUpdate];
        }
    }];
}

- (void)startPing
{
    [[PubApiClient getInstance] startPing];
}

- (void)stopPing
{
    [[PubApiClient getInstance] stopPing];
}

- (NSString *)wrapError:(NSError *)error {
    NSDictionary *dic = @{@"code": @(error.code), @"message": error.localizedDescription};
    NSData *data = [NSJSONSerialization dataWithJSONObject:dic options:kNilOptions error:nil];
    if (!data) { return nil; }
    return [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
}

@end
