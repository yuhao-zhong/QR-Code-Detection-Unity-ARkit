//
//  SwiftForUnity.swift
//  SwiftForUnityPlugin
//
//  Created by Yuhao Zhong on 11.06.20.
//  Copyright © 2020 Yuhao Zhong. All rights reserved.
//

import Foundation
import UIKit

@objc public class SwiftForUnity: UIViewController {
    
    @objc static let shared = SwiftForUnity()
    @objc func SayHiToUnity() -> String {
        return "Hi, I'm Swift"
    }
}
