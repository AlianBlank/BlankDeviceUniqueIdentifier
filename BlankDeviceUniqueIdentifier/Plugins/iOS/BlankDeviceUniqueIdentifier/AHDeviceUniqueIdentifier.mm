//
//  AHDeviceUniqueIdentifier.m
//  keychain
//
//  Created by AlianHome on 16/8/16.
//  Copyright © 2016年 AlianHome. All rights reserved.
//

#import "AHDeviceUniqueIdentifier.h"
#import "SSKeychain.h"

@implementation AHDeviceUniqueIdentifier


+ (NSString *) GenUUID
{
    
    CFUUIDRef uuid_ref = CFUUIDCreate(NULL);
    
    CFStringRef uuid_string_ref= CFUUIDCreateString(NULL, uuid_ref);
    
    CFRelease(uuid_ref);
    
    NSString *uuid = [NSString stringWithString:(__bridge NSString*)uuid_string_ref];
    
    CFRelease(uuid_string_ref);
    
    return uuid;
}

+ (NSString *)getuuid{
    
    NSString * serviceName =@"com.alianhome.uuid";
    
    NSString * accountName =@"blank";
        // get value
    NSString * value = [SSKeychain passwordForService:serviceName account:accountName];
    
    
    if (value==nil) {
        
            // gen uuid
        NSString * uuid =[self GenUUID];

            // save uuid
        [SSKeychain setPassword:uuid forService:serviceName account:accountName];
        return uuid;
    }else{
        return value;
    }
    
}



char * DeviceUniqueId(){
    
        // get uuid
    const char *uuid = [[AHDeviceUniqueIdentifier getuuid] UTF8String];
        // alloc
    char *result = (char*)malloc(strlen(uuid)+1);
        // copy
    strcpy(result, uuid);
        // return
    return result;
}

@end
