


using CommunityToolkit.Maui.Views;
using DoneBusiness2025.AppResourcee;
using DoneBusiness2025.Enums;
using DoneBusiness2025.Model;

using Newtonsoft.Json;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using DoneBusiness2025.Model.Delegate;
using Plugin.Maui.Audio;



#if ANDROID
using Android.Content;
using Android.Locations;
#endif

#if IOS
using UIKit;
using Foundation;
using CoreLocation;
using Microsoft.Maui.Devices;


#endif


namespace DoneBusiness2025.Views.Delegate;

public partial class MainPage : ContentPage
{
    public string WidthCoordinatesAddresss = "";
    public string LengthCoordinatesAddresss = "";

    public int Iddriver;
    public int Idorderintpay=0;
    public string priceintpay = "0";
    public int TypeDriver = 0;
    private string MyDatabaseFile = "DoneBusinessDelegate.db3";
    public int NumberRun = 17;
    string NameVrsions = "0";
    int Logins = 0;
    string LanguageNames = "";
    public ObservableCollection<Order> IsMyOrder { get; set; }
    public ObservableCollection<Order> IsOrder { get; set; }
    ChatUserRole? userRole;

    int pickerIsToggled = 0;

    int Toggled = 0;
    public MainPage()
	{
		InitializeComponent();

        Connecteds.BackgroundColor = Color.FromHex("#7CD185");
        Notconnected.BackgroundColor = Color.FromHex("#DCDBDB");

        try
        {
            string Name = AppResource.NameLang;
            if (Name == "ok")
            {

                LanguageNames = "en";
                this.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                LanguageNames = "ar";
                this.FlowDirection = FlowDirection.RightToLeft;
            }
        }
        catch
        {

        }

        try
        {
            var dddd = DatabaseAcss.SelectDriver<Driver>(MyDatabaseFile);

            if (dddd.Count > 0)
            {
                Iddriver = dddd[0].Id;
            }
            else
            {
                //var dddds = DatabaseAcss.SelectDriverUserShopBoshesDriver<UserShopBoshesDriver>(MyDatabaseFile);

                //if (dddds.Count > 0)
                //{
                //    TypeDriver = 1;
                //    Iddriver = dddd[0].Id;
                //}

            }

        }
        catch
        {

        }

        try
        {
            ListIsOrder.RefreshCommand = new Command(() => {
                //Do your stuff.    
                try
                {
                    if (NameVrsions == "0")
                    {
                        Update();
                    }
                    else
                    {

                        pOPs();
                    }
                }
                catch
                {

                }

                ListIsOrder.IsRefreshing = false;
            });
        }
        catch
        {

        }

        try
        {
            ListIsMyOrder.RefreshCommand = new Command(() => {
                //Do your stuff.    
                try
                {
                    if (NameVrsions == "0")
                    {
                        Update();
                    }
                    else
                    {
                        pOPs();
                    }
                }
                catch
                {

                }

                ListIsMyOrder.IsRefreshing = false;
            });
        }
        catch
        {

        }

        try
        {
            Toupdate();
        }
        catch
        {

        }
    }

