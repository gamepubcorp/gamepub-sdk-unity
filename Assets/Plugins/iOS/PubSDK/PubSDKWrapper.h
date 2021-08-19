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

- (void)setupSDK:(NSString *)identifier
       projectId:(NSString *)projectId;

- (void)login:(NSString *)identifier
         type:(int)loginType
  serviceType:(int)accountServiceType;

- (void)logout:(NSString *)identifier;

- (void)userInfoUpdate:(NSString *)identifier
          languageCode:(int)languageCode
                  push:(BOOL)push
             pushNight:(BOOL)pushNight
                pushAd:(BOOL)pushAd;

- (void)setAgreePush:(BOOL)push
           pushNight:(BOOL)pushNight
              pushAd:(BOOL)pushAd;

- (NSString *)getLoginType;
- (NSString *)getLanguageList;
- (NSString *)getProductList;

- (void)secede:(NSString *)identifier;
- (void)secedeCancel:(NSString *)identifier
           loginType:(int)loginType;

- (void)openPolicyLink:(NSString *)identifier
            policyType:(int)policyType;

//- (void)imageBanner:(NSString *)identifier
//         ratioWidth:(NSString *)ratioWidth
//        ratioHeight:(NSString *)ratioHeight;
- (void)getImageBanner:(NSString *)identifier;

- (void)purchaseLaunch:(NSString *)identifier
                   pid:(NSString *)pid
              serverId:(NSString *)serverId
              playerId:(NSString *)playerId
                   etc:(NSString *)etc;

- (void)userRefundListSearch:(NSString *)identifier
                   accountId:(NSString *)accountId
                   loginType:(NSString *)loginType
                   channelId:(NSString *)channelId;
- (void)userRefundRepurchase:(NSString *)identifier
                   accountId:(NSString *)accountId
                   loginType:(NSString *)loginType
                   channelId:(NSString *)channelId
                         pid:(NSString *)pid
                    serverId:(NSString *)serverId
                    playerId:(NSString *)playerId
                         etc:(NSString *)etc
                   voidedTid:(NSString *)voidedTid;

- (void)versionCheck:(NSString *)identifier;

- (void)openNotice:(NSString *)identifier;

- (void)openHelpURL:(NSString *)identifier;

- (void)couponUse:(NSString *)identifier
              key:(NSString *)key
         serverId:(NSString *)serverId
         playerId:(NSString *)playerId
              etc:(NSString *)etc;

- (void)syncRemoteConfig:(NSString *)identifier;
- (NSString *)getRemoteConfigValue:(NSString *)key;

- (void)ping:(NSString *)identifier;
- (void)startPing;
- (void)stopPing;



@end
