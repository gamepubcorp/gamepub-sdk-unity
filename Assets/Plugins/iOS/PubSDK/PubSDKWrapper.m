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
{
    if(self.setup) {
        return;
    }
    self.setup = YES;
    
    [[PubApiClient getInstance] setupSDK:^(NSString *sdkResult,
                                           NSError *error)
    {
        if(error)
        {
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
            [callbackMsg sendMessageError];
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:sdkResult];
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
          languageCode:(NSString *)languageCode
                  push:(BOOL)push
             pushNight:(BOOL)pushNight
                pushAd:(BOOL)pushAd
{
    [[PubApiClient getInstance] userInfoUpdate:languageCode
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

- (NSString *)currentLoginType
{
    return [[PubApiClient getInstance] getAuthState];
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

- (void)purchaseInit:(NSString *)identifier
{
    [[PubApiClient getInstance] purchaseInit:^(NSString * _Nullable unitResult,
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

- (void)ping:(NSString *)identifier
{
    
}

- (void)startPing
{
    
}

- (void)stopPing
{
    
}

- (NSString *)wrapError:(NSError *)error {
    NSDictionary *dic = @{@"code": @(error.code), @"message": error.localizedDescription};
    NSData *data = [NSJSONSerialization dataWithJSONObject:dic options:kNilOptions error:nil];
    if (!data) { return nil; }
    return [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
}

@end