    public async void pOPs()
    {
        bool answer = await DisplayAlert(AppResource.Notice, AppResource.Sorry, AppResource.Update, AppResource.closetheapp);
        if (answer == true)
        {
            StStatic.IsVisible = true;
            LabelStatic.Text = AppResource.Pleaseupdatecontinue;
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                await Launcher.OpenAsync("https://apps.apple.com/sa/app/fast-delivery-%D8%AA%D9%88%D8%B5%D9%8A%D9%84-%D8%B7%D9%84%D8%A8%D8%A7%D8%AA/id1585400420?l=ar");

            }
            else
            {
                await Launcher.OpenAsync("https://play.google.com/store/apps/details?id=com.companyname.appll");
            }


        }
        else
        {
            StStatic.IsVisible = true;
            LabelStatic.Text = AppResource.Pleaseupdatecontinue;
        }
    }


   

    protected override async void OnAppearing()
    {
        try
        {
            WeakReferenceMessenger.Default.Register<InterposPaymentResponse>(this, HandleInterpayPayment);
        }
        catch
        {

        }


        try
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                int PRssss = 0;
                var clientsfscv = new HttpClient();
                var strResultsfsxv = await clientsfscv.GetStringAsync("https://www.doneksa.com/api/ApidataMyFasts?NameVrsDriverTow=27");
                string PRs = strResultsfsxv.ToString();
                PRssss = int.Parse(PRs);
                if (PRssss == 0)
                {
                    Update();
                    Preferences.Set("NameVrsion", "0");
                    NameVrsions = "0";
                }
                else
                {
                    NameVrsions = "1";
                    pOPs();

                }
            }
            else
            {
                StStatic.IsVisible = true;
                LabelStatic.Text = AppResource.Thenetworkstable;
            }
        }
        catch
        {

        }




    }
    private async void HandleInterpayPayment(object recipient, InterposPaymentResponse interPosResponse)
    {
        try
        {

        
        //when interpos returns the response through callback we are taking the response here
        if (interPosResponse.IsPaymentFailed)
        {        try
                {
                    await DisplayAlert(AppResource.PaymentFailed, interPosResponse.Message, "Ok");
                }
                catch
                {

                }
          
        }
        else
        {

            var client = new HttpClient();
            string strResult = await client.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?IdOrdersinter=" + Idorderintpay + "&IsPaymentFailedinter=" + interPosResponse.IsPaymentFailed + "&Statusinter=" + interPosResponse.Status + "&RefNointer=" + interPosResponse.RefNo + "&ReceiptURLsinter=" + interPosResponse.ReceiptURLs + "&transactionAmounts=" + priceintpay);
            int istoggle = JsonConvert.DeserializeObject<int>(strResult);
            if (istoggle == 1)
            {
            await DisplayAlert(AppResource.Successss, AppResource.paymentsuccessfullyinterpay , "Ok");

                    

            }
            else
           {
                    await DisplayAlert(interPosResponse.RefNo, AppResource.paymentreference + interPosResponse.RefNo, "Ok");
           }

           
            // create the order as payment success here

        }
        }
        catch
        {

        }
    }

    protected override void OnDisappearing()
    {
        // Mandatory : payment response observer should be unsubscribe otherwise, memory leak can happens
        WeakReferenceMessenger.Default.Unregister<InterposPaymentResponse>(this);
    }


    public async void Update()
    {
        try
        {
            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                ButtLoction.IsVisible = false;
                WidthCoordinatesAddresss = location.Longitude.ToString();
                LengthCoordinatesAddresss = location.Latitude.ToString();

                AddIsOrderNewOld(LengthCoordinatesAddresss, WidthCoordinatesAddresss);




            }
            else
            {

            }
        }
        catch
        {
            try
            {
                if (IsOrder.Count > 0)
                {
                    IsOrder.Clear();
                }



            }
            catch
            {

            }

            try
            {
                if (IsMyOrder.Count > 0)
                {
                    IsMyOrder.Clear();
                }



            }
            catch
            {

            }

            ListIsOrder.ItemsSource = null;
            ListIsMyOrder.ItemsSource = null;
            StIsOrder.IsVisible = false;
            StIsMyOrder.IsVisible = false;
            // StActivityIndicator.IsVisible = false;
            ButtLoction.IsVisible = true;
            StStatic.IsVisible = true;
            LabelStatic.Text = AppResource.Pleaseactivatescontinue;



        }

    }


    public async void AddIsOrderNewOld(string latitudecoordinates, string Longitudecoordinates)
    {
        try
        {

            var clientsa = new HttpClient();
            string strResultsa = await clientsa.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?latitudenew=" + Longitudecoordinates + "&Longitudenew=" + latitudecoordinates + "&Langanew=" + LanguageNames + "&IdDriversnew=" + Iddriver + "&pickerIsToggledsnew=" + pickerIsToggled);
            PageOdersRun<List<Order>, List<Order>> Orders = JsonConvert.DeserializeObject<PageOdersRun<List<Order>, List<Order>>>(strResultsa);

            List<Order> ordersold = Orders.TabelOrderOlds;

            List<Order> ordersnew = Orders.TabelOrderNews;

            NumberRun = Orders.NumberRun;

            string Massege = Orders.Massges;

            try
            {
                Toggled = Orders.pickerToggled;
                if (Toggled == 0)
                {
                    Connecteds.BackgroundColor = Color.FromHex("#DCDBDB");
                    Notconnected.BackgroundColor = Color.FromHex("#D17C7C");
                }
                else
                {
                    if (Toggled == 1)
                    {
                        Connecteds.BackgroundColor = Color.FromHex("#7CD185");
                        Notconnected.BackgroundColor = Color.FromHex("#DCDBDB");
                    }

                }
            }
            catch
            {

            }

            if (Massege == "0")
            {


                StStatic.IsVisible = false;

                IsOrder = new ObservableCollection<Order>();
                if (IsOrder.Count > 0)
                {
                    IsOrder.Clear();
                }


                if (ordersnew != null)
                {
                    foreach (Order Orde in ordersnew)
                    {
                        Orde.NoteStatusDriver = "false";
                        Orde.PaymentProcessNumber = "true";
                        if (Orde.Cash == "true")
                        {
                            Orde.DataOrder = "#B4A63B";
                            Orde.TimeAccsptReadyBosh = AppResource.cashs;
                        }

                        if (Orde.PaymentStatus == "true")
                        {
                            Orde.DataOrder = "#7EDC86";
                            Orde.TimeAccsptReadyBosh = AppResource.Paids;
                        }

                        if (Orde.cahckWallts == "true")
                        {
                            Orde.DataOrder = "#7EDC86";
                            Orde.TimeAccsptReadyBosh = AppResource.Paids;
                        }

                        if (Orde.IdBosh == 43)
                        {
                            Orde.DataOrder = "#9BCCE2";
                            Orde.TimeAccsptReadyBosh = AppResource.fazieas;
                            Orde.PaymentProcessNumber = "false";
                            Orde.NoteStatusDriver = "true";
                            Orde.TimeAccsptBosh = AppResource.Fazaaorder; 
                        }

                        if (Orde.PostalCode == "storedone")
                        {
                            if(Orde.NoteBosh == "nonofa" || Orde.NoteBosh == "nono")
                            {
                                Orde.DataOrder = "#e29b9b";
                                Orde.TimeAccsptReadyBosh = AppResource.Specialrequest; 
                                Orde.PaymentProcessNumber = "false";
                                Orde.PaymentStatus = "false";
                                Orde.Cash = "true";
                                Orde.NoteStatusDriver = "true";
                                Orde.TimeAccsptBosh = AppResource.SpecialrequestGo;  
                            }   
                        }
                        else
                        {
                            Orde.NoteStatusDriver = "false";
                            Orde.PaymentProcessNumber = "true";
                           
                        }


                        Orde.NoteStatusDriver = "true";

                        IsOrder.Add(Orde);
                    }
                }


                IsMyOrder = new ObservableCollection<Order>();

                if (IsMyOrder.Count > 0)
                {
                    IsMyOrder.Clear();
                }

                if (ordersold != null)
                {

                    foreach (Order Orde in ordersold)
                    {
                        Orde.IdcahckWallts = "false";
                        if (Orde.Cash == "true")
                        {
                            if(Orde.PostalCode == "storedone")
                            {
                                Orde.TimeAccsptReadyBosh = AppResource.cashs;

                                Orde.Paymentcodess = "#B4A63B";
                            }
                            else
                            {
                                if(Orde.StatusBosh == "true" && Orde.ReceivedDriver == "true" || Orde.StatusBosh == "true" )
                                {
                                    Orde.IdcahckWallts = "true";
                                }

                               
                                // تفعيل زر الدفع انتر باي 


                                Orde.TimeAccsptReadyBosh = AppResource.cashs;

                                Orde.Paymentcodess = "#B4A63B";
                            }
                           
                        }

                        if (Orde.PaymentStatus == "true")
                        {

                            Orde.TimeAccsptReadyBosh = AppResource.Paids;
                            Orde.Paymentcodess = "#7EDC86";
                        }

                        if (Orde.cahckWallts == "true")
                        {

                            Orde.TimeAccsptReadyBosh = AppResource.Paids;
                            Orde.Paymentcodess = "#7EDC86";
                        }

                        if (Orde.IdBosh == 43)
                        {

                            Orde.TimeAccsptReadyBosh = AppResource.fazieas;
                            Orde.Paymentcodess = "#9BCCE2";
                        }

                        if (Orde.PostalCode == "storedone")
                        {
                            if (Orde.NoteBosh == "nonofa" || Orde.NoteBosh == "nono" || Orde.NoteBosh == "yesyes" || Orde.NoteBosh == "yesyesfa")
                            {
                                Orde.TimeAccsptReadyBosh = AppResource.Specialrequest;
                                Orde.Paymentcodess = "#e29b9b";
                                 
                                Orde.PaymentStatus = "false";
                                Orde.Cash = "true";
                            }
                            



                        }

                        try
                        {
                            if (!string.IsNullOrEmpty(Orde.StreetThoroughfare))
                            {

                                if (Orde.StreetThoroughfare.Length > 2)
                                {
                                    Orde.NoteStatusDriver = "true";
                                }
                                else
                                {
                                    Orde.NoteStatusDriver = "false";
                                }

                            }
                            else
                            {
                                Orde.NoteStatusDriver = "false";
                            }
                        }
                        catch
                        {
                            Orde.NoteStatusDriver = "false";
                        }


                        if (Orde.IdBosh != 43 && Orde.Cash == "true" && Orde.PostalCode != "storedone")
                        {
                            Orde.PaymentCardStartEnd = "true";
                             
                            try
                            {
                                double Servicefees = 0;
                                try
                                {



                                    Servicefees = double.Parse(Orde.NeighborhoodSubLocality);



                                }
                                catch
                                {


                                }




                                double TotalPrices = 0;
                                try
                                {



                                    TotalPrices = double.Parse(Orde.TotalPrice);



                                }
                                catch
                                {


                                }


                                double DeliveryPrices = 0;
                                try
                                {
                                    DeliveryPrices = double.Parse(Orde.DeliveryPrice);
                                }
                                catch
                                {


                                }


                                double PricepackagDrivers = 0;
                                try
                                {
                                    PricepackagDrivers = double.Parse(Orde.PricepackagDriver);
                                }
                                catch
                                {


                                }

                                double PricepackagAfters = 0;
                                try
                                {
                                    PricepackagAfters = double.Parse(Orde.PricepackagAfter);
                                }
                                catch
                                {


                                }




                                double CobenPrices = 0;
                                try
                                {
                                    CobenPrices = double.Parse(Orde.CobenPrice);
                                }
                                catch
                                {


                                }

                                double TimeArriveds = 0;

                                try
                                {
                                    TimeArriveds = double.Parse(Orde.TimeArrived);
                                }
                                catch
                                {


                                }


                                //TotalPrices
                                //DeliveryPrices
                                //PricepackagDrivers
                                //PricepackagAfters
                                //CobenPrices
                                //TimeArriveds

                                double totel = 0;

                                try
                                {
                                    double to1 = TotalPrices - CobenPrices;

                                    totel = to1;

                                    if (totel < 0)
                                    {
                                        totel = 0;
                                    }

                                }
                                catch
                                {


                                }

                                double totelCustomer = 0;

                                try
                                {
                                    double to1 = totel + DeliveryPrices+Servicefees;

                                    totelCustomer = to1;

                                }
                                catch
                                {


                                }

                                Orde.NotCancelOrder = totel.ToString() + " " + AppResource.SAR;
                                Orde.TimeAccsptDriver = totelCustomer.ToString() + " " + AppResource.SAR;
                                
                            }
                            catch
                            {

                            }





                        }
                        else
                        {
                            Orde.PaymentCardStartEnd = "false";
                        }

                        if (Orde.IdBosh == 43)
                        {
                            Orde.TimeDriver = "true";

                            if (Orde.Cash == "false")
                            {
                                Orde.TimeAccsptBosh = AppResource.customerpaid;
                            }
                            else
                            {

                                if (Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.NoteBosh == "true" && Orde.ReceivedDriver == "true")
                                {

                                    double Totel = double.Parse(Orde.TotalPrice) + double.Parse(Orde.DeliveryPrice) - double.Parse(Orde.CobenPrice);

                                    Orde.TimeAccsptBosh = AppResource.Receiptofmone + Totel + " " + AppResource.SAR;
                                }
                                else
                                {
                                    Orde.TimeAccsptBosh = AppResource.Pleaseissuean;
                                }



                            }

                        }
                        else
                        {
                            Orde.TimeDriver = "false";
                        }


                        if (Orde.StatusBosh == "true" && Orde.ReceivedDriver != "true")
                        {
                            Orde.PaymentAmount = "true";

                            Orde.TimeAccsptReceivedDriver = "true";
                            Orde.DateAccsptReceivedDriver = AppResource.Gotostore;
                        }
                        else
                        {
                            if (Orde.StatusBosh == "new" && Orde.ReceivedDriver != "true")
                            {
                                Orde.PaymentAmount = "true";

                                Orde.TimeAccsptReceivedDriver = "false";
                                Orde.DateAccsptReceivedDriver = AppResource.Awaitingstoreapproval;

                            }
                            else
                            {
                                Orde.PaymentAmount = "false";
                            }

                        }


                        if (Orde.PostalCode == "storedone" && Orde.NoteBosh == "nonofa" || Orde.PostalCode == "storedone" && Orde.NoteBosh == "nono" )
                        {
                            if (Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.IDDriver>0)
                            { 
                                Orde.TimeOrder = "true";
                            }
                            

                        }
                        else
                        { 
                            Orde.TimeOrder = "false";

                        }


                        if (Orde.StatusBosh == "true" && Orde.ReceivedDriver != "true" && Orde.IdBosh != 43 && Orde.PostalCode != "storedone" )
                        {
                            Orde.PaymentProcessNumber = "true";

                        }
                        else
                        {
                            Orde.PaymentProcessNumber = "false";

                        }


                        if (Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.ReceivedDriver == "true")
                        { 
                            Orde.CancelOrder = "true";
                            Orde.FreeDriveriv = "true";
                        }
                        else
                        {
                            
                            Orde.CancelOrder = "false";
                            Orde.FreeDriveriv = "false";

                        }

                        if (Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.IdBosh == 43 && Orde.ReceivedDriver != "true")
                        {
                            Orde.NoteReadyBosh = "true";
                        }
                        else
                        {
                            Orde.NoteReadyBosh = "false";
                        }

                         

                        if (Orde.PostalCode == "storedone"&& Orde.NoteBosh == "nonofa" || Orde.PostalCode == "storedone" && Orde.NoteBosh == "nono")
                        {
                            Orde.PaymentCardStartEnd = "false";
                      
                            Orde.TimeDriver = "true";

                            
                                if (Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.NoteBosh == "nonofa" && Orde.ReceivedDriver == "true" || Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.NoteBosh == "nono" && Orde.ReceivedDriver == "true")
                                {

                                if (Orde.NoteBosh == "nono")
                                {
                                      
                                    double billprice = 0;


                                    try
                                    {
                                        billprice = double.Parse(Orde.NotCancelOrder);
                                    }
                                    catch
                                    {

                                    }


                                    double TotalPrices = 0;


                                    try
                                    {
                                        TotalPrices = double.Parse(Orde.TotalPrice);
                                    }
                                    catch
                                    {

                                    }
                                    if (TotalPrices > billprice)
                                    {
                                        Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued   + billprice.ToString() + " " + AppResource.SAR + AppResource.deliveryfees ;

                                    }
                                    else if (TotalPrices < billprice)
                                    {// تفعيل زر الدفع انتر باي 
                                        Orde.IdcahckWallts = "true";
                                        Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.Receivemoney  + Orde.DateAccsptReadyBosh + " " + AppResource.SAR + AppResource.onlyss;

                                    }
                                    else if (TotalPrices == billprice)
                                    {
                                        Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.deliveryfees ;

                                    }



                                }
                                else if(Orde.NoteBosh == "nonofa")
                                {
                                    double billprice = 0;


                                    try
                                    {
                                        billprice = double.Parse(Orde.NotCancelOrder);
                                    }
                                    catch
                                    {

                                    }
                                     
                                   Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.Receivemoney + Orde.DateAccsptReadyBosh + " " + AppResource.SAR + AppResource.onlyss;
                                    // تفعيل زر الدفع انتر باي 
                                    Orde.IdcahckWallts = "true";
                                }
                                else if (Orde.NoteBosh == "yesyesfa")
                                {



                                    double billprice = 0;


                                    try
                                    {
                                        billprice = double.Parse(Orde.NotCancelOrder);
                                    }
                                    catch
                                    {

                                    }


                                    double TotalPrices = 0;


                                    try
                                    {
                                        TotalPrices = double.Parse(Orde.TotalPrice);
                                    }
                                    catch
                                    {

                                    }
                                    if (TotalPrices > billprice)
                                    {
                                        Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.deliveryfees;

                                    }
                                    else if (TotalPrices < billprice)
                                    {

                                        // تفعيل زر الدفع انتر باي 
                                        Orde.IdcahckWallts = "true";
                                        Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.Receivemoney + Orde.DateAccsptReadyBosh + " " + AppResource.SAR + AppResource.onlyss;

                                    }
                                    else if (TotalPrices == billprice)
                                    {
                                        Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.deliveryfees;

                                    }



                                }


                                }
                                else
                                {
                                    if (Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.NoteBosh == "yesyes" && Orde.ReceivedDriver == "true" || Orde.StatusBosh == "true" && Orde.StatusDriver == "true" && Orde.NoteBosh == "yesyesfa" && Orde.ReceivedDriver == "true")
                                    {
                                        double price1 = 0;


                                        try
                                        { 
                                            price1 = double.Parse(Orde.NotCancelOrder);
                                        }
                                        catch
                                        {

                                        }

                                    if (Orde.NoteBosh == "yesyesfa")
                                    {
                                        
                                    }
                                    else
                                    {
                                        Orde.TimeOrder = "false";
                                    }
                                     
                                    Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + price1.ToString() + " " + AppResource.SAR + AppResource.deliveryfees;
                                     }
                                    else
                                    {
                                        Orde.TimeAccsptBosh = AppResource.SpecialrequestGo; 

                                    }


                                       
                                }


                                
                           

                        }
                        else
                        {
                           

                            if (Orde.PostalCode == "storedone" && Orde.NoteBosh == "yesyes" )
                            {
                                Orde.PaymentCardStartEnd = "false";
                                Orde.TimeDriver = "true";
                                Orde.TimeOrder = "false";
                                double price1 = 0;


                                try
                                {
                                    price1 = double.Parse(Orde.NotCancelOrder);
                                }
                                catch
                                {

                                } 
                                Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + price1.ToString() + " " + AppResource.SAR + AppResource.deliveryfees ;
                                 
                               }
                             else
                            {
                                if (Orde.PostalCode == "storedone" && Orde.NoteBosh == "yesyesfa" )
                                {
                                    Orde.PaymentCardStartEnd = "false";
                                    Orde.TimeDriver = "true";
                                    Orde.TimeOrder = "true";
                                    double price1 = 0;


                                    try
                                    {
                                        price1 = double.Parse(Orde.NotCancelOrder);
                                    }
                                    catch
                                    {

                                    }
                                    Orde.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + price1.ToString() + " " + AppResource.SAR + AppResource.deliveryfees;

                                }

                            }

                            // Orde.TimeDriver = "false";
                        }




                        IsMyOrder.Add(Orde);
                    }
                }

                if (IsMyOrder.Count > 0)
                {
                    // StActivityIndicator.IsVisible = false;
                    // ActivityIndicatorMain.IsRunning = false;

                    StIsOrder.IsVisible = false;
                    ListIsOrder.ItemsSource = null;

                    StIsMyOrder.IsVisible = true;

                    ListIsMyOrder.ItemsSource = IsMyOrder;

                    if (IsOrder.Count > 0)
                    {
                        try
                        {
                            Order orders = IsMyOrder.Where(x => x.ReceivedDriver == "new").FirstOrDefault();
                            if (orders != null)
                            {
                                StackLayoutShopNewOrder.IsVisible = false;
                            }
                            else
                            {
                                StackLayoutShopNewOrder.IsVisible = true;
                            }
                        }
                        catch
                        {
                            StackLayoutShopNewOrder.IsVisible = false;
                        }


                    }
                    else
                    {
                        StackLayoutShopNewOrder.IsVisible = false;
                    }


                }
                else
                {
                    if (IsOrder.Count > 0)
                    {
                        // StActivityIndicator.IsVisible = false;
                        //  ActivityIndicatorMain.IsRunning = false;
                    }
                    else
                    {
                        //  StActivityIndicator.IsVisible = true;
                        //  ActivityIndicatorMain.IsRunning = true;
                    }

                    StIsMyOrder.IsVisible = false;
                    ListIsMyOrder.ItemsSource = null;

                    StIsOrder.IsVisible = true;

                    ListIsOrder.ItemsSource = IsOrder;
                    StackLayoutShopNewOrder.IsVisible = false;
                }

                BindingContext = this;
            }
            else
            {
                if (Massege == "1")
                {
                    try
                    {
                        if (IsOrder.Count > 0)
                        {
                            IsOrder.Clear();
                        }

                    }
                    catch
                    {

                    }

                    try
                    {
                        if (IsMyOrder.Count > 0)
                        {
                            IsMyOrder.Clear();
                        }
                    }
                    catch
                    {

                    }

                    ListIsOrder.ItemsSource = null;
                    ListIsMyOrder.ItemsSource = null;
                    StIsOrder.IsVisible = false;
                    StIsMyOrder.IsVisible = false;
                    //  StActivityIndicator.IsVisible = false;

                    StStatic.IsVisible = true;
                    LabelStatic.Text = AppResource.Youraccountis;

                }

                if (Massege == "2")
                {
                    try
                    {
                        if (IsOrder.Count > 0)
                        {
                            IsOrder.Clear();
                        }

                    }
                    catch
                    {

                    }

                    try
                    {
                        if (IsMyOrder.Count > 0)
                        {
                            IsMyOrder.Clear();
                        }
                    }
                    catch
                    {

                    }

                    ListIsOrder.ItemsSource = null;
                    ListIsMyOrder.ItemsSource = null;
                    StIsOrder.IsVisible = false;
                    StIsMyOrder.IsVisible = false;
                    //  StActivityIndicator.IsVisible= false;

                    StStatic.IsVisible = true;
                    LabelStatic.Text = AppResource.offlines;

                }
                if (Massege == "3")
                {
                    try
                    {
                        if (IsOrder.Count > 0)
                        {
                            IsOrder.Clear();
                        }

                    }
                    catch
                    {

                    }

                    try
                    {
                        if (IsMyOrder.Count > 0)
                        {
                            IsMyOrder.Clear();
                        }
                    }
                    catch
                    {

                    }


                    ListIsOrder.ItemsSource = null;
                    ListIsMyOrder.ItemsSource = null;
                    StIsOrder.IsVisible = false;
                    StIsMyOrder.IsVisible = false;
                    // StActivityIndicator.IsVisible = false;

                    StStatic.IsVisible = true;
                    LabelStatic.Text = AppResource.Outofservice;

                }
            }

        }
        catch
        {

        }
    }

    public void Toupdate()
    {
        try
        {
            Microsoft.Maui.Controls.Device.StartTimer(TimeSpan.FromSeconds(NumberRun), () =>
            {
                Microsoft.Maui.Controls.Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        var current = Connectivity.NetworkAccess;
                        if (current == NetworkAccess.Internet)
                        {
                            try
                            {
                                var location = await Geolocation.GetLocationAsync();

                                if (location != null)
                                {
                                    ButtLoction.IsVisible = false;
                                    WidthCoordinatesAddresss = location.Longitude.ToString();
                                    LengthCoordinatesAddresss = location.Latitude.ToString();

                                    AddIsOrderNewOld(LengthCoordinatesAddresss, WidthCoordinatesAddresss);

                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (IsOrder.Count > 0)
                                    {
                                        IsOrder.Clear();
                                    }

                                }
                                catch
                                {

                                }
                                try
                                {
                                    if (IsMyOrder.Count > 0)
                                    {
                                        IsMyOrder.Clear();
                                    }

                                }
                                catch
                                {

                                }


                                ListIsOrder.ItemsSource = null;
                                ListIsMyOrder.ItemsSource = null;
                                StIsOrder.IsVisible = false;
                                StIsMyOrder.IsVisible = false;

                                // StActivityIndicator.IsVisible = false;
                                StStatic.IsVisible = true;
                                LabelStatic.Text = AppResource.Pleaseactivate;
                                ButtLoction.IsVisible = true;


                            }
                        }
                        else
                        {
                            await DisplayAlert(AppResource.Notice, AppResource.Networknotavailable, "OK");
                        }
                    }
                    catch
                    {
                        await DisplayAlert(AppResource.Notice, AppResource.Networknotavailable, "OK");
                    }

                });
                return true;
            });
        }
        catch
        {

        }

    }

    private async void Dites_Clicked(object sender, EventArgs e)
    {
        
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();

            int IdOrder = int.Parse(sebzeads);
            try
            {
                try
                {
                    IsOrder.Where(x => x.Id == IdOrder).First().NoteStatusDriver = "false";
                }
                catch
                {

                }
                var client = new HttpClient();
                string strResult = await client.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?IdDrivers=" + Iddriver + "&IdOrders=" + IdOrder + "&StatusDrivers=true");
                int istoggle = JsonConvert.DeserializeObject<int>(strResult);
                if (istoggle == 0)
                {
                    try
                    {
                        IsOrder.Where(x => x.Id == IdOrder).First().NoteStatusDriver = "true";
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        IsOrder.Where(x => x.Id == IdOrder).First().NoteStatusDriver = "false";
                    }
                    catch
                    {

                    }

                }
            }
            catch
            {
                try
                {
                    IsOrder.Where(x => x.Id == IdOrder).First().NoteStatusDriver = "true";
                }
                catch
                {

                }
            }

            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }


        }
        catch (Exception ex)
        {
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }
            await DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }

    }

    private void ShopNewOrder_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        this.ShowPopup(new ViewsPopupNewAdress(Iddriver));

    }

    private async void GoToShop_Clicked(object sender, EventArgs e)
    {
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);

            try
            {
                Order Ordersss = IsMyOrder.Where(x => x.Id == IdOrder).FirstOrDefault();

                if (Ordersss.IdBosh == 43)
                {
                    try
                    {
                        var locations = await Geolocation.GetLocationAsync();

                        double LocationBoshxxxxx = Convert.ToDouble(Ordersss.PostalCode);
                        double LocationBoshyyyyy = Convert.ToDouble(Ordersss.NeighborhoodSubLocality);
                        if (locations != null)
                        {
                            await Launcher.OpenAsync("http://maps.google.com/?daddr=" + LocationBoshxxxxx + "," + LocationBoshyyyyy + "&" + locations.Latitude + "," + locations.Longitude);

                        }
                        else
                        {
                            await Launcher.OpenAsync("http://maps.google.com/?daddr=" + LocationBoshxxxxx + ", " + LocationBoshyyyyy);

                        }

                    }
                    catch
                    {

                    }


                }
                else
                {

                    try
                    {
                        var locations = await Geolocation.GetLocationAsync();
                        var clienv = new HttpClient();
                        string strResuv = await clienv.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?idshopLocation=" + Ordersss.IdBosh);
                        List<string> ListLocation = JsonConvert.DeserializeObject<List<string>>(strResuv);


                        double LocationBoshxxxxx = Convert.ToDouble(ListLocation[0]);
                        double LocationBoshyyyyy = Convert.ToDouble(ListLocation[1]);


                        if (locations != null)
                        {
                            await Launcher.OpenAsync("http://maps.google.com/?daddr=" + LocationBoshxxxxx + "," + LocationBoshyyyyy + "&" + locations.Latitude + "," + locations.Longitude);

                        }
                        else
                        {
                            await Launcher.OpenAsync("http://maps.google.com/?daddr=" + LocationBoshxxxxx + ", " + LocationBoshyyyyy);

                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }
        }
        catch (Exception ex)
        {
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }
            await DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }


    }

    private async void IreceivedtheOrder_Clicked(object sender, EventArgs e)
    {
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);

            try
            {
                try
                {
                    IsMyOrder.Where(x => x.Id == IdOrder).First().DateAccsptReadyBosh = "false";
                }
                catch
                {

                }
                var client = new HttpClient();
                string strResult = await client.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?IdOrdersreceived=" + IdOrder);
                int istoggle = JsonConvert.DeserializeObject<int>(strResult);

                if (istoggle == 0)
                {
                    try
                    {
                        IsMyOrder.Where(x => x.Id == IdOrder).First().DateAccsptReadyBosh = "true";
                    }
                    catch
                    {

                    }
                }
                else

                {
                    try
                    {
                        IsMyOrder.Where(x => x.Id == IdOrder).First().DateAccsptReadyBosh = "false";
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {
                try
                {
                    IsMyOrder.Where(x => x.Id == IdOrder).First().DateAccsptReadyBosh = "true";
                }
                catch
                {

                }

            }


            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }

        }
        catch (Exception ex)
        {
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }

            await DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }


    }
    private void IssuinganInvoice_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);

         
            this.ShowPopup(new ViewsPopupBill(IdOrder));


        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }

    }

    private void Bill_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);
            Order Ordersss = IsMyOrder.Where(x => x.Id == IdOrder).FirstOrDefault();

             
            this.ShowPopup(new ViewsPopupShowBill(Ordersss.NoteYESORNODriver, Ordersss.Note));


        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }

    }


    private void complaintl_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);

            string numberDriver = "05";
            string maneDriver = "Ali";
            try
            {
                var dddd = DatabaseAcss.SelectDriver<Driver>(MyDatabaseFile);

                if (dddd.Count > 0)
                {
                    Iddriver = dddd[0].Id;
                    try
                    {
                        numberDriver = dddd[0].NumberDriver;
                        maneDriver = dddd[0].NameDriver;
                    }
                    catch
                    {

                    }
                    
                }
                else
                {

                }

            }
            catch
            {

            }


           
            this.ShowPopup(new ViewsPopupComplaint(IdOrder, Iddriver, numberDriver, maneDriver));


        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }

    }


    private void interpayorder_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);

            
            try
            {
                IsMyOrder.Where(x => x.Id == IdOrder).First().IdcahckWallts = "false";
            }
            catch
            {

            }

            Idorderintpay = IdOrder;

            Order Ordersss = IsMyOrder.Where(x => x.Id == Idorderintpay).FirstOrDefault();
            if (Ordersss != null)
            {
                if (Ordersss.Cash == "true")
                {
                    if (Ordersss.PostalCode == "storedone" && Ordersss.NoteBosh == "nonofa" || Ordersss.PostalCode == "storedone" && Ordersss.NoteBosh == "nono")
                    {
                         
                        if (Ordersss.StatusBosh == "true" && Ordersss.StatusDriver == "true" && Ordersss.NoteBosh == "nonofa" && Ordersss.ReceivedDriver == "true" || Ordersss.StatusBosh == "true" && Ordersss.StatusDriver == "true" && Ordersss.NoteBosh == "nono" && Ordersss.ReceivedDriver == "true")
                        { 
                            if (Ordersss.NoteBosh == "nono")
                            {
                                  
                                    double billprice = 0;
                                decimal billpricedone = 0;

                                try
                                {
                                    billprice = double.Parse(Ordersss.NotCancelOrder);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    billpricedone = decimal.Parse(Ordersss.DateAccsptReadyBosh);
                                }
                                catch
                                {

                                }

                                double TotalPrices = 0;


                                try
                                {
                                    TotalPrices = double.Parse(Ordersss.TotalPrice);
                                }
                                catch
                                {

                                }
                                if (TotalPrices > billprice)
                                {
                                  //  Ordersss.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.deliveryfees;

                                }
                                else if (TotalPrices < billprice)
                                {


                                    priceintpay = billpricedone.ToString();

 

                                    decimal transactionAmount = billpricedone;
                                    DependencyService.Get<IInterpay>().StartTransaction(transactionAmount);

                                   // Ordersss.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.Receivemoney + Ordersss.DateAccsptReadyBosh + " " + AppResource.SAR + AppResource.onlyss;

                                }
                                else if (TotalPrices == billprice)
                                {
                                 //   Ordersss.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.deliveryfees;

                                }



                            }
                            else if (Ordersss.NoteBosh == "nonofa")
                            {
                                decimal billprice = 0;


                                try
                                {
                                    billprice = decimal.Parse(Ordersss.DateAccsptReadyBosh);
                                }
                                catch
                                {

                                }
                                
                               // Ordersss.TimeAccsptBosh = AppResource.Aninvoicehasbeenissued + billprice.ToString() + " " + AppResource.SAR + AppResource.Receivemoney + Ordersss.DateAccsptReadyBosh + " " + AppResource.SAR + AppResource.onlyss;
                                
                                priceintpay = billprice.ToString();
                                decimal transactionAmount = billprice;
                                DependencyService.Get<IInterpay>().StartTransaction(transactionAmount);
                            }


                        }
                    }
                    else
                    {

                        if (Ordersss.IdBosh == 43)
                        {

                            decimal driverpricer = 0;
                            decimal billpricer = 0;
                            decimal waltepricer = 0;
                            decimal copenpricen = 0;
                            decimal totelpricer = 0;
                            decimal totelpricerall = 0;
                            try
                            {
                                driverpricer = decimal.Parse(Ordersss.DeliveryPrice);

                            }
                            catch
                            {

                            }
                            try
                            {
                                waltepricer = decimal.Parse(Ordersss.PricePshWallts);

                            }
                            catch
                            {

                            }
                            try
                            {
                                billpricer = decimal.Parse(Ordersss.TotalPrice);

                            }
                            catch
                            {

                            }
                            try
                            {
                                copenpricen = decimal.Parse(Ordersss.CobenPrice);

                            }
                            catch
                            {

                            }
                            try
                            {
                                totelpricer = driverpricer + billpricer;

                            }
                            catch
                            {

                            }
                            try
                            {
                                totelpricerall = totelpricer - copenpricen - waltepricer;

                            }
                            catch
                            {

                            }

                            priceintpay = totelpricerall.ToString();
                            decimal transactionAmount = totelpricerall;
                            DependencyService.Get<IInterpay>().StartTransaction(transactionAmount);


                        }
                        else
                        {
                            decimal driverpricer = 0;
                            decimal billpricer = 0;
                            decimal waltepricer = 0;
                            decimal copenpricen = 0;
                            decimal totelpricer = 0;


                            //رسوم الخدمة
                            decimal Servicefees = 0;
                            try
                            {
                                Servicefees = decimal.Parse(Ordersss.NeighborhoodSubLocality);

                            }
                            catch
                            {


                            }


                            decimal totelpricerall = 0;
                            try
                            {
                                driverpricer = decimal.Parse(Ordersss.DeliveryPrice);

                            }
                            catch
                            {

                            }
                            try
                            {
                                waltepricer = decimal.Parse(Ordersss.PricePshWallts);

                            }
                            catch
                            {

                            }
                            try
                            {
                                billpricer = decimal.Parse(Ordersss.TotalPrice);

                            }
                            catch
                            {

                            }
                            try
                            {
                                copenpricen = decimal.Parse(Ordersss.CobenPrice);

                            }
                            catch
                            {

                            }
                            try
                            {
                                totelpricer = driverpricer + billpricer + Servicefees;

                            }
                            catch
                            {

                            }
                            try
                            {
                                totelpricerall = totelpricer - copenpricen - waltepricer;

                            }
                            catch
                            {

                            }

                            priceintpay = totelpricerall.ToString();
                            decimal transactionAmount = totelpricerall;
                            DependencyService.Get<IInterpay>().StartTransaction(transactionAmount);
                        }



                    }
                }

                

            }



        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }

    }


    private async void GoTotheClient_Clicked(object sender, EventArgs e)
    {
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);
            try
            {
                Order Ordersss = IsMyOrder.Where(x => x.Id == IdOrder).FirstOrDefault();
                double LocationBoshxxxxxx = Convert.ToDouble(Ordersss.LocalYY);
                double LocationBoshyyyyyx = Convert.ToDouble(Ordersss.LocalXX);

                var locations = await Geolocation.GetLocationAsync();
                if (locations != null)
                {
                    await Launcher.OpenAsync("http://maps.google.com/?daddr=" + LocationBoshxxxxxx + "," + LocationBoshyyyyyx + "&" + locations.Latitude + "," + locations.Longitude);

                }
                else
                {
                    if (DeviceInfo.Platform == DevicePlatform.iOS)
                    {
                        await Launcher.OpenAsync("http://maps.google.com/?daddr=" + LocationBoshxxxxxx + ", " + LocationBoshyyyyyx);

                    }
                    else if (DeviceInfo.Platform == DevicePlatform.Android)
                    {
                        await Launcher.OpenAsync("http://maps.google.com/?daddr=" + LocationBoshxxxxxx + "," + LocationBoshyyyyyx);
                    }
                    else if (DeviceInfo.Platform == DevicePlatform.UWP)
                    {

                        //  await Launcher.OpenAsync("bingmaps:?rtp=adr.394 Pacific Ave San Francisco CA~adr.One Microsoft Way Redmond WA 98052");
                    }

                }


            }
            catch
            {

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }
    }


    private async void SendWhatsapp(string phoneNumber, string message)
    {
        bool supportsUri = await Launcher.Default.CanOpenAsync($"whatsapp://send?phone=+{phoneNumber}&text={message}");
        if (supportsUri)
            await Launcher.Default.OpenAsync($"whatsapp://send?phone=+{phoneNumber}&text={message}");

        else
            await App.Current.MainPage.DisplayAlert("خطاء", "غير قادر على فتح الواتساب.", "OK");

    }

    private async void ChatWiththeCustomer_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);
            Order Ordersss = IsMyOrder.Where(x => x.Id == IdOrder).FirstOrDefault();


            //try
            //{
            //    var client = new HttpClient();
            //    string strResult = await client.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?IdIdCustomers=" + Ordersss.IdCustomer);
            //    string istoggle = JsonConvert.DeserializeObject<string>(strResult);

            //    if (istoggle != "0")
            //    {
            //        bool answer = await DisplayAlert(AppResource.Notice, AppResource.Selectthemethod, AppResource.directconnection, AppResource.viawhatsapp);
            //        if (answer == true)
            //        {
            //            try
            //            {
            //                PhoneDialer.Open(istoggle);
            //            }
            //            catch
            //            {
            //            }
                         

            //        }
            //        if (answer == false)
            //        {
            //            try
            //            {
            //                string uriString = "966" + istoggle;
            //                string message = AppResource.slmmm;
                             
            //                try
            //                {  
            //                    string sd = istoggle.Substring(1);
            //                    string number = "966" + sd;
            //                    SendWhatsapp(number, " السلام عليكم - رقم الطلب هو " + Ordersss.Id.ToString() + "- طلبك من متجر  - " + Ordersss.SubThoroughfare);
            //                }
            //                catch
            //                {
            //                    await DisplayAlert(AppResource.Notice, AppResource.WhatsappNotInstalled, "ok");
            //                }

            //            }
            //            catch
            //            {
            //                await DisplayAlert(AppResource.Notice, AppResource.WhatsappNotInstalled, "ok");


            //            }
            //        }
            //    }
            //    else
            //    {

                    try
                    {
                        var audioManager = this.Handler?.MauiContext?.Services?.GetRequiredService<IAudioManager>();
                        if (audioManager == null)
                        {
                            await DisplayAlert("خطأ", "لم يتم العثور على خدمة الصوت.", "موافق");
                            return;
                        }

                        await Navigation.PushAsync(new ChatListPage(audioManager, Ordersss.Id.ToString(), Ordersss.IdCustomer.ToString(), "", Ordersss.IDDriver.ToString(), "Driverdata.TypeDriver", "Driverdata.NumberDriver"));
                    }
                    catch
                    {
                        await DisplayAlert("خطأ", "تعذر فتح صفحة الدردشة.", "موافق");
                    }






                    //    await Navigation.PushAsync(new ChatPage(Ordersss.Id, userRole.Value));

               // }
            //}
            //catch
            //{

            //}


           


        }
        catch (Exception ex)
        {
            await DisplayAlert(AppResource.Notice, ex.Message, "ok");

        }


    }

    private async void CustomerSiteReached_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int idCustom = int.Parse(sebzeads);

            try
            {
                var client = new HttpClient();
                string strResult = await client.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?idCustomers=" + idCustom);
                int istoggle = JsonConvert.DeserializeObject<int>(strResult);

            }
            catch (Exception ex)
            {
                await DisplayAlert(AppResource.Notice, ex.Message, "ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert(AppResource.Notice, ex.Message, "ok");

        }


    }

    private async void YesOrder_Clicked(object sender, EventArgs e)
    {
        
        try
        {
            Border btns = (Border)sender;

            TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
            var sebzeads = tapGesture.CommandParameter.ToString();
            int IdOrder = int.Parse(sebzeads);

            try
            {
                try
                {
                    IsMyOrder.Where(x => x.Id == IdOrder).First().FreeDriveriv = "false";
                }
                catch
                {

                }
                 
                var client = new HttpClient();
                string strResult = await client.GetStringAsync("https://www.doneksa.com/api/ApiGetDrivers?IdOrdersYesOrder=" + IdOrder);
                int istoggle = JsonConvert.DeserializeObject<int>(strResult);

                if (istoggle == 0)
                {
                    try
                    {
                        IsMyOrder.Where(x => x.Id == IdOrder).First().FreeDriveriv = "true";
                    }
                    catch
                    {

                    }
                }
                else
                    {
                        try
                        {
                            IsMyOrder.Where(x => x.Id == IdOrder).First().FreeDriveriv = "false";
                    }
                    catch
                    {

                    }

                }
            }
            catch
            {
                try
                {
                    IsMyOrder.Where(x => x.Id == IdOrder).First().FreeDriveriv = "true";
                }
                catch
                {

                }
            }
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }
        }
        catch (Exception ex)
        {
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }
            await DisplayAlert(AppResource.Notice, ex.Message, "ok");

        }
    }

    private void Connecteds_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        pickerIsToggled = 1;
        Connecteds.BackgroundColor = Color.FromHex("#7CD185");
        Notconnected.BackgroundColor = Color.FromHex("#DCDBDB");
    }

    private void Notconnected_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        pickerIsToggled = 2;
        Connecteds.BackgroundColor = Color.FromHex("#DCDBDB");
        Notconnected.BackgroundColor = Color.FromHex("#D17C7C");

    }
    private async void PushBillOrder_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }
        try
        { 
            
                Border btns = (Border)sender;

                TapGestureRecognizer tapGesture = (TapGestureRecognizer)btns.GestureRecognizers[0];
                var sebzeads = tapGesture.CommandParameter.ToString();
                int IdOrder = int.Parse(sebzeads);
             

                string numberDriver = "05";
                string maneDriver = "Ali";
                try
                {
                    var dddd = DatabaseAcss.SelectDriver<Driver>(MyDatabaseFile);

                    if (dddd.Count > 0)
                    {
                        Iddriver = dddd[0].Id;
                        try
                        {
                            numberDriver = dddd[0].NumberDriver;
                            maneDriver = dddd[0].NameDriver;
                        }
                        catch
                        {

                        }
                       
                    }
                    else
                    {

                    }

                }
                catch
                {

                }

           

            this.ShowPopup(new ViewsPopupBillPush(IdOrder, Iddriver, numberDriver, maneDriver));

             
        }
        catch (Exception ex)
        {
            try
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            }
            catch
            {

            }

            await DisplayAlert("Error", ex.Message.ToString(), "Ok");
        }


    }
    private void ButtLoction_Clicked(object sender, EventArgs e)
    {
        try
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        }
        catch
        {

        }

