//
//  PubSDKUnityAppDelegate.m
//  PubSDKUnityBridge
//
//  Created by gamepub on 2021/01/26.
//  Copyright © 2021 gamepub. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "UnityAppController.h"
#import <UserNotifications/UserNotifications.h>
@import PubSDK;

@interface PubSDKUnityAppDelegate : UnityAppController<UNUserNotificationCenterDelegate>
@end

IMPL_APP_CONTROLLER_SUBCLASS(PubSDKUnityAppDelegate)

@implementation PubSDKUnityAppDelegate

-(BOOL)application:(UIApplication*) application didFinishLaunchingWithOptions:(NSDictionary*) options
{
    if (@available(iOS 10.0, *)) {
        if ([UNUserNotificationCenter class] != nil) {
            // iOS 10 or later
            // For iOS 10 display notification (sent via APNS)
            [UNUserNotificationCenter currentNotificationCenter].delegate = self;
            UNAuthorizationOptions authOptions = UNAuthorizationOptionAlert |
            UNAuthorizationOptionSound | UNAuthorizationOptionBadge;
            
            [[UNUserNotificationCenter currentNotificationCenter]
             requestAuthorizationWithOptions:authOptions
             completionHandler:^(BOOL granted,NSError * _Nullable error)
            {
                if(error){
                    NSLog(@"%@", error);
                }else{
                    dispatch_async(dispatch_get_main_queue(),^{
                        [[UIApplication sharedApplication] registerForRemoteNotifications];
                    });
                }
            }];
        }
    }
    
    [[PubSDKApplicationDelegate sharedInstance] application:application didFinishLaunchingWithOptions:options];
    
    NSLog(@"[PubSDKUnityAppDelegate application:%@ didFinishLaunchingWithOptions:%@]", application, options);
    return [super application:application didFinishLaunchingWithOptions:options];
}

-(void)application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceToken {
    const unsigned char *dataBuffer = (const unsigned char *)deviceToken.bytes;
    NSMutableString *hexString  = [NSMutableString stringWithCapacity:(deviceToken.length * 2)];
    for (int i = 0; i < deviceToken.length; ++i) {
        [hexString appendFormat:@"%02x", dataBuffer[i]];
    }
    NSString *result = [hexString copy];
    NSLog(@"토큰 : %@", result);
    
    [[PubApiClient getInstance] setDeviceToken:result];
}

// 호출되는 조건
// 1. 앱 포그라운드 상태일 때 알림 오면 호출됨
- (void)userNotificationCenter:(UNUserNotificationCenter *)center
       willPresentNotification:(UNNotification *)notification
         withCompletionHandler:(void (^)(UNNotificationPresentationOptions))completionHandler  API_AVAILABLE(ios(10.0)) {
    NSDictionary *userInfo = notification.request.content.userInfo;
    NSLog(@"푸시 데이터 : %@", userInfo);    
    if (@available(iOS 14.0, *)) {
        completionHandler(UNNotificationPresentationOptionList);
    } else {
        // 포그라운드 상태에서 푸시왔을 때 푸시 마노출
        completionHandler(UNNotificationPresentationOptionNone);
    }
}

// 호출되는 조건
// 1. 앱 미실행 상태일 때 알림 터치하면 호출됨
// 2. 백그라운드 상태일 때 알림 표시된 후 알림 터치하면 호출됨
- (void)userNotificationCenter:(UNUserNotificationCenter *)center
didReceiveNotificationResponse:(UNNotificationResponse *)response
         withCompletionHandler:(void(^)(void))completionHandler  API_AVAILABLE(ios(10.0)){
    NSDictionary *userInfo = response.notification.request.content.userInfo;
    NSLog(@"푸시 데이터 : %@", userInfo);
    completionHandler();
}

@end
