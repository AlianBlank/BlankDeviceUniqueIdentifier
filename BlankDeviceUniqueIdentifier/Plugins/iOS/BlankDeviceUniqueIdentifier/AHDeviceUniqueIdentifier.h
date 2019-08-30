//
//  AHDeviceUniqueIdentifier.h
//  keychain
//
//  Created by AlianHome on 16/8/16.
//  Copyright © 2016年 AlianHome. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface AHDeviceUniqueIdentifier : NSObject

#ifdef __cplusplus
extern "C" {
#endif
    char * DeviceUniqueId();
#ifdef __cplusplus
}
#endif


@end
