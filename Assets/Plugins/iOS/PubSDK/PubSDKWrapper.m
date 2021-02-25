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
        }else{
            PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:sdkResult];
            
            [callbackMsg sendMessageOK];
        }
    }];
}

- (void)login:(NSString *)identifier
         type:(int)loginType
  serviceType:(int)accountServiceType
{
    [[PubApiClient getInstance]login:GOOGLE viewController:UnityGetGLViewController()
                          completion:^(NSString * _Nullable loginResult, NSError * _Nullable error)
    {
       if(error)
       {
           PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:[self wrapError:error]];
       }else{
           PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:loginResult];
           
           [callbackMsg sendMessageOK];
       }
    }];
}

- (void)logout:(NSString *)identifier
     loginType:(int)loginType
{
    
}

- (void)userInfoUpdate:(NSString *)identifier
          languageCode:(NSString *)languageCode
                  push:(BOOL)push
             pushNight:(BOOL)pushNight
                pushAd:(BOOL)pushAd
{
    
}

- (void)autoLogin:(NSString *)identifier
{
    
}

- (NSString *)authenticationState
{
    return @"null";
}

- (void)secede:(NSString *)identifier
{
    
}

- (void)openPolicyLink:(NSString *)identifier
            policyType:(int)policyType

{
    
}

- (void)imageBanner:(NSString *)identifier
         ratioWidth:(NSString *)ratioWidth
        ratioHeight:(NSString *)ratioHeight
{
    
}

- (void)purchaseLaunch:(NSString *)identifier
                   pid:(NSString *)pid
              serverId:(NSString *)serverId
              playerId:(NSString *)playerId
                   etc:(NSString *)etc
{
    
}

- (void)versionCheck:(NSString *)identifier
{
    
}

- (void)openNotice:(NSString *)identifier
{
    
}

- (void)openHelpURL:(NSString *)identifier
{
    
}

- (void)couponUse:(NSString *)identifier
              key:(NSString *)key
         serverId:(NSString *)serverId
         playerId:(NSString *)playerId
              etc:(NSString *)etc
{
    
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
