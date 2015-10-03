//
//  CameraViewController.swift
//  WishMaster.IOS
//
//  Created by Kaan on 10/3/15.
//  Copyright © 2015 genie. All rights reserved.
//

import UIKit

class CameraViewController: UIViewController, UIImagePickerControllerDelegate, UINavigationControllerDelegate {
    
    @IBOutlet weak var productPhoto: UIImageView!
    var cameraAvailable = true
    
    override func viewDidLoad() {
        super.viewDidLoad()

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

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func imagePickerController(picker: UIImagePickerController, didFinishPickingMediaWithInfo info: [String : AnyObject]) {
        
        cameraAvailable = false;
        
        productPhoto.image = info[UIImagePickerControllerOriginalImage] as? UIImage
        
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

            picker.dismissViewControllerAnimated(true, completion: nil)
        }
    }
}
