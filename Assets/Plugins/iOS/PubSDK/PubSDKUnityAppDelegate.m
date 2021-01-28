//
//  PubSDKUnityAppDelegate.m
//  PubSDKUnityBridge
//
//  Created by gamepub on 2021/01/26.
//  Copyright © 2021 gamepub. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "UnityAppController.h"
@import PubSDK;

@interface PubSDKUnityAppDelegate : UnityAppController
@end

IMPL_APP_CONTROLLER_SUBCLASS(PubSDKUnityAppDelegate)

@implementation PubSDKUnityAppDelegate

-(BOOL)application:(UIApplication*) application didFinishLaunchingWithOptions:(NSDictionary*) options
{
    [[PubSDKApplicationDelegate sharedInstance] application:application didFinishLaunchingWithOptions:options];
    
    NSLog(@"[PubSDKUnityAppDelegate application:%@ didFinishLaunchingWithOptions:%@]", application, options);
    return [super application:application didFinishLaunchingWithOptions:options];
}

@end
