//
//  SwiftForUnityBridge.m
//  SwiftForUnityPlugin
//
//  Created by Yuhao Zhong on 11.06.20.
//  Copyright © 2020 Yuhao Zhong. All rights reserved.
//

#import <Foundation/Foundation.h>
#include "SwiftForUnityPlugin-Swift.h"

#pragma mark - C interface

extern "C" {
    
    char* _sayHiToUnity() {
        
        NSString* returnString = [[SwiftForUnity shared] SayHiToUnity];
        
        char* cStringCopy(const char* string);
        
        return cStringCopy([retrunString UTF8String]);
    }
}

char* cStringCopy(const char* string) {
    
    if (string == NULL) {
        return NULL;
    }
    char* res = (char*)malloc(strlen(string)+1);
    strcpy(res, string);
    return res;
}
