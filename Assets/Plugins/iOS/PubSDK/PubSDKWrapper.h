//
//  PubSDKWrapper.h
//  PubSDKUnityBridge
//
//  Created by gamepub on 2021/01/25.
//  Copyright © 2021 gamepub. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface PubSDKWrapper : NSObject

+ (instancetype)sharedInstance;

- (void)setupSDK:(NSString *)identifier;

- (void)login:(NSString *)identifier
         type:(int)loginType
  serviceType:(int)accountServiceType;

- (void)logout:(NSString *)identifier;

- (void)userInfoUpdate:(NSString *)identifier
          languageCode:(NSString *)languageCode
                  push:(BOOL)push
             pushNight:(BOOL)pushNight
                pushAd:(BOOL)pushAd;

- (NSString *)currentLoginType;

- (void)secede:(NSString *)identifier;
- (void)secedeCancel:(NSString *)identifier
           loginType:(int)loginType;

- (void)openPolicyLink:(NSString *)identifier
            policyType:(int)policyType;

- (void)imageBanner:(NSString *)identifier
         ratioWidth:(NSString *)ratioWidth
        ratioHeight:(NSString *)ratioHeight;

- (void)purchaseInit:(NSString *)identifier;
- (void)purchaseLaunch:(NSString *)identifier
                   pid:(NSString *)pid
              serverId:(NSString *)serverId
              playerId:(NSString *)playerId
                   etc:(NSString *)etc;

- (void)versionCheck:(NSString *)identifier;

- (void)openNotice:(NSString *)identifier;

- (void)openHelpURL:(NSString *)identifier;

- (void)couponUse:(NSString *)identifier
              key:(NSString *)key
         serverId:(NSString *)serverId
         playerId:(NSString *)playerId
              etc:(NSString *)etc;

- (void)ping:(NSString *)identifier;
- (void)startPing;
- (void)stopPing;



@end
