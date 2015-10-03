//
//  CameraViewController.swift
//  WishMaster.IOS
//
//  Created by Kaan on 10/3/15.
//  Copyright © 2015 genie. All rights reserved.
//

import UIKit

class CameraViewController: UIViewController, UIImagePickerControllerDelegate, UINavigationControllerDelegate, UIPickerViewDelegate, UIPickerViewDataSource {
    
    @IBOutlet weak var topConstraint: NSLayoutConstraint!
    @IBOutlet weak var availableDays: UITextField!
    @IBOutlet weak var customPicker: UIPickerView!
    @IBOutlet weak var productPhoto: UIImageView!
    var cameraAvailable = true
    var pickerData = [String]()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        for index in 1...30 {
            pickerData.append(String(index))
        }
        
        customPicker.hidden = true
        
        self.availableDays.keyboardType = UIKeyboardType.NumberPad
        self.availableDays.returnKeyType = UIReturnKeyType.Done
        
        NSNotificationCenter.defaultCenter().addObserver(self, selector: Selector("keyboardWillShow:"), name:UIKeyboardWillShowNotification, object: nil);
        NSNotificationCenter.defaultCenter().addObserver(self, selector: Selector("keyboardWillHide:"), name:UIKeyboardWillHideNotification, object: nil);
        
        // Do any additional setup after loading the view.
    }
    
    override func viewDidAppear(animated: Bool) {
        if (cameraAvailable)
        {
            let picker = UIImagePickerController()
            picker.delegate = self
            picker.sourceType = .Camera
            
            presentViewController(picker, animated: true, completion: nil)
        }

    }
    
    func keyboardWillShow(notification: NSNotification) {
        //var info = notification.userInfo!
        //let keyboardFrame: CGRect = (info[UIKeyboardFrameEndUserInfoKey] as! NSValue).CGRectValue()
        
        UIView.animateWithDuration(0.1, animations: { () -> Void in
            self.topConstraint.constant = self.topConstraint.constant-20
        })
    }
    
    func keyboardWillHide(notification: NSNotification) {
        //var info = notification.userInfo!
        //let keyboardFrame: CGRect = (info[UIKeyboardFrameEndUserInfoKey] as! NSValue).CGRectValue()
        
        UIView.animateWithDuration(0.1, animations: { () -> Void in
            self.topConstraint.constant = self.topConstraint.constant + 20
        })
    }
    
    //Hide keyboard after editing
    func textFieldShouldReturn(textField: UITextField) -> Bool {
        self.view.endEditing(true)
        customPicker.hidden = true
        return false
    }
    
    //Hide keyboard when touched outside textbox
    override func touchesBegan(touches: Set<UITouch>, withEvent event: UIEvent?) {
        self.view.endEditing(true)
    }
    func numberOfComponentsInPickerView(pickerView: UIPickerView) -> Int {
        return 1
    }
    func pickerView(pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int {
        return pickerData.count
    }
    func pickerView(pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {
        return pickerData[row]
    }
    
    func pickerView(pickerView: UIPickerView, didSelectRow row: Int, inComponent component: Int) {
        availableDays.text = pickerData[row]
        customPicker.hidden = true
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func sendProductClick(sender: AnyObject) {
        
        let imageData = UIImageJPEGRepresentation(productPhoto.image!, 0.2)
        
        if imageData != nil{
            let request = NSMutableURLRequest(URL: NSURL(string:"http://172.29.4.211/account/PhotoTest")!)
            let session = NSURLSession.sharedSession()
            
            request.HTTPMethod = "POST"
            
            let boundary = NSString(format: "---------------------------1Hackaton032489567")
            let contentType = NSString(format: "multipart/form-data; boundary=%@",boundary)
            request.addValue(contentType as String, forHTTPHeaderField: "Content-Type")
            
            let body = NSMutableData()
            
            // Extra Data
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"title\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData("Hello World".dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            
            // Image
            body.appendData(NSString(format: "\r\n--%@\r\n", boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"profile_img\"; filename=\"img.jpg\"\\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format: "Content-Type: application/octet-stream\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(imageData!)
            body.appendData(NSString(format: "\r\n--%@\r\n", boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            
            request.HTTPBody = body
            
            session.dataTaskWithRequest(request, completionHandler: {(data, response, error) in
                print(data)
                print(response)
                print(error)
            }).resume()
            
            
        }
        
    }
    
    func imagePickerController(picker: UIImagePickerController, didFinishPickingMediaWithInfo info: [String : AnyObject]) {
        
        picker.dismissViewControllerAnimated(true, completion: nil)
        
        cameraAvailable = false;
        
        productPhoto.image = info[UIImagePickerControllerOriginalImage] as? UIImage

    }
}