#if ANDROID
        try
        {
            LocationManager locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);

            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false) ;
            {
                Intent intent = new Intent(Android.Provider.Settings.ActionLocat‌​ionSourceSettings);
                intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

                try
                {
                    Android.App.Application.Context.StartActivity(intent);

                }
                catch (ActivityNotFoundException activityNotFoundException)
                {
                    System.Diagnostics.Debug.WriteLine(activityNotFoundException.Message);
                    Android.Widget.Toast.MakeText(Android.App.Application.Context, "Error: Gps Activity", Android.Widget.ToastLength.Short).Show();
                }
            }
        }
        catch
        {

        }



#endif

#if IOS
try
{ if (CLLocationManager.Status == CLAuthorizationStatus.Denied)
        {
            var WiFiURL = new NSUrl("prefs:root=WIFI");

            if (UIApplication.SharedApplication.CanOpenUrl(WiFiURL))
            {   //> Pre iOS 10
                UIApplication.SharedApplication.OpenUrl(WiFiURL);
            }
            else
            {   //> iOS 10
                UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=WIFI"));
            }
        }
}
catch 
{ 
}   
       

       
#endif


        //bool IsGpsEnable = DependencyService.Get<IGpsDependencyService>().IsGpsEnable();

        //if (!IsGpsEnable)
        //{
        //    DependencyService.Get<IGpsDependencyService>().OpenSettings();
        //}
    }


}