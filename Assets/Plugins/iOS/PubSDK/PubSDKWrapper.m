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
    
    [[PubApiClient getInstance]setupSDK:@""
                                success:^(id val)
    {
        PubSDKCallbackMessageForUnity *callbackMsg = [PubSDKCallbackMessageForUnity callbackMessage:identifier value:@"callbackMessage"];
        
        [callbackMsg sendMessageOK];
        
    }failure:^(int val){
        
    }];
}

- (void)loginWithGamepub:(NSString *)identifier
               loginType:(int)loginType
      accountServiceType:(int)accountServiceType
{
    [[PubApiClient getInstance]login:0 uiview:UnityGetGLViewController() obj:UnityGetGLViewController()];
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


@end
