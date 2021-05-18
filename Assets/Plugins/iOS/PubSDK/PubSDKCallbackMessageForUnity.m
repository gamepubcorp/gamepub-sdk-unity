//
//  PubSDKNativeCallbackMessageForUnity.m
//  PubSDKUnityBridge
//
//  Created by gamepub on 2021/01/22.
//  Copyright © 2021 gamepub. All rights reserved.
//

#import "PubSDKCallbackMessageForUnity.h"
#import "PubSDKNativeInterface.h"

@interface PubSDKCallbackMessageForUnity()

@property (nonatomic, copy) NSString *identifier;
@property (nonatomic, copy) NSString *value;

@end

@implementation PubSDKCallbackMessageForUnity

+ (instancetype)callbackMessage:(NSString *)identifier
                          value:(NSString *)value
{
    return [[self alloc] initWithIdentifier:identifier value:value];
}

- (instancetype)initWithIdentifier:(NSString *)identifier
                             value:(NSString *)value
{
    self = [super init];
    if (self) {
        _identifier = identifier;
        _value = value;
    }
    return self;
}

- (NSString *)generateMessageJson {
    if (!self.identifier || !self.value) {
        NSLog(@"[PubSDK] Either `identifier` and `value` is nil. Check response value to make sure a valid result.");
        return nil;
    }

    NSDictionary *dic = @{@"identifier": self.identifier, @"value": self.value};
    NSData *data = [NSJSONSerialization dataWithJSONObject:dic options:kNilOptions error:nil];
    
    if (!data){
        return nil;
    }

    return [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
}

- (void)sendMessageOK {
    pub_sdk_UnitySendMessage("GamePubSDK", "OnApiOk", [self generateMessageJson]);
}

- (void)sendMessageError {
    pub_sdk_UnitySendMessage("GamePubSDK", "OnApiError", [self generateMessageJson]);
}

- (void)sendMessageUpdate {
    pub_sdk_UnitySendMessage("GamePubSDK", "OnApiUpdate", [self generateMessageJson]);
}

@end
