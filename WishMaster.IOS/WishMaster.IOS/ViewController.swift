//
//  ViewController.swift
//  WishMaster.IOS
//
//  Created by Kaan on 10/3/15.
//  Copyright © 2015 genie. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    @IBOutlet weak var usernameBox: UITextField!
    @IBOutlet weak var passwordBox: UITextField!
    @IBOutlet weak var errorLabel: UILabel!
    override func viewDidLoad() {
        super.viewDidLoad()
        errorLabel.text = "" //celan error label
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    //Hide keyboard after editing
    func textFieldShouldReturn(textField: UITextField) -> Bool {
        self.view.endEditing(true)
        return false
    }
    
    //Hide keyboard when touched outside textbox
    override func touchesBegan(touches: Set<UITouch>, withEvent event: UIEvent?) {
        self.view.endEditing(true)
    }

    
    @IBAction func loginAction(sender: UIButton) {
        if (usernameBox.text == "")
        {
            errorLabel.text = "*Please enter UserName."
            return
        }else if (passwordBox.text == ""){
            errorLabel.text = "*Please enter PassWord."
            return
        }
        
        let request = NSMutableURLRequest(URL: NSURL(string: "http://172.29.4.3/account/login/")!)
        
        let session = NSURLSession.sharedSession()
        
        request.HTTPMethod = "POST"
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        request.addValue("application/json", forHTTPHeaderField: "Accept")
        
        let jsonString = "{\"username\":\"" + usernameBox.text! + "\",\"password\":\"" + passwordBox.text! + "\"}"
        
        request.HTTPBody = jsonString.dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)
        
        
        let task = session.dataTaskWithRequest(request) { data, response, error in
            guard data != nil else {
                print("no data received and the error is: \(error)")
                return
            }
            
            do {
                if let json = try NSJSONSerialization.JSONObjectWithData(data!, options: []) as? NSDictionary {
                    
                    let success = json["Success"] as? Bool
                    
                    if(success == true)
                    {
                        dispatch_async(dispatch_get_main_queue(), { () -> Void in
                            
                            let mainStoryboard = UIStoryboard(name: "Main", bundle: NSBundle.mainBundle())
                            let vc : UIViewController = mainStoryboard.instantiateViewControllerWithIdentifier("cameraView")
                            self.presentViewController(vc, animated: true, completion: nil)
                        })
                    }
                    else
                    {
                        dispatch_async(dispatch_get_main_queue(), { () -> Void in
                            self.errorLabel.text = "*Username/Password error!";
                            self.errorLabel.hidden = false
                        }) //Username or password does not match
                        
                    }
                } else {
                    let jsonText = NSString(data: data!, encoding: NSUTF8StringEncoding)
                    
                    dispatch_async(dispatch_get_main_queue(), { () -> Void in
                        self.errorLabel.text = "*Server error!";
                        self.errorLabel.hidden = false
                    }) //Expected NSDictionary, something else is received
                    
                    
                    print("Error parsing JSON: \(jsonText)")
                }
            } catch let parseError {
                
                print(parseError)
                
                let jsonText = NSString(data: data!, encoding: NSUTF8StringEncoding)
                
                dispatch_async(dispatch_get_main_queue(), { () -> Void in
                    self.errorLabel.text = "*Server error!";
                    self.errorLabel.hidden = false
                })
                
                print("Error could not parse JSON: '\(jsonText)'") //check json format
            }
        }
        
        task.resume()

    }

}

