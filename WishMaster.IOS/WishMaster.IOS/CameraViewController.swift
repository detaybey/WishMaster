//
//  CameraViewController.swift
//  WishMaster.IOS
//
//  Created by Kaan on 10/3/15.
//  Copyright © 2015 genie. All rights reserved.
//

import UIKit
import CoreLocation

class CameraViewController: UIViewController, UIImagePickerControllerDelegate, UINavigationControllerDelegate, UIPickerViewDelegate, UIPickerViewDataSource, CLLocationManagerDelegate {
    
    @IBOutlet weak var newProductButton: UIButton!
    @IBOutlet weak var postButton: UIButton!
    @IBOutlet weak var priceLabel: UILabel!
    @IBOutlet weak var quantityLabel: UILabel!
    @IBOutlet weak var countryLabel: UILabel!
    @IBOutlet weak var deliveryDaysLabel: UILabel!
    @IBOutlet weak var purchaseDaysLabel: UILabel!
    @IBOutlet weak var category: UITextField!
    @IBOutlet weak var price: UITextField!
    @IBOutlet weak var quantity: UITextField!
    @IBOutlet weak var country: UITextField!
    @IBOutlet weak var daysToShip: UITextField!
    @IBOutlet weak var pDescription: UITextField!
    @IBOutlet weak var pTitle: UITextField!
    @IBOutlet weak var topConstraint: NSLayoutConstraint!
    @IBOutlet weak var availableDays: UITextField!
    @IBOutlet weak var customPicker: UIPickerView!
    @IBOutlet weak var productPhoto: UIImageView!
    var sessionid:String!
    var pickerSelected = 0
    var selectedCategoryId = 0
    var cameraAvailable = true
    var moveConst = 20 as CGFloat
    var countryData = ["United States","Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegowina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo", "Congo, the Democratic Republic of the", "Cook Islands", "Costa Rica", "Cote d'Ivoire", "Croatia (Hrvatska)", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "France Metropolitan", "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard and Mc Donald Islands", "Holy See (Vatican City State)", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran (Islamic Republic of)", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, Democratic People's Republic of", "Korea, Republic of", "Kuwait", "Kyrgyzstan", "Lao, People's Democratic Republic", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia, The Former Yugoslav Republic of", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia, Federated States of", "Moldova, Republic of", "Monaco", "Mongolia", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Seychelles", "Sierra Leone", "Singapore", "Slovakia (Slovak Republic)", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "Spain", "Sri Lanka", "St. Helena", "St. Pierre and Miquelon", "Sudan", "Suriname", "Svalbard and Jan Mayen Islands", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic", "Taiwan, Province of China", "Tajikistan", "Tanzania, United Republic of", "Thailand", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "United States Minor Outlying Islands", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Virgin Islands (British)", "Virgin Islands (U.S.)", "Wallis and Futuna Islands", "Western Sahara", "Yemen", "Yugoslavia", "Zambia", "Zimbabwe"]
    var categoryData = ["Fashion","Electronics","Home & Garden","Toys","Kids & Baby", "Sports", "Books", "Music & Games", "Healt & Beauty", "Other"]
    var locationManager: CLLocationManager = CLLocationManager()
    var lastLocation: CLLocation!
    override func viewDidLoad() {
        super.viewDidLoad()
        customPicker.removeFromSuperview()
        self.country.inputView = customPicker
        self.category.inputView = customPicker
        print(sessionid)
        customPicker.hidden = false
        
        postButton.layer.cornerRadius = 5
        postButton.layer.masksToBounds = true
        
        priceLabel.layer.cornerRadius = 5
        priceLabel.layer.masksToBounds = true
        
        
        quantityLabel.layer.cornerRadius = 5
        quantityLabel.layer.masksToBounds = true
        
        countryLabel.layer.cornerRadius = 5
        countryLabel.layer.masksToBounds = true
        
        deliveryDaysLabel.layer.cornerRadius = 5
        deliveryDaysLabel.layer.masksToBounds = true
        
        purchaseDaysLabel.layer.cornerRadius = 5
        purchaseDaysLabel.layer.masksToBounds = true
        
        postButton.layer.cornerRadius = 5
        newProductButton.layer.cornerRadius = 5
        self.availableDays.keyboardType = UIKeyboardType.NumberPad
        self.availableDays.returnKeyType = UIReturnKeyType.Done
        
        NSNotificationCenter.defaultCenter().addObserver(self, selector: Selector("keyboardWillShow:"), name:UIKeyboardWillShowNotification, object: nil);
        NSNotificationCenter.defaultCenter().addObserver(self, selector: Selector("keyboardWillHide:"), name:UIKeyboardWillHideNotification, object: nil);
        
        locationManager.desiredAccuracy = kCLLocationAccuracyBest
        locationManager.delegate = self
        locationManager.requestWhenInUseAuthorization()
        locationManager.startUpdatingLocation()
        
        // Do any additional setup after loading the view.
    }
    
    func locationManager(manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
        lastLocation = locations[locations.count - 1]
    }
    
    @IBAction func categoryClick(sender: AnyObject) {
        if (pickerSelected == 0)
        {
            pickerSelected = 1
            if (category.text == "")
            {
                category.text = categoryData[0]
            }
            
            customPicker.reloadAllComponents()
        }
    }
    @IBAction func priceClick(sender: UITextField) {
        moveConst = 130
    }
    @IBAction func quantityClick(sender: UITextField) {
        moveConst = 90
    }
    @IBAction func daysToShipClick(sender: UITextField) {
        moveConst = 20
    }
    @IBAction func countryClick(sender: UITextField) {
        moveConst = 65
        if (pickerSelected == 1)
        {
            pickerSelected = 0
            if (country.text == "")
            {
                country.text = countryData[0]
            }
            customPicker.reloadAllComponents()
        }
    }
    @IBAction func titleClick(sender: UITextField) {
        moveConst = 0
    }
   
    @IBAction func descClick(sender: AnyObject) {
        moveConst = 0
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
        
        UIView.animateWithDuration(0.1, animations: { () -> Void in
            self.topConstraint.constant = 27 - self.moveConst
        })
    }
    
    func keyboardWillHide(notification: NSNotification) {

        UIView.animateWithDuration(0.1, animations: { () -> Void in
            self.topConstraint.constant = 27
        })
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
    
    func numberOfComponentsInPickerView(pickerView: UIPickerView) -> Int {
        return 1
    }
    
    func pickerView(pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int {
        if(pickerSelected == 0)
        {
            return countryData.count
        }
        else
        {
            return categoryData.count
        }
        
    }
    func pickerView(pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {
        if(pickerSelected == 0)
        {
            return countryData[row]
        }
        else
        {
            return categoryData[row]
        }

    }
    
    func pickerView(pickerView: UIPickerView, didSelectRow row: Int, inComponent component: Int) {
        if(pickerSelected == 0)
        {
            country.text = countryData[row]
        }
        else
        {
            category.text = categoryData[row]
            selectedCategoryId = row + 1
        }
        
        
        //customPicker.hidden = true
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func retakePhoto(sender: AnyObject) {
        self.cameraAvailable = true
        let picker = UIImagePickerController()
        picker.delegate = self
        picker.sourceType = .Camera
        self.price.text = ""
        self.quantity.text = ""
        self.daysToShip.text = ""
        self.pDescription.text = ""
        self.pTitle.text = ""
        self.availableDays.text = ""
        
        self.presentViewController(picker, animated: true, completion: nil)
    }
    
    @IBAction func sendProductClick(sender: AnyObject) {
        
        let imageData = UIImageJPEGRepresentation(productPhoto.image!, 0.2)
        
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
            //availableDays
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"daystopurchase\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(availableDays?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(availableDays?.text ?? ""))
            //pTitle
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"title\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(pTitle?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(pTitle?.text ?? ""))
            //price
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"price\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(price?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(price?.text ?? ""))
            //quantity
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"quantity\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(quantity?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(quantity?.text ?? ""))
            //description
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"description\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(pDescription?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(pDescription?.text ?? ""))
            //country
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"country\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(country?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(country?.text ?? ""))
            //daystoship
            body.appendData(NSString(format: "\r\n--%@\r\n",boundary).dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(NSString(format:"Content-Disposition: form-data; name=\"daystoship\"\r\n\r\n").dataUsingEncoding(NSUTF8StringEncoding)!)
            body.appendData(String(daysToShip?.text ?? "").dataUsingEncoding(NSUTF8StringEncoding, allowLossyConversion: true)!)
            print(String(daysToShip?.text ?? ""))
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
                        self.quantity.text = ""
                        self.daysToShip.text = ""
                        self.pDescription.text = ""
                        self.pTitle.text = ""
                        self.availableDays.text = ""
                        
                        self.presentViewController(picker, animated: true, completion: nil)

                    })
                }
                
            }).resume()
            
            
        }
        
    }
    
    func imagePickerController(picker: UIImagePickerController, didFinishPickingMediaWithInfo info: [String : AnyObject]) {
        
        picker.dismissViewControllerAnimated(true, completion: nil)
        
        cameraAvailable = false;
        
        productPhoto.image = info[UIImagePickerControllerOriginalImage] as? UIImage

    }
}
