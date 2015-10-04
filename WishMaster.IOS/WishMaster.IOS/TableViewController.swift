//
//  TableViewController.swift
//  WishMaster.IOS
//
//  Created by Kaan on 10/4/15.
//  Copyright © 2015 genie. All rights reserved.
//

import UIKit
import CoreLocation

class TableViewController: UITableViewController, CLLocationManagerDelegate, UIImagePickerControllerDelegate, UINavigationControllerDelegate {


    @IBOutlet weak var price: UITextField!
    @IBOutlet weak var pquantity: UITextField!
    @IBOutlet weak var deliverydays: UITextField!
    @IBOutlet weak var daystopurchase: UITextField!
    @IBOutlet weak var pcategory: UITextField!
    @IBOutlet weak var pdescription: UITextField!
    @IBOutlet weak var ptitle: UITextField!
    @IBOutlet weak var countryText: UITextField!
    @IBOutlet weak var categoryText: UITextField!
    var sessionid:String!
    var cameraAvailable = true
    var locationManager: CLLocationManager = CLLocationManager()
    var lastLocation: CLLocation!
    var selectedCategoryId = 0
    var productPhoto: UIImage!
    override func viewDidLoad() {
        super.viewDidLoad()
        self.tableView.contentInset = UIEdgeInsetsMake(20, 0, 0, 0);
        // Uncomment the following line to preserve selection between presentations
        // self.clearsSelectionOnViewWillAppear = false
        let tapGesture = UITapGestureRecognizer(target: self, action: Selector("hideKeyboard"))
        tapGesture.cancelsTouchesInView = true
        tableView.addGestureRecognizer(tapGesture)
        
        locationManager.desiredAccuracy = kCLLocationAccuracyBest
        locationManager.delegate = self
        locationManager.requestWhenInUseAuthorization()
        locationManager.startUpdatingLocation()

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

    func hideKeyboard() {
        tableView.endEditing(true)
    }
    
    func locationManager(manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
        lastLocation = locations[locations.count - 1]
    }
    
    //Hide keyboard after editing
    func textFieldShouldReturn(textField: UITextField) -> Bool {
        self.view.endEditing(true)
        //customPicker.hidden = true
        return false
    }
    
    //Hide keyboard when touched outside textbox
    override func touchesBegan(touches: Set<UITouch>, withEvent event: UIEvent?) {
        self.view.endEditing(true)
    }
    // MARK: - Table view data source

    @IBAction func countryClick(sender: AnyObject) {
        
        let mainStoryboard = UIStoryboard(name: "Main", bundle: NSBundle.mainBundle())
        let vc = mainStoryboard.instantiateViewControllerWithIdentifier("selectionView") as! SelectionViewController
        vc.pickerSelected = 0
        self.presentViewController(vc, animated: true, completion: nil)
    }
    
    @IBAction func categoryClick(sender: AnyObject) {
        let mainStoryboard = UIStoryboard(name: "Main", bundle: NSBundle.mainBundle())
        let vc = mainStoryboard.instantiateViewControllerWithIdentifier("selectionView") as! SelectionViewController
        vc.pickerSelected = 1
        self.presentViewController(vc, animated: true, completion: nil)
    }
    @IBAction func saveProduct(sender: AnyObject) {
        let imageData = UIImageJPEGRepresentation(productPhoto!, 0.2)
        
        if imageData != nil{
            let request = NSMutableURLRequest(URL: NSURL(string:"http://172.29.4.3/product/add")!)
            let session = NSURLSession.sharedSession()
            
            request.HTTPMethod = "POST"
            
            let boundary = NSString(format: "---------------------------1Hackaton032489567")
            let contentType = NSString(format: "multipart/form-data; boundary=%@",boundary)
            request.addValue(contentType as String, forHTTPHeaderField: "Content-Type")
            
            let body = NSMutableData()
            
            // Lat
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"lat\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(lastLocation.coordinate.latitude).dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(lastLocation.coordinate.latitude))
            //Lng
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"lng\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(lastLocation.coordinate.longitude).dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(lastLocation.coordinate.longitude))
            
            if (daystopurchase.text == "")
            {
                
                showAlert("Please input how many days the product can be ordered.")
                return
                
            }
            //availableDays
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"daystopurchase\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(daystopurchase?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(daystopurchase?.text ?? ""))
            
            if (ptitle.text == "")
            {
                
                showAlert("Please give a title to the product.")
                return
                
            }
            //pTitle
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"title\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(ptitle?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(ptitle?.text ?? ""))
            
            if (price.text == "")
            {
                
                showAlert("Please indicate the price for the product.")
                return
                
            }
            //price
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"price\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(price?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(price?.text ?? ""))
            
            if (pquantity.text == "")
            {
                
                showAlert("Please indicate the quantity.")
                return
                
            }
            
            //quantity
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"quantity\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(pquantity?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(pquantity?.text ?? ""))
            
            if (pdescription.text == "")
            {
                
                showAlert("Please write a description for the product.")
                return
                
            }
            //description
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"description\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(pdescription?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(pdescription?.text ?? ""))
            
            if (countryText.text == "")
            {
                
                showAlert("Please choose a destination Country.")
                return
                
            }
            //country
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"country\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(countryText?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(countryText?.text ?? ""))
            
            if (deliverydays.text == "")
            {
                
                showAlert("Please indicate when you can ship the product.")
                return
                
            }
            //daystoship
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"daystoship\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(deliverydays?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(deliverydays?.text ?? ""))
            
            if (selectedCategoryId == 0)
            {
                
                showAlert("Please select a category for the product.")
                return
                
            }
            //categoryId
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"categoryid\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(selectedCategoryId).dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(selectedCategoryId))
            
            //12345678-1234-1234-1234-123456789abc
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"sessionid\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(sessionid).dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(sessionid))
            
            // Image
            body.appendData(NSString(format: "\r\n--%@\r\n", boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"profile_img\"; filename=\"img.jpg\"\\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format: "Content-Type: application/octet-stream\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(imageData!)
            body.appendData(NSString(format: "\r\n--%@\r\n", boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            
            request.HTTPBody = body
            
            session.dataTaskWithRequest(request, completionHandler: {(data, response, error) in
                //print(data)
                //print(response)
                //print(error)
                
                if (error == nil)
                {
                    dispatch_async(dispatch_get_main_queue(), { () -> Void in
                        self.cameraAvailable = true
                        let picker = UIImagePickerController()
                        picker.delegate = self
                        picker.sourceType = .Camera
                        self.price.text = ""
                        self.pquantity.text = ""
                        self.deliverydays.text = ""
                        self.pdescription.text = ""
                        self.ptitle.text = ""
                        self.daystopurchase.text = ""
                        
                        self.presentViewController(picker, animated: true, completion: nil)
                        
                    })
                }
                
            }).resume()
            
            
        }

    }

    @IBAction func newProduct(sender: AnyObject) {
        self.cameraAvailable = true
        let picker = UIImagePickerController()
        picker.delegate = self
        picker.sourceType = .Camera
        self.price.text = ""
        self.pquantity.text = ""
        self.deliverydays.text = ""
        self.pdescription.text = ""
        self.ptitle.text = ""
        self.daystopurchase.text = ""
        
        self.presentViewController(picker, animated: true, completion: nil)
    }
    
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    
    @IBAction func cancelPick(segue:UIStoryboardSegue) {
        
    }
    
    @IBAction func setPick(segue:UIStoryboardSegue) {
        
    }
    
    func showAlert(msg: String)
    {
        let alertController = UIAlertController(title: "Info", message:
            msg, preferredStyle: UIAlertControllerStyle.Alert)
        alertController.addAction(UIAlertAction(title: "Ok", style: UIAlertActionStyle.Default,handler: nil))
        
        self.presentViewController(alertController, animated: true, completion: nil)
    }
    
    func imagePickerController(picker: UIImagePickerController, didFinishPickingMediaWithInfo info: [String : AnyObject]) {
        
        picker.dismissViewControllerAnimated(true, completion: nil)
        
        cameraAvailable = false;
        
        productPhoto = info[UIImagePickerControllerOriginalImage] as? UIImage
        
    }
    /*
    override func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCellWithIdentifier("reuseIdentifier", forIndexPath: indexPath)

        // Configure the cell...

        return cell
    }
    */

    /*
    // Override to support conditional editing of the table view.
    override func tableView(tableView: UITableView, canEditRowAtIndexPath indexPath: NSIndexPath) -> Bool {
        // Return false if you do not want the specified item to be editable.
        return true
    }
    */

    /*
    // Override to support editing the table view.
    override func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
        if editingStyle == .Delete {
            // Delete the row from the data source
            tableView.deleteRowsAtIndexPaths([indexPath], withRowAnimation: .Fade)
        } else if editingStyle == .Insert {
            // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
        }    
    }
    */

    /*
    // Override to support rearranging the table view.
    override func tableView(tableView: UITableView, moveRowAtIndexPath fromIndexPath: NSIndexPath, toIndexPath: NSIndexPath) {

    }
    */

    /*
    // Override to support conditional rearranging of the table view.
    override func tableView(tableView: UITableView, canMoveRowAtIndexPath indexPath: NSIndexPath) -> Bool {
        // Return false if you do not want the item to be re-orderable.
        return true
    }
    */

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
