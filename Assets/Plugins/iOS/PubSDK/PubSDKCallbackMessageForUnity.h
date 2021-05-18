//
//  PubSDKNativeCallbackMessageForUnity.h
//  PubSDKUnityBridge
//
//  Created by gamepub on 2021/01/22.
//  Copyright © 2021 gamepub. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface PubSDKCallbackMessageForUnity : NSObject

+ (instancetype)callbackMessage:(NSString *)identifier value:(NSString *)value;

- (instancetype)initWithIdentifier:(NSString *)identifier value:(NSString *)value;
- (void)sendMessageOK;
- (void)sendMessageError;
- (void)sendMessageUpdate;

@end

NS_ASSUME_NONNULL_END
