using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

using MyFast.Controllers;
using MyFast.DAL;
using MyFast.Migrations;
using MyFast.Models;
using MyFast.Wrappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyFast.AdminShops
{
    public partial class OrdersTow : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["ANUser"] != null)
                {


                    string string_to_search = "the cat jumped onto the table";
                    string string_to_find = "jumped onto";

                    var fdf = string_to_search.ToLower().Contains(string_to_find.ToLower());


                    string name = Session["ANUser"].ToString();
                    UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
                    if (UserRoleDonesc != null)
                    {

                        if (UserRoleDonesc.ADDData == "0")
                        {
                            // Button1Save.Visible = false;
                            // ButtonAccountsCompnyShop.Visible = false;


                        }
                        if (UserRoleDonesc.EditData == "0")
                        {

                        }
                        else
                        {

                        }
                        if (UserRoleDonesc.SecetcData == "1")
                        {
                            List<Order> blogs = DataAccess.Instance.GetOrders1();

                            MultiView1.ActiveViewIndex = 0;



                            ListView1.DataSource = blogs;
                            ListView1.DataBind();

                        }
                        else
                        {
                            Response.Redirect("/AdminShops/Admin", false);
                        }

                        if (UserRoleDonesc.DeledtData == "0")
                        {


                        }


                    }
                    else
                    {
                        Response.Redirect("/AdminShops/Admin", false);
                    }


                }
                else
                {

                    Response.Redirect("/AdminShops/AL", false);
                }
            }
        }





        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int INN = int.Parse(e.CommandName);

            try
            {

                CustomerData CustomerDatasss = DataAccess.Instance.GetCustomerData(INN);

                name.Text = CustomerDatasss.NameUser;
                Number.Text = CustomerDatasss.NumberPhoneUser;
                Label49.Text = CustomerDatasss.Id.ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModal", "$('#logoutModal').modal()", true);


            }
            catch
            {

            }
        }

        protected void Button2_Command(object sender, CommandEventArgs e)
        {
            int INN = int.Parse(e.CommandName);

            Models.Driver Driverss = DataAccess.Instance.GetDriverscccc(INN);

            try
            {

                if (!String.IsNullOrEmpty(Driverss.WidthCoordinatesAddress))
                {
                    Labelssxx.Text = Driverss.WidthCoordinatesAddress;
                    Labelssyy.Text = Driverss.LengthCoordinatesAddress;
                    name.Text = Driverss.NameDriver;
                    Number.Text = Driverss.NumberDriver;
                    Label49.Text = Driverss.Id.ToString();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModal", "$('#logoutModal').modal()", true);
                }
            }
            catch
            {

            }
        }

        protected void Button3_Command(object sender, CommandEventArgs e)
        {
            int INN = int.Parse(e.CommandName);

            List<UserShopBoshServic> Billsccc = DataAccess.Instance.GetUserShopBoshServics(INN);



            try
            {


                ListView9.DataSource = Billsccc;
                ListView9.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalWastp", "$('#logoutModalWastp').modal()", true);

            }
            catch
            {

            }
        }

        protected void Button4_Command(object sender, CommandEventArgs e)
        {

            try
            {
                try
                {
                    string illlls = e.CommandName;
                    string lastCharacter = illlls.Substring(illlls.Length - 1);

                    string result = "";
                    if (lastCharacter == ".")
                    {
                        result = illlls.Remove(illlls.Length - 1);

                    }
                    else
                    {
                        result = illlls;
                    }



                    string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                    XmlDocument xmltest = new XmlDocument();
                    xmltest.LoadXml(resultd);

                    XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");

                    List<BillllsccArEn> BillllsccArEnc = new List<BillllsccArEn>();






                    foreach (XmlNode xn in xnList)
                    {
                        BillllsccArEn billllsccAr = new BillllsccArEn();
                        billllsccAr.Cost = "X" + " " + xn["Cost"].InnerText;



                        billllsccAr.sproar = xn["sproar"].InnerText;
                        billllsccAr.sproen = xn["sproen"].InnerText;
                        billllsccAr.spakerar = xn["spakerar"].InnerText;
                        billllsccAr.spakeren = xn["spakeren"].InnerText;
                        billllsccAr.spric = xn["spric"].InnerText + " " + "ريال";



                        if (xn["stAdd"].InnerText == ",-,,,")
                        {
                            billllsccAr.stAdd = "";

                        }
                        else
                        {
                            billllsccAr.stAdd = xn["stAdd"].InnerText;

                        }






                        BillllsccArEnc.Add(billllsccAr);

                    }

                    MyBill.DataSource = BillllsccArEnc;
                    MyBill.DataBind();



                }
                catch (Exception ex)
                {


                }



                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalBill", "$('#logoutModalBill').modal()", true);


            }
            catch
            {

            }







        }

        protected void Button5_Command(object sender, CommandEventArgs e)
        {
            int INN = int.Parse(e.CommandName);

            try
            {

                Models.Driver Driverssss = DataAccess.Instance.GetDriverscccc(INN);

                string url = "https://www.google.com.sa/maps/place/" + Driverssss.LengthCoordinatesAddress + "," + Driverssss.WidthCoordinatesAddress;
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "window.open('" + url + "');", true);



            }
            catch
            {

            }
        }


        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);



            List<Order> blogs = DataAccess.Instance.GetOrders1();



            MultiView1.ActiveViewIndex = 0;

            ListView1.DataSource = blogs;
            ListView1.DataBind();
        }

















        //public void PutOrderSSSS(int id, Order order)
        //{
        //    order.DateAccsptReadyBosh = DateTime.Now.ToString("yyyy:MM:dd");

        //    if (order.ReadyBosh == "new")
        //    {

        //        order.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");
        //    }
        //    else
        //    {

        //        order.TimeAccsptReadyBosh = DateTime.Now.ToString("HH:mm");

        //    }

        //    dbContexts.Entry(order).State = EntityState.Modified;

        //    dbContexts.SaveChanges();



        //    try
        //    {
        //        int IdCousrtmer = order.IdCustomer;
        //        CustomerData CCCustomerData = dbContexts.CustomerDatas.Find(order.IdCustomer);

        //        if (order.StatusBosh == "true" )
        //        {
        //            Task.Run(() =>
        //            {
        //                SendNotification("", CCCustomerData.FirebaseToken, "رسالة", " تم قبول المتجر وسيتم تجهيز طلبك", "");
        //            });

        //        }
        //        else
        //        {
        //            if (order.StatusBosh == "false")
        //            { 
        //                    if (order.PaymentStatus == "true")
        //                     {
        //                    Task.Run(() =>
        //                    {
        //                        SendNotification("", CCCustomerData.FirebaseToken, "رسالة", " عميلنا العزيز نعتذر لعدم  قبول المتجر لطلبية - وسوف يتم أسترجاع اموالك خلال 24 ساعة القادمة ", "");

        //                    });

        //                string Messgss = "عميلنا العزيز نعتذر لعدم قبول المتجر لطلبية رقم " + order.Id.ToString() + "لذا سوف يتم أسترجاع اموالك خلال 24 ساعة القادمة";

        //                          //  MakeWebAPICall(CCCustomerData.Id, Messgss);




        //                            if (order.Cash == "true")
        //                            {
        //                        Task.Run(() =>
        //                        {
        //                            SendNotification("", CCCustomerData.FirebaseToken, "رسالة", " عميلنا العزيز نعتذر لعدم  قبول المتجر لطلبية - وسوف يتم أسترجاع اموالك الى محفظتك ", "");
        //                        });


        //                        string WhayBack = "عملية أسترداد اموال وذلك بسبب عدم قبول المتجر لطلبية رقم " + order.Id.ToString();

        //                                BackManyTowalat(CCCustomerData.Id, order.PricePshWallts, WhayBack);


        //                                string Messgd = "عميلنا العزيز نعتذر لعدم قبول المتجر لطلبية رقم " + order.Id.ToString() + "وتم ارجاع اموالك الى محفظتك";

        //                            //    MakeWebAPICall(CCCustomerData.Id, Messgd);

        //                            }


        //                        }
        //                        else
        //                        {



        //                            if (order.cahckWallts == "true")
        //                            {
        //                        Task.Run(() =>
        //                        {
        //                            SendNotification("", CCCustomerData.FirebaseToken, "رسالة", " عميلنا العزيز نعتذر لعدم  قبول المتجر لطلبية - وسوف يتم أسترجاع اموالك الى محفظتك ", "");
        //                        });

        //                        string WhayBack = "عملية أسترداد اموال وذلك بسبب عدم قبول المتجر لطلبية رقم " + order.Id.ToString();

        //                                BackManyTowalat(CCCustomerData.Id, order.PricePshWallts, WhayBack);


        //                                string Messgd = "عميلنا العزيز نعتذر لعدم قبول المتجر لطلبية رقم " + order.Id.ToString() + "وتم ارجاع اموالك الى محفظتك";

        //                              //  MakeWebAPICall(CCCustomerData.Id, Messgd);

        //                            }

        //                    Task.Run(() =>
        //                    {
        //                        SendNotification("", CCCustomerData.FirebaseToken, "رسالة", " عميلنا العزيز نعتذر لعدم  قبول المتجر لطلبية ", "");

        //                    });
        //                }









        //            }


        //        }


        //    }
        //    catch 
        //    {

        //    }


        //    try
        //    {
        //        GetDriverSendNofcationssss(order.IDDriver);
        //    }
        //    catch
        //    {

        //    }


        //    if (order.ReadyBosh == "ready")
        //    {
        //        try
        //        {
        //            AddAcount(order);

        //        }
        //        catch
        //        {


        //        }

        //    }
        //    else
        //    {



        //    }











        //}



        public void MakeWebAPICall(int idcustomer, string messages)
        {
            string numberss = "";

            //   sd = dbContexts.CustomerDatas.OrderBy(x => x.Id).ToList();



            //CustomerData UserShopBoss = (from b in dbContexts.CustomerDatas

            //                    where b.Id == idcustomer

            //                    select b).FirstOrDefault();
            CustomerData UserShopBoss = DataAccess.Instance.GetCustomerData(idcustomer); //db.Drivers.Find(itemOrderlist.IDDriver);

            numberss = UserShopBoss.NumberPhoneUser;




            //HttpClient client = new HttpClient();

            //string dates = DateTime.Now.ToString("yyyy-MM-dd"); ;

            //string times = DateTime.Now.ToString("HH:mm");
            //string senders = "Done ksa";

            //string num = "966" + numberss.Substring(1);

            //client.GetStringAsync("https://www.hisms.ws/api.php?send_sms&username=966542100091&password=Qaqa1212@!&numbers=" + num + "&sender=" + senders + "&message=" + " " + messages + "&date=" + dates + "&time=" + times);


            string num = "966" + numberss.Substring(1);

            DataAccess.Instance.Send4jawaly(num, messages);
        }

        public void BackManyTowalat(int Idcustomer, string TextBox2Mony, string TextBox2NotSO, int idOrders)
        {
            int IdDriver = Idcustomer;
            Wallet WalletSS = new Wallet();
            WalletSS.IdCUstomerWallet = IdDriver;
            WalletSS.IdOrderWallet = idOrders;
            double AccountsCompnyxx = Convert.ToDouble(TextBox2Mony);
            WalletSS.AddPricToWallet = AccountsCompnyxx;
            WalletSS.DiscountPricFormWallet = 0;
            WalletSS.NoteWallet = TextBox2NotSO;
            WalletSS.NoteWalletTow = DateTime.Now.ToString("yyyy:MM:dd") + " " + DateTime.Now.ToString("HH:mm");


            SqlParameter[] sqlpr = new SqlParameter[6];
            sqlpr[0] = new SqlParameter("@IdCUstomerWallets", WalletSS.IdCUstomerWallet);
            sqlpr[1] = new SqlParameter("@IdOrderWallets", WalletSS.IdOrderWallet);
            sqlpr[2] = new SqlParameter("@AddPricToWallets", WalletSS.AddPricToWallet);
            sqlpr[3] = new SqlParameter("@DiscountPricFormWallets", WalletSS.DiscountPricFormWallet);
            sqlpr[4] = new SqlParameter("@NoteWallets", WalletSS.NoteWallet);
            sqlpr[5] = new SqlParameter("@NoteWalletTows", WalletSS.NoteWalletTow);
            int i = ExecuteNonQuerynews(CommandType.StoredProcedure, "sp_AddtoWallet", sqlpr);


            //dbContexts.Wallets.Add(WalletSS);
            //dbContexts.SaveChanges();

        }







        //20234new
        public int ExecuteNonQuerynews(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //  var con = new SqlConnection(dbContexts.Database.Connection.ConnectionString);
            // SqlConnection con = (SqlConnection)db.Database.Connection;
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);



            int response = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = commandType;
                if (commandType == CommandType.StoredProcedure)
                {
                    if (commandParameters != null)
                    {
                        foreach (SqlParameter sqlPara in commandParameters)
                        {
                            if (sqlPara != null)
                            {
                                if (sqlPara.Direction == ParameterDirection.Output)
                                {
                                    cmd.Parameters.Add(sqlPara);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(sqlPara.ParameterName, sqlPara.SqlValue);
                                }
                            }
                        }
                    }
                }
                con.Open();
                response = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return response;
        }




        //public void AddAcount(Order Ordersd)

        //{
        //    bool Chaing = true;
        //    try
        //    {
        //        ShopAccount obj = dbContexts.ShopAccounts.Where(a => a.IdOrderShop.Equals(Ordersd.Id)).FirstOrDefault();

        //        if (obj.Id > 0)
        //        {
        //            Chaing = false;

        //        }

        //    }
        //    catch
        //    {
        //        Chaing = true;

        //    }

        //    if (Chaing == true)
        //    {

        //        ShopAccount driverAccounts = new ShopAccount();



        //        if (Ordersd.Cash == "true")
        //        {
        //            driverAccounts.IdShop = Ordersd.IdBosh;
        //            driverAccounts.IdOrderShop = Ordersd.Id;


        //            if (Ordersd.CobenNumber != "0")
        //            {
        //                //  [Display(Name = "مبلغ الخصم من الكوبون")]
        //                driverAccounts.PricCobon = Ordersd.CobenPrice;

        //                //  [Display(Name = "رقم الكوبون")]
        //                driverAccounts.NumberCobon = Ordersd.CobenNumber;




        //            }
        //            else
        //            {//  [Display(Name = "رقم الكوبون")]
        //                driverAccounts.NumberCobon = "لا يوجد";
        //                driverAccounts.PricCobon = "0";

        //            }

        //            driverAccounts.NotesShop = "تم أضافة عملية دفع عند الاستلام ولقد استلمت المبلغ من السائق";

        //            if (Ordersd.FreeDriveriv == "true")
        //            {
        //                driverAccounts.PricBill = Ordersd.TotalPrice;

        //                // [Display(Name = "هل التوصيل مجاني")]
        //                driverAccounts.NoteBill = "التوصيل مجاني";
        //                // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
        //                driverAccounts.PricFree = Ordersd.PricepackagAfter.ToString();
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    //  [Display(Name = "مبلغ الفاتورة")]

        //                    double PricToT = double.Parse(Ordersd.TotalPrice) - double.Parse(Ordersd.PricepackagAfter);

        //                    driverAccounts.PricBill = PricToT.ToString();

        //                }
        //                catch
        //                {

        //                    driverAccounts.PricBill = Ordersd.TotalPrice;
        //                }




        //                // [Display(Name = "هل التوصيل مجاني")]
        //                driverAccounts.NoteBill = "التوصيل غير مجاني";
        //                // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
        //                driverAccounts.PricFree = "0";

        //            }




        //            driverAccounts.TrueOrfalseIdOrdersShop = "true";
        //            driverAccounts.TrueOrfalseMonysShop = "true";

        //            driverAccounts.NoteThreeShop = "ic_action_monetization_on.png";

        //            // [Display(Name = "خذ من السائق ")

        //            double MonyTotalCostmerShopss = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);
        //            driverAccounts.MonyTotalCostmerShop = MonyTotalCostmerShopss;







        //            PercentageShop PercentageShopss = new PercentageShop();

        //            List<PercentageShop> fdsc = dbContexts.PercentageShops.OrderBy(x => x.Id).ToList();

        //            foreach (PercentageShop item in fdsc)
        //            {
        //                PercentageShopss = item;

        //            }


        //            UserShopBoshesArEn UserShopBoshscc = new UserShopBoshesArEn();

        //            UserShopBoshscc = DataAccess.Instance.GetBoshOffse(Ordersd.IdBosh);


        //            if (UserShopBoshscc.Percentage > 0)
        //            {
        //                double pricBosh = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);

        //                double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;
        //                driverAccounts.MonyShopShop = pricBosh - pricBoshAfterDescount;

        //                driverAccounts.MonyCompenyShop = pricBoshAfterDescount;

        //                double pricTAX = 0;
        //                double TAXs = 0;
        //                try
        //                {
        //                    driverAccounts.NoteFourShop = pricBoshAfterDescount.ToString();
        //                     pricTAX = pricBoshAfterDescount / 100;
        //                     TAXs = pricTAX * 15;
        //                    driverAccounts.NoteSexShop = TAXs.ToString();
        //                }
        //                catch
        //                {

        //                }



        //                driverAccounts.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
        //                driverAccounts.TimesShop = DateTime.Now.ToString("HH:mm");


        //                driverAccounts.IdPricepackagShop = 0;
        //                driverAccounts.IdPriceShop = pricBoshAfterDescount+ TAXs;
        //                driverAccounts.AccountsCompnyShop = 0;
        //                driverAccounts.DesAccountsCompnyShop = 0;



        //            }
        //            else
        //            {
        //                double pricBosh = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);



        //                double pricBoshAfterDescount = PercentageShopss.CountPercentageShop * pricBosh / 100;
        //                driverAccounts.MonyShopShop = pricBosh - pricBoshAfterDescount;



        //                driverAccounts.MonyCompenyShop = pricBoshAfterDescount;

        //                double pricTAX = 0;
        //                double TAXs = 0;
        //                try
        //                {
        //                    driverAccounts.NoteFourShop = pricBoshAfterDescount.ToString();
        //                    pricTAX = pricBoshAfterDescount / 100;
        //                    TAXs = pricTAX * 15;
        //                    driverAccounts.NoteSexShop = TAXs.ToString();
        //                }
        //                catch
        //                {

        //                }

        //                driverAccounts.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
        //                driverAccounts.TimesShop = DateTime.Now.ToString("HH:mm");
        //                driverAccounts.IdPricepackagShop = 0;
        //                driverAccounts.IdPriceShop = pricBoshAfterDescount+ TAXs;
        //                driverAccounts.AccountsCompnyShop = 0;
        //                driverAccounts.DesAccountsCompnyShop = 0;


        //            }









        //        }

        //        else
        //        {
        //            driverAccounts.IdShop = Ordersd.IdBosh;
        //            driverAccounts.IdOrderShop = Ordersd.Id;



        //            try
        //            {



        //                //  [Display(Name = "مبلغ الفاتورة")]

        //                double PricToT = double.Parse(Ordersd.TotalPrice) - double.Parse(Ordersd.PricepackagAfter);

        //                driverAccounts.PricBill = PricToT.ToString();

        //            }
        //            catch
        //            {

        //                driverAccounts.PricBill = Ordersd.TotalPrice;
        //            }






        //            if (Ordersd.CobenNumber != "0")
        //            {
        //                //  [Display(Name = "مبلغ الخصم من الكوبون")]
        //                driverAccounts.PricCobon = Ordersd.CobenPrice;

        //                //  [Display(Name = "رقم الكوبون")]
        //                driverAccounts.NumberCobon = Ordersd.CobenNumber;




        //            }
        //            else
        //            {//  [Display(Name = "رقم الكوبون")]
        //                driverAccounts.NumberCobon = "لا يوجد";
        //                driverAccounts.PricCobon = "0";

        //            }





        //            driverAccounts.NotesShop = "تم أضافة عملية دفع الكترونية ";



        //            if (Ordersd.FreeDriveriv == "true")
        //            {



        //                driverAccounts.PricBill = Ordersd.TotalPrice;





        //                // [Display(Name = "هل التوصيل مجاني")]
        //                driverAccounts.NoteBill = "التوصيل مجاني";
        //                // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
        //                driverAccounts.PricFree = Ordersd.PricepackagAfter.ToString();

        //            }
        //            else
        //            {

        //                try
        //                {



        //                    //  [Display(Name = "مبلغ الفاتورة")]

        //                    double PricToT = double.Parse(Ordersd.TotalPrice) - double.Parse(Ordersd.PricepackagAfter);

        //                    driverAccounts.PricBill = PricToT.ToString();

        //                }
        //                catch
        //                {

        //                    driverAccounts.PricBill = Ordersd.TotalPrice;
        //                }


        //                // [Display(Name = "هل التوصيل مجاني")]
        //                driverAccounts.NoteBill = "التوصيل غير مجاني";
        //                // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
        //                driverAccounts.PricFree = "0";

        //            }









        //            driverAccounts.TrueOrfalseIdOrdersShop = "true";
        //            driverAccounts.TrueOrfalseMonysShop = "false";

        //            driverAccounts.NoteThreeShop = "ic_action_subtitles.png";
        //            // [Display(Name = "خذ من السائق ")
        //            double MonyTotalCostmerShopssaaa = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);
        //            driverAccounts.MonyTotalCostmerShop = MonyTotalCostmerShopssaaa;


        //            PercentageShop PercentageShopss = new PercentageShop();

        //            List<PercentageShop> fdsc = dbContexts.PercentageShops.OrderBy(x => x.Id).ToList();

        //            foreach (PercentageShop item in fdsc)
        //            {
        //                PercentageShopss = item;

        //            }


        //            UserShopBoshesArEn UserShopBoshscc = new UserShopBoshesArEn();

        //            UserShopBoshscc = DataAccess.Instance.GetBoshOffse(Ordersd.IdBosh);


        //            if (UserShopBoshscc.Percentage > 0)
        //            {
        //                double MonyTotalCostmerShopss = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);
        //                double pricBosh = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);

        //                double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;


        //                driverAccounts.MonyShopShop = pricBosh - pricBoshAfterDescount;
        //                driverAccounts.MonyCompenyShop = pricBoshAfterDescount;

        //                double pricTAX = 0;
        //                double TAXs = 0;
        //                try
        //                {
        //                    driverAccounts.NoteFourShop = pricBoshAfterDescount.ToString();
        //                    pricTAX = pricBoshAfterDescount / 100;
        //                    TAXs = pricTAX * 15;
        //                    driverAccounts.NoteSexShop = TAXs.ToString();
        //                }
        //                catch
        //                {

        //                }

        //                driverAccounts.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
        //                driverAccounts.TimesShop = DateTime.Now.ToString("HH:mm");

        //                driverAccounts.IdPricepackagShop = pricBosh - pricBoshAfterDescount- TAXs;
        //                driverAccounts.IdPriceShop = 0;
        //                driverAccounts.AccountsCompnyShop = 0;
        //                driverAccounts.DesAccountsCompnyShop = 0;
        //            }
        //            else
        //            {

        //                double MonyTotalCostmerShopss = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);
        //                double pricBosh = Convert.ToDouble(Ordersd.TotalPrice) - Convert.ToDouble(Ordersd.PricepackagAfter);

        //                double pricBoshAfterDescount = PercentageShopss.CountPercentageShop * pricBosh / 100;


        //                driverAccounts.MonyShopShop = pricBosh - pricBoshAfterDescount;
        //                driverAccounts.MonyCompenyShop = pricBoshAfterDescount;

        //                double pricTAX = 0;
        //                double TAXs = 0;
        //                try
        //                {
        //                    driverAccounts.NoteFourShop = pricBoshAfterDescount.ToString();
        //                    pricTAX = pricBoshAfterDescount / 100;
        //                    TAXs = pricTAX * 15;
        //                    driverAccounts.NoteSexShop = TAXs.ToString();
        //                }
        //                catch
        //                {

        //                }

        //                driverAccounts.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
        //                driverAccounts.TimesShop = DateTime.Now.ToString("HH:mm");

        //                driverAccounts.IdPricepackagShop = pricBosh - pricBoshAfterDescount- TAXs;
        //                driverAccounts.IdPriceShop = 0;
        //                driverAccounts.AccountsCompnyShop = 0;
        //                driverAccounts.DesAccountsCompnyShop = 0;

        //            }





        //        }


        //        dbContexts.ShopAccounts.Add(driverAccounts);
        //        dbContexts.SaveChanges();


        //    }













        //}

        public int AddAcountNewsNew(Order MyOrders)
        {
            int shopp = 0;
            try
            {
                ShopAccount obj = DataAccess.Instance.OstShopAccounts(MyOrders.Id);
                if (obj == null)
                {
                    ShopAccount AddShopAccount = new ShopAccount();

                    if (MyOrders.Cash == "true")
                    {
                        AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                        AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");
                        AddShopAccount.IdShop = MyOrders.IdBosh;
                        AddShopAccount.IdOrderShop = MyOrders.Id;
                        AddShopAccount.NoteFiveShop = MyOrders.Id.ToString();

                        if (MyOrders.CobenPrice != null)
                        {
                            if (MyOrders.CobenPrice != "0")
                            {
                                AddShopAccount.NumberCobon = MyOrders.CobenNumber;
                                AddShopAccount.PricCobon = MyOrders.CobenPrice;

                            }
                            else
                            {
                                AddShopAccount.NumberCobon = "لا يوجد";
                                AddShopAccount.PricCobon = "0";

                            }

                        }
                        else
                        {//  [Display(Name = "رقم الكوبون")]
                            AddShopAccount.NumberCobon = "لا يوجد";
                            AddShopAccount.PricCobon = "0";

                        }

                        AddShopAccount.NotesShop = "تم أضافة عملية دفع عند الاستلام ولقد استلمت المبلغ من السائق";

                        if (MyOrders.FreeDriveriv == "true")
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل مجاني";
                            AddShopAccount.PricFree = "0";

                        }
                        else
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل غير مجاني";
                            // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
                            AddShopAccount.PricFree = "0";

                        }

                        try
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;


                        }
                        catch
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;
                        }

                        AddShopAccount.TrueOrfalseIdOrdersShop = "true";
                        AddShopAccount.TrueOrfalseMonysShop = "true";

                        AddShopAccount.NoteThreeShop = "ic_action_monetization_on.png";

                        // [Display(Name = "خذ من السائق ")

                        double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                        AddShopAccount.MonyTotalCostmerShop = MonyTotalCostmerShopss;

                        UserShopBoshesArEn UserShopBoshscc = DataAccess.Instance.GetBoshOffse(MyOrders.IdBosh);

                        if (UserShopBoshscc.Percentage > 0)
                        {
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;
                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;

                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;
                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }

                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");


                            AddShopAccount.IdPricepackagShop = 0;

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }

                            AddShopAccount.IdPriceShop = pricBoshAfterDescount + TAXs - Discoun;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;


                        }
                        else
                        {


                            List<PercentageShop> PercentageShopss = DataAccess.Instance.GetOPercentageShop();
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);



                            double pricBoshAfterDescount = PercentageShopss.First().CountPercentageShop * pricBosh / 100;
                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;

                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");

                            AddShopAccount.IdPricepackagShop = 0;

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }

                            AddShopAccount.IdPriceShop = pricBoshAfterDescount + TAXs - Discoun;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;


                        }



                    }
                    else
                    {
                        AddShopAccount.IdShop = MyOrders.IdBosh;
                        AddShopAccount.IdOrderShop = MyOrders.Id;
                        AddShopAccount.NoteFiveShop = MyOrders.Id.ToString();
                        AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                        AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");


                        if (MyOrders.CobenPrice != null)
                        {
                            if (MyOrders.CobenPrice != "0")
                            {
                                AddShopAccount.NumberCobon = MyOrders.CobenNumber;
                                AddShopAccount.PricCobon = MyOrders.CobenPrice;

                            }
                            else
                            {
                                AddShopAccount.NumberCobon = "لا يوجد";
                                AddShopAccount.PricCobon = "0";

                            }

                        }
                        else
                        {//  [Display(Name = "رقم الكوبون")]
                            AddShopAccount.NumberCobon = "لا يوجد";
                            AddShopAccount.PricCobon = "0";

                        }

                        try
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;


                        }
                        catch
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;
                        }

                        AddShopAccount.NotesShop = "تم أضافة عملية دفع الكترونية ";

                        if (MyOrders.FreeDriveriv == "true")
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل مجاني";
                            AddShopAccount.PricFree = "0";

                        }
                        else
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل غير مجاني";
                            // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
                            AddShopAccount.PricFree = "0";

                        }


                        AddShopAccount.TrueOrfalseIdOrdersShop = "true";
                        AddShopAccount.TrueOrfalseMonysShop = "false";

                        AddShopAccount.NoteThreeShop = "ic_action_subtitles.png";
                        // [Display(Name = "خذ من السائق ")
                        double MonyTotalCostmerShopssaaa = Convert.ToDouble(AddShopAccount.PricBill);
                        AddShopAccount.MonyTotalCostmerShop = MonyTotalCostmerShopssaaa;

                        UserShopBoshesArEn UserShopBoshscc = DataAccess.Instance.GetBoshOffse(MyOrders.IdBosh);


                        if (UserShopBoshscc.Percentage > 0)
                        {
                            double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;

                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;


                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }

                            AddShopAccount.IdPricepackagShop = pricBosh - pricBoshAfterDescount - TAXs - Discoun;
                            AddShopAccount.IdPriceShop = 0;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;
                        }
                        else
                        {
                            List<PercentageShop> PercentageShopss = DataAccess.Instance.GetOPercentageShop();
                            double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = PercentageShopss.First().CountPercentageShop * pricBosh / 100;


                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;


                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");
                            AddShopAccount.IdPricepackagShop = pricBosh - pricBoshAfterDescount - TAXs - Discoun;
                            AddShopAccount.IdPriceShop = 0;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;

                        }





                    }


                    try
                    {
                        SqlParameter[] sqlprD = new SqlParameter[24];
                        sqlprD[0] = new SqlParameter("@IdShopx", AddShopAccount.IdShop);
                        sqlprD[1] = new SqlParameter("@IdOrderShopx", AddShopAccount.IdOrderShop);
                        sqlprD[2] = new SqlParameter("@IdPricepackagShopx", AddShopAccount.IdPricepackagShop);
                        sqlprD[3] = new SqlParameter("@IdPriceShopx", AddShopAccount.IdPriceShop);
                        sqlprD[4] = new SqlParameter("@AccountsCompnyShopx", AddShopAccount.AccountsCompnyShop);
                        sqlprD[5] = new SqlParameter("@DatesShopx", AddShopAccount.DatesShop);
                        sqlprD[6] = new SqlParameter("@TimesShopx", AddShopAccount.TimesShop);
                        sqlprD[7] = new SqlParameter("@NotesShopx", AddShopAccount.NotesShop);
                        sqlprD[8] = new SqlParameter("@NoteTowsShopx", AddShopAccount.NoteTowsShop);
                        sqlprD[9] = new SqlParameter("@NoteThreeShopx", AddShopAccount.NoteThreeShop);
                        sqlprD[10] = new SqlParameter("@MonyTotalCostmerShopx", AddShopAccount.MonyTotalCostmerShop);
                        sqlprD[11] = new SqlParameter("@MonyShopShopx", AddShopAccount.MonyShopShop);
                        sqlprD[12] = new SqlParameter("@MonyCompenyShopx", AddShopAccount.MonyCompenyShop);
                        sqlprD[13] = new SqlParameter("@TrueOrfalseIdOrdersShopx", AddShopAccount.TrueOrfalseIdOrdersShop);
                        sqlprD[14] = new SqlParameter("@TrueOrfalseMonysShopx", AddShopAccount.TrueOrfalseMonysShop);
                        sqlprD[15] = new SqlParameter("@NoteFourShopx", AddShopAccount.NoteFourShop);
                        sqlprD[16] = new SqlParameter("@NoteFiveShopx", AddShopAccount.NoteFiveShop);
                        sqlprD[17] = new SqlParameter("@NoteSexShopx", AddShopAccount.NoteSexShop);
                        sqlprD[18] = new SqlParameter("@DesAccountsCompnyShopx", AddShopAccount.DesAccountsCompnyShop);
                        sqlprD[19] = new SqlParameter("@PricBillx", AddShopAccount.PricBill);
                        sqlprD[20] = new SqlParameter("@PricFreex", AddShopAccount.PricFree);
                        sqlprD[21] = new SqlParameter("@NumberCobonx", AddShopAccount.NumberCobon);
                        sqlprD[22] = new SqlParameter("@PricCobonx", AddShopAccount.PricCobon);
                        sqlprD[23] = new SqlParameter("@NoteBillx", AddShopAccount.NoteBill);

                        int ibbc = ExecuteNonQueryADD(CommandType.StoredProcedure, "sp_AddShopAccounts", sqlprD);
                        shopp = ibbc;
                    }
                    catch
                    {

                    }


                }
                else
                {
                    shopp = 1;
                }

            }
            catch
            {

            }

            return shopp;

        }

        public void AddDrivers(Order order)
        {
            if (order.Cash == "true")
            {


                try
                {

                    bool Chaing = true;
                    try
                    {


                        // var obj = dbContexts.DriverAccounts.Where(a => a.IdOrder.Equals(order.Id)).FirstOrDefault();
                        DriverAccounts obj = DataAccess.Instance.OstDriverAccounts(order.Id);
                        if (obj.Id > 0)
                        {
                            Chaing = false;

                        }


                    }
                    catch
                    {
                        Chaing = true;

                    }

                    if (Chaing == true)
                    {
                        DriverAccounts driverAccounts = new DriverAccounts();
                        driverAccounts.IdDriver = order.IDDriver;
                        driverAccounts.IdOrder = order.Id;
                        driverAccounts.NoteSex = order.Id.ToString();
                        driverAccounts.Type = "Cash";

                        driverAccounts.TrueOrfalseIdOrders = "true";
                        driverAccounts.TrueOrfalseMonys = "true";

                        driverAccounts.NoteThree = "ic_action_monetization_on.png";

                        driverAccounts.MonyTotalCostmer = Convert.ToDouble(order.TotalPrice);
                        driverAccounts.MonyShop = Convert.ToDouble(order.TotalPrice) - Convert.ToDouble(order.PricepackagAfter);
                        driverAccounts.MonyDriver = Convert.ToDouble(order.PricepackagDriver);

                        double Tee = 0;

                        try
                        {

                            Tee = Convert.ToDouble(order.PricepackagAfter) - Convert.ToDouble(order.PricepackagDriver);

                            if (Tee <= 0)
                            { //-1                                 //7                                         //8

                                driverAccounts.MonyCompeny = Convert.ToDouble(order.DeliveryPrice) - Convert.ToDouble(order.PricepackagDriver);
                                Tee = driverAccounts.MonyCompeny;
                            }
                            else
                            { //-1                                 //7                                         //8
                                driverAccounts.MonyCompeny = Convert.ToDouble(order.PricepackagAfter) - Convert.ToDouble(order.PricepackagDriver);

                            }
                        }
                        catch
                        { //-1                                 //7                                         //8

                            Tee = Convert.ToDouble(order.PricepackagAfter) - Convert.ToDouble(order.PricepackagDriver);


                            driverAccounts.MonyCompeny = Tee;
                        }

                        driverAccounts.IdPricepackagDriver = 0;


                        driverAccounts.IdPrice = Tee;


                        driverAccounts.AccountsCompny = 0;

                        driverAccounts.Dates = DateTime.Now.ToString("yyyy:MM:dd");
                        driverAccounts.Times = DateTime.Now.ToString("HH:mm");






                        try
                        {
                            SqlParameter[] sqlprD = new SqlParameter[20];
                            sqlprD[0] = new SqlParameter("@IdDriverx", driverAccounts.IdDriver);
                            sqlprD[1] = new SqlParameter("@IdOrderx", driverAccounts.IdOrder);
                            sqlprD[2] = new SqlParameter("@IdPricepackagDriverx", driverAccounts.IdPricepackagDriver);
                            sqlprD[3] = new SqlParameter("@IdPricex", driverAccounts.IdPrice);
                            sqlprD[4] = new SqlParameter("@AccountsCompnyx", driverAccounts.AccountsCompny);
                            sqlprD[5] = new SqlParameter("@Datesx", driverAccounts.Dates);
                            sqlprD[6] = new SqlParameter("@Timesx", driverAccounts.Times);
                            sqlprD[7] = new SqlParameter("@Notesx", driverAccounts.Notes);
                            sqlprD[8] = new SqlParameter("@NoteTowsx", driverAccounts.NoteTows);
                            sqlprD[9] = new SqlParameter("@NoteThreex", driverAccounts.NoteThree);
                            sqlprD[10] = new SqlParameter("@Typex", driverAccounts.Type);
                            sqlprD[11] = new SqlParameter("@MonyTotalCostmerx", driverAccounts.MonyTotalCostmer);
                            sqlprD[12] = new SqlParameter("@MonyShopx", driverAccounts.MonyShop);
                            sqlprD[13] = new SqlParameter("@MonyDriverx", driverAccounts.MonyDriver);
                            sqlprD[14] = new SqlParameter("@MonyCompenyx", driverAccounts.MonyCompeny);
                            sqlprD[15] = new SqlParameter("@TrueOrfalseIdOrdersx", driverAccounts.TrueOrfalseIdOrders);
                            sqlprD[16] = new SqlParameter("@TrueOrfalseMonysx", driverAccounts.TrueOrfalseMonys);
                            sqlprD[17] = new SqlParameter("@NoteFourx", driverAccounts.NoteFour);
                            sqlprD[18] = new SqlParameter("@NoteFivex", driverAccounts.NoteFive);
                            sqlprD[19] = new SqlParameter("@NoteSexx", driverAccounts.NoteSex);

                            int ibbc = ExecuteNonQueryADD(CommandType.StoredProcedure, "sp_AddDriverAccounts", sqlprD);

                        }
                        catch
                        {

                        }


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
                    bool Chaing = true;
                    try
                    {
                        // var obj = dbContexts.DriverAccounts.Where(a => a.IdOrder.Equals(order.Id)).FirstOrDefault();
                        DriverAccounts obj = DataAccess.Instance.OstDriverAccounts(order.Id);
                        if (obj.Id > 0)
                        {
                            Chaing = false;
                        }

                    }
                    catch
                    {
                        Chaing = true;

                    }

                    if (Chaing == true)
                    {
                        DriverAccounts driverAccounts = new DriverAccounts();

                        driverAccounts.IdDriver = order.IDDriver;
                        driverAccounts.IdOrder = order.Id;
                        driverAccounts.NoteSex = order.Id.ToString();
                        driverAccounts.TrueOrfalseIdOrders = "true";
                        driverAccounts.TrueOrfalseMonys = "false";

                        driverAccounts.Type = "NotCash";

                        driverAccounts.NoteThree = "ic_action_subtitles.png";

                        //42                                    //8
                        // double Toooo = Convert.ToDouble(order.TotalPrice) - Convert.ToDouble(order.PricepackagAfter);
                        //38

                        // double Tooooww = Toooo + Convert.ToDouble(order.PricepackagDriver);

                        driverAccounts.IdPricepackagDriver = Convert.ToDouble(order.PricepackagAfter);
                        driverAccounts.IdPrice = 0;
                        driverAccounts.AccountsCompny = 0;
                        driverAccounts.Dates = DateTime.Now.ToString("yyyy:MM:dd");
                        driverAccounts.Times = DateTime.Now.ToString("HH:mm");

                        try
                        {
                            SqlParameter[] sqlprD = new SqlParameter[20];
                            sqlprD[0] = new SqlParameter("@IdDriverx", driverAccounts.IdDriver);
                            sqlprD[1] = new SqlParameter("@IdOrderx", driverAccounts.IdOrder);
                            sqlprD[2] = new SqlParameter("@IdPricepackagDriverx", driverAccounts.IdPricepackagDriver);
                            sqlprD[3] = new SqlParameter("@IdPricex", driverAccounts.IdPrice);
                            sqlprD[4] = new SqlParameter("@AccountsCompnyx", driverAccounts.AccountsCompny);
                            sqlprD[5] = new SqlParameter("@Datesx", driverAccounts.Dates);
                            sqlprD[6] = new SqlParameter("@Timesx", driverAccounts.Times);
                            sqlprD[7] = new SqlParameter("@Notesx", driverAccounts.Notes);
                            sqlprD[8] = new SqlParameter("@NoteTowsx", driverAccounts.NoteTows);
                            sqlprD[9] = new SqlParameter("@NoteThreex", driverAccounts.NoteThree);
                            sqlprD[10] = new SqlParameter("@Typex", driverAccounts.Type);
                            sqlprD[11] = new SqlParameter("@MonyTotalCostmerx", driverAccounts.MonyTotalCostmer);
                            sqlprD[12] = new SqlParameter("@MonyShopx", driverAccounts.MonyShop);
                            sqlprD[13] = new SqlParameter("@MonyDriverx", driverAccounts.MonyDriver);
                            sqlprD[14] = new SqlParameter("@MonyCompenyx", driverAccounts.MonyCompeny);
                            sqlprD[15] = new SqlParameter("@TrueOrfalseIdOrdersx", driverAccounts.TrueOrfalseIdOrders);
                            sqlprD[16] = new SqlParameter("@TrueOrfalseMonysx", driverAccounts.TrueOrfalseMonys);
                            sqlprD[17] = new SqlParameter("@NoteFourx", driverAccounts.NoteFour);
                            sqlprD[18] = new SqlParameter("@NoteFivex", driverAccounts.NoteFive);
                            sqlprD[19] = new SqlParameter("@NoteSexx", driverAccounts.NoteSex);

                            int i = ExecuteNonQueryADD(CommandType.StoredProcedure, "sp_AddDriverAccounts", sqlprD);

                        }
                        catch
                        {

                        }

                    }

                }
                catch
                {
                }

            }



        }


        public void GetDriverSendNofcationssss(int IdDriver)
        {

            try
            {
                // UserShopBoshesDriver pServic = dbContexts.UserShopBoshesDrivers.Find(IdDriver);
                UserShopBoshesDriver pServic = DataAccess.Instance.GetDriverShop(IdDriver);
                Task.Run(async () =>
                {

                    try
                    {
                        await new FMCnofication().sendnofication("تنوية", "تم اسنادلك طلب", pServic.CodeBoshDriver, "delivery");


                    }
                    catch
                    {
                    }


                    try
                    {
                        SendNotificationhuaweiDriver("", pServic.CodeBoshDriver, "تنوية", "تم أسناد طلب لك", "");

                    }
                    catch
                    {
                    }



                });

            }
            catch
            {

            }




        }


        public void SendNotificationWhatsUp(string Nmber, string messge)
        {

            //try
            //{
            //    var sd = new whatsappweb().Sendmssegwhatsapp(Nmber, messge);
            //}
            //catch
            //{

            //}

            HttpClient client = new HttpClient();

            client.GetStringAsync("https://api.ultramsg.com/instance3076/messages/chat?token=iqxbxdg35g7ow6ml&to=+966" + Nmber + "&body=" + messge + "  ✏️هذه رسالة الكترونية لا يجب الرد عليها" + "&priority=10");

        }

        public void SendNotificationWhatsUp22(string Nmber, string messge)
        {
            //try
            //{
            //    var sd = new whatsappweb().Sendmssegwhatsapp(Nmber, messge);
            //}
            //catch
            //{

            //}

            HttpClient client = new HttpClient();

            client.GetStringAsync("https://api.ultramsg.com/instance3076/messages/chat?token=iqxbxdg35g7ow6ml&to=+966" + Nmber + "&body=" + messge + " ✏️هذه رسالة الكترونية تلقائية من النظام لا يجب الرد عليها" + "&priority=10");

        }






        public async void SendNotificationhuaweichsaer(string topic, string token, string title, string body,
        string image, string deepLink = "", string url = "")
        {


            string Authorizationss = "";


            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://login.cloud.huawei.com/oauth2/v2/token"))
                {
                    var contentList = new List<string>();
                    contentList.Add($"grant_type={Uri.EscapeDataString("client_credentials")}");
                    contentList.Add($"client_id={Uri.EscapeDataString("104710517")}");
                    contentList.Add($"client_secret={Uri.EscapeDataString("5fde8a686fa985f9c877d61e85ca6dbeb5dfa3bba0c1ee26f196d23222111790")}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    string tokensc = response.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(tokensc);


                    foreach (var sd in json)
                    {
                        if (sd.Key == "access_token")
                        {

                            Authorizationss = sd.Value.ToString();
                        }

                    }


                    //  var tokenv = await response.Content.ReadAsAsync<AccessTokenResponse>
                }
            }


            HUnotification notification = new HUnotification();


            notification.validate_only = false;
            notification.message.notification.title = title;
            notification.message.notification.body = body;
            notification.message.notification.pushtype = 0;


            notification.message.android.notification.title = title;
            notification.message.android.notification.body = body;
            notification.message.android.notification.default_sound = true;
            notification.message.android.notification.channel_id = "RingRing";

            notification.message.android.notification.click_action.type = 3;


            //notification.message.android.notification.click_action.intent = "app://slova.de/?gid=10825";

            notification.message.token = new string[] { token };




            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://push-api.cloud.huawei.com/v1/104710517/messages:send"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Authorizationss);
                    request.Content = new StringContent(JsonConvert.SerializeObject(notification));

                    var sdfsd = JsonConvert.SerializeObject(notification);

                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    string resStr = await response.Content.ReadAsStringAsync();

                }
            }


        }



        public async void SendNotificationhuaweiDriver(string topic, string token, string title, string body,
       string image, string deepLink = "", string url = "")
        {


            string Authorizationss = "";


            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://login.cloud.huawei.com/oauth2/v2/token"))
                {
                    var contentList = new List<string>();
                    contentList.Add($"grant_type={Uri.EscapeDataString("client_credentials")}");
                    contentList.Add($"client_id={Uri.EscapeDataString("104723969")}");
                    contentList.Add($"client_secret={Uri.EscapeDataString("2a628516fa215a3e07ae01dc20a81cdf4152d3a1903390b4b8f7a6f825dfb1de")}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    string tokensc = response.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(tokensc);


                    foreach (var sd in json)
                    {
                        if (sd.Key == "access_token")
                        {

                            Authorizationss = sd.Value.ToString();
                        }

                    }


                    //  var tokenv = await response.Content.ReadAsAsync<AccessTokenResponse>
                }
            }


            HUnotification notification = new HUnotification();


            notification.validate_only = false;
            notification.message.notification.title = title;
            notification.message.notification.body = body;
            notification.message.notification.pushtype = 0;


            notification.message.android.notification.title = title;
            notification.message.android.notification.body = body;
            notification.message.android.notification.default_sound = true;
            notification.message.android.notification.channel_id = "RingRing";

            notification.message.android.notification.click_action.type = 3;


            //notification.message.android.notification.click_action.intent = "app://slova.de/?gid=10825";

            notification.message.token = new string[] { token };




            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://push-api.cloud.huawei.com/v1/104723969/messages:send"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Authorizationss);
                    request.Content = new StringContent(JsonConvert.SerializeObject(notification));

                    var sdfsd = JsonConvert.SerializeObject(notification);

                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    string resStr = await response.Content.ReadAsStringAsync();

                }
            }


        }




        protected void Button6_Command(object sender, CommandEventArgs e)
        {
            int INNss = int.Parse(e.CommandName);
            Order orderr = DataAccess.Instance.GetOrdersID(INNss);

            try
            {
                Label21.Text = orderr.Id.ToString();
                Label22.Text = orderr.Id.ToString();
                Label1.Text = orderr.SubThoroughfare;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalConselOrder", "$('#logoutModalConselOrder').modal()", true);


            }
            catch
            {

            }

        }

        protected void Button7_Command(object sender, CommandEventArgs e)
        {
            int IIdBosh = int.Parse(e.CommandName);



            try
            {

                List<notificationsSave> notificationsSavess = DataAccess.Instance.GetnotificationforIdBosh(IIdBosh.ToString());
                foreach (notificationsSave Drv in notificationsSavess)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            await new FMCnofication().sendnofication("تنوية", "لديك طلب جديد", Drv.Token, "store");


                        }
                        catch
                        {
                        }
                        try
                        {
                            SendNotificationhuaweichsaer("", Drv.Token, "تنوية", "لديك طلب جديد ", "");

                        }
                        catch
                        {
                        }
                        try
                        {

                            SendNotificationhuaweiDriver("", Drv.Token, "تنوية", "لديك طلب جديد ", "");

                        }
                        catch
                        {
                        }


                    });

                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert('لقد تم أرسال الاشعار بنجاح ')", true);
                // Label23.Text = IIdBosh.ToString();

                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalNofBosh", "$('#logoutModalNofBosh').modal()", true);

            }
            catch
            {

            }
        }

        protected void Button8_Command(object sender, CommandEventArgs e)
        {


            try
            {
                int IIDriver = int.Parse(e.CommandName);

                Label25.Text = IIDriver.ToString();






                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalNofDriver", "$('#logoutModalNofDriver').modal()", true);


            }
            catch
            {

            }
        }



        protected void Button10_Command(object sender, CommandEventArgs e)
        {

        }



        protected void Button12_Command(object sender, CommandEventArgs e)
        {

        }

        protected void Button9_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int IIclien = int.Parse(e.CommandName);

                Label24.Text = IIclien.ToString();






                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalNofClien", "$('#logoutModalNofClien').modal()", true);


            }
            catch
            {

            }
        }

        public int ExecuteNonQueryADD(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //  var con = new SqlConnection(dbContexts.Database.Connection.ConnectionString);
            // SqlConnection con = (SqlConnection)dbContexts.Database.Connection;

            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);


            int response = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = commandType;
                if (commandType == CommandType.StoredProcedure)
                {
                    if (commandParameters != null)
                    {
                        foreach (SqlParameter sqlPara in commandParameters)
                        {
                            if (sqlPara != null)
                            {
                                if (sqlPara.Direction == ParameterDirection.Output)
                                {
                                    cmd.Parameters.Add(sqlPara);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(sqlPara.ParameterName, sqlPara.SqlValue);
                                }
                            }
                        }
                    }
                }
                con.Open();
                response = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return response;
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText, int ids)
        {
            //  var con = new SqlConnection(dbContexts.Database.Connection.ConnectionString);
            //  SqlConnection con = (SqlConnection)dbContexts.Database.Connection;

            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);


            int response = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = commandType;
                cmd.Parameters.AddWithValue("@Ids", ids);
                con.Open();
                response = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return response;
        }
        protected async void Button13_Click(object sender, EventArgs e)
        {
            string name = Session["ANUser"].ToString();
            UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
            if (UserRoleDonesc != null)
            {

                if (UserRoleDonesc.ADDData == "0")
                {
                    // Button1Save.Visible = false;
                    // ButtonAccountsCompnyShop.Visible = false;


                }
                if (UserRoleDonesc.EditData == "0")
                {

                }
                else
                {
                    int INNsscccc = int.Parse(Label22.Text);

                    Order orderr = DataAccess.Instance.GetOrdersID(INNsscccc);

                    if (TextBox1.Text == "Aa2022")
                    {


                        try
                        {
                            orderr.StatusBosh = "false";
                            orderr.StatusDriver = "false";

                            try
                            {

                                orderr.Arrived = name + " رفض الطلب " + DateTime.Now.ToString("HH:mm:ss");

                            }
                            catch
                            {

                            }

                            orderr.DateAccsptReadyBosh = DateTime.Now.ToString("yyyy:MM:dd");
                            orderr.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");
                            // dbContexts.Entry(orderr).State = EntityState.Modified;
                            // dbContexts.SaveChanges();

                            //صح

                            try
                            {

                                SqlParameter[] sqlpr = new SqlParameter[37];
                                sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                                sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                                sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                                sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                                sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                                sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                                sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                                sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                                sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                                sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                                sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                                sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                                sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                                sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                                sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                                sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                                sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                                sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                                sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                                sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                                sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                                sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                                sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                                sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                                sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                                sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                                sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                                sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                                sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                                sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                                sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                                sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                                sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                                sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);
                                // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                                sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                                sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                                sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                                int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);
                            }
                            catch
                            {

                            }


                            try
                            {
                                CustomerData CCCustomerData = DataAccess.Instance.GetCustomerData(orderr.IdCustomer); //db.Drivers.Find(itemOrderlist.IDDriver);
                                if (orderr.PaymentStatus == "true")
                                {
                                    try
                                    {
                                        double Totel = 0;
                                        double Totel1 = 0;
                                        double Totel2 = 0;
                                        double TotalPrices = 0;
                                        double PricePshWalltss = 0;
                                        double DeliveryPrices = 0;
                                        double cOPENS = 0;
                                        double feeprice = 0;


                                        try
                                        {
                                            feeprice = double.Parse(orderr.NeighborhoodSubLocality);
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            TotalPrices = double.Parse(orderr.TotalPrice);
                                        }
                                        catch
                                        {

                                        }

                                        try
                                        {
                                            PricePshWalltss = double.Parse(orderr.PricePshWallts);
                                        }
                                        catch
                                        {

                                        }
                                        try
                                        {
                                            DeliveryPrices = double.Parse(orderr.DeliveryPrice);
                                        }
                                        catch
                                        {

                                        }

                                        try
                                        {
                                            cOPENS = double.Parse(orderr.CobenPrice);
                                        }
                                        catch
                                        {

                                        }

                                        Totel = TotalPrices + DeliveryPrices + feeprice;
                                        Totel1 = Totel - PricePshWalltss;
                                        Totel2 = Totel1 - cOPENS;

                                        try
                                        {
                                            SendNotificationWhatsUp("0546029025", "🔔تم ارجاع المبلغ بعد رفض الطلب من قبل الادارة :" + "\\n " + " رقم الطلب " + orderr.Id.ToString() + "معرف تلر" + orderr.PaymentProcessNumber + "\\n ");
                                            SendNotificationWhatsUp("0530702492", "🔔تم ارجاع المبلغ بعد رفض الطلب من قبل الادارة :" + "\\n " + " رقم الطلب " + orderr.Id.ToString() + "معرف تلر" + orderr.PaymentProcessNumber + "\\n ");
                                        }
                                        catch
                                        {


                                        }
                                        try
                                        {
                                            Order ordfgfg = DataAccess.Instance.GetOrdersID(INNsscccc);
                                            ordfgfg.PaymentProcessNumber += name;
                                            // dbContexts.Entry(ordfgfg).State = EntityState.Modified;
                                            // dbContexts.SaveChanges();

                                            SqlParameter[] sqlpr = new SqlParameter[6];
                                            sqlpr[0] = new SqlParameter("@Id", ordfgfg.Id);
                                            sqlpr[1] = new SqlParameter("@PaymentStatuss", ordfgfg.PaymentStatus);
                                            sqlpr[2] = new SqlParameter("@PaymentProcessNumbers", ordfgfg.PaymentProcessNumber);
                                            sqlpr[3] = new SqlParameter("@PaymentAmounts", ordfgfg.PaymentAmount);
                                            sqlpr[4] = new SqlParameter("@PaymentCardStartEnds", ordfgfg.PaymentCardStartEnd);
                                            sqlpr[5] = new SqlParameter("@Paymentcodesss", ordfgfg.Paymentcodess);

                                            int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrderTelrNumber", sqlpr);


                                        }
                                        catch
                                        {

                                        }

                                        if (orderr.PostalCode == "webdone")
                                        {
                                            string s = await new retPay().packsswebAsync(Totel2, orderr.PaymentProcessNumber);

                                            if (s == "A")
                                            {

                                            }
                                        }
                                        else
                                        {
                                            string s = await new retPay().packssAsync(Totel2, orderr.PaymentProcessNumber);

                                            if (s == "A")
                                            {

                                            }

                                        }
                                    }
                                    catch
                                    {

                                    }



                                    try
                                    {
                                        await Task.Run(async () =>
                                        {

                                            await new FMCnofication().sendnofication("تنوية", "عميلنا العزيز تم الغاء الطلب - سيتم أسترجاع اموالك خلال 11 دقيقة", CCCustomerData.FirebaseToken, "client");
                                        });



                                    }
                                    catch
                                    {
                                    }




                                    if (orderr.cahckWallts == "true")
                                    {
                                        BackManyTowalat(orderr.Id);
                                    }


                                }
                                else
                                {
                                    if (orderr.cahckWallts == "true")
                                    {
                                        try
                                        {
                                            await Task.Run(async () =>
                                            {

                                                await new FMCnofication().sendnofication("تنوية", " عميلنا العزيز تم الغاء الطلب - تم إرجاع مبلغ الطلب الى محفظتك", CCCustomerData.FirebaseToken, "client");
                                            });



                                        }
                                        catch
                                        {

                                        }


                                        BackManyTowalat(orderr.Id);
                                    }


                                }

                            }
                            catch
                            {

                            }
                            try
                            {
                                Models.Driver Driverxxx = DataAccess.Instance.GetDriverByIdDriver(orderr.IDDriver); //db.Drivers.Find(itemOrderlist.IDDriver);
                                string numbersss = Driverxxx.NumberDriver;
                                string number = numbersss.Remove(0, 1);
                                SendNotificationWhatsUp(number, "اهلا :" + Driverxxx.NameDriver + "\\n  " + "تم الغاء الطلب رقم " + orderr.Id.ToString() + "\\n  ");


                            }
                            catch
                            {
                                try
                                {

                                    UserShopBoshesDriver Driverxxx = DataAccess.Instance.GetDriverShop(orderr.IDDriver);
                                    string numbersss = Driverxxx.NumberPhoneBoshDriver;
                                    string number = numbersss.Remove(0, 1);
                                    SendNotificationWhatsUp(number, "اهلا" + "\\n " + "تم الغاء الطلب " + orderr.Id.ToString() + "\\n  ");
                                }
                                catch
                                {

                                }
                            }
                            try
                            {
                                ShopAccount obj = DataAccess.Instance.OstShopAccounts(orderr.Id);
                                if (obj != null)
                                {

                                    try
                                    {
                                        int i = ExecuteNonQuery(CommandType.Text, "DELETE FROM ShopAccounts WHERE Id=@Ids", obj.Id);
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
                            try
                            {
                                DriverAccounts DriverAccountsb = DataAccess.Instance.OstDriverAccounts(orderr.Id);

                                if (DriverAccountsb != null)
                                {


                                    try
                                    {
                                        SqlParameter[] sqlprs = new SqlParameter[1];
                                        sqlprs[0] = new SqlParameter("@Id", DriverAccountsb.Id);
                                        int ifv = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_DELETEtoDriverAccounts", sqlprs);

                                        // int i = ExecuteNonQuery(CommandType.Text, "DELETE FROM DriverAccounts WHERE Id=@Ids", DriverAccountsb.Id);
                                    }
                                    catch
                                    {

                                    }


                                    //  dbContexts.DriverAccounts.Remove(DriverAccountsb);
                                    // dbContexts.SaveChanges();






                                }

                            }
                            catch (Exception ex)
                            {

                            }


                            try
                            {
                                List<UserShopBoshServic> Billsccc = DataAccess.Instance.GetUserShopBoshServics(orderr.Id);
                                foreach (UserShopBoshServic userShopBosh in Billsccc)
                                {
                                    SendNotificationWhatsUp(userShopBosh.Size1, "⛔تم الغاء الطلب رقم : " + orderr.Id.ToString() + "من قبل الادارة"
    + "\\n " + "⛔Order No. has been cancelled : " + orderr.Id.ToString() + "by the administration"
    + "\\n " + "Date-التاريخ " + orderr.DataOrder + "order amount-مبلغ الطلب " + orderr.TotalPrice.ToString() + "SAR" + "\\n ");
                                }


                            }
                            catch
                            {

                            }


                            TextBox1.Text = "";
                            try
                            {
                                Response.Redirect("/AdminShops/OrdersTow.aspx", false);
                                //  Response.Redirect("/AdminShops/OrdersTow.aspx");
                            }
                            catch
                            {

                            }


                        }
                        catch
                        {
                            TextBox1.Text = "";

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                        }




                    }
                    else
                    {

                        TextBox1.Text = "";

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);

                    }

                }
                if (UserRoleDonesc.SecetcData == "1")
                {


                }
                else
                {

                    Response.Redirect("/AdminShops/Admin", false);
                }

                if (UserRoleDonesc.DeledtData == "0")
                {


                }


            }
            else
            {
                Response.Redirect("/AdminShops/Admin", false);
            }


        }
        public int ExecuteNonQueryOrder(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //  var con = new SqlConnection(dbContexts.Database.Connection.ConnectionString);
            // SqlConnection con = (SqlConnection)dbs.Database.Connection;
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);

            int response = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = commandType;
                if (commandType == CommandType.StoredProcedure)
                {
                    if (commandParameters != null)
                    {
                        foreach (SqlParameter sqlPara in commandParameters)
                        {
                            if (sqlPara != null)
                            {
                                if (sqlPara.Direction == ParameterDirection.Output)
                                {
                                    cmd.Parameters.Add(sqlPara);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(sqlPara.ParameterName, sqlPara.SqlValue);
                                }
                            }
                        }
                    }
                }
                con.Open();
                response = cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return response;
        }
        public string ToXML(Object oObject)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(oObject.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                var streamWriter = new StreamWriter(xmlStream, System.Text.Encoding.UTF8);
                xmlSerializer.Serialize(streamWriter, oObject);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;


            }
        }
        public void BackManyTowalat(int Idcustomer)
        {
            try
            {
                Wallet WalletSS = DataAccess.Instance.Getowallets(Idcustomer);
                // Wallet WalletSS = dbContexts.Wallets.Where(x => x.IdOrderWallet == Idcustomer).FirstOrDefault();


                SqlParameter[] sqlprs = new SqlParameter[1];
                sqlprs[0] = new SqlParameter("@Ids", WalletSS.Id);
                int ifv = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_DELETEtoWallets", sqlprs);

                // dbContexts.Wallets.Remove(WalletSS);
                //  dbContexts.SaveChanges();
            }
            catch
            {

            }
        }
        private class Remote
        {
            public string store { get; set; }
            public string @key { get; set; }

            public Tran tran { get; set; }
        }

        private class Tran
        {
            public string @type { get; set; }
            public string @class { get; set; }
            public string currency { get; set; }
            public string amount { get; set; }
            public string @ref { get; set; }
            public string test { get; set; }

        }

        protected void Button14_Click(object sender, EventArgs e)
        {


            string name = Session["ANUser"].ToString();
            UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
            if (UserRoleDonesc != null)
            {

                if (UserRoleDonesc.ADDData == "0")
                {
                    // Button1Save.Visible = false;
                    // ButtonAccountsCompnyShop.Visible = false;


                }
                if (UserRoleDonesc.EditData == "0")
                {

                }
                else
                {
                    int INNsscccc = int.Parse(Label22.Text);

                    Order orderr = DataAccess.Instance.GetOrdersID(INNsscccc);
                    if (TextBox1.Text == "Aa2022")
                    {
                        if (orderr.StatusBosh == "new" && orderr.CancelOrder != "true")
                        {
                            orderr.StatusBosh = "true";
                            orderr.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");
                            orderr.DateAccsptReadyBosh = DateTime.Now.ToString("yyyy:MM:dd");
                            orderr.TimeAccsptDriver = DateTime.Now.ToString("HH:mm");

                            try
                            {
                                orderr.Arrived = name + " قبول الطلب " + DateTime.Now.ToString("HH:mm:ss");

                            }
                            catch
                            {

                            }
                            // orderr.PaymentProcessNumber += name;
                            // PutOrderSSSS(INNsscccc, orderr);

                            // dbContexts.Entry(orderr).State = EntityState.Modified;
                            //  dbContexts.SaveChanges();

                            //صح

                            try
                            {

                                SqlParameter[] sqlpr = new SqlParameter[37];
                                sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                                sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                                sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                                sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                                sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                                sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                                sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                                sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                                sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                                sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                                sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                                sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                                sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                                sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                                sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                                sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                                sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                                sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                                sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                                sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                                sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                                sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                                sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                                sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                                sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                                sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                                sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                                sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                                sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                                sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                                sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                                sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                                sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                                sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);
                                // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                                sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                                sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                                sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                                int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);
                            }
                            catch
                            {

                            }


                            TextBox1.Text = "";

                            try
                            {
                                CustomerData CustomerDatacc = DataAccess.Instance.GetCustomerData(orderr.IdCustomer); //db.Drivers.Find(itemOrderlist.IDDriver);
                                string numberCustomer = CustomerDatacc.NumberPhoneUser;



                                if (orderr.IDDriver == 7)
                                {

                                    string PaymentStatusvvvv = "";
                                    if (orderr.PaymentStatus == "true")
                                    {
                                        PaymentStatusvvvv = "دفع الكتروني";
                                    }


                                    if (orderr.Cash == "true")
                                    {
                                        PaymentStatusvvvv = "الدفع عند الاستلام";
                                    }

                                    if (orderr.Cash != "true" && orderr.PaymentStatus != "true")
                                    {
                                        PaymentStatusvvvv = "دفع الكتروني";
                                    }

                                    string numberssccs = numberCustomer;
                                    string numbercccc = numberssccs.Remove(0, 1);

                                    string NoteYESORNODrivers = "";
                                    try
                                    {
                                        string illlls = orderr.NoteYESORNODriver;

                                        string lastCharacter = illlls.Substring(illlls.Length - 1);

                                        string result = "";
                                        if (lastCharacter == ".")
                                        {
                                            result = illlls.Remove(illlls.Length - 1);

                                        }
                                        else
                                        {
                                            result = illlls;
                                        }



                                        string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                                        XmlDocument xmltest = new XmlDocument();
                                        xmltest.LoadXml(resultd);

                                        XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                                        foreach (XmlNode xn in xnList)
                                        {
                                            NoteYESORNODrivers = NoteYESORNODrivers + "\r\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                                        }

                                        if (xnList.Count > 0)
                                        {


                                        }
                                        else
                                        {
                                            NoteYESORNODrivers = orderr.NoteYESORNODriver;



                                        }

                                    }
                                    catch
                                    {
                                        NoteYESORNODrivers = orderr.NoteYESORNODriver;

                                    }

                                    string FD = "https://api.whatsapp.com/send?phone=966" + numbercccc;


                                    try
                                    {

                                        if (orderr.IdBosh == 2289)
                                        {
                                            SendNotificationWhatsUp("0563773756", "* رقم الطلب :" + orderr.Id + "\\n "

                                           + "*التاريخ :" + orderr.DataOrder + "\\n "

                                        + "*نوع الدفع:" + PaymentStatusvvvv + "\\n "

                                        + "*الفاتورة :" + "\\n " + NoteYESORNODrivers + "\\n "
                                        + "\\n "
                                         + "*رقم جوال العميل" + "\\n" + FD + "\\n" + numberCustomer + "\\n "
                                        + "\\n ");

                                        }

                                    }
                                    catch
                                    {

                                    }




                                }
                                else
                                {


                                    Models.Driver Driverxxx = DataAccess.Instance.GetDriverByIdDriver(orderr.IDDriver); //db.Drivers.Find(itemOrderlist.IDDriver);
                                    string numbersss = Driverxxx.NumberDriver;
                                    string number = numbersss.Remove(0, 1);

                                    string PaymentStatusvvvv = "";
                                    if (orderr.PaymentStatus == "true")
                                    {
                                        PaymentStatusvvvv = "دفع الكتروني";
                                    }


                                    if (orderr.Cash == "true")
                                    {
                                        PaymentStatusvvvv = "الدفع عند الاستلام";
                                    }

                                    if (orderr.Cash != "true" && orderr.PaymentStatus != "true")
                                    {
                                        PaymentStatusvvvv = "دفع الكتروني";
                                    }

                                    string numberssccs = numberCustomer;
                                    string numbercccc = numberssccs.Remove(0, 1);


                                    string FD = "https://api.whatsapp.com/send?phone=966" + numbercccc;

                                    string NoteYESORNODrivers = "";
                                    try
                                    {



                                        string illlls = orderr.NoteYESORNODriver;


                                        string lastCharacter = illlls.Substring(illlls.Length - 1);

                                        string result = "";
                                        if (lastCharacter == ".")
                                        {
                                            result = illlls.Remove(illlls.Length - 1);

                                        }
                                        else
                                        {
                                            result = illlls;
                                        }



                                        string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                                        XmlDocument xmltest = new XmlDocument();
                                        xmltest.LoadXml(resultd);

                                        XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                                        foreach (XmlNode xn in xnList)
                                        {
                                            NoteYESORNODrivers = NoteYESORNODrivers + "\r\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                                        }

                                        if (xnList.Count > 0)
                                        {


                                        }
                                        else
                                        {
                                            NoteYESORNODrivers = orderr.NoteYESORNODriver;



                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        NoteYESORNODrivers = orderr.NoteYESORNODriver;

                                    }


                                    if (orderr.IDDriver == 4915 || orderr.IDDriver == 5131 || orderr.IDDriver == 5600)
                                    {


                                        string Locationss = "https://www.google.com.sa/maps/place/" + orderr.LocalYY + "," + orderr.LocalXX;

                                        string loxshop = "000000000000";
                                        string loyshop = "000000000000";
                                        string pudf = "null";
                                        try
                                        {
                                            UserShopBoshesArEn userShopBoshs = DataAccess.Instance.GetBoshOffse(orderr.IdBosh);
                                            loxshop = userShopBoshs.LocationXXXBosh;
                                            loyshop = userShopBoshs.LocationYYYBosh;
                                            pudf = userShopBoshs.provincesBoshs;


                                        }
                                        catch
                                        {

                                        }

                                        string Locationssshop = "https://www.google.com.sa/maps/place/" + loxshop + "," + loyshop;

                                        SendNotificationWhatsUp(number, "* رقم الطلب :" + orderr.Id + "\\n  "

                                       + "*التاريخ :" + orderr.DataOrder + "\\n  "

                                      + "* المطعم :" + orderr.SubThoroughfare + "\\n  "

                                       + "* رقم معرف المتجر :" + orderr.IdBosh.ToString() + "\\n  "

                                      + "* الحي :" + pudf + "\\n  "

                                    + "*نوع الدفع:" + PaymentStatusvvvv + "\\n  "

                                    + "*الفاتورة :" + "\\n  " + NoteYESORNODrivers + "\\n  "
                                    + "\\n  "
                                     + "* موقع المتجر :" + "\\n " + Locationssshop + "\\n  "
                                    + "\\n  "
                                    + "\\n  "
                                     + "*رقم جوال العميل" + "\\n " + FD + "\\n " + numberCustomer + "\\n  "
                                    + "\\n  "
                                     + "* موقع العميل" + "\\n " + Locationss + "\\n  "
                                    + "\\n  ");



                                    }
                                    else
                                    {
                                        SendNotificationWhatsUp(number, "🟥 لديك طلب جديد ," + "\\n  " + "للتفاصيل الدخول على تطبيق دن دليفري" + "\\n  " + "* رقم الطلب :" + orderr.Id + "\\n  " + "*التاريخ :" + orderr.DataOrder + "\\n  "
                                     
                                    + " التواصل مع العميل عبر الدردشة الخاصة بالتطبيق أولاً وفي حال عدم تجاوب العميل يتم التواصل معه على الرقم" + "\\n " + FD + "\\n " + numberCustomer + "\\n  "
                                    + "\\n  "
                                     + "ملاحظة : التواصل مع العميل مباشرةً على رقم الجوال يعرض حسابك للحظر." + "\\n  "
                                   + "\\n  ");
                                    }

                                    try
                                    {

                                        if (orderr.IdBosh == 2289)
                                        {

                                            SendNotificationWhatsUp("0563773756", "* رقم الطلب :" + orderr.Id + "\\n "

                                               + "*التاريخ :" + orderr.DataOrder + "\\n "

                                            + "*نوع الدفع:" + PaymentStatusvvvv + "\\n "

                                            + "*الفاتورة :" + "\\n " + NoteYESORNODrivers + "\\n "
                                            + "\\n "
                                             + "*رقم جوال العميل" + "\\n" + FD + "\\n" + numberCustomer + "\\n "
                                            + "\\n ");

                                        }

                                    }
                                    catch
                                    {

                                    }

                                    try
                                    {


                                        List<notificationsSave> notificationsSavess = DataAccess.Instance.GetnotificationforIdBosh(orderr.IdBosh.ToString());

                                        if (notificationsSavess.Count > 0)
                                        {

                                            foreach (notificationsSave notifications in notificationsSavess)
                                            {
                                                try
                                                {
                                                    Task.Run(async () =>
                                                    {


                                                        try
                                                        {
                                                            await new FMCnofication().sendnofication("تنوية", "تم قبول طلب رقم " + orderr.Id + " من قبل الادارة", notifications.Token, "store");

                                                        }
                                                        catch
                                                        {

                                                        }
                                                        try
                                                        {


                                                            SendNotificationhuaweichsaer("", notifications.Token, "تنوية", "تم قبول طلب رقم " + orderr.Id + " من قبل الادارة", "");
                                                            SendNotificationhuaweiDriver("", notifications.Token, "تنوية", "تم قبول طلب رقم " + orderr.Id + " من قبل الادارة", "");
                                                        }
                                                        catch
                                                        {
                                                        }

                                                    });


                                                }
                                                catch
                                                {

                                                }
                                            }


                                        }
                                    }
                                    catch
                                    {

                                    }


                                    try
                                    {

                                        // List<UserShopBoshServic> objsss = dbContexts.UserShopBoshServics.Where(a => a.IdUserShopBosh.Equals(orderr.IdBosh)).ToList();
                                        List<UserShopBoshServic> objsss = DataAccess.Instance.GetUserShopBoshServics(orderr.IdBosh);

                                        foreach (UserShopBoshServic RT in objsss)
                                        {

                                            string numbersssv = RT.Size1;
                                            string numberv = numbersssv.Remove(0, 1);



                                            double BIL = Convert.ToDouble(orderr.TotalPrice);

                                            string bbosh = "";

                                            if (orderr.PaymentStatus == "true")
                                            {
                                                bbosh = "دفع الكتروني-electronic payment";
                                            }


                                            if (orderr.Cash == "true")
                                            {
                                                bbosh = "الدفع عند الاستلام- Paiement when recieving";
                                            }

                                            if (orderr.Cash != "true" && orderr.PaymentStatus != "true")
                                            {
                                                bbosh = "دفع الكتروني-electronic payment";
                                            }
                                            string NoteYESORNODriversv = "";
                                            try
                                            {



                                                string illlls = orderr.NoteYESORNODriver;


                                                string lastCharacter = illlls.Substring(illlls.Length - 1);

                                                string result = "";
                                                if (lastCharacter == ".")
                                                {
                                                    result = illlls.Remove(illlls.Length - 1);

                                                }
                                                else
                                                {
                                                    result = illlls;
                                                }



                                                string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                                                XmlDocument xmltest = new XmlDocument();
                                                xmltest.LoadXml(resultd);

                                                XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                                                foreach (XmlNode xn in xnList)
                                                {
                                                    NoteYESORNODriversv = NoteYESORNODriversv + "\r\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                                                }

                                                if (xnList.Count > 0)
                                                {


                                                }
                                                else
                                                {
                                                    NoteYESORNODriversv = orderr.NoteYESORNODriver;



                                                }

                                            }
                                            catch (Exception ex)
                                            {
                                                NoteYESORNODriversv = orderr.NoteYESORNODriver;

                                            }

                                            SendNotificationWhatsUp(numberv, "📳" + TextBox3.Text.ToString() + "عملية الدفع :" + bbosh + "رقم الطلبية :" + orderr.Id + "\\n  " + NoteYESORNODriversv + "\\n  🧾اجمالي مبلغ الفاتورة " + BIL.ToString() + "\\n " + "ملاحظة : قبول الطلبية عن طريق برنامج الكاشير" + "\\n ");

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

                            Response.Redirect("/AdminShops/OrdersTow.aspx", false);


                        }


                    }
                    else
                    {
                        TextBox1.Text = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                    }
                }
                if (UserRoleDonesc.SecetcData == "1")
                {


                }
                else
                {
                    Response.Redirect("/AdminShops/Admin", false);
                }

                if (UserRoleDonesc.DeledtData == "0")
                {


                }


            }
            else
            {
                Response.Redirect("/AdminShops/Admin", false);
            }







        }

        protected void Button11_Click(object sender, EventArgs e)
        {

            try
            {
                if (TextBox3.Text.Length > 5 && TextBox2.Text.Length > 3)
                {

                    // int Idca = int.Parse(Label23.Text);


                    //  Order orderr = dbContexts.Orders.Where(x => x.Id == Idca).FirstOrDefault();

                    //  int Idcasss = orderr.IdBosh;
                    //   UserShopBoshCasher obj = dbContexts.UserShopBoshCashers.Where(a => a.Id.Equals(Idcasss)).FirstOrDefault();


                    //try
                    //{

                    //   // List<UserShopBoshServic> objsss = dbContexts.UserShopBoshServics.Where(a => a.IdUserShopBosh.Equals(Idcasss)).ToList();
                    //    List<UserShopBoshServic> objsss = DataAccess.Instance.GetUserShopBoshServics(Idcasss);

                    //    foreach (var RT in objsss)
                    //    {

                    //        string numbersss = RT.Size1;
                    //        string number = numbersss.Remove(0, 1);



                    //        double BIL = Convert.ToDouble(orderr.TotalPrice) ;

                    //        string bbosh = "";

                    //        if (orderr.PaymentStatus == "true")
                    //        {
                    //            bbosh = "دفع الكتروني-electronic payment";
                    //        }


                    //        if (orderr.Cash == "true")
                    //        {
                    //            bbosh = "الدفع عند الاستلام- Paiement when recieving";
                    //        }

                    //        if (orderr.Cash != "true" && orderr.PaymentStatus != "true")
                    //        {
                    //            bbosh = "دفع الكتروني-electronic payment";
                    //        }
                    //        string NoteYESORNODrivers = "";
                    //        try
                    //        {



                    //            string illlls = orderr.NoteYESORNODriver;


                    //            string lastCharacter = illlls.Substring(illlls.Length - 1);

                    //            string result = "";
                    //            if (lastCharacter == ".")
                    //            {
                    //                result = illlls.Remove(illlls.Length - 1);

                    //            }
                    //            else
                    //            {
                    //                result = illlls;
                    //            }



                    //            string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                    //            XmlDocument xmltest = new XmlDocument();
                    //            xmltest.LoadXml(resultd);

                    //            XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                    //            foreach (XmlNode xn in xnList)
                    //            {
                    //                NoteYESORNODrivers = NoteYESORNODrivers + "\\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                    //            }

                    //            if (xnList.Count > 0)
                    //            {


                    //            }
                    //            else
                    //            {
                    //                NoteYESORNODrivers = orderr.NoteYESORNODriver;



                    //            }

                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            NoteYESORNODrivers = orderr.NoteYESORNODriver;

                    //        }

                    //        SendNotificationWhatsUp(number, "📳" + TextBox3.Text.ToString() + "عملية الدفع :" + bbosh + "رقم الطلبية :" + orderr.Id + "\\n  " + NoteYESORNODrivers + "\\n  🧾اجمالي مبلغ الفاتورة " + BIL.ToString() + "\\n " + "ملاحظة : قبول الطلبية عن طريق برنامج الكاشير" + "\\n ");

                    //    }


                    //}
                    //catch
                    //{

                    //}

                    //List<notificationsSave> notificationsSavess = DataAccess.Instance.GetnotificationforIdBosh(orderv.IdBosh.ToString());
                    //foreach (notificationsSave Drv in notificationsSavess)
                    //{
                    //    Task.Run(() =>
                    //    {
                    //        try
                    //        {
                    //            SendNotification("", Drv.Token, "تنوية", "لديك طلب جديد", "");

                    //        }
                    //        catch
                    //        {
                    //        }
                    //        try
                    //        {
                    //            SendNotificationhuaweichsaer("", Drv.Token, "تنوية", "لديك طلب جديد ", "");

                    //        }
                    //        catch
                    //        {
                    //        }
                    //        try
                    //        {

                    //            SendNotificationhuaweiDriver("", Drv.Token, "تنوية", "لديك طلب جديد ", "");

                    //        }
                    //        catch
                    //        {
                    //        }


                    //    });

                    //}

                    //Task.Run(() =>
                    //{




                    //    SendNotification("", obj.CasherFirebaseToken, TextBox2.Text.ToString(), TextBox3.Text.ToString(), "");

                    //    SendNotificationhuaweichsaer("", obj.CasherFirebaseToken, TextBox2.Text.ToString(), TextBox3.Text.ToString(), "");
                    //    SendNotificationhuaweiDriver("", obj.CasherFirebaseToken, TextBox2.Text.ToString(), TextBox3.Text.ToString(), "");


                    //});

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert('لقد تم أرسال الاشعار بنجاح ')", true);
                }
                else
                {
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert(' يرجئ كتابة الرسالة')", true);
                }
            }
            catch
            {
                //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert('يرجئ تحديد كاشير ')", true);

            }

        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            try
            {


                int Idca = int.Parse(Label25.Text);

                Models.Driver obj = DataAccess.Instance.GetDriverscccc(Idca);

                if (TextBox7.Text.Length > 5 && TextBox6.Text.Length > 3)
                {
                    try
                    {

                        Task.Run(async () =>
                        {
                            try
                            {
                                await new FMCnofication().sendnofication(TextBox6.Text.ToString(), TextBox7.Text.ToString(), obj.TypeDriver, "delivery");

                            }
                            catch
                            {

                            }

                            SendNotificationhuaweichsaer("", obj.TypeDriver, TextBox6.Text.ToString(), TextBox7.Text.ToString(), "");
                            SendNotificationhuaweiDriver("", obj.TypeDriver, TextBox6.Text.ToString(), TextBox7.Text.ToString(), "");


                        });
                    }
                    catch
                    {

                    }

                    try
                    {
                        NofiactionDriver nofiactionDriverv = new NofiactionDriver();
                        nofiactionDriverv.IDDriver = obj.Id;
                        nofiactionDriverv.Messeg = "اهلا :" + obj.NameDriver + "   " + "🛑" + TextBox6.Text + "  " + TextBox7.Text;
                        nofiactionDriverv.Date = DateTime.Now.ToString("yyyy/MM/dd");
                        nofiactionDriverv.Not1 = "new";
                        nofiactionDriverv.Not2 = "new";
                        nofiactionDriverv.Not3 = "new";
                        nofiactionDriverv.Not4 = "new";

                        // dbContexts.NofiactionDrivers.Add(nofiactionDriverv);
                        //  dbContexts.SaveChanges();


                        SqlParameter[] sqlpr = new SqlParameter[7];

                        sqlpr[0] = new SqlParameter("@IDDrivers", nofiactionDriverv.IDDriver);
                        sqlpr[1] = new SqlParameter("@Messegs", nofiactionDriverv.Messeg);
                        sqlpr[2] = new SqlParameter("@Dates", nofiactionDriverv.Date);
                        sqlpr[3] = new SqlParameter("@Not1s", nofiactionDriverv.Not1);
                        sqlpr[4] = new SqlParameter("@Not2s", nofiactionDriverv.Not2);
                        sqlpr[5] = new SqlParameter("@@Not3s", nofiactionDriverv.Not3);
                        sqlpr[6] = new SqlParameter("@@Not4s", nofiactionDriverv.Not4);

                        int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_AddNofiactionDrivers", sqlpr);



                    }
                    catch
                    {






                    }


                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert('لقد تم أرسال الاشعار بنجاح ')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert(' يرجئ كتابة الرسالة')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert('يرجئ تحديد كاشير ')", true);

            }

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            try
            {



                int Idca = int.Parse(Label24.Text);




                //CustomerData obj = dbContexts.CustomerDatas.Where(a => a.Id.Equals(Idca)).FirstOrDefault();
                CustomerData obj = DataAccess.Instance.GetCustomerData(Idca);



                if (TextBox5.Text.Length > 5 && TextBox2.Text.Length > 3)
                {

                    Task.Run(async () =>
                    {
                        await new FMCnofication().sendnofication(TextBox4.Text.ToString(), TextBox5.Text.ToString(), obj.FirebaseToken, "client");


                        SendNotificationhuaweichsaer("", obj.FirebaseToken, TextBox4.Text.ToString(), TextBox5.Text.ToString(), "");
                        SendNotificationhuaweiDriver("", obj.FirebaseToken, TextBox4.Text.ToString(), TextBox5.Text.ToString(), "");


                    });

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert('لقد تم أرسال الاشعار بنجاح ')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert(' يرجئ كتابة الرسالة')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "رسالة", "alert('يرجئ تحديد كاشير ')", true);

            }
        }

        protected void Button15_Command(object sender, CommandEventArgs e)
        {
            int INNss = int.Parse(e.CommandName);


            try
            {



                try
                {
                    Order orderr = DataAccess.Instance.GetOrdersID(INNss);


                    if (orderr != null)
                    {



                        //  List<DoneDriver> blogs = DataAccess.Instance.GetDriverDonesidCity(orderr.IdCashers);

                        List<DoneDriver> blogs = DataAccess.Instance.GetDriverDonesidCityorderbynumber(orderr.IdCashers);

                        foreach (DoneDriver b in blogs)
                        {
                            List<Order> obj = DataAccess.Instance.getorderOldDriverAllnew(b.IDdriver);



                            b.not1 = obj.Count.ToString();
                            try
                            {
                                b.not2 = "";
                                for (int i = 0; i < obj.Count; i++)
                                {
                                    b.not2 = b.not2 + "-" + obj[i].SubThoroughfare + obj[i].TimeOrder;

                                }
                            }
                            catch
                            {

                            }




                        }

                        ListView3.DataSource = blogs;
                        ListView3.DataBind();

                    }


                }
                catch
                {

                }



                Label26.Text = INNss.ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalADDOrder", "$('#logoutModalADDOrder').modal()", true);


            }
            catch
            {

            }

        }

        protected void Button14444335_Command(object sender, CommandEventArgs e)
        {
            int INNss = int.Parse(e.CommandName);


            try
            {


                Label6867.Text = INNss.ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalADDOrderQuicly", "$('#logoutModalADDOrderQuicly').modal()", true);


            }
            catch
            {

            }

        }



        protected void Button16_Click(object sender, EventArgs e)
        {
            string name = Session["ANUser"].ToString();
            UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
            if (UserRoleDonesc != null)
            {

                if (UserRoleDonesc.ADDData == "0")
                {
                    // Button1Save.Visible = false;
                    // ButtonAccountsCompnyShop.Visible = false;


                }
                if (UserRoleDonesc.EditData == "0")
                {

                }
                else
                {

                    string oldDirverid = "";

                    int INNsscccc = int.Parse(Label26.Text);

                    Order orderr = DataAccess.Instance.GetOrdersID(INNsscccc);
                    oldDirverid = orderr.IDDriver.ToString();
                    if (TextBox8.Text == "Aa2022")
                    {
                        if (orderr.IdBosh == 43)
                        {
                            int INNssccc = int.Parse(TextBox9.Text);
                            orderr.StatusDriver = "true";
                            orderr.IDDriver = INNssccc;
                            orderr.StatusBosh = "true";
                            orderr.TimeAccsptReceivedDriver = DateTime.Now.ToString("HH:mm");
                            orderr.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");
                            orderr.DateAccsptReadyBosh = DateTime.Now.ToString("yyyy:MM:dd");
                            orderr.TimeAccsptDriver = DateTime.Now.ToString("HH:mm");
                            try
                            {
                                orderr.Arrived = name + "اسناد " + DateTime.Now.ToString("HH:mm:ss");

                            }
                            catch
                            {

                            }
                            // dbContexts.Entry(orderr).State = EntityState.Modified;

                            // dbContexts.SaveChanges();

                            // صج

                            try
                            {

                                SqlParameter[] sqlpr = new SqlParameter[37];
                                sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                                sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                                sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                                sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                                sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                                sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                                sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                                sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                                sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                                sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                                sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                                sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                                sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                                sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                                sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                                sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                                sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                                sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                                sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                                sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                                sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                                sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                                sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                                sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                                sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                                sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                                sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                                sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                                sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                                sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                                sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                                sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                                sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                                sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);
                                // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                                sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                                sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                                sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                                int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);
                                if (i == 1)
                                {
                                    try
                                    {
                                        SendNotificationWhatsUp("0546029025", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");
                                        SendNotificationWhatsUp("0530702492", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");


                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            catch
                            {

                            }

                        }
                        else
                        {

                            if (orderr.StatusDriver == "newdriver")
                            {

                            }
                            else
                            {

                                if (orderr.PostalCode == "storedone" && orderr.NoteBosh == "nonofa" || orderr.PostalCode == "storedone" && orderr.NoteBosh == "nono")
                                {
                                    int YesorNo = 0;

                                    try
                                    {
                                        int INNssccc = int.Parse(TextBox9.Text);
                                        orderr.StatusBosh = "true";
                                        orderr.StatusDriver = "true";
                                        orderr.IDDriver = INNssccc;

                                        orderr.TimeAccsptDriver = DateTime.Now.ToString("HH:mm");
                                        orderr.DateAccsptReadyBosh = "0";
                                        orderr.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");

                                        try
                                        {
                                            SqlParameter[] sqlprc = new SqlParameter[7];
                                            sqlprc[0] = new SqlParameter("@Id", orderr.Id);
                                            sqlprc[1] = new SqlParameter("@StatusDrivers", "true");
                                            sqlprc[2] = new SqlParameter("@IDDrivers", INNssccc);
                                            sqlprc[3] = new SqlParameter("@StatusBoshs", "true");
                                            sqlprc[4] = new SqlParameter("@TimeAccsptDrivers", DateTime.Now.ToString("HH:mm"));
                                            sqlprc[5] = new SqlParameter("@DateAccsptReadyBoshs", "0");
                                            sqlprc[6] = new SqlParameter("@TimeAccsptBoshs", DateTime.Now.ToString("HH:mm"));

                                            int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriver", sqlprc);
                                            YesorNo = 1;
                                        }
                                        catch
                                        {

                                        }
                                        if (YesorNo == 1)
                                        {
                                            try
                                            {

                                                CustomerData CustomerDatacc = DataAccess.Instance.GetCustomerData(orderr.IdCustomer); //db.Drivers.Find(itemOrderlist.IDDriver);
                                                string numberCustomer = CustomerDatacc.NumberPhoneUser;
                                                string numberssccs = numberCustomer;
                                                string numbercccc = numberssccs.Remove(0, 1);

                                                Models.Driver Driverxxx = DataAccess.Instance.GetDriverByIdDriver(INNssccc); //db.Drivers.Find(itemOrderlist.IDDriver);

                                                string numbersss = Driverxxx.NumberDriver;
                                                string number = numbersss.Remove(0, 1);



                                                string FD = "https://api.whatsapp.com/send?phone=966" + numbercccc;

                                                string NoteYESORNODrivers = "";
                                                try
                                                {
                                                    string illlls = orderr.NoteYESORNODriver;
                                                    string lastCharacter = illlls.Substring(illlls.Length - 1);
                                                    string result = "";
                                                    if (lastCharacter == ".")
                                                    {
                                                        result = illlls.Remove(illlls.Length - 1);

                                                    }
                                                    else
                                                    {
                                                        result = illlls;
                                                    }



                                                    string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                                                    XmlDocument xmltest = new XmlDocument();
                                                    xmltest.LoadXml(resultd);

                                                    XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                                                    foreach (XmlNode xn in xnList)
                                                    {
                                                        NoteYESORNODrivers = NoteYESORNODrivers + "\r\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                                                    }

                                                    if (xnList.Count > 0)
                                                    {


                                                    }
                                                    else
                                                    {
                                                        NoteYESORNODrivers = orderr.NoteYESORNODriver;



                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    NoteYESORNODrivers = orderr.NoteYESORNODriver;

                                                }


                                                SendNotificationWhatsUp(number, "* رقم الطلب :" + orderr.Id + "\\n  " + "*التاريخ :" + orderr.DataOrder + "\\n  "

                                                    + "*نوع الطلب:" + " طلب خـــاص  " + "*ملاحظة:" + " توجه للمتجر  ثم اطلب طلب العميل ثم اصدر فاتورة بمبلغ الفاتورة  " + "\\n  "
                                                + "* المتجر :" + orderr.SubThoroughfare + "\\n  "
                                                    + "*الفاتورة :" + NoteYESORNODrivers + "\\n  "
                                                    + "\\n  "
                                                     + " التواصل مع العميل عبر الدردشة الخاصة بالتطبيق أولاً وفي حال عدم تجاوب العميل يتم التواصل معه على الرقم" + "\\n " + FD + "\\n " + numberCustomer + "\\n  "
                                                     + "\\n  "
                                                      + "ملاحظة : التواصل مع العميل مباشرةً على رقم الجوال يعرض حسابك للحظر." + "\\n  "
                                                    + "\\n  ");


                                            }
                                            catch
                                            {

                                            }

                                            try
                                            {
                                                SendNotificationWhatsUp("0546029025", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");
                                                SendNotificationWhatsUp("0530702492", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");


                                            }
                                            catch
                                            {

                                            }

                                        }

                                    }
                                    catch
                                    {
                                        YesorNo = 0;
                                    }

                                }
                                else
                                {


                                    if (orderr.IDDriver != 11)
                                    {
                                        int INNssccc = int.Parse(TextBox9.Text);
                                        orderr.IDDriver = INNssccc;
                                        orderr.StatusDriver = "true";
                                        orderr.TimeAccsptDriver = DateTime.Now.ToString("HH:mm");


                                        try
                                        {

                                            orderr.Arrived = name + "قبول الطلب " + DateTime.Now.ToString("HH:mm:ss");

                                        }
                                        catch
                                        {

                                        }
                                        //  dbContexts.Entry(orderr).State = EntityState.Modified;

                                        //  dbContexts.SaveChanges();
                                        // صج
                                        try
                                        {

                                            SqlParameter[] sqlpr = new SqlParameter[37];
                                            sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                                            sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                                            sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                                            sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                                            sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                                            sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                                            sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                                            sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                                            sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                                            sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                                            sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                                            sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                                            sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                                            sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                                            sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                                            sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                                            sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                                            sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                                            sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                                            sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                                            sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                                            sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                                            sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                                            sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                                            sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                                            sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                                            sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                                            sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                                            sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                                            sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                                            sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                                            sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                                            sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                                            sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);
                                            // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                                            sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                                            sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                                            sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                                            int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);

                                            if (i > 0)
                                            {

                                                try
                                                {


                                                    CustomerData CustomerDatacc = DataAccess.Instance.GetCustomerData(orderr.IdCustomer); //db.Drivers.Find(itemOrderlist.IDDriver);
                                                    string numberCustomer = CustomerDatacc.NumberPhoneUser;
                                                    Models.Driver Driverxxx = DataAccess.Instance.GetDriverByIdDriver(orderr.IDDriver); //db.Drivers.Find(itemOrderlist.IDDriver);
                                                    string numbersss = "";


                                                    if (Driverxxx == null)
                                                    {
                                                        try
                                                        {
                                                            UserShopBoshesDriver Drive = DataAccess.Instance.GetDriverShop(orderr.IDDriver);
                                                            numbersss = Drive.NumberPhoneBoshDriver;

                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        numbersss = Driverxxx.NumberDriver;
                                                    }



                                                    string number = numbersss.Remove(0, 1);

                                                    string PaymentStatusvvvv = "";
                                                    if (orderr.PaymentStatus == "true")
                                                    {
                                                        PaymentStatusvvvv = "دفع الكتروني";
                                                    }


                                                    if (orderr.Cash == "true")
                                                    {
                                                        PaymentStatusvvvv = "الدفع عند الاستلام";
                                                    }

                                                    if (orderr.Cash != "true" && orderr.PaymentStatus != "true")
                                                    {
                                                        PaymentStatusvvvv = "دفع الكتروني";
                                                    }



                                                    string numberssccs = numberCustomer;
                                                    string numbercccc = numberssccs.Remove(0, 1);

                                                    string NoteYESORNODrivers = "";
                                                    try
                                                    {
                                                        string illlls = orderr.NoteYESORNODriver;

                                                        string lastCharacter = illlls.Substring(illlls.Length - 1);

                                                        string result = "";
                                                        if (lastCharacter == ".")
                                                        {
                                                            result = illlls.Remove(illlls.Length - 1);

                                                        }
                                                        else
                                                        {
                                                            result = illlls;
                                                        }



                                                        string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                                                        XmlDocument xmltest = new XmlDocument();
                                                        xmltest.LoadXml(resultd);

                                                        XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                                                        foreach (XmlNode xn in xnList)
                                                        {
                                                            NoteYESORNODrivers = NoteYESORNODrivers + "\r\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                                                        }

                                                        if (xnList.Count > 0)
                                                        {


                                                        }
                                                        else
                                                        {
                                                            NoteYESORNODrivers = orderr.NoteYESORNODriver;



                                                        }

                                                    }
                                                    catch
                                                    {
                                                        NoteYESORNODrivers = orderr.NoteYESORNODriver;

                                                    }

                                                    string FD = "https://api.whatsapp.com/send?phone=966" + numbercccc;
                                                    if (orderr.IDDriver == 4915 || orderr.IDDriver == 5131 || orderr.IDDriver == 5600)
                                                    {
                                                        string Locationss = "https://www.google.com.sa/maps/place/" + orderr.LocalYY + "," + orderr.LocalXX;

                                                        string loxshop = "000000000000";
                                                        string loyshop = "000000000000";
                                                        string pudf = "null";
                                                        try
                                                        {
                                                            UserShopBoshesArEn userShopBoshs = DataAccess.Instance.GetBoshOffse(orderr.IdBosh);
                                                            loxshop = userShopBoshs.LocationXXXBosh;
                                                            loyshop = userShopBoshs.LocationYYYBosh;
                                                            pudf = userShopBoshs.provincesBoshs;


                                                        }
                                                        catch
                                                        {

                                                        }

                                                        string Locationssshop = "https://www.google.com.sa/maps/place/" + loxshop + "," + loyshop;
                                                        SendNotificationWhatsUp(number, "* رقم الطلب :" + orderr.Id + "\\n "
                                                        + "*التاريخ :" + orderr.DataOrder + "\\n "
                                                        + "* المطعم :" + orderr.SubThoroughfare + "\\n "
                                                        + "* رقم معرف المتجر :" + orderr.IdBosh.ToString() + "\\n "

                                                      + "* الحي :" + pudf + "\\n "

                                                    + "*نوع الدفع:" + PaymentStatusvvvv + "\\n "

                                                    + "*الفاتورة :" + "\\n " + NoteYESORNODrivers + "\\n "
                                                    + "\\n "
                                                     + "* موقع المتجر :" + "\\n" + Locationssshop + "\\n "
                                                    + "\\n "
                                                    + "\\n "
                                                     + "*رقم جوال العميل" + "\\n" + FD + "\\n" + numberCustomer + "\\n "
                                                    + "\\n "
                                                     + "* موقع العميل" + "\\n" + Locationss + "\\n "
                                                    + "\\n ");



                                                    }
                                                    else
                                                    {
                                                        SendNotificationWhatsUp(number, "🟥 لديك طلب جديد ," + "\\n  " + "للتفاصيل الدخول على تطبيق دن دليفري" + "\\n  " + "* رقم الطلب :" + orderr.Id + "\\n  " + "*التاريخ :" + orderr.DataOrder + "\\n  "
                                                        
                                                      + "\\n " + FD + "\\n " + numberCustomer + "\\n  "
                                                      + "\\n  "

                                                     + "\\n  ");
                                                    }



                                                }
                                                catch
                                                {

                                                }

                                                try
                                                {
                                                    SendNotificationWhatsUp("0546029025", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");
                                                    SendNotificationWhatsUp("0530702492", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");


                                                }
                                                catch
                                                {

                                                }

                                            }


                                        }
                                        catch
                                        {

                                        }
                                    }

                                }


                            }


                        }


                        // PutOrdexxxx(INNsscccc, orderr);

                        Response.Redirect("/AdminShops/OrdersTow.aspx", false);

                    }
                    else
                    {
                        TextBox8.Text = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                    }

                }
                if (UserRoleDonesc.SecetcData == "1")
                {


                }
                else
                {
                    Response.Redirect("/AdminShops/Admin", false);
                }

                if (UserRoleDonesc.DeledtData == "0")
                {


                }


            }
            else
            {
                Response.Redirect("/AdminShops/Admin", false);
            }





        }


        public void PutOrdexxxx(int id, Order order)
        {



            order.DateAccsptReadyBosh = DateTime.Now.ToString("yyyy:MM:dd");

            if (order.ReadyBosh == "new")
            {

                order.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");
            }
            else
            {

                order.TimeAccsptReadyBosh = DateTime.Now.ToString("HH:mm");

            }


            //  dbContexts.Entry(order).State = EntityState.Modified;

            //  dbContexts.SaveChanges();
            // صج
            try
            {

                SqlParameter[] sqlpr = new SqlParameter[37];
                sqlpr[0] = new SqlParameter("@Id", order.Id);
                sqlpr[1] = new SqlParameter("@DeliveryPrices", order.DeliveryPrice);
                sqlpr[2] = new SqlParameter("@TotalPrices", order.TotalPrice);
                sqlpr[3] = new SqlParameter("@StreetThoroughfares", order.StreetThoroughfare);

                sqlpr[4] = new SqlParameter("@PaymentStatuss", order.PaymentStatus);
                sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", order.PaymentProcessNumber);
                sqlpr[6] = new SqlParameter("@StatusDrivers", order.StatusDriver);
                sqlpr[7] = new SqlParameter("@IDDrivers", order.IDDriver);
                sqlpr[8] = new SqlParameter("@Cashs", order.Cash);

                sqlpr[9] = new SqlParameter("@PaymentAmounts", order.PaymentAmount);
                sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", order.PaymentCardStartEnd);
                sqlpr[11] = new SqlParameter("@Paymentcodesss", order.Paymentcodess);
                sqlpr[12] = new SqlParameter("@IdcahckWalltss", order.IdcahckWallts);
                sqlpr[13] = new SqlParameter("@cahckWalltss", order.cahckWallts);
                sqlpr[14] = new SqlParameter("@PricePshWalltss", order.PricePshWallts);

                sqlpr[15] = new SqlParameter("@CobenNumbers", order.CobenNumber);
                sqlpr[16] = new SqlParameter("@CobenPrices", order.CobenPrice);

                sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", order.TimeAccsptReceivedDriver);
                sqlpr[18] = new SqlParameter("@TimeDrivers", order.TimeDriver);
                sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", order.DateAccsptReceivedDriver);
                sqlpr[20] = new SqlParameter("@ReadyBoshs", order.ReadyBosh);
                sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", order.TimeAccsptBosh);
                sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", order.DateAccsptReadyBosh);

                sqlpr[23] = new SqlParameter("@DataOrders", order.DataOrder);
                sqlpr[24] = new SqlParameter("@TimeOrders", order.TimeOrder);
                sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", order.TimeAccsptDriver);
                sqlpr[26] = new SqlParameter("@NoteReadyBoshs", order.NoteReadyBosh);
                sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", order.TimeAccsptReadyBosh);
                sqlpr[28] = new SqlParameter("@ReceivedDrivers", order.ReceivedDriver);
                sqlpr[29] = new SqlParameter("@NotCancelOrders", order.NotCancelOrder);
                sqlpr[30] = new SqlParameter("@StatusBoshs", order.StatusBosh);
                sqlpr[31] = new SqlParameter("@CancelOrders", order.CancelOrder);
                sqlpr[32] = new SqlParameter("@Arriveds", order.Arrived);
                sqlpr[33] = new SqlParameter("@TimeArriveds", order.TimeArrived);
                // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                sqlpr[34] = new SqlParameter("@NoteBoshs", order.NoteBosh);
                sqlpr[35] = new SqlParameter("@YESORNODrivers", order.YESORNODriver);
                sqlpr[36] = new SqlParameter("@Notes", order.Note);

                int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);
            }
            catch
            {

            }



        }






        protected void Button17_Command(object sender, CommandEventArgs e)
        {
            int IIdBosh = int.Parse(e.CommandName);


            try
            {

                UserShopBoshesArEn UserShopBoshCashersccc = DataAccess.Instance.GetBoshOffse(IIdBosh);
                string url = "https://www.google.com.sa/maps/place/" + UserShopBoshCashersccc.LocationXXXBosh + "," + UserShopBoshCashersccc.LocationYYYBosh;
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", "window.open('" + url + "');", true);

            }
            catch
            {

            }
        }



        protected void btnview1_Click(object sender, EventArgs e)
        {

            if (Session["ANUser"] != null)
            {
                string name = Session["ANUser"].ToString();

                MultiView1.ActiveViewIndex = 0;

                List<Order> blogs = DataAccess.Instance.GetOrders1();

                ListView1.DataSource = blogs;
                ListView1.DataBind();

            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }




        }
        protected void btnview5_Click(object sender, EventArgs e)
        {

            if (Session["ANUser"] != null)
            {
                string name = Session["ANUser"].ToString();


                List<Order> blogs = DataAccess.Instance.GetOrders2();

                MultiView1.ActiveViewIndex = 1;






                ListView7.DataSource = blogs;
                ListView7.DataBind();



            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }




        }
        protected void btnview2_Click(object sender, EventArgs e)
        {

            if (Session["ANUser"] != null)
            {




                List<Order> blogs = DataAccess.Instance.GetOrdersByGetAccepet();




                MultiView1.ActiveViewIndex = 2;


                ListView4.DataSource = blogs;
                ListView4.DataBind();



            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }

        }

        protected void btnview3_Click(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {
                string name = Session["ANUser"].ToString();



                List<Order> blogs = DataAccess.Instance.GetOrdersByGetGet();

                //*
                MultiView1.ActiveViewIndex = 4;




                ListView5.DataSource = blogs;
                ListView5.DataBind();



            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }
        }

        protected void btnview4_Click(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {
                string name = Session["ANUser"].ToString();


                List<Order> blogs = DataAccess.Instance.GetOrdersByGetsessful();
                //*
                MultiView1.ActiveViewIndex = 5;


                ListView6.DataSource = blogs;
                ListView6.DataBind();



            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }
        }

        protected void btnview6_Click(object sender, EventArgs e)
        {

            if (Session["ANUser"] != null)
            {
                string name = Session["ANUser"].ToString();
                List<Order> blogs = DataAccess.Instance.GetOrdersByGetFiled();
                //*
                MultiView1.ActiveViewIndex = 6;

                ListView8.DataSource = blogs;
                ListView8.DataBind();

            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }




        }

        protected void btnview9_Click(object sender, EventArgs e)
        {

            if (Session["ANUser"] != null)
            {
                //string name = Session["ANUser"].ToString();
                //List<Order> blogs = DataAccess.Instance.GetOrdersByGetFiled();
                ////*
                //MultiView1.ActiveViewIndex = 9;

                //ListView12.DataSource = blogs;
                //ListView12.DataBind();
                // LoadComplaints();
                LoadComplaints("لا يوجد اي ملاحظة");

                MultiView1.ActiveViewIndex = 9;

                // FilterComplaints()

            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }




        }

       

        // تحميل الشكاوى بناءً على حالة الفلترة المحددة
        protected void FilterComplaints(object sender, EventArgs e)
        {
            // الحصول على قيمة الزر الذي تم النقر عليه (يعني حالة الشكوى)
            string status = (sender as Button).CommandArgument;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // الاتصال بقاعدة البيانات 

            string query = "SELECT TOP(100)  * FROM Supporttables WHERE SupNot = @Status Order by Id DESC"; // استعلام SQL مع المتغير = "SELECT TOP(10) * FROM Supporttables WHERE SupNot = @Status";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status); // تعيين المتغير @Status

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // هنا يمكن استخدام reader لعرض البيانات أو تمريرها إلى DataSource
                ListView12.DataSource = reader;
                ListView12.DataBind();
            }
        }

        protected void FilterComplaints22(object sender, EventArgs e)
        {
            // الحصول على قيمة الزر الذي تم النقر عليه (يعني حالة الشكوى)
            string status = (sender as Button).CommandArgument;
            string status2 = "There is no note";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // الاتصال بقاعدة البيانات 

            string query = "SELECT  * FROM Supporttables WHERE SupNot = @Status and Id>=13620 or SupNot = @Status2 and Id>=13620  Order by Id DESC"; // استعلام SQL مع المتغير = "SELECT TOP(10) * FROM Supporttables WHERE SupNot = @Status";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status); // تعيين المتغير @Status
                command.Parameters.AddWithValue("@Status2", status2); // تعيين المتغير @Status
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // هنا يمكن استخدام reader لعرض البيانات أو تمريرها إلى DataSource
                ListView12.DataSource = reader;
                ListView12.DataBind();
            }
        }
        protected void FilterComplaints33(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {

                string name = Session["ANUser"].ToString();
                // الحصول على قيمة الزر الذي تم النقر عليه (يعني حالة الشكوى)
                string status = (sender as Button).CommandArgument;
                
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                // الاتصال بقاعدة البيانات 

                string query = "SELECT TOP(100)  * FROM Supporttables WHERE SupNot = @Status and User_StartProcess = @User_StartProcess   Order by Id DESC"; // استعلام SQL مع المتغير = "SELECT TOP(10) * FROM Supporttables WHERE SupNot = @Status";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Status", status); // تعيين المتغير @Status
                    command.Parameters.AddWithValue("@User_StartProcess", name); // تعيين المتغير @Status
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // هنا يمكن استخدام reader لعرض البيانات أو تمريرها إلى DataSource
                    ListView12.DataSource = reader;
                    ListView12.DataBind();
                }
            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }
        }
        private void LoadComplaints(string status)
        {
             
            if (Session["ANUser"] != null)
            {
                string name = Session["ANUser"].ToString();
                 
                    if (status == "تحت المعالجة")
                    {
                       
                        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                        string query = "SELECT TOP(100)  * FROM Supporttables WHERE SupNot = @Status and User_StartProcess = @User_StartProcess   Order by Id DESC";
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@Status", status);
                            cmd.Parameters.AddWithValue("@User_StartProcess", name); // تعيين المتغير @Status
                            con.Open();

                            SqlDataReader reader = cmd.ExecuteReader();
                            ListView12.DataSource = reader;
                            ListView12.DataBind();
                        }
                    }
                    else if (status == "منتهية")
                     {
                    string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    string query = "SELECT Top(100) * FROM Supporttables WHERE SupNot = @SupNot   Order by Id DESC";
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SupNot", status);
                        cmd.Parameters.AddWithValue("@User_Complete", name); // تعيين المتغير @Status
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        ListView12.DataSource = reader;
                        ListView12.DataBind();
                       }
                       }
                    else if (status == "تم تحويلها للإدارة")
                        {
                       
                        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                        string query = "SELECT Top(100) * FROM Supporttables WHERE SupNot = @SupNot  Order by Id DESC";
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@SupNot", status);
                         
                            con.Open();

                            SqlDataReader reader = cmd.ExecuteReader();
                            ListView12.DataSource = reader;
                            ListView12.DataBind();
                        }
                    }
                else
                {
                    string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    string query = "SELECT  * FROM Supporttables WHERE SupNot = @SupNot and Id>=13620 or SupNot = 'There is no note' and Id>=13620 Order by Id DESC";
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SupNot", status);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        ListView12.DataSource = reader;
                        ListView12.DataBind();
                    }
                }



            }
            else
            {
                Response.Redirect("/AdminShops/AL", false);
            }

           
        }


        private string SaveUploadedFile(ListViewCommandEventArgs e, string controlId)
        {
            FileUpload fileUpload = (FileUpload)e.Item.FindControl(controlId);
            if (fileUpload != null && fileUpload.HasFile)
            {
                string uploadsFolder = Server.MapPath("~/UploadedImages/");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                fileUpload.SaveAs(filePath);

                return uniqueFileName;
            }
            return null;
        }


        // معالجة الأوامر عند الضغط على الأزرار
        protected void ListView12_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (Session["ANUser"] != null)
            {

                string name = Session["ANUser"].ToString();

                string commandName = e.CommandName;
                int id = Convert.ToInt32(e.CommandArgument);

                if (commandName == "StartProcess")
                {
                    // معالجة الشكوى ووضعها في حالة "تحت المعالجة"
                    UpdateComplaintStatus(id, "تحت المعالجة",  DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") , name ,null, null, null, null, null, null,null ,null);



                    LoadComplaints("تحت المعالجة");
                }
                else if (commandName == "Complete")
                { 

                    // الشكوى تم معالجتها
                    string note = ((TextBox)e.Item.FindControl("txtAdminNote")).Text; 
                    string action = ((TextBox)e.Item.FindControl("txtAdminAction")).Text;
                    string fileName = SaveUploadedFile(e, "fuCompleteImage");

                    UpdateComplaintStatus(id, "منتهية", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), name, null, null, null, null, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), action, note, name);
                    LoadComplaints("منتهية");
                }
                else if (commandName == "ToAdmin")
                { 
                    // تحويل الشكوى للإدارة
                    string adminNote = ((TextBox)e.Item.FindControl("txtNote")).Text;
                    string adminAction = ((TextBox)e.Item.FindControl("txtAction")).Text;
                    string fileName = SaveUploadedFile(e, "fuToAdminImage");

                    UpdateComplaintStatus(id, "تم تحويلها للإدارة", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), name, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), adminAction, adminNote, name, null, null, null, null);
                    LoadComplaints("تم تحويلها للإدارة");
                }
                else if (e.CommandName == "UploadImage")
                {
                    IdSus.Text = e.CommandArgument.ToString(); 
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "uploadModal", "$('#uploadModal').modal()", true);
                    
                    
                }
                else if (e.CommandName == "Image2Click")
                { 
                        string imageRelativeUrl = ((System.Web.UI.WebControls.Image)e.Item.FindControl("ImageButton1")).ImageUrl;
                     
                        string imageUrl = ResolveClientUrl(imageRelativeUrl); // تأكد أن المسار جاهز للعرض في المتصفح

                        string js = $@"
        document.getElementById('modalImage').src = '{imageUrl}';
        var modalElement = new bootstrap.Modal(document.getElementById('imageModal'));
        modalElement.show();";

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowImageModal", js, true);
                     


                }
                else if (e.CommandName == "Image3Click")
                {
                    string imageRelativeUrl = ((System.Web.UI.WebControls.Image)e.Item.FindControl("ImageButton2")).ImageUrl;

                    string imageUrl = ResolveClientUrl(imageRelativeUrl); // تأكد أن المسار جاهز للعرض في المتصفح

                    string js = $@"
        document.getElementById('modalImage').src = '{imageUrl}';
        var modalElement = new bootstrap.Modal(document.getElementById('imageModal'));
        modalElement.show();";

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowImageModal", js, true);



                }

                else if (e.CommandName == "Image4Click")
                {
                    string imageRelativeUrl = ((System.Web.UI.WebControls.Image)e.Item.FindControl("ImageButton3")).ImageUrl;

                    string imageUrl = ResolveClientUrl(imageRelativeUrl); // تأكد أن المسار جاهز للعرض في المتصفح

                    string js = $@"
        document.getElementById('modalImage').src = '{imageUrl}';
        var modalElement = new bootstrap.Modal(document.getElementById('imageModal'));
        modalElement.show();";

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowImageModal", js, true);



                }
            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }

        }


        protected void btnUploadAdmin_Click(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {
                Button btn = (Button)sender;
                ListViewDataItem item = (ListViewDataItem)btn.NamingContainer;

                FileUpload fileUpload = (FileUpload)item.FindControl("fuAdminImage");
                HiddenField hiddenId = (HiddenField)item.FindControl("hiddenId");

                if (fileUpload != null && fileUpload.HasFile && hiddenId != null)
                {
                    int id = int.Parse(hiddenId.Value);
                    string uploadsFolder = Server.MapPath("~/Uploads/chat");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    fileUpload.SaveAs(filePath);

                    // حفظ اسم الصورة في قاعدة البيانات في حقل مخصص للإدارة
                    string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        string query = "UPDATE Supporttables SET Image_ToAdmin = @ImageName WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ImageName", uniqueFileName);
                        cmd.Parameters.AddWithValue("@Id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    LoadComplaints("تم تحويلها للإدارة");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('تم رفع صورة الإدارة بنجاح.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('الرجاء اختيار صورة.');", true);
                }
            }
            else
            {
                Response.Redirect("/AdminShops/AL", false);
            }
        }

        protected void btnUploadProcessing_Click(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {
                Button btn = (Button)sender;
                ListViewDataItem item = (ListViewDataItem)btn.NamingContainer;

                FileUpload fileUpload = (FileUpload)item.FindControl("fuProcessing");
                HiddenField hiddenId = (HiddenField)item.FindControl("hiddenId"); // تأكد من وجود HiddenField فيه ID داخل كل عنصر

                if ( fileUpload.HasFile )
                {
                    int id = int.Parse(hiddenId.Value);
                    string uploadsFolder = Server.MapPath("~/Uploads/chat");
                   
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    fileUpload.SaveAs(filePath);

                    // حفظ اسم الصورة في قاعدة البيانات
                    string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        string query = "UPDATE Supporttables SET Image_path = @Image_path WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Image_path", uniqueFileName);
                        cmd.Parameters.AddWithValue("@Id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // تحديث العرض
                    LoadComplaints("تحت المعالجة");

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('تم رفع الصورة بنجاح.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('الرجاء اختيار صورة.');", true);
                }
            }
            else
            {
                Response.Redirect("/AdminShops/AL", false);
            }
        }

        // تحديث حالة الشكوى
        private void UpdateComplaintStatus(int id, string status ,string Date_and_time_StartProcess ,string User_StartProcess
            , string Date_and_time_ToAdmins
            , string Action_ToAdmins
            , string Note_ToAdmins
             , string User_ToAdminss

            , string Date_and_time_Completes
            , string Action_Completes
            , string Note_Completes
            , string User_Completes
            
            )
        {
 

            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                
                if (status=="تحت المعالجة")
                {
                    string query = "UPDATE Supporttables SET SupNot = @SupNot, Date_and_time_StartProcess = @Date_and_time_StartProcess, User_StartProcess = @User_StartProcess WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SupNot", status);
                    cmd.Parameters.AddWithValue("@Date_and_time_StartProcess", Date_and_time_StartProcess);
                    cmd.Parameters.AddWithValue("@User_StartProcess", User_StartProcess); 
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                else if(status == "منتهية")
                { 
                    string query = "UPDATE Supporttables SET SupNot = @SupNot, Date_and_time_Complete = @Date_and_time_Complete, Action_Complete = @Action_Complete  , Note_Complete = @Note_Complete , User_Complete = @User_Complete   WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SupNot", status);
                    cmd.Parameters.AddWithValue("@Date_and_time_Complete", Date_and_time_Completes);
                    cmd.Parameters.AddWithValue("@Action_Complete", Action_Completes);
                    cmd.Parameters.AddWithValue("@Note_Complete", Note_Completes);
                    cmd.Parameters.AddWithValue("@User_Complete", User_Completes);
           
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery(); 
                   
                }
                else if (status == "تم تحويلها للإدارة")
                {
                    string query = "UPDATE Supporttables SET SupNot = @SupNot, Date_and_time_ToAdmin = @Date_and_time_ToAdmin, Action_ToAdmin = @Action_ToAdmin  , Note_ToAdmin = @Note_ToAdmin  ,User_ToAdmins = @User_ToAdmins  WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SupNot", status);
                    cmd.Parameters.AddWithValue("@Date_and_time_ToAdmin", Date_and_time_ToAdmins);
                    cmd.Parameters.AddWithValue("@Action_ToAdmin", Action_ToAdmins);
                    cmd.Parameters.AddWithValue("@Note_ToAdmin", Note_ToAdmins);
                    cmd.Parameters.AddWithValue("@User_ToAdmins", User_ToAdminss);
                   
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                 
                
               


             






            }
        }


        //// تحميل الشكاوى بدون تصفية (عند أول تحميل الصفحة أو في حالة إعادة تعيين الفلاتر)
        //private void LoadComplaints()
        //{
        //    string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    string query = "SELECT TOP(10) * FROM Supporttables"; // الاستعلام بدون تصفية
        //    SqlDataSource sqlDataSource = new SqlDataSource
        //    {
        //        ConnectionString = strcon, // ضع هنا سلسلة الاتصال الخاصة بك
        //        SelectCommand = query
        //    };

        //    // ربط البيانات بـ ListView
        //    ListView12.DataSource = sqlDataSource;
        //    ListView12.DataBind();
        //}







        //// تحميل الشكاوى بناءً على حالة الفلترة المحددة
        //protected void FilterComplaints(object sender, EventArgs e)
        //{
        //    // الحصول على قيمة الزر الذي تم النقر عليه (يعني حالة الشكوى)
        //    string status = (sender as Button).CommandArgument;
        //    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    // الاتصال بقاعدة البيانات 

        //    string query = "SELECT TOP(30)  * FROM Supporttables WHERE SupNot = @Status"; // استعلام SQL مع المتغير = "SELECT TOP(10) * FROM Supporttables WHERE SupNot = @Status";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@Status", status); // تعيين المتغير @Status

        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        // هنا يمكن استخدام reader لعرض البيانات أو تمريرها إلى DataSource
        //        ListView12.DataSource = reader;
        //        ListView12.DataBind();
        //    }
        //}


        //protected void ListView12_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListViewItemType.DataItem)
        //    {
        //        var status = DataBinder.Eval(e.Item.DataItem, "SupNot").ToString();
        //        var badge = e.Item.FindControl("statusBadge") as System.Web.UI.WebControls.Label;

        //        // تعيين الفئة المناسبة بناءً على الحالة
        //        if (badge != null)
        //        {
        //            badge.CssClass = GetStatusClass(status);
        //        }
        //    }
        //}

        // دالة لتحديث حالة الشكوى في قاعدة البيانات
        //protected void Button33_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int complaintId = Convert.ToInt32(btn.CommandArgument); // أخذ ID الشكوى من زر الضغط
        //    TextBox txtNote = (TextBox)btn.NamingContainer.FindControl("txtNote"); // العثور على مربع النص الخاص بالشكوى
        //    string note = txtNote.Text; // الحصول على الملاحظة المكتوبة

        //    // تحديث حالة الشكوى والملاحظة في قاعدة البيانات
        //    UpdateComplaintStatus(complaintId, note);

        //}

        //protected void btnProcessComplaint_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    string complaintId = btn.CommandArgument;

        //    // ابحث عن TextBox الموجود في نفس العنصر
        //    ListViewItem item = (ListViewItem)btn.NamingContainer;
        //    TextBox txtNote = (TextBox)item.FindControl("txtNote");

        //    string note = txtNote.Text;
        //    UpdateComplaintStatus(complaintId, note);

        //}


        //// دالة لتحديث حالة الشكوى في قاعدة البيانات
        //private void UpdateComplaintStatus(string complaintId, string note)
        //{

        //    string notenew = "" + note;


        //    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    string query = "SELECT TOP(30)  * FROM Supporttables WHERE SupNot = @Status";
        //    string updateQuery = "UPDATE Supporttables SET SupNot = 'processing', Supsubject = @Note WHERE Id = @Id";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(updateQuery, conn);
        //        cmd.Parameters.AddWithValue("@Id", complaintId);
        //        cmd.Parameters.AddWithValue("@Note", note);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }

        //    // إعادة تحميل البيانات لتحديث الـ ListView
        //   BindData();
        //}

        // تهيئة حالة الشكوى لتغيير اللون
        //protected string GetStatusClass(string status)
        //{
        //    switch (status.ToLower())
        //    {
        //        case "لا يوجد اي ملاحظة":
        //            return "badge-warning";
        //        case "processing":
        //            return "badge-info";
        //        case "transferred":
        //            return "badge-primary";
        //        case "completed":
        //            return "badge-success";
        //        default:
        //            return "badge-secondary";
        //    }
        //}


        protected void ListView4_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            // set current page startindex,max rows and rebind to false  
            DataPager2.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);



            List<Order> blogs = DataAccess.Instance.GetOrders2();


            //  where b.LocalYY.StartsWith(xxxxx) && b.LocalXX.StartsWith(yyyyy) || b.LocalYY.StartsWith("25") && b.LocalXX.StartsWith(yyyyy)

            MultiView1.ActiveViewIndex = 1;


            ListView4.DataSource = blogs;
            ListView4.DataBind();
        }

        protected void ListView5_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {// set current page startindex,max rows and rebind to false  
            DataPager3.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            List<Order> blogs = DataAccess.Instance.GetOrdersByGetAccepet();
            MultiView1.ActiveViewIndex = 2;




            ListView5.DataSource = blogs;
            ListView5.DataBind();

        }

        protected void ListView6_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            // set current page startindex,max rows and rebind to false  
            DataPager4.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            List<Order> blogs = DataAccess.Instance.GetOrdersByGetGet();

            //  where b.LocalYY.StartsWith(xxxxx) && b.LocalXX.StartsWith(yyyyy) || b.LocalYY.StartsWith("25") && b.LocalXX.StartsWith(yyyyy)
            //*
            MultiView1.ActiveViewIndex = 4;




            ListView6.DataSource = blogs;
            ListView6.DataBind();
        }

        protected void ListView7_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void ListView8_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }



        protected void Button773_Command(object sender, CommandEventArgs e)
        {
            int INNss = int.Parse(e.CommandName);


            try
            {

                Label32.Text = INNss.ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalADDBillPrice", "$('#logoutModalADDBillPrice').modal()", true);


            }
            catch
            {

            }
        }

        protected void Button22_Click(object sender, EventArgs e)
        {


            string name = Session["ANUser"].ToString();
            UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
            if (UserRoleDonesc != null)
            {

                if (UserRoleDonesc.ADDData == "0")
                {
                    // Button1Save.Visible = false;
                    // ButtonAccountsCompnyShop.Visible = false;


                }
                if (UserRoleDonesc.EditData == "0")
                {

                }
                else
                {
                    int INNsscccc = int.Parse(Label32.Text);

                    Order orderr = DataAccess.Instance.GetOrdersID(INNsscccc);

                    if (TextBox11.Text == "Aa2022")
                    {
                        if (orderr.IdBosh == 43)
                        {

                            orderr.NoteBosh = "true";
                            orderr.ReadyBosh = "ready";
                            orderr.ReceivedDriver = "true";
                            orderr.TimeAccsptReceivedDriver = DateTime.Now.ToString("HH:mm");
                            try
                            {

                                orderr.Arrived = name + "اصدار فاتورة فزعة" + DateTime.Now.ToString("HH:mm:ss");

                            }
                            catch
                            {

                            }
                            double PricToT = double.Parse(TextBox10.Text) + double.Parse(orderr.PricepackagAfter);

                            orderr.TotalPrice = PricToT.ToString();




                            try
                            {

                                SqlParameter[] sqlpr = new SqlParameter[37];
                                sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                                sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                                sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                                sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                                sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                                sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                                sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                                sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                                sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                                sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                                sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                                sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                                sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                                sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                                sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                                sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                                sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                                sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                                sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                                sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                                sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                                sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                                sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                                sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                                sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                                sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                                sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                                sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                                sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                                sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                                sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                                sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                                sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                                sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);

                                sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                                sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                                sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                                int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);




                            }
                            catch
                            {

                            }

                            // dbContexts.Entry(orderr).State = EntityState.Modified;


                            try
                            {

                                //dbContexts.SaveChanges();


                                try
                                {

                                    CustomerData CCCustomerData = DataAccess.Instance.Getcustomer(orderr.IdCustomer);
                                    double Tooo = 0;
                                    Tooo = double.Parse(orderr.TotalPrice) - double.Parse(orderr.DeliveryPrice);

                                    Task.Run(async () =>
                                    {
                                        try
                                        {
                                            await new FMCnofication().sendnofication("تنوية", "مندوبنا اصدر فاتورة بمبلغ " + Tooo.ToString() + "وتم استلام الطلب", CCCustomerData.FirebaseToken, "client");

                                        }
                                        catch
                                        {

                                        }

                                    });
                                }
                                catch
                                {
                                }
                            }
                            catch
                            {
                            }


                            //  where b.LocalYY.StartsWith(xxxxx) && b.LocalXX.StartsWith(yyyyy) || b.LocalYY.StartsWith("25") && b.LocalXX.StartsWith(yyyyy)

                            MultiView1.ActiveViewIndex = 2;

                            Response.Redirect("/AdminShops/OrdersTow.aspx", false);


                        }


                    }
                    else
                    {
                        TextBox11.Text = "";
                        TextBox10.Text = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                    }

                }
                if (UserRoleDonesc.SecetcData == "1")
                {


                }
                else
                {
                    Response.Redirect("/AdminShops/Admin", false);
                }

                if (UserRoleDonesc.DeledtData == "0")
                {


                }


            }
            else
            {
                Response.Redirect("/AdminShops/Admin", false);
            }












        }


        protected void Button23_Command(object sender, CommandEventArgs e)
        {

            int INNss = int.Parse(e.CommandName);

            //  List<Order> Billscccssss = DataAccess.Instance.GetOrdersIDList(INNss);
            try
            {
                Label15.Text = INNss.ToString();
                Label16.Text = INNss.ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalConselOrderSusses", "$('#logoutModalConselOrderSusses').modal()", true);


            }
            catch
            {

            }


        }

        protected void Button27_Click(object sender, EventArgs e)
        {
            string name = Session["ANUser"].ToString();
            UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
            if (UserRoleDonesc != null)
            {

                if (UserRoleDonesc.ADDData == "0")
                {
                    // Button1Save.Visible = false;
                    // ButtonAccountsCompnyShop.Visible = false;


                }
                if (UserRoleDonesc.EditData == "0")
                {

                }
                else
                {
                    int INNsscccc = int.Parse(Label16.Text);


                    if (TextBox13.Text == "Aa2022")
                    {


                        int YesorNo = 0;

                        try
                        {
                            Order order = DataAccess.Instance.GetOrders(Label16.Text);
                            order.ReceivedDriver = "true";
                            order.YESORNODriver = "yes";
                            order.TimeAccsptReceivedDriver = DateTime.Now.ToString("HH:mm");
                            order.TimeDriver = DateTime.Now.ToString("HH:mm");
                            order.DateAccsptReceivedDriver = DateTime.Now.ToString("yyyy:MM:dd");
                            order.ReadyBosh = "ready";
                            order.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");
                            order.DateAccsptReadyBosh = DateTime.Now.ToString("yyyy:MM:dd");




                            try
                            {
                                int isso = AddAcountToShopnEW(order);

                                if (isso > 0)
                                {
                                    try
                                    {

                                        SqlParameter[] sqlpr = new SqlParameter[37];
                                        sqlpr[0] = new SqlParameter("@Id", order.Id);
                                        sqlpr[1] = new SqlParameter("@DeliveryPrices", order.DeliveryPrice);
                                        sqlpr[2] = new SqlParameter("@TotalPrices", order.TotalPrice);
                                        sqlpr[3] = new SqlParameter("@StreetThoroughfares", order.StreetThoroughfare);

                                        sqlpr[4] = new SqlParameter("@PaymentStatuss", order.PaymentStatus);
                                        sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", order.PaymentProcessNumber);
                                        sqlpr[6] = new SqlParameter("@StatusDrivers", order.StatusDriver);
                                        sqlpr[7] = new SqlParameter("@IDDrivers", order.IDDriver);
                                        sqlpr[8] = new SqlParameter("@Cashs", order.Cash);

                                        sqlpr[9] = new SqlParameter("@PaymentAmounts", order.PaymentAmount);
                                        sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", order.PaymentCardStartEnd);
                                        sqlpr[11] = new SqlParameter("@Paymentcodesss", order.Paymentcodess);
                                        sqlpr[12] = new SqlParameter("@IdcahckWalltss", order.IdcahckWallts);
                                        sqlpr[13] = new SqlParameter("@cahckWalltss", order.cahckWallts);
                                        sqlpr[14] = new SqlParameter("@PricePshWalltss", order.PricePshWallts);

                                        sqlpr[15] = new SqlParameter("@CobenNumbers", order.CobenNumber);
                                        sqlpr[16] = new SqlParameter("@CobenPrices", order.CobenPrice);

                                        sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", order.TimeAccsptReceivedDriver);
                                        sqlpr[18] = new SqlParameter("@TimeDrivers", order.TimeDriver);
                                        sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", order.DateAccsptReceivedDriver);
                                        sqlpr[20] = new SqlParameter("@ReadyBoshs", order.ReadyBosh);
                                        sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", order.TimeAccsptBosh);
                                        sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", order.DateAccsptReadyBosh);

                                        sqlpr[23] = new SqlParameter("@DataOrders", order.DataOrder);
                                        sqlpr[24] = new SqlParameter("@TimeOrders", order.TimeOrder);
                                        sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", order.TimeAccsptDriver);
                                        sqlpr[26] = new SqlParameter("@NoteReadyBoshs", order.NoteReadyBosh);
                                        sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", order.TimeAccsptReadyBosh);
                                        sqlpr[28] = new SqlParameter("@ReceivedDrivers", order.ReceivedDriver);
                                        sqlpr[29] = new SqlParameter("@NotCancelOrders", order.NotCancelOrder);
                                        sqlpr[30] = new SqlParameter("@StatusBoshs", order.StatusBosh);
                                        sqlpr[31] = new SqlParameter("@CancelOrders", order.CancelOrder);
                                        sqlpr[32] = new SqlParameter("@Arriveds", order.Arrived);
                                        sqlpr[33] = new SqlParameter("@TimeArriveds", order.TimeArrived);

                                        sqlpr[34] = new SqlParameter("@NoteBoshs", order.NoteBosh);
                                        sqlpr[35] = new SqlParameter("@YESORNODrivers", order.YESORNODriver);
                                        sqlpr[36] = new SqlParameter("@Notes", order.Note);

                                        int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);
                                        // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);

                                    }
                                    catch
                                    {

                                    }
                                    YesorNo = 1;
                                    Response.Redirect("/AdminShops/OrdersTow.aspx", false);
                                }
                                else
                                {
                                    YesorNo = 0;
                                }



                            }
                            catch
                            {
                                YesorNo = 0;
                            }



                        }
                        catch
                        {
                            YesorNo = 0;

                        }


                    }
                    else
                    {
                        TextBox12.Text = "";

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                    }




                }
                if (UserRoleDonesc.SecetcData == "1")
                {


                }
                else
                {
                    Response.Redirect("/AdminShops/Admin", false);
                }

                if (UserRoleDonesc.DeledtData == "0")
                {


                }


            }
            else
            {
                Response.Redirect("/AdminShops/Admin", false);
            }
        }



        public int AddAcountToShopnEW(Order MyOrders)
        {

            int iiis = 0;
            try
            {


                ShopAccount obj = DataAccess.Instance.OstShopAccounts(MyOrders.Id);
                if (obj == null)
                {
                    ShopAccount AddShopAccount = new ShopAccount();

                    if (MyOrders.Cash == "true")
                    {
                        AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                        AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");
                        AddShopAccount.IdShop = MyOrders.IdBosh;
                        AddShopAccount.IdOrderShop = MyOrders.Id;
                        AddShopAccount.NoteFiveShop = MyOrders.Id.ToString();


                        if (MyOrders.CobenPrice != null)
                        {
                            if (MyOrders.CobenPrice != "0")
                            {
                                AddShopAccount.NumberCobon = MyOrders.CobenNumber;
                                AddShopAccount.PricCobon = MyOrders.CobenPrice;

                            }
                            else
                            {
                                AddShopAccount.NumberCobon = "لا يوجد";
                                AddShopAccount.PricCobon = "0";

                            }

                        }
                        else
                        {//  [Display(Name = "رقم الكوبون")]
                            AddShopAccount.NumberCobon = "لا يوجد";
                            AddShopAccount.PricCobon = "0";

                        }

                        AddShopAccount.NotesShop = "تم أضافة عملية دفع عند الاستلام ولقد استلمت المبلغ من السائق";

                        if (MyOrders.FreeDriveriv == "true")
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل مجاني";
                            AddShopAccount.PricFree = "0";

                        }
                        else
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل غير مجاني";
                            // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
                            AddShopAccount.PricFree = "0";

                        }

                        try
                        {


                            AddShopAccount.PricBill = MyOrders.TotalPrice;


                        }
                        catch
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;
                        }

                        AddShopAccount.TrueOrfalseIdOrdersShop = "true";
                        AddShopAccount.TrueOrfalseMonysShop = "true";

                        AddShopAccount.NoteThreeShop = "ic_action_monetization_on.png";

                        // [Display(Name = "خذ من السائق ")

                        double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                        AddShopAccount.MonyTotalCostmerShop = MonyTotalCostmerShopss;

                        UserShopBoshesArEn UserShopBoshscc = DataAccess.Instance.GetBoshOffse(MyOrders.IdBosh);

                        if (UserShopBoshscc.Percentage > 0)
                        {
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;
                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;

                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;
                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }

                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");


                            AddShopAccount.IdPricepackagShop = 0;

                            //double Discoun = 0;
                            //try
                            //{
                            //    Discoun = double.Parse(AddShopAccount.PricCobon);

                            //}
                            //catch
                            //{

                            //}

                            AddShopAccount.IdPriceShop = pricBoshAfterDescount + TAXs;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;


                        }
                        else
                        {


                            List<PercentageShop> PercentageShopss = DataAccess.Instance.GetOPercentageShop();
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);



                            double pricBoshAfterDescount = PercentageShopss.First().CountPercentageShop * pricBosh / 100;
                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;

                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");

                            AddShopAccount.IdPricepackagShop = 0;

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }

                            AddShopAccount.IdPriceShop = pricBoshAfterDescount + TAXs;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;


                        }



                    }
                    else
                    {
                        AddShopAccount.IdShop = MyOrders.IdBosh;
                        AddShopAccount.IdOrderShop = MyOrders.Id;
                        AddShopAccount.NoteFiveShop = MyOrders.Id.ToString();
                        AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                        AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");


                        if (MyOrders.CobenPrice != null)
                        {
                            if (MyOrders.CobenPrice != "0")
                            {
                                AddShopAccount.NumberCobon = MyOrders.CobenNumber;
                                AddShopAccount.PricCobon = MyOrders.CobenPrice;

                            }
                            else
                            {
                                AddShopAccount.NumberCobon = "لا يوجد";
                                AddShopAccount.PricCobon = "0";

                            }

                        }
                        else
                        {//  [Display(Name = "رقم الكوبون")]
                            AddShopAccount.NumberCobon = "لا يوجد";
                            AddShopAccount.PricCobon = "0";

                        }

                        try
                        {

                            AddShopAccount.PricBill = MyOrders.TotalPrice;


                        }
                        catch
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;
                        }

                        AddShopAccount.NotesShop = "تم أضافة عملية دفع الكترونية ";

                        if (MyOrders.FreeDriveriv == "true")
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل مجاني";
                            AddShopAccount.PricFree = "0";

                        }
                        else
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل غير مجاني";
                            // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
                            AddShopAccount.PricFree = "0";

                        }


                        AddShopAccount.TrueOrfalseIdOrdersShop = "true";
                        AddShopAccount.TrueOrfalseMonysShop = "false";

                        AddShopAccount.NoteThreeShop = "ic_action_subtitles.png";
                        // [Display(Name = "خذ من السائق ")
                        double MonyTotalCostmerShopssaaa = Convert.ToDouble(AddShopAccount.PricBill);
                        AddShopAccount.MonyTotalCostmerShop = MonyTotalCostmerShopssaaa;

                        UserShopBoshesArEn UserShopBoshscc = DataAccess.Instance.GetBoshOffse(MyOrders.IdBosh);


                        if (UserShopBoshscc.Percentage > 0)
                        {
                            double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;

                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;


                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }

                            AddShopAccount.IdPricepackagShop = pricBosh - pricBoshAfterDescount - TAXs - Discoun;
                            AddShopAccount.IdPriceShop = 0;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;
                        }
                        else
                        {
                            List<PercentageShop> PercentageShopss = DataAccess.Instance.GetOPercentageShop();
                            double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = PercentageShopss.First().CountPercentageShop * pricBosh / 100;


                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;


                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");
                            AddShopAccount.IdPricepackagShop = pricBosh - pricBoshAfterDescount - TAXs - Discoun;
                            AddShopAccount.IdPriceShop = 0;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;

                        }





                    }


                    try
                    {
                        SqlParameter[] sqlprD = new SqlParameter[24];
                        sqlprD[0] = new SqlParameter("@IdShopx", AddShopAccount.IdShop);
                        sqlprD[1] = new SqlParameter("@IdOrderShopx", AddShopAccount.IdOrderShop);
                        sqlprD[2] = new SqlParameter("@IdPricepackagShopx", AddShopAccount.IdPricepackagShop);
                        sqlprD[3] = new SqlParameter("@IdPriceShopx", AddShopAccount.IdPriceShop);
                        sqlprD[4] = new SqlParameter("@AccountsCompnyShopx", AddShopAccount.AccountsCompnyShop);
                        sqlprD[5] = new SqlParameter("@DatesShopx", AddShopAccount.DatesShop);
                        sqlprD[6] = new SqlParameter("@TimesShopx", AddShopAccount.TimesShop);
                        sqlprD[7] = new SqlParameter("@NotesShopx", AddShopAccount.NotesShop);
                        sqlprD[8] = new SqlParameter("@NoteTowsShopx", AddShopAccount.NoteTowsShop);
                        sqlprD[9] = new SqlParameter("@NoteThreeShopx", AddShopAccount.NoteThreeShop);
                        sqlprD[10] = new SqlParameter("@MonyTotalCostmerShopx", AddShopAccount.MonyTotalCostmerShop);
                        sqlprD[11] = new SqlParameter("@MonyShopShopx", AddShopAccount.MonyShopShop);
                        sqlprD[12] = new SqlParameter("@MonyCompenyShopx", AddShopAccount.MonyCompenyShop);
                        sqlprD[13] = new SqlParameter("@TrueOrfalseIdOrdersShopx", AddShopAccount.TrueOrfalseIdOrdersShop);
                        sqlprD[14] = new SqlParameter("@TrueOrfalseMonysShopx", AddShopAccount.TrueOrfalseMonysShop);
                        sqlprD[15] = new SqlParameter("@NoteFourShopx", AddShopAccount.NoteFourShop);
                        sqlprD[16] = new SqlParameter("@NoteFiveShopx", AddShopAccount.NoteFiveShop);
                        sqlprD[17] = new SqlParameter("@NoteSexShopx", AddShopAccount.NoteSexShop);
                        sqlprD[18] = new SqlParameter("@DesAccountsCompnyShopx", AddShopAccount.DesAccountsCompnyShop);
                        sqlprD[19] = new SqlParameter("@PricBillx", AddShopAccount.PricBill);
                        sqlprD[20] = new SqlParameter("@PricFreex", AddShopAccount.PricFree);
                        sqlprD[21] = new SqlParameter("@NumberCobonx", AddShopAccount.NumberCobon);
                        sqlprD[22] = new SqlParameter("@PricCobonx", AddShopAccount.PricCobon);
                        sqlprD[23] = new SqlParameter("@NoteBillx", AddShopAccount.NoteBill);

                        int ibbc = ExecuteNonQueryADD(CommandType.StoredProcedure, "sp_AddShopAccounts", sqlprD);
                        iiis = ibbc;
                    }
                    catch
                    {

                    }


                }
                else
                {
                    iiis = 1;
                }

            }
            catch
            {

            }
            return iiis;
        }
        protected void Button26Auto_Click(object sender, EventArgs e)
        {

        }




        protected void Button5544_Command(object sender, CommandEventArgs e)
        {

            int INNss = int.Parse(e.CommandName);

            List<Order> Billscccssss = DataAccess.Instance.GetOrdersIDList(INNss);
            try
            {
                Label13.Text = INNss.ToString();
                Label14.Text = INNss.ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalConselOrderNew", "$('#logoutModalConselOrderNew').modal()", true);

            }
            catch
            {

            }


        }

        protected void Button27df_Click(object sender, EventArgs e)
        {
            string name = Session["ANUser"].ToString();
            UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
            if (UserRoleDonesc != null)
            {

                if (UserRoleDonesc.ADDData == "0")
                {
                    // Button1Save.Visible = false;
                    // ButtonAccountsCompnyShop.Visible = false;


                }
                if (UserRoleDonesc.EditData == "0")
                {

                }
                else
                {
                    int INNsscccc = int.Parse(Label13.Text);

                    Order orderr = DataAccess.Instance.GetOrdersID(INNsscccc);
                    if (TextBox12.Text == "Aa2022")
                    {


                        if (orderr.StatusBosh == "false")
                        {
                            orderr.StatusBosh = "new";
                            orderr.ReadyBosh = "new";
                            orderr.NoteReadyBosh = "new";
                            orderr.YESORNODriver = "new";
                            orderr.ReceivedDriver = "new";

                            if (orderr.IdBosh == 43)
                            {
                                orderr.NoteBosh = "new";
                            }



                            if (orderr.DeliveryPrice == "0")
                            {
                                if (orderr.PricepackagDriver == "0")
                                {
                                    orderr.Note = "new";
                                }

                            }

                        }


                        if (orderr.StatusDriver == "false")
                        {
                            if (orderr.IDDriver > 0)
                            {
                                orderr.StatusDriver = "true";

                            }
                            else
                            {


                                orderr.StatusDriver = "new";

                                if (orderr.DeliveryPrice == "0")
                                {
                                    if (orderr.PricepackagDriver == "0")
                                    {
                                        orderr.StatusDriver = "newdriver";
                                    }

                                }




                            }

                        }
                        if (orderr.CancelOrder == "true")
                        {
                            orderr.CancelOrder = "";
                        }



                        try
                        {
                            orderr.Arrived = name;

                        }
                        catch
                        {

                        }




                        // PutOrderSSSS(INNsscccc, orderr);

                        // dbContexts.Entry(orderr).State = EntityState.Modified;
                        // dbContexts.SaveChanges();
                        try
                        {

                            SqlParameter[] sqlpr = new SqlParameter[37];
                            sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                            sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                            sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                            sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                            sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                            sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                            sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                            sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                            sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                            sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                            sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                            sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                            sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                            sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                            sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                            sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                            sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                            sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                            sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                            sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                            sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                            sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                            sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                            sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                            sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                            sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                            sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                            sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                            sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                            sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                            sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                            sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                            sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                            sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);
                            // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                            sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                            sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                            sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                            int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);
                        }
                        catch
                        {

                        }


                        Response.Redirect("/AdminShops/OrdersTow.aspx", false);

                    }
                    else
                    {
                        TextBox12.Text = "";

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                    }




                }
                if (UserRoleDonesc.SecetcData == "1")
                {


                }
                else
                {
                    Response.Redirect("/AdminShops/Admin", false);
                }

                if (UserRoleDonesc.DeledtData == "0")
                {


                }


            }
            else
            {
                Response.Redirect("/AdminShops/Admin", false);
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int ids = int.Parse(TextBox14.Text);
                List<Order> blogs = DataAccess.Instance.GetOrdOrderid(ids);
                //*
                MultiView1.ActiveViewIndex = 7;

                ListView2.DataSource = blogs;
                ListView2.DataBind();

            }
            catch
            {

            }

        }



        protected void Button31_Command(object sender, CommandEventArgs e)
        {
            int INNss = int.Parse(e.CommandName);

            Order Billscccssss = DataAccess.Instance.GetOrdersID(INNss);
            try
            {
                if (Billscccssss.PaymentStatus == "true")
                {


                    Label51.Text = Billscccssss.Id.ToString();


                    string xx = Billscccssss.PaymentProcessNumber;
                    string res = xx.Substring(0, 1);

                    if (res != "*")
                    {
                        Label52.Text = Billscccssss.PaymentProcessNumber;
                        TextBox16.Text = Billscccssss.TotalPrice;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutrefund", "$('#logoutrefund').modal()", true);

                    }
                    else
                    {



                    }






                }
            }
            catch
            {

            }
        }

        protected void Button30_Click(object sender, EventArgs e)
        {

            string name = Session["ANUser"].ToString();
            UserRoleDone UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "OrdersTow");
            if (UserRoleDonesc != null)
            {

                if (UserRoleDonesc.ADDData == "0")
                {
                    // Button1Save.Visible = false;
                    // ButtonAccountsCompnyShop.Visible = false;


                }
                if (UserRoleDonesc.EditData == "0")
                {

                }
                else
                {

                    if (TextBox15.Text == "Aa2023")
                    {
                        if (Label52.Text != " ")
                        {
                            if (TextBox16.Text != " ")
                            {

                                Task.Run(async () =>
                                {
                                    using (var httpClient = new HttpClient())
                                    {
                                        using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://secure.telr.com/gateway/remote.xml"))
                                        {
                                            Remote remote = new Remote();
                                            remote.store = "25790";
                                            remote.key = "wGSKb-R4Pk~KLhH7";

                                            remote.tran = new Tran()
                                            {
                                                @type = "refund",
                                                @class = "ecom",
                                                currency = "SAR",
                                                amount = TextBox16.Text,
                                                @ref = Label52.Text,
                                                test = "0"

                                            };

                                            string xmldata = ToXML(remote);
                                            request.Content = new StringContent(xmldata);


                                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/xml");

                                            var response = await httpClient.SendAsync(request);
                                            var respStr = await response.Content.ReadAsStringAsync();


                                            DataSet ds = new DataSet();
                                            ds.ReadXml(new XmlTextReader(new StringReader(respStr)));

                                            if (ds.Tables.Count > 0)
                                            {
                                                string status = ds.Tables["auth"].Rows[0]["status"].ToString();
                                                if (status == "A")
                                                {
                                                    Order orderr = DataAccess.Instance.GetOrdersID(int.Parse(Label51.Text));
                                                    orderr.PaymentProcessNumber = "*" + orderr.PaymentProcessNumber;
                                                    // dbContexts.Entry(orderr).State = EntityState.Modified;
                                                    // dbContexts.SaveChanges();

                                                    SqlParameter[] sqlpr = new SqlParameter[6];
                                                    sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                                                    sqlpr[1] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                                                    sqlpr[2] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                                                    sqlpr[3] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                                                    sqlpr[4] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                                                    sqlpr[5] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);

                                                    int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrderTelrNumber", sqlpr);
                                                }


                                            }










                                        }
                                    }
                                });


                                Response.Redirect("/AdminShops/OrdersTow.aspx", false);
                            }
                            else
                            {
                                TextBox15.Text = "";

                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                            }
                        }
                        else
                        {
                            TextBox15.Text = "";

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                        }
                    }
                    else
                    {
                        TextBox15.Text = "";

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
                    }




                }
                if (UserRoleDonesc.SecetcData == "1")
                {


                }
                else
                {
                    Response.Redirect("/AdminShops/Admin", false);
                }

                if (UserRoleDonesc.DeledtData == "0")
                {


                }


            }
            else
            {
                Response.Redirect("/AdminShops/Admin", false);
            }






        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {
                List<Order> blogsnew = new List<Order>();

                List<Order> blogs = DataAccess.Instance.GetOrdersByGetAccepetDriver7();

                if (blogs.Count > 0)
                {
                    foreach (Order order in blogs)
                    {
                        string startTime = order.TimeAccsptBosh; // "7:00";
                        string endTime = DateTime.Now.ToString("HH:mm");

                        int muintsss = 12;
                        try
                        {
                            UserShopBoshesArEn ShopBoshex = DataAccess.Instance.GetBoshOffse(order.IdBosh);


                            if (!string.IsNullOrEmpty(ShopBoshex.Enabled1) && ShopBoshex.Enabled1 != "true")
                            {

                                try
                                {
                                    muintsss = int.Parse(ShopBoshex.Enabled1);
                                }
                                catch
                                {

                                }

                            }


                        }
                        catch
                        {

                        }

                        TimeSpan threeHours = new TimeSpan(0, muintsss, 0);
                        TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

                        //|| muintsss <= 12)

                        if (duration >= threeHours || duration.Ticks < 0)
                        {
                            blogsnew.Add(order);
                        }
                        else
                        {

                        }




                    }

                }



                //*
                MultiView1.ActiveViewIndex = 3;


                ListView10.DataSource = blogsnew;
                ListView10.DataBind();



            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {
                List<Order> blogsnew = new List<Order>();

                List<Order> blogs = DataAccess.Instance.GetOrdersByGetAccepet();

                if (blogs.Count > 0)
                {
                    foreach (Order order in blogs)
                    {
                        string startTime = order.TimeAccsptBosh; // "7:00";
                        string endTime = DateTime.Now.ToString("HH:mm");

                        int muintsss = 35;


                        TimeSpan threeHours = new TimeSpan(0, muintsss, 0);
                        TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

                        //|| muintsss <= 12)

                        if (duration >= threeHours || duration.Ticks < -35)
                        {
                            blogsnew.Add(order);
                        }
                        else
                        {

                        }




                    }

                }



                //@@@@@@
                MultiView1.ActiveViewIndex = 8;


                ListView11.DataSource = blogsnew;
                ListView11.DataBind();



            }
            else
            {

                Response.Redirect("/AdminShops/AL", false);
            }

        }
        //20234new30 5
        private int AddAcountToShopnew(Order MyOrders)
        {
            if (MyOrders.PaymentCardStartEnd == "Interpay")
            {
                MyOrders.Cash = "true";
                MyOrders.PaymentStatus = "false";

            }


            int uui = 0;

            try
            {
                ShopAccount obj = DataAccess.Instance.OstShopAccounts(MyOrders.Id);
                if (obj == null)
                {
                    ShopAccount AddShopAccount = new ShopAccount();
                    if (MyOrders.Cash == "true")
                    {
                        AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                        AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");
                        AddShopAccount.IdShop = MyOrders.IdBosh;
                        AddShopAccount.IdOrderShop = MyOrders.Id;
                        AddShopAccount.NoteFiveShop = MyOrders.Id.ToString();


                        if (MyOrders.CobenPrice != null)
                        {
                            if (MyOrders.CobenPrice != "0")
                            {
                                AddShopAccount.NumberCobon = MyOrders.CobenNumber;
                                AddShopAccount.PricCobon = MyOrders.CobenPrice;

                            }
                            else
                            {
                                AddShopAccount.NumberCobon = "لا يوجد";
                                AddShopAccount.PricCobon = "0";

                            }

                        }
                        else
                        {//  [Display(Name = "رقم الكوبون")]
                            AddShopAccount.NumberCobon = "لا يوجد";
                            AddShopAccount.PricCobon = "0";

                        }

                        AddShopAccount.NotesShop = "تم أضافة عملية دفع عند الاستلام ولقد استلمت المبلغ من السائق";

                        if (MyOrders.FreeDriveriv == "true")
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل مجاني";
                            AddShopAccount.PricFree = "0";

                        }
                        else
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل غير مجاني";
                            // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
                            AddShopAccount.PricFree = "0";

                        }

                        try
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;

                        }
                        catch
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;
                        }

                        AddShopAccount.TrueOrfalseIdOrdersShop = "true";
                        AddShopAccount.TrueOrfalseMonysShop = "true";

                        AddShopAccount.NoteThreeShop = "ic_action_monetization_on.png";

                        // [Display(Name = "خذ من السائق ")

                        double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                        AddShopAccount.MonyTotalCostmerShop = MonyTotalCostmerShopss;

                        UserShopBoshesArEn UserShopBoshscc = DataAccess.Instance.GetBoshOffse(MyOrders.IdBosh);

                        if (UserShopBoshscc.Percentage > 0)
                        {
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;
                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;

                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;
                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }

                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");


                            AddShopAccount.IdPricepackagShop = 0;

                            //double Discoun = 0;
                            //try
                            //{
                            //    Discoun = double.Parse(AddShopAccount.PricCobon);

                            //}
                            //catch
                            //{

                            //}


                            AddShopAccount.IdPriceShop = pricBoshAfterDescount + TAXs;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;


                        }
                        else
                        {


                            List<PercentageShop> PercentageShopss = DataAccess.Instance.GetOPercentageShop();
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);



                            double pricBoshAfterDescount = PercentageShopss.First().CountPercentageShop * pricBosh / 100;
                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;

                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");

                            AddShopAccount.IdPricepackagShop = 0;

                            //double Discoun = 0;
                            //try
                            //{
                            //    Discoun = double.Parse(AddShopAccount.PricCobon);

                            //}
                            //catch
                            //{

                            //}

                            AddShopAccount.IdPriceShop = pricBoshAfterDescount + TAXs;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;


                        }



                    }
                    else
                    {
                        AddShopAccount.IdShop = MyOrders.IdBosh;
                        AddShopAccount.IdOrderShop = MyOrders.Id;
                        AddShopAccount.NoteFiveShop = MyOrders.Id.ToString();
                        AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                        AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");


                        if (MyOrders.CobenPrice != null)
                        {
                            if (MyOrders.CobenPrice != "0")
                            {
                                AddShopAccount.NumberCobon = MyOrders.CobenNumber;
                                AddShopAccount.PricCobon = MyOrders.CobenPrice;

                            }
                            else
                            {
                                AddShopAccount.NumberCobon = "لا يوجد";
                                AddShopAccount.PricCobon = "0";

                            }

                        }
                        else
                        {//  [Display(Name = "رقم الكوبون")]
                            AddShopAccount.NumberCobon = "لا يوجد";
                            AddShopAccount.PricCobon = "0";

                        }

                        try
                        {


                            AddShopAccount.PricBill = MyOrders.TotalPrice;


                        }
                        catch
                        {
                            AddShopAccount.PricBill = MyOrders.TotalPrice;
                        }

                        AddShopAccount.NotesShop = "تم أضافة عملية دفع الكترونية ";

                        if (MyOrders.FreeDriveriv == "true")
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل مجاني";
                            AddShopAccount.PricFree = "0";

                        }
                        else
                        {
                            // [Display(Name = "هل التوصيل مجاني")]
                            AddShopAccount.NoteBill = "التوصيل غير مجاني";
                            // [Display(Name = "مبلغ الخصم من التوصيل المجاني")]
                            AddShopAccount.PricFree = "0";

                        }


                        AddShopAccount.TrueOrfalseIdOrdersShop = "true";
                        AddShopAccount.TrueOrfalseMonysShop = "false";

                        AddShopAccount.NoteThreeShop = "ic_action_subtitles.png";
                        // [Display(Name = "خذ من السائق ")
                        double MonyTotalCostmerShopssaaa = Convert.ToDouble(AddShopAccount.PricBill);
                        AddShopAccount.MonyTotalCostmerShop = MonyTotalCostmerShopssaaa;

                        UserShopBoshesArEn UserShopBoshscc = DataAccess.Instance.GetBoshOffse(MyOrders.IdBosh);


                        if (UserShopBoshscc.Percentage > 0)
                        {
                            double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = UserShopBoshscc.Percentage * pricBosh / 100;

                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;


                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }

                            AddShopAccount.IdPricepackagShop = pricBosh - pricBoshAfterDescount - TAXs - Discoun;
                            AddShopAccount.IdPriceShop = 0;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;
                        }
                        else
                        {
                            List<PercentageShop> PercentageShopss = DataAccess.Instance.GetOPercentageShop();
                            double MonyTotalCostmerShopss = Convert.ToDouble(AddShopAccount.PricBill);
                            double pricBosh = Convert.ToDouble(AddShopAccount.PricBill);

                            double pricBoshAfterDescount = PercentageShopss.First().CountPercentageShop * pricBosh / 100;


                            AddShopAccount.MonyShopShop = pricBosh - pricBoshAfterDescount;
                            AddShopAccount.MonyCompenyShop = pricBoshAfterDescount;


                            double pricTAX = 0;
                            double TAXs = 0;
                            try
                            {
                                AddShopAccount.NoteFourShop = pricBoshAfterDescount.ToString();
                                pricTAX = pricBoshAfterDescount / 100;
                                TAXs = pricTAX * 15;
                                AddShopAccount.NoteSexShop = TAXs.ToString();
                            }
                            catch
                            {

                            }

                            double Discoun = 0;
                            try
                            {
                                Discoun = double.Parse(AddShopAccount.PricCobon);

                            }
                            catch
                            {

                            }


                            AddShopAccount.DatesShop = DateTime.Now.ToString("yyyy:MM:dd");
                            AddShopAccount.TimesShop = DateTime.Now.ToString("HH:mm");
                            AddShopAccount.IdPricepackagShop = pricBosh - pricBoshAfterDescount - TAXs - Discoun;
                            AddShopAccount.IdPriceShop = 0;
                            AddShopAccount.AccountsCompnyShop = 0;
                            AddShopAccount.DesAccountsCompnyShop = 0;

                        }





                    }
                    try
                    {
                        ShopAccount obj2 = DataAccess.Instance.OstShopAccounts(MyOrders.Id);
                        if (obj2 == null)
                        {
                            SqlParameter[] sqlprD = new SqlParameter[24];
                            sqlprD[0] = new SqlParameter("@IdShopx", AddShopAccount.IdShop);
                            sqlprD[1] = new SqlParameter("@IdOrderShopx", AddShopAccount.IdOrderShop);
                            sqlprD[2] = new SqlParameter("@IdPricepackagShopx", AddShopAccount.IdPricepackagShop);
                            sqlprD[3] = new SqlParameter("@IdPriceShopx", AddShopAccount.IdPriceShop);
                            sqlprD[4] = new SqlParameter("@AccountsCompnyShopx", AddShopAccount.AccountsCompnyShop);
                            sqlprD[5] = new SqlParameter("@DatesShopx", AddShopAccount.DatesShop);
                            sqlprD[6] = new SqlParameter("@TimesShopx", AddShopAccount.TimesShop);
                            sqlprD[7] = new SqlParameter("@NotesShopx", AddShopAccount.NotesShop);
                            sqlprD[8] = new SqlParameter("@NoteTowsShopx", AddShopAccount.NoteTowsShop);
                            sqlprD[9] = new SqlParameter("@NoteThreeShopx", AddShopAccount.NoteThreeShop);
                            sqlprD[10] = new SqlParameter("@MonyTotalCostmerShopx", AddShopAccount.MonyTotalCostmerShop);
                            sqlprD[11] = new SqlParameter("@MonyShopShopx", AddShopAccount.MonyShopShop);
                            sqlprD[12] = new SqlParameter("@MonyCompenyShopx", AddShopAccount.MonyCompenyShop);
                            sqlprD[13] = new SqlParameter("@TrueOrfalseIdOrdersShopx", AddShopAccount.TrueOrfalseIdOrdersShop);
                            sqlprD[14] = new SqlParameter("@TrueOrfalseMonysShopx", AddShopAccount.TrueOrfalseMonysShop);
                            sqlprD[15] = new SqlParameter("@NoteFourShopx", AddShopAccount.NoteFourShop);
                            sqlprD[16] = new SqlParameter("@NoteFiveShopx", AddShopAccount.NoteFiveShop);
                            sqlprD[17] = new SqlParameter("@NoteSexShopx", AddShopAccount.NoteSexShop);
                            sqlprD[18] = new SqlParameter("@DesAccountsCompnyShopx", AddShopAccount.DesAccountsCompnyShop);
                            sqlprD[19] = new SqlParameter("@PricBillx", AddShopAccount.PricBill);
                            sqlprD[20] = new SqlParameter("@PricFreex", AddShopAccount.PricFree);
                            sqlprD[21] = new SqlParameter("@NumberCobonx", AddShopAccount.NumberCobon);
                            sqlprD[22] = new SqlParameter("@PricCobonx", AddShopAccount.PricCobon);
                            sqlprD[23] = new SqlParameter("@NoteBillx", AddShopAccount.NoteBill);

                            int ibbc = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_AddShopAccounts", sqlprD);
                            uui = ibbc;
                        }
                    }
                    catch
                    {

                    }

                }
                else
                {
                    uui = 1;
                }
            }
            catch
            {

            }
            return uui;

        }

        private int AddDrivernew(Order order)
        {
            int iuu = 0;
            try
            {
                // var obj = db.DriverAccounts.Where(a => a.IdOrder.Equals(order.Id)).FirstOrDefault();
                DriverAccounts obj = DataAccess.Instance.OstDriverAccounts(order.Id);
                if (obj == null)
                {
                    if (order.Cash == "true")
                    {
                        try
                        {
                            DriverAccounts driverAccounts = new DriverAccounts();
                            driverAccounts.IdDriver = order.IDDriver;
                            driverAccounts.IdOrder = order.Id;
                            driverAccounts.NoteSex = order.Id.ToString();
                            driverAccounts.Type = "Cash";

                            driverAccounts.TrueOrfalseIdOrders = "true";
                            driverAccounts.TrueOrfalseMonys = "true";

                            driverAccounts.NoteThree = "ic_action_monetization_on.png";


                            //40                              //30                                   //10
                            double tote = Convert.ToDouble(order.TotalPrice) + Convert.ToDouble(order.DeliveryPrice);



                            //3        
                            driverAccounts.MonyTotalCostmer = tote - Convert.ToDouble(order.CobenPrice);


                            //27                                           //30                                 //3
                            driverAccounts.MonyShop = Convert.ToDouble(order.TotalPrice) - Convert.ToDouble(order.CobenPrice);


                            //8
                            driverAccounts.MonyDriver = Convert.ToDouble(order.PricepackagDriver);

                            double Tee = 0;

                            try
                            {

                                Tee = Convert.ToDouble(order.PricepackagAfter) - Convert.ToDouble(order.PricepackagDriver);

                                if (Tee <= 0)
                                { //-1                                 //7                                         //8
                                    driverAccounts.MonyCompeny = Convert.ToDouble(order.DeliveryPrice) - Convert.ToDouble(order.PricepackagDriver);
                                    Tee = driverAccounts.MonyCompeny;
                                }
                                else
                                { //-1                                 //7                                         //8
                                    driverAccounts.MonyCompeny = Convert.ToDouble(order.PricepackagAfter) - Convert.ToDouble(order.PricepackagDriver);

                                }
                            }
                            catch
                            { //-1                                 //7                                         //8

                                Tee = Convert.ToDouble(order.PricepackagAfter) - Convert.ToDouble(order.PricepackagDriver);


                                driverAccounts.MonyCompeny = Tee;
                            }



                            driverAccounts.IdPricepackagDriver = 0;

                            //-1
                            driverAccounts.IdPrice = Tee;
                            driverAccounts.AccountsCompny = 0;

                            driverAccounts.Dates = DateTime.Now.ToString("yyyy:MM:dd");
                            driverAccounts.Times = DateTime.Now.ToString("HH:mm");


                            try
                            {
                                SqlParameter[] sqlprD = new SqlParameter[20];
                                sqlprD[0] = new SqlParameter("@IdDriverx", driverAccounts.IdDriver);
                                sqlprD[1] = new SqlParameter("@IdOrderx", driverAccounts.IdOrder);
                                sqlprD[2] = new SqlParameter("@IdPricepackagDriverx", driverAccounts.IdPricepackagDriver);
                                sqlprD[3] = new SqlParameter("@IdPricex", driverAccounts.IdPrice);
                                sqlprD[4] = new SqlParameter("@AccountsCompnyx", driverAccounts.AccountsCompny);
                                sqlprD[5] = new SqlParameter("@Datesx", driverAccounts.Dates);
                                sqlprD[6] = new SqlParameter("@Timesx", driverAccounts.Times);
                                sqlprD[7] = new SqlParameter("@Notesx", driverAccounts.Notes);
                                sqlprD[8] = new SqlParameter("@NoteTowsx", driverAccounts.NoteTows);
                                sqlprD[9] = new SqlParameter("@NoteThreex", driverAccounts.NoteThree);
                                sqlprD[10] = new SqlParameter("@Typex", driverAccounts.Type);
                                sqlprD[11] = new SqlParameter("@MonyTotalCostmerx", driverAccounts.MonyTotalCostmer);
                                sqlprD[12] = new SqlParameter("@MonyShopx", driverAccounts.MonyShop);
                                sqlprD[13] = new SqlParameter("@MonyDriverx", driverAccounts.MonyDriver);
                                sqlprD[14] = new SqlParameter("@MonyCompenyx", driverAccounts.MonyCompeny);
                                sqlprD[15] = new SqlParameter("@TrueOrfalseIdOrdersx", driverAccounts.TrueOrfalseIdOrders);
                                sqlprD[16] = new SqlParameter("@TrueOrfalseMonysx", driverAccounts.TrueOrfalseMonys);
                                sqlprD[17] = new SqlParameter("@NoteFourx", driverAccounts.NoteFour);
                                sqlprD[18] = new SqlParameter("@NoteFivex", driverAccounts.NoteFive);
                                sqlprD[19] = new SqlParameter("@NoteSexx", driverAccounts.NoteSex);

                                int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_AddDriverAccounts", sqlprD);
                                iuu = i;
                            }
                            catch
                            {

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
                            DriverAccounts driverAccounts = new DriverAccounts();

                            driverAccounts.IdDriver = order.IDDriver;
                            driverAccounts.IdOrder = order.Id;
                            driverAccounts.NoteSex = order.Id.ToString();
                            driverAccounts.TrueOrfalseIdOrders = "true";
                            driverAccounts.TrueOrfalseMonys = "false";

                            driverAccounts.Type = "NotCash";

                            driverAccounts.NoteThree = "ic_action_subtitles.png";
                            //20                                       //10
                            // double Toooo = Convert.ToDouble(order.TotalPrice) - Convert.ToDouble(order.PricepackagAfter);
                            // 10                             //8
                            // double Tooooww = Toooo + Convert.ToDouble(order.PricepackagDriver);

                            // 18


                            driverAccounts.IdPricepackagDriver = Convert.ToDouble(order.PricepackagDriver);
                            driverAccounts.IdPrice = 0;
                            driverAccounts.AccountsCompny = 0;
                            driverAccounts.Dates = DateTime.Now.ToString("yyyy:MM:dd");
                            driverAccounts.Times = DateTime.Now.ToString("HH:mm");

                            try
                            {
                                SqlParameter[] sqlprD = new SqlParameter[20];
                                sqlprD[0] = new SqlParameter("@IdDriverx", driverAccounts.IdDriver);
                                sqlprD[1] = new SqlParameter("@IdOrderx", driverAccounts.IdOrder);
                                sqlprD[2] = new SqlParameter("@IdPricepackagDriverx", driverAccounts.IdPricepackagDriver);
                                sqlprD[3] = new SqlParameter("@IdPricex", driverAccounts.IdPrice);
                                sqlprD[4] = new SqlParameter("@AccountsCompnyx", driverAccounts.AccountsCompny);
                                sqlprD[5] = new SqlParameter("@Datesx", driverAccounts.Dates);
                                sqlprD[6] = new SqlParameter("@Timesx", driverAccounts.Times);
                                sqlprD[7] = new SqlParameter("@Notesx", driverAccounts.Notes);
                                sqlprD[8] = new SqlParameter("@NoteTowsx", driverAccounts.NoteTows);
                                sqlprD[9] = new SqlParameter("@NoteThreex", driverAccounts.NoteThree);
                                sqlprD[10] = new SqlParameter("@Typex", driverAccounts.Type);
                                sqlprD[11] = new SqlParameter("@MonyTotalCostmerx", driverAccounts.MonyTotalCostmer);
                                sqlprD[12] = new SqlParameter("@MonyShopx", driverAccounts.MonyShop);
                                sqlprD[13] = new SqlParameter("@MonyDriverx", driverAccounts.MonyDriver);
                                sqlprD[14] = new SqlParameter("@MonyCompenyx", driverAccounts.MonyCompeny);
                                sqlprD[15] = new SqlParameter("@TrueOrfalseIdOrdersx", driverAccounts.TrueOrfalseIdOrders);
                                sqlprD[16] = new SqlParameter("@TrueOrfalseMonysx", driverAccounts.TrueOrfalseMonys);
                                sqlprD[17] = new SqlParameter("@NoteFourx", driverAccounts.NoteFour);
                                sqlprD[18] = new SqlParameter("@NoteFivex", driverAccounts.NoteFive);
                                sqlprD[19] = new SqlParameter("@NoteSexx", driverAccounts.NoteSex);

                                int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_AddDriverAccounts", sqlprD);
                                iuu = i;
                            }
                            catch
                            {

                            }



                        }
                        catch
                        {
                        }

                    }

                }
                else
                {
                    iuu = 1;
                }
            }
            catch
            {

            }

            return iuu;

        }

        public int ExecuteNonQuerygETTT(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //  var con = new SqlConnection(dbContexts.Database.Connection.ConnectionString);
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            int response = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = commandType;
                if (commandType == CommandType.StoredProcedure)
                {
                    if (commandParameters != null)
                    {
                        foreach (SqlParameter sqlPara in commandParameters)
                        {
                            if (sqlPara != null)
                            {
                                if (sqlPara.Direction == ParameterDirection.Output)
                                {
                                    cmd.Parameters.Add(sqlPara);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(sqlPara.ParameterName, sqlPara.SqlValue);
                                }
                            }
                        }
                    }
                }
                con.Open();
                response = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return response;
        }
        private int AddDrivernewnnnnn(Order order, double prices)
        {
            int iuu = 0;
            try
            {
                // var obj = db.DriverAccounts.Where(a => a.IdOrder.Equals(order.Id)).FirstOrDefault();
                DriverAccounts obj = DataAccess.Instance.OstDriverAccounts(order.Id);
                if (obj == null)
                {


                    try
                    {
                        DriverAccounts driverAccounts = new DriverAccounts();

                        driverAccounts.IdDriver = order.IDDriver;
                        driverAccounts.IdOrder = order.Id;
                        driverAccounts.NoteSex = order.Id.ToString();
                        driverAccounts.TrueOrfalseIdOrders = "true";
                        driverAccounts.TrueOrfalseMonys = "false";

                        driverAccounts.Type = "NotCash";

                        driverAccounts.NoteThree = "ic_action_subtitles.png";
                        //20                                       //10
                        // double Toooo = Convert.ToDouble(order.TotalPrice) - Convert.ToDouble(order.PricepackagAfter);
                        // 10                             //8
                        // double Tooooww = Toooo + Convert.ToDouble(order.PricepackagDriver);

                        // 18

                        double Tooooww = Convert.ToDouble(order.PricepackagDriver) + prices;
                        driverAccounts.IdPricepackagDriver = Tooooww;
                        driverAccounts.IdPrice = 0;
                        driverAccounts.AccountsCompny = 0;
                        driverAccounts.Dates = DateTime.Now.ToString("yyyy:MM:dd");
                        driverAccounts.Times = DateTime.Now.ToString("HH:mm");

                        try
                        {
                            SqlParameter[] sqlprD = new SqlParameter[20];
                            sqlprD[0] = new SqlParameter("@IdDriverx", driverAccounts.IdDriver);
                            sqlprD[1] = new SqlParameter("@IdOrderx", driverAccounts.IdOrder);
                            sqlprD[2] = new SqlParameter("@IdPricepackagDriverx", driverAccounts.IdPricepackagDriver);
                            sqlprD[3] = new SqlParameter("@IdPricex", driverAccounts.IdPrice);
                            sqlprD[4] = new SqlParameter("@AccountsCompnyx", driverAccounts.AccountsCompny);
                            sqlprD[5] = new SqlParameter("@Datesx", driverAccounts.Dates);
                            sqlprD[6] = new SqlParameter("@Timesx", driverAccounts.Times);
                            sqlprD[7] = new SqlParameter("@Notesx", driverAccounts.Notes);
                            sqlprD[8] = new SqlParameter("@NoteTowsx", driverAccounts.NoteTows);
                            sqlprD[9] = new SqlParameter("@NoteThreex", driverAccounts.NoteThree);
                            sqlprD[10] = new SqlParameter("@Typex", driverAccounts.Type);
                            sqlprD[11] = new SqlParameter("@MonyTotalCostmerx", driverAccounts.MonyTotalCostmer);
                            sqlprD[12] = new SqlParameter("@MonyShopx", driverAccounts.MonyShop);
                            sqlprD[13] = new SqlParameter("@MonyDriverx", driverAccounts.MonyDriver);
                            sqlprD[14] = new SqlParameter("@MonyCompenyx", driverAccounts.MonyCompeny);
                            sqlprD[15] = new SqlParameter("@TrueOrfalseIdOrdersx", driverAccounts.TrueOrfalseIdOrders);
                            sqlprD[16] = new SqlParameter("@TrueOrfalseMonysx", driverAccounts.TrueOrfalseMonys);
                            sqlprD[17] = new SqlParameter("@NoteFourx", driverAccounts.NoteFour);
                            sqlprD[18] = new SqlParameter("@NoteFivex", driverAccounts.NoteFive);
                            sqlprD[19] = new SqlParameter("@NoteSexx", driverAccounts.NoteSex);

                            int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_AddDriverAccounts", sqlprD);
                            iuu = i;
                        }
                        catch
                        {

                        }



                    }
                    catch
                    {
                    }



                }
                else
                {
                    iuu = 1;
                }
            }
            catch
            {

            }

            return iuu;

        }
        protected void Button2DD8_Command(object sender, CommandEventArgs e)
        {

            int INNss = int.Parse(e.CommandName);

            //  List<Order> Billscccssss = DataAccess.Instance.GetOrdersIDList(INNss);
            try
            {
                Labelidorder.Text = INNss.ToString();
                Label67ss.Text = INNss.ToString();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalConselOrderfinsh", "$('#logoutModalConselOrderfinsh').modal()", true);


            }
            catch
            {

            }

        }

        protected void Buttonfinsh_Click(object sender, EventArgs e)
        {


            if (TextBoxpassword.Text == "Aa2022")
            {
                int YesorNo = 0;
                int idorer = int.Parse(Labelidorder.Text);

                try
                {
                    Order orders = DataAccess.Instance.GetOrdersByids(idorer);

                    if (orders != null)
                    {
                        if (orders.Id > 0)
                        {
                            if (orders.IdBosh == 43)
                            {
                                if (orders.StatusBosh == "true" && orders.StatusDriver == "true" && orders.NoteBosh == "true" && orders.ReadyBosh == "ready" && orders.ReceivedDriver == "true")
                                {

                                    orders.NoteReadyBosh = "true";
                                    orders.YESORNODriver = "yes";
                                    orders.TimeDriver = DateTime.Now.ToString("HH:mm");
                                    orders.DateAccsptReceivedDriver = DateTime.Now.ToString("yyyy:MM:dd");

                                    try
                                    {
                                        int Drivfff = 0;
                                        try
                                        {
                                            if (orders.Cash == "true")
                                            {
                                                Drivfff = AddDrivernew(orders);
                                            }
                                            else
                                            {
                                                Drivfff = 1;
                                            }

                                        }
                                        catch
                                        {

                                        }

                                        if (Drivfff > 0)
                                        {
                                            try
                                            {
                                                SqlParameter[] sqlpr = new SqlParameter[5];
                                                sqlpr[0] = new SqlParameter("@Id", orders.Id);
                                                sqlpr[1] = new SqlParameter("@NoteReadyBoshs", "true");
                                                sqlpr[2] = new SqlParameter("@YESORNODrivers", "yes");
                                                sqlpr[3] = new SqlParameter("@TimeDrivers", DateTime.Now.ToString("HH:mm"));
                                                sqlpr[4] = new SqlParameter("@DateAccsptReceivedDrivers", DateTime.Now.ToString("yyyy:MM:dd"));

                                                int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriverYesOrder", sqlpr);
                                                YesorNo = 1;
                                            }
                                            catch
                                            {

                                            }


                                        }


                                    }
                                    catch
                                    {
                                        YesorNo = 0;
                                    }

                                }

                            }
                            else
                            {
                                if (orders.PostalCode == "storedone")
                                {

                                    if (orders.NoteBosh == "nonofa" || orders.NoteBosh == "nono")
                                    {
                                        if (orders.NoteBosh == "nonofa")
                                        {
                                            int oShopss = 0;
                                            int Drivers = 0;

                                            try
                                            {

                                                orders.TotalPrice = orders.NotCancelOrder;

                                                oShopss = AddAcountToShopnew(orders);
                                            }
                                            catch
                                            {

                                            }

                                            try
                                            {
                                                Drivers = AddDrivernew(orders);
                                            }
                                            catch
                                            {

                                            }



                                            if (orders.StatusBosh == "true" && orders.StatusDriver == "true" && orders.ReadyBosh == "ready" && orders.ReceivedDriver == "true")
                                            {

                                                orders.NoteReadyBosh = "true";
                                                orders.YESORNODriver = "yes";
                                                orders.TimeDriver = DateTime.Now.ToString("HH:mm");
                                                orders.DateAccsptReceivedDriver = DateTime.Now.ToString("yyyy:MM:dd");

                                                try
                                                {
                                                    if (Drivers > 0)
                                                    {
                                                        try
                                                        {
                                                            SqlParameter[] sqlpr = new SqlParameter[12];
                                                            sqlpr[0] = new SqlParameter("@Id", orders.Id);
                                                            sqlpr[1] = new SqlParameter("@ReadyBoshs", orders.ReadyBosh);
                                                            sqlpr[2] = new SqlParameter("@TimeAccsptReadyBoshs", orders.TimeAccsptReadyBosh);
                                                            sqlpr[3] = new SqlParameter("@ReceivedDrivers", orders.ReceivedDriver);
                                                            sqlpr[4] = new SqlParameter("@TimeAccsptReceivedDrivers", orders.TimeAccsptReceivedDriver);
                                                            sqlpr[5] = new SqlParameter("@NoteBoshs", "yesyes");
                                                            sqlpr[6] = new SqlParameter("@DateAccsptReadyBoshs", "تم اضافة رسوم التوصيل فقط" + orders.DateAccsptReadyBosh);
                                                            sqlpr[7] = new SqlParameter("@Notss", orders.Note);
                                                            sqlpr[8] = new SqlParameter("@NoteReadyBoshs", "true");
                                                            sqlpr[9] = new SqlParameter("@YESORNODrivers", "yes");
                                                            sqlpr[10] = new SqlParameter("@TimeDrivers", DateTime.Now.ToString("HH:mm"));
                                                            sqlpr[11] = new SqlParameter("@DateAccsptReceivedDrivers", DateTime.Now.ToString("yyyy:MM:dd"));

                                                            int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriverYesyesOrderBill", sqlpr);


                                                            YesorNo = 1;
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }


                                                }
                                                catch
                                                {
                                                    YesorNo = 0;
                                                }

                                            }

                                        }
                                        else if (orders.NoteBosh == "nono")
                                        {
                                            int oShopss = 0;
                                            int Drivers = 0;
                                            double price = 0;
                                            double totelsorder = 0;



                                            try
                                            {
                                                try
                                                {
                                                    totelsorder = double.Parse(orders.TotalPrice);
                                                }
                                                catch
                                                {

                                                }

                                                double pricsBile = 0;

                                                try
                                                {
                                                    pricsBile = double.Parse(orders.NotCancelOrder);
                                                }
                                                catch
                                                {

                                                }

                                                // 21       //20
                                                if (totelsorder < pricsBile)
                                                {
                                                    try
                                                    {
                                                        oShopss = AddAcountToShopnew(orders);
                                                    }
                                                    catch
                                                    {

                                                    }

                                                    try
                                                    {
                                                        Drivers = AddDrivernewnnnnn(orders, totelsorder);
                                                    }
                                                    catch
                                                    {

                                                    }

                                                    price = pricsBile - totelsorder;

                                                }
                                            }
                                            catch
                                            {

                                            }


                                            if (orders.StatusBosh == "true" && orders.StatusDriver == "true" && orders.ReadyBosh == "ready" && orders.ReceivedDriver == "true")
                                            {

                                                orders.NoteReadyBosh = "true";
                                                orders.YESORNODriver = "yes";
                                                orders.TimeDriver = DateTime.Now.ToString("HH:mm");
                                                orders.DateAccsptReceivedDriver = DateTime.Now.ToString("yyyy:MM:dd");

                                                try
                                                {

                                                    try
                                                    {
                                                        SqlParameter[] sqlpr = new SqlParameter[12];
                                                        sqlpr[0] = new SqlParameter("@Id", orders.Id);
                                                        sqlpr[1] = new SqlParameter("@ReadyBoshs", orders.ReadyBosh);
                                                        sqlpr[2] = new SqlParameter("@TimeAccsptReadyBoshs", orders.TimeAccsptReadyBosh);
                                                        sqlpr[3] = new SqlParameter("@ReceivedDrivers", orders.ReceivedDriver);
                                                        sqlpr[4] = new SqlParameter("@TimeAccsptReceivedDrivers", orders.TimeAccsptReceivedDriver);
                                                        sqlpr[5] = new SqlParameter("@NoteBoshs", "yesyes");
                                                        sqlpr[6] = new SqlParameter("@DateAccsptReadyBoshs", "تم اضافة رسوم التوصيل وقيمة الفاتورة المدفوعة لدينا " + orders.DateAccsptReadyBosh);
                                                        sqlpr[7] = new SqlParameter("@Notss", orders.Note);
                                                        sqlpr[8] = new SqlParameter("@NoteReadyBoshs", "true");
                                                        sqlpr[9] = new SqlParameter("@YESORNODrivers", "yes");
                                                        sqlpr[10] = new SqlParameter("@TimeDrivers", DateTime.Now.ToString("HH:mm"));
                                                        sqlpr[11] = new SqlParameter("@DateAccsptReceivedDrivers", DateTime.Now.ToString("yyyy:MM:dd"));

                                                        int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriverYesyesOrderBill", sqlpr);


                                                        YesorNo = 1;
                                                    }
                                                    catch
                                                    {

                                                    }


                                                }
                                                catch
                                                {
                                                    YesorNo = 0;
                                                }

                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (orders.NoteBosh == "yesyes" || orders.NoteBosh == "yesyesfa")
                                        {
                                            if (orders.StatusBosh == "true" && orders.StatusDriver == "true" && orders.ReadyBosh == "ready" && orders.ReceivedDriver == "true")
                                            {
                                                orders.NoteReadyBosh = "true";
                                                orders.YESORNODriver = "yes";
                                                orders.TimeDriver = DateTime.Now.ToString("HH:mm");
                                                orders.DateAccsptReceivedDriver = DateTime.Now.ToString("yyyy:MM:dd");

                                                try
                                                {
                                                    try
                                                    {
                                                        SqlParameter[] sqlpr = new SqlParameter[12];
                                                        sqlpr[0] = new SqlParameter("@Id", orders.Id);
                                                        sqlpr[1] = new SqlParameter("@ReadyBoshs", orders.ReadyBosh);
                                                        sqlpr[2] = new SqlParameter("@TimeAccsptReadyBoshs", orders.TimeAccsptReadyBosh);
                                                        sqlpr[3] = new SqlParameter("@ReceivedDrivers", orders.ReceivedDriver);
                                                        sqlpr[4] = new SqlParameter("@TimeAccsptReceivedDrivers", orders.TimeAccsptReceivedDriver);
                                                        sqlpr[5] = new SqlParameter("@NoteBoshs", "yesyes");
                                                        sqlpr[6] = new SqlParameter("@DateAccsptReadyBoshs", orders.DateAccsptReadyBosh);
                                                        sqlpr[7] = new SqlParameter("@Notss", orders.Note);
                                                        sqlpr[8] = new SqlParameter("@NoteReadyBoshs", "true");
                                                        sqlpr[9] = new SqlParameter("@YESORNODrivers", "yes");
                                                        sqlpr[10] = new SqlParameter("@TimeDrivers", DateTime.Now.ToString("HH:mm"));
                                                        sqlpr[11] = new SqlParameter("@DateAccsptReceivedDrivers", DateTime.Now.ToString("yyyy:MM:dd"));

                                                        int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriverYesyesOrderBill", sqlpr);


                                                        YesorNo = 1;
                                                    }
                                                    catch
                                                    {

                                                    }


                                                }
                                                catch
                                                {
                                                    YesorNo = 0;
                                                }

                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        if (orders.StatusBosh == "true" && orders.StatusDriver == "true" && orders.ReadyBosh == "ready" && orders.ReceivedDriver == "true")
                                        {
                                            orders.NoteReadyBosh = "true";
                                            orders.YESORNODriver = "yes";
                                            orders.TimeDriver = DateTime.Now.ToString("HH:mm");
                                            orders.DateAccsptReceivedDriver = DateTime.Now.ToString("yyyy:MM:dd");

                                            try
                                            {
                                                int shopssss = 0;
                                                int Driversss = 0;

                                                try
                                                {
                                                    shopssss = AddAcountToShopnew(orders);
                                                }
                                                catch
                                                {

                                                }

                                                try
                                                {
                                                    Driversss = AddDrivernew(orders);
                                                }
                                                catch
                                                {

                                                }



                                                if (shopssss > 0 && Driversss > 0)
                                                {

                                                    try
                                                    {
                                                        SqlParameter[] sqlpr = new SqlParameter[5];
                                                        sqlpr[0] = new SqlParameter("@Id", orders.Id);
                                                        sqlpr[1] = new SqlParameter("@NoteReadyBoshs", "true");
                                                        sqlpr[2] = new SqlParameter("@YESORNODrivers", "yes");
                                                        sqlpr[3] = new SqlParameter("@TimeDrivers", DateTime.Now.ToString("HH:mm"));
                                                        sqlpr[4] = new SqlParameter("@DateAccsptReceivedDrivers", DateTime.Now.ToString("yyyy:MM:dd"));

                                                        int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriverYesOrder", sqlpr);
                                                        YesorNo = 1;
                                                    }
                                                    catch
                                                    {

                                                    }


                                                }



                                            }
                                            catch
                                            {
                                                YesorNo = 0;
                                            }

                                        }
                                        else
                                        {
                                            if (orders.StatusBosh == "true" && orders.StatusDriver == "true")
                                            {
                                                orders.ReceivedDriver = "true";
                                                orders.ReadyBosh = "ready";
                                                orders.NoteReadyBosh = "true";
                                                orders.YESORNODriver = "yes";
                                                orders.TimeDriver = DateTime.Now.ToString("HH:mm");
                                                orders.DateAccsptReceivedDriver = DateTime.Now.ToString("yyyy:MM:dd");

                                                try
                                                {
                                                    int shopssss = 0;
                                                    int Driversss = 0;

                                                    try
                                                    {
                                                        shopssss = AddAcountToShopnew(orders);
                                                    }
                                                    catch
                                                    {

                                                    }

                                                    try
                                                    {
                                                        Driversss = AddDrivernew(orders);
                                                    }
                                                    catch
                                                    {

                                                    }



                                                    if (shopssss > 0 && Driversss > 0)
                                                    {
                                                        try
                                                        {
                                                            SqlParameter[] sqlpr2 = new SqlParameter[5];
                                                            sqlpr2[0] = new SqlParameter("@Id", orders.Id);
                                                            sqlpr2[1] = new SqlParameter("@ReadyBoshs", "ready");
                                                            sqlpr2[2] = new SqlParameter("@TimeAccsptReadyBoshs", DateTime.Now.ToString("HH:mm"));
                                                            sqlpr2[3] = new SqlParameter("@ReceivedDrivers", "true");
                                                            sqlpr2[4] = new SqlParameter("@TimeAccsptReceivedDrivers", DateTime.Now.ToString("HH:mm"));

                                                            int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriverFazz", sqlpr2);
                                                        }
                                                        catch
                                                        {

                                                        }


                                                        try
                                                        {
                                                            SqlParameter[] sqlpr = new SqlParameter[5];
                                                            sqlpr[0] = new SqlParameter("@Id", orders.Id);
                                                            sqlpr[1] = new SqlParameter("@NoteReadyBoshs", "true");
                                                            sqlpr[2] = new SqlParameter("@YESORNODrivers", "yes");
                                                            sqlpr[3] = new SqlParameter("@TimeDrivers", DateTime.Now.ToString("HH:mm"));
                                                            sqlpr[4] = new SqlParameter("@DateAccsptReceivedDrivers", DateTime.Now.ToString("yyyy:MM:dd"));

                                                            int i = ExecuteNonQuerygETTT(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriverYesOrder", sqlpr);
                                                            YesorNo = 1;
                                                        }
                                                        catch
                                                        {

                                                        }

                                                    }



                                                }
                                                catch
                                                {
                                                    YesorNo = 0;
                                                }

                                            }
                                        }

                                    }
                                    catch
                                    {
                                        YesorNo = 0;
                                    }
                                }
                            }

                        }
                        else
                        {
                            YesorNo = 0;
                        }
                    }

                }
                catch
                {
                    YesorNo = 0;
                }

            }
            else
            {
                TextBoxpassword.Text = "";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalErorr", "$('#logoutModalErorr').modal()", true);
            }


        }

        protected void ButtonAddnotss_Command(object sender, CommandEventArgs e)
        {
            int INNss = int.Parse(e.CommandName);
            Label67.Text = INNss.ToString();

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalAddNots", "$('#logoutModalAddNots').modal()", true);




        }

        protected void ButtonAddnotsss_Click(object sender, EventArgs e)
        {
            LabelErrornotss.Text = "";
            if (DropDownList1.SelectedValue == "0")
            {
                LabelErrornotss.ForeColor = Color.Red;
                LabelErrornotss.Text = "يرجى تحديد نوع الاجراء";
            }
            else
            {
                double prrice = 0;
                if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "4" || DropDownList1.SelectedValue == "5" || DropDownList1.SelectedValue == "6")
                {
                    if (!string.IsNullOrEmpty(TextBoxpricrnoots.Text))
                    {
                        try
                        {
                            prrice = double.Parse(TextBoxpricrnoots.Text);
                        }
                        catch
                        {

                        }

                        if (prrice > 0)
                        {
                            int INNsscccc = int.Parse(Label67.Text);


                            try
                            {
                                SqlParameter[] sqlprD = new SqlParameter[16];
                                sqlprD[0] = new SqlParameter("@id_orders", INNsscccc);
                                sqlprD[1] = new SqlParameter("@action_types", int.Parse(DropDownList1.SelectedValue));
                                sqlprD[2] = new SqlParameter("@action_type_texts", DropDownList1.SelectedItem.Text);
                                sqlprD[3] = new SqlParameter("@action_prices", prrice.ToString());
                                sqlprD[4] = new SqlParameter("@action_notes", TextBoxnotsss.Text);
                                string name = "";
                                try
                                {
                                    name = Session["ANUser"].ToString();
                                }
                                catch
                                {

                                }
                                sqlprD[5] = new SqlParameter("@name_sends", name);
                                sqlprD[6] = new SqlParameter("@action_datetimes", DateTime.Now);
                                sqlprD[7] = new SqlParameter("@name_procedure_performers", "new");
                                sqlprD[8] = new SqlParameter("@procedure_performer_datetimess", DateTime.Now);
                                sqlprD[9] = new SqlParameter("@id_wallets", 0);
                                sqlprD[10] = new SqlParameter("@id_shopaccountss", 0);
                                sqlprD[11] = new SqlParameter("@id_driveraccountss", 0);
                                sqlprD[12] = new SqlParameter("@action_statuss", "new");
                                sqlprD[13] = new SqlParameter("@nots1s", "0");
                                sqlprD[14] = new SqlParameter("@nots2s", "new");
                                sqlprD[15] = new SqlParameter("@nots3s", "new");


                                int ibbc = ExecuteNonQueryADD(CommandType.StoredProcedure, "sp_Addrequests_procedures", sqlprD);
                                if (ibbc > 0)
                                {
                                    DropDownList1.SelectedIndex = 0;
                                    TextBoxpricrnoots.Text = "";
                                    TextBoxnotsss.Text = "";
                                    LabelErrornotss.ForeColor = Color.Green;
                                    LabelErrornotss.Text = "تم ارسال الملاحظة بنجاح";
                                }
                                else
                                {
                                    LabelErrornotss.ForeColor = Color.Red;
                                    LabelErrornotss.Text = "خطاء غير متوقع ";
                                }

                            }

                            catch (Exception ex)
                            {
                                LabelErrornotss.ForeColor = Color.Red;
                                LabelErrornotss.Text = ex.Message;
                            }


                        }
                        else
                        {
                            LabelErrornotss.ForeColor = Color.Red;
                            LabelErrornotss.Text = "يرجى ادخال المبلغ بشكل صحيح ";
                        }




                    }
                    else
                    {
                        LabelErrornotss.ForeColor = Color.Red;
                        LabelErrornotss.Text = "يرجى ادخال المبلغ";
                    }

                }
                else
                {
                    if (DropDownList1.SelectedValue == "7")
                    {
                        if (!string.IsNullOrEmpty(TextBoxnotsss.Text))
                        {

                            int INNsscccc = int.Parse(Label67.Text);

                            try
                            {
                                SqlParameter[] sqlprD = new SqlParameter[16];
                                sqlprD[0] = new SqlParameter("@id_orders", INNsscccc);
                                sqlprD[1] = new SqlParameter("@action_types", int.Parse(DropDownList1.SelectedValue));
                                sqlprD[2] = new SqlParameter("@action_type_texts", DropDownList1.SelectedItem.Text);
                                sqlprD[3] = new SqlParameter("@action_prices", "0");
                                sqlprD[4] = new SqlParameter("@action_notes", TextBoxnotsss.Text);
                                string name = "";
                                try
                                {
                                    name = Session["ANUser"].ToString();
                                }
                                catch
                                {

                                }
                                sqlprD[5] = new SqlParameter("@name_sends", name);
                                sqlprD[6] = new SqlParameter("@action_datetimes", DateTime.Now);
                                sqlprD[7] = new SqlParameter("@name_procedure_performers", "new");
                                sqlprD[8] = new SqlParameter("@procedure_performer_datetimess", DateTime.Now);
                                sqlprD[9] = new SqlParameter("@id_wallets", 0);
                                sqlprD[10] = new SqlParameter("@id_shopaccountss", 0);
                                sqlprD[11] = new SqlParameter("@id_driveraccountss", 0);
                                sqlprD[12] = new SqlParameter("@action_statuss", "new");
                                sqlprD[13] = new SqlParameter("@nots1s", "0");
                                sqlprD[14] = new SqlParameter("@nots2s", "new");
                                sqlprD[15] = new SqlParameter("@nots3s", "new");


                                int ibbc = ExecuteNonQueryADD(CommandType.StoredProcedure, "sp_Addrequests_procedures", sqlprD);
                                if (ibbc > 0)
                                {
                                    DropDownList1.SelectedIndex = 0;
                                    TextBoxpricrnoots.Text = "";
                                    TextBoxnotsss.Text = "";
                                    LabelErrornotss.ForeColor = Color.Green;
                                    LabelErrornotss.Text = "تم ارسال الملاحظة بنجاح";
                                }
                                else
                                {
                                    LabelErrornotss.ForeColor = Color.Red;
                                    LabelErrornotss.Text = "خطاء غير متوقع ";
                                }


                            }
                            catch (Exception ex)
                            {
                                LabelErrornotss.ForeColor = Color.Red;
                                LabelErrornotss.Text = ex.Message;
                            }

                        }
                        else
                        {
                            LabelErrornotss.ForeColor = Color.Red;

                            LabelErrornotss.Text = "يرجى ادخال الملاحظة";
                        }
                    }

                }

            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "logoutModalAddNots", "$('#logoutModalAddNots').modal()", true);
        }

        protected void Button3542_Click(object sender, EventArgs e)
        {

            try
            {


                string oldDirverid = "";

                int INNssccccccb = int.Parse(Label6867.Text);

                Order orderr = DataAccess.Instance.GetOrdersID(INNssccccccb);
                oldDirverid = orderr.IDDriver.ToString();

                if (orderr.IdBosh == 43)
                {
                    int INNssccc = int.Parse(TextBox17.Text);
                    orderr.StatusDriver = "true";
                    orderr.IDDriver = INNssccc;
                    orderr.StatusBosh = "true";
                    orderr.TimeAccsptReceivedDriver = DateTime.Now.ToString("HH:mm");
                    orderr.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");
                    orderr.DateAccsptReadyBosh = DateTime.Now.ToString("yyyy:MM:dd");
                    orderr.TimeAccsptDriver = DateTime.Now.ToString("HH:mm");
                    try
                    {
                        orderr.Arrived = name + "اسناد " + DateTime.Now.ToString("HH:mm:ss");

                    }
                    catch
                    {

                    }
                    // dbContexts.Entry(orderr).State = EntityState.Modified;

                    // dbContexts.SaveChanges();

                    // صج

                    try
                    {

                        SqlParameter[] sqlpr = new SqlParameter[37];
                        sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                        sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                        sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                        sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                        sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                        sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                        sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                        sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                        sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                        sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                        sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                        sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                        sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                        sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                        sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                        sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                        sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                        sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                        sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                        sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                        sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                        sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                        sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                        sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                        sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                        sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                        sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                        sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                        sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                        sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                        sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                        sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                        sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                        sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);
                        // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                        sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                        sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                        sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                        int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);
                        if (i == 1)
                        {
                            try
                            {
                                SendNotificationWhatsUp("0546029025", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");
                                SendNotificationWhatsUp("0530702492", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");


                            }
                            catch
                            {

                            }
                        }
                    }
                    catch
                    {

                    }
                    Response.Redirect("/AdminShops/OrdersTow.aspx", false);
                }
                else
                {

                    if (orderr.StatusDriver == "newdriver")
                    {

                    }
                    else
                    {

                        if (orderr.PostalCode == "storedone" && orderr.NoteBosh == "nonofa" || orderr.PostalCode == "storedone" && orderr.NoteBosh == "nono")
                        {
                            int YesorNo = 0;

                            try
                            {
                                int INNssccc = int.Parse(TextBox17.Text);
                                orderr.StatusBosh = "true";
                                orderr.StatusDriver = "true";
                                orderr.IDDriver = INNssccc;

                                orderr.TimeAccsptDriver = DateTime.Now.ToString("HH:mm");
                                orderr.DateAccsptReadyBosh = "0";
                                orderr.TimeAccsptBosh = DateTime.Now.ToString("HH:mm");

                                try
                                {
                                    SqlParameter[] sqlprc = new SqlParameter[7];
                                    sqlprc[0] = new SqlParameter("@Id", orderr.Id);
                                    sqlprc[1] = new SqlParameter("@StatusDrivers", "true");
                                    sqlprc[2] = new SqlParameter("@IDDrivers", INNssccc);
                                    sqlprc[3] = new SqlParameter("@StatusBoshs", "true");
                                    sqlprc[4] = new SqlParameter("@TimeAccsptDrivers", DateTime.Now.ToString("HH:mm"));
                                    sqlprc[5] = new SqlParameter("@DateAccsptReadyBoshs", "0");
                                    sqlprc[6] = new SqlParameter("@TimeAccsptBoshs", DateTime.Now.ToString("HH:mm"));

                                    int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrderAcceptdDriver", sqlprc);
                                    YesorNo = 1;
                                }
                                catch
                                {

                                }
                                if (YesorNo == 1)
                                {
                                    try
                                    {

                                        CustomerData CustomerDatacc = DataAccess.Instance.GetCustomerData(orderr.IdCustomer); //db.Drivers.Find(itemOrderlist.IDDriver);
                                        string numberCustomer = CustomerDatacc.NumberPhoneUser;
                                        string numberssccs = numberCustomer;
                                        string numbercccc = numberssccs.Remove(0, 1);

                                        Models.Driver Driverxxx = DataAccess.Instance.GetDriverByIdDriver(INNssccc); //db.Drivers.Find(itemOrderlist.IDDriver);

                                        string numbersss = Driverxxx.NumberDriver;
                                        string number = numbersss.Remove(0, 1);



                                        string FD = "https://api.whatsapp.com/send?phone=966" + numbercccc;

                                        string NoteYESORNODrivers = "";
                                        try
                                        {
                                            string illlls = orderr.NoteYESORNODriver;
                                            string lastCharacter = illlls.Substring(illlls.Length - 1);
                                            string result = "";
                                            if (lastCharacter == ".")
                                            {
                                                result = illlls.Remove(illlls.Length - 1);

                                            }
                                            else
                                            {
                                                result = illlls;
                                            }



                                            string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                                            XmlDocument xmltest = new XmlDocument();
                                            xmltest.LoadXml(resultd);

                                            XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                                            foreach (XmlNode xn in xnList)
                                            {
                                                NoteYESORNODrivers = NoteYESORNODrivers + "\r\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                                            }

                                            if (xnList.Count > 0)
                                            {


                                            }
                                            else
                                            {
                                                NoteYESORNODrivers = orderr.NoteYESORNODriver;



                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            NoteYESORNODrivers = orderr.NoteYESORNODriver;

                                        }


                                        SendNotificationWhatsUp(number, "* رقم الطلب :" + orderr.Id + "\\n  " + "*التاريخ :" + orderr.DataOrder + "\\n  "

                                            + "*نوع الطلب:" + " طلب خـــاص  " + "*ملاحظة:" + " توجه للمتجر  ثم اطلب طلب العميل ثم اصدر فاتورة بمبلغ الفاتورة  " + "\\n  "
                                        + "* المتجر :" + orderr.SubThoroughfare + "\\n  "
                                            + "*الفاتورة :" + NoteYESORNODrivers + "\\n  "
                                            + "\\n  "
                                             + " التواصل مع العميل عبر الدردشة الخاصة بالتطبيق أولاً وفي حال عدم تجاوب العميل يتم التواصل معه على الرقم" + "\\n " + FD + "\\n " + numberCustomer + "\\n  "
                                             + "\\n  "
                                              + "ملاحظة : التواصل مع العميل مباشرةً على رقم الجوال يعرض حسابك للحظر." + "\\n  "
                                            + "\\n  ");


                                    }
                                    catch
                                    {

                                    }

                                    try
                                    {
                                        SendNotificationWhatsUp("0546029025", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");
                                        SendNotificationWhatsUp("0530702492", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");


                                    }
                                    catch
                                    {

                                    }

                                }

                            }
                            catch
                            {
                                YesorNo = 0;
                            }

                        }
                        else
                        {
                            if (orderr.IDDriver != 11)
                            {
                                int INNssccc = int.Parse(TextBox17.Text);
                                orderr.IDDriver = INNssccc;
                                orderr.StatusDriver = "true";
                                orderr.TimeAccsptDriver = DateTime.Now.ToString("HH:mm");


                                try
                                {

                                    orderr.Arrived = name + "قبول الطلب " + DateTime.Now.ToString("HH:mm:ss");

                                }
                                catch
                                {

                                }
                                //  dbContexts.Entry(orderr).State = EntityState.Modified;

                                //  dbContexts.SaveChanges();
                                // صج
                                try
                                {

                                    SqlParameter[] sqlpr = new SqlParameter[37];
                                    sqlpr[0] = new SqlParameter("@Id", orderr.Id);
                                    sqlpr[1] = new SqlParameter("@DeliveryPrices", orderr.DeliveryPrice);
                                    sqlpr[2] = new SqlParameter("@TotalPrices", orderr.TotalPrice);
                                    sqlpr[3] = new SqlParameter("@StreetThoroughfares", orderr.StreetThoroughfare);

                                    sqlpr[4] = new SqlParameter("@PaymentStatuss", orderr.PaymentStatus);
                                    sqlpr[5] = new SqlParameter("@PaymentProcessNumbers", orderr.PaymentProcessNumber);
                                    sqlpr[6] = new SqlParameter("@StatusDrivers", orderr.StatusDriver);
                                    sqlpr[7] = new SqlParameter("@IDDrivers", orderr.IDDriver);
                                    sqlpr[8] = new SqlParameter("@Cashs", orderr.Cash);

                                    sqlpr[9] = new SqlParameter("@PaymentAmounts", orderr.PaymentAmount);
                                    sqlpr[10] = new SqlParameter("@PaymentCardStartEnds", orderr.PaymentCardStartEnd);
                                    sqlpr[11] = new SqlParameter("@Paymentcodesss", orderr.Paymentcodess);
                                    sqlpr[12] = new SqlParameter("@IdcahckWalltss", orderr.IdcahckWallts);
                                    sqlpr[13] = new SqlParameter("@cahckWalltss", orderr.cahckWallts);
                                    sqlpr[14] = new SqlParameter("@PricePshWalltss", orderr.PricePshWallts);

                                    sqlpr[15] = new SqlParameter("@CobenNumbers", orderr.CobenNumber);
                                    sqlpr[16] = new SqlParameter("@CobenPrices", orderr.CobenPrice);

                                    sqlpr[17] = new SqlParameter("@TimeAccsptReceivedDrivers", orderr.TimeAccsptReceivedDriver);
                                    sqlpr[18] = new SqlParameter("@TimeDrivers", orderr.TimeDriver);
                                    sqlpr[19] = new SqlParameter("@DateAccsptReceivedDrivers", orderr.DateAccsptReceivedDriver);
                                    sqlpr[20] = new SqlParameter("@ReadyBoshs", orderr.ReadyBosh);
                                    sqlpr[21] = new SqlParameter("@TimeAccsptBoshs", orderr.TimeAccsptBosh);
                                    sqlpr[22] = new SqlParameter("@DateAccsptReadyBoshs", orderr.DateAccsptReadyBosh);

                                    sqlpr[23] = new SqlParameter("@DataOrders", orderr.DataOrder);
                                    sqlpr[24] = new SqlParameter("@TimeOrders", orderr.TimeOrder);
                                    sqlpr[25] = new SqlParameter("@TimeAccsptDrivers", orderr.TimeAccsptDriver);
                                    sqlpr[26] = new SqlParameter("@NoteReadyBoshs", orderr.NoteReadyBosh);
                                    sqlpr[27] = new SqlParameter("@TimeAccsptReadyBoshs", orderr.TimeAccsptReadyBosh);
                                    sqlpr[28] = new SqlParameter("@ReceivedDrivers", orderr.ReceivedDriver);
                                    sqlpr[29] = new SqlParameter("@NotCancelOrders", orderr.NotCancelOrder);
                                    sqlpr[30] = new SqlParameter("@StatusBoshs", orderr.StatusBosh);
                                    sqlpr[31] = new SqlParameter("@CancelOrders", orderr.CancelOrder);
                                    sqlpr[32] = new SqlParameter("@Arriveds", orderr.Arrived);
                                    sqlpr[33] = new SqlParameter("@TimeArriveds", orderr.TimeArrived);
                                    // int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelf", sqlpr);
                                    sqlpr[34] = new SqlParameter("@NoteBoshs", orderr.NoteBosh);
                                    sqlpr[35] = new SqlParameter("@YESORNODrivers", orderr.YESORNODriver);
                                    sqlpr[36] = new SqlParameter("@Notes", orderr.Note);

                                    int i = ExecuteNonQueryOrder(CommandType.StoredProcedure, "sp_UpdateOrdersTelrYourSelfAll", sqlpr);

                                    if (i > 0)
                                    {

                                        try
                                        {


                                            CustomerData CustomerDatacc = DataAccess.Instance.GetCustomerData(orderr.IdCustomer); //db.Drivers.Find(itemOrderlist.IDDriver);
                                            string numberCustomer = CustomerDatacc.NumberPhoneUser;
                                            Models.Driver Driverxxx = DataAccess.Instance.GetDriverByIdDriver(orderr.IDDriver); //db.Drivers.Find(itemOrderlist.IDDriver);
                                            string numbersss = "";


                                            if (Driverxxx == null)
                                            {
                                                try
                                                {
                                                    UserShopBoshesDriver Drive = DataAccess.Instance.GetDriverShop(orderr.IDDriver);
                                                    numbersss = Drive.NumberPhoneBoshDriver;

                                                }
                                                catch
                                                {

                                                }
                                            }
                                            else
                                            {
                                                numbersss = Driverxxx.NumberDriver;
                                            }



                                            string number = numbersss.Remove(0, 1);

                                            string PaymentStatusvvvv = "";
                                            if (orderr.PaymentStatus == "true")
                                            {
                                                PaymentStatusvvvv = "دفع الكتروني";
                                            }


                                            if (orderr.Cash == "true")
                                            {
                                                PaymentStatusvvvv = "الدفع عند الاستلام";
                                            }

                                            if (orderr.Cash != "true" && orderr.PaymentStatus != "true")
                                            {
                                                PaymentStatusvvvv = "دفع الكتروني";
                                            }



                                            string numberssccs = numberCustomer;
                                            string numbercccc = numberssccs.Remove(0, 1);

                                            string NoteYESORNODrivers = "";
                                            try
                                            {
                                                string illlls = orderr.NoteYESORNODriver;

                                                string lastCharacter = illlls.Substring(illlls.Length - 1);

                                                string result = "";
                                                if (lastCharacter == ".")
                                                {
                                                    result = illlls.Remove(illlls.Length - 1);

                                                }
                                                else
                                                {
                                                    result = illlls;
                                                }



                                                string resultd = "<BillllsccArEns>" + result + "</BillllsccArEns>";

                                                XmlDocument xmltest = new XmlDocument();
                                                xmltest.LoadXml(resultd);

                                                XmlNodeList xnList = xmltest.SelectNodes("BillllsccArEns/BillllsccArEn");


                                                foreach (XmlNode xn in xnList)
                                                {
                                                    NoteYESORNODrivers = NoteYESORNODrivers + "\r\n" + xn["Cost"].InnerText + "×" + "\t\t" + xn["sproar"].InnerText + "\t\t" + xn["spakerar"].InnerText + "\t\t" + xn["spric"].InnerText + " " + "ريال" + "\t" + xn["stAdd"].InnerText;

                                                }

                                                if (xnList.Count > 0)
                                                {


                                                }
                                                else
                                                {
                                                    NoteYESORNODrivers = orderr.NoteYESORNODriver;



                                                }

                                            }
                                            catch
                                            {
                                                NoteYESORNODrivers = orderr.NoteYESORNODriver;

                                            }

                                            string FD = "https://api.whatsapp.com/send?phone=966" + numbercccc;
                                            if (orderr.IDDriver == 4915 || orderr.IDDriver == 5131 || orderr.IDDriver == 5600)
                                            {
                                                string Locationss = "https://www.google.com.sa/maps/place/" + orderr.LocalYY + "," + orderr.LocalXX;

                                                string loxshop = "000000000000";
                                                string loyshop = "000000000000";
                                                string pudf = "null";
                                                try
                                                {
                                                    UserShopBoshesArEn userShopBoshs = DataAccess.Instance.GetBoshOffse(orderr.IdBosh);
                                                    loxshop = userShopBoshs.LocationXXXBosh;
                                                    loyshop = userShopBoshs.LocationYYYBosh;
                                                    pudf = userShopBoshs.provincesBoshs;


                                                }
                                                catch
                                                {

                                                }

                                                string Locationssshop = "https://www.google.com.sa/maps/place/" + loxshop + "," + loyshop;
                                                SendNotificationWhatsUp(number, "* رقم الطلب :" + orderr.Id + "\\n "
                                                + "*التاريخ :" + orderr.DataOrder + "\\n "
                                                + "* المطعم :" + orderr.SubThoroughfare + "\\n "
                                                + "* رقم معرف المتجر :" + orderr.IdBosh.ToString() + "\\n "

                                              + "* الحي :" + pudf + "\\n "

                                            + "*نوع الدفع:" + PaymentStatusvvvv + "\\n "

                                            + "*الفاتورة :" + "\\n " + NoteYESORNODrivers + "\\n "
                                            + "\\n "
                                             + "* موقع المتجر :" + "\\n" + Locationssshop + "\\n "
                                            + "\\n "
                                            + "\\n "
                                             + "*رقم جوال العميل" + "\\n" + FD + "\\n" + numberCustomer + "\\n "
                                            + "\\n "
                                             + "* موقع العميل" + "\\n" + Locationss + "\\n "
                                            + "\\n ");



                                            }
                                            else
                                            {
                                                SendNotificationWhatsUp(number, "🟥 لديك طلب جديد ," + "\\n  " + "للتفاصيل الدخول على تطبيق دن دليفري" + "\\n  " + "🟥 رقم الطلب :" + orderr.Id + "\\n  " + "*التاريخ :" + orderr.DataOrder + "\\n  "
                                                 
                                              + "\\n " + FD + "\\n " + numberCustomer + "\\n  "
                                              + "\\n  "

                                             + "\\n  ");
                                            }



                                        }
                                        catch
                                        {

                                        }

                                        try
                                        {
                                            SendNotificationWhatsUp("0546029025", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");
                                            SendNotificationWhatsUp("0530702492", " 📳تم اسناد طلب من مندوب " + oldDirverid + " الى مندوب " + orderr.IDDriver.ToString() + "\\n " + " اسم المستخدم " + name + "\\n ");


                                        }
                                        catch
                                        {

                                        }

                                    }


                                }
                                catch
                                {

                                }
                            }

                        }


                    }

                    Response.Redirect("/AdminShops/OrdersTow.aspx", false);
                }



            }
            catch
            {

            }






        }
       
        protected void btnUploadModal_Click(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {

                  // تأكد من وجود HiddenField فيه ID داخل كل عنصر
                   

                if (fuModal.HasFile)
                {
                    int id = int.Parse(IdSus.Text);
                    string filename = Path.GetFileName(fuModal.FileName);
                    string uploadsFolder = Server.MapPath("~/Uploads/chat");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fuModal.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    fuModal.SaveAs(filePath);

                    // حفظ اسم الصورة في قاعدة البيانات
                    string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        string query = "UPDATE Supporttables SET Image_path = @Image_path WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Image_path", uniqueFileName);
                        cmd.Parameters.AddWithValue("@Id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // تحديث العرض
                    LoadComplaints("تحت المعالجة");

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('تم رفع الصورة بنجاح.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('الرجاء اختيار صورة.');", true);
                }
            }
            else
            {
                Response.Redirect("/AdminShops/AL", false);
            }

        }
    }





}