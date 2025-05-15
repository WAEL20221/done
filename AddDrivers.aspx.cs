using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using DocumentFormat.OpenXml.ExtendedProperties;
using MyFast.Controllers;
using MyFast.DAL;
using MyFast.Migrations;
using MyFast.Models;
using MyFast.Wrappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyFast.AdminShops
{
    public partial class AddDrivers : System.Web.UI.Page
    {
      
       // // public ApplicationDbContext dbContexts = new ApplicationDbContext();
        string ImagedrivinglicenseGet = "487024210PHOTO-2021-08-19-00-23-14.jpg";
        string ImageIdentityDriverGet = "487024210PHOTO-2021-08-19-00-23-14.jpg";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ANUser"] != null)
                {
                    List<CitiesSaudiArabia> CissstiesSaudiArabias = DataAccess.Instance.GetCitiesSaudiArabiasENALL();
                    DropDownList1.DataSource = CissstiesSaudiArabias;
                    DropDownList1.DataBind();


                    List<UserShopBoshesArEn> boshesArEns = DataAccess.Instance.GetUserShopBoshhARENNEW(CissstiesSaudiArabias.First().Id.ToString());
                     
                    foreach (UserShopBoshesArEn boshe in boshesArEns)
                    {
                         boshe.Not1 = "false";
                         
                    }

                    // 

                    CheckBoxList1.DataSource = boshesArEns;
                    CheckBoxList1.DataBind();


                }
                else
                {

                    Response.Redirect("/AdminShops/AL");
                }



            }
        }

        protected void TextBoxRePass_TextChanged(object sender, EventArgs e)
        {
           

        }
        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight, int maxWidth)
        {
            // var ratio = (double)maxHeight / image.Height;
            var newWidth = (int)(maxWidth);
            var newHeight = (int)(maxHeight);
            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
        public int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
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
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            
                if ( !string.IsNullOrEmpty(TextBoxIdDriver.Text)
                    && !string.IsNullOrEmpty(TextBoxStartWork.Text)
                    && !string.IsNullOrEmpty(TextBoxEndWork.Text))
                {   
               
            
               try   
                { 
                      try
                      {
                           Models.Driver drivers = DataAccess.Instance.GetDrivers(int.Parse(TextBoxIdDriver.Text));
                            if (drivers != null)
                            {

                            if (CheckBoxYes.Checked == true)
                            {
                                if (!string.IsNullOrEmpty(TextBoxstrtTow.Text) && !string.IsNullOrEmpty(TextBoxEndTow.Text))
                                {
                                    try
                                    {

                                        string idcity = DropDownList1.SelectedItem.Value;
                                         

                                        TimeSpan timeopen1s = TimeSpan.Parse(TextBoxStartWork.Text);

                                        TimeSpan timeclose1s = TimeSpan.Parse(TextBoxEndWork.Text);

                                        
                                        TimeSpan timeopen2s = TimeSpan.Parse(TextBoxstrtTow.Text);

                                        TimeSpan timeclose2s = TimeSpan.Parse(TextBoxEndTow.Text);


                                        TimeSpan timeopen3s = TimeSpan.Parse(TextBoxstrtThree.Text);

                                        TimeSpan timeclose3s = TimeSpan.Parse(TextBoxEndThree.Text);



                                        SqlParameter[] sqlpr = new SqlParameter[15];
                                        sqlpr[0] = new SqlParameter("@IDdrivers", drivers.Id);
                                        sqlpr[1] = new SqlParameter("@nameDrivers", drivers.NameDriver);
                                        sqlpr[2] = new SqlParameter("@idCitys", int.Parse(idcity));
                                        sqlpr[3] = new SqlParameter("@staticDrivers", "false");
                                   
                                       
                                        
                                        
                                        
                                        sqlpr[5] = new SqlParameter("@timeopen1s", timeopen1s);
                                        sqlpr[6] = new SqlParameter("@timeclose1s", timeclose1s); 

                                        sqlpr[7] = new SqlParameter("@timeopen2s", timeopen2s);
                                        sqlpr[8] = new SqlParameter("@timeclose2s", timeclose2s);




                                        sqlpr[9] = new SqlParameter("@not1x", drivers.NumberDriver);

                                        string idshop = "";
                                        string mameshop = "";
                                        try
                                        {
                                            var selectedItems = CheckBoxList1.Items.Cast<ListItem>().Where(x => x.Selected);

                                            foreach (ListItem item in selectedItems)
                                            {
                                                if (idshop == "")
                                                {
                                                    idshop = item.Value;
                                                    mameshop=item.Text;
                                                }
                                                else
                                                {
                                                    idshop = idshop + "," + item.Value;
                                                    mameshop = mameshop+ "-" + item.Text;
                                                }

                                            }
                                        }
                                        catch
                                        {

                                        }


                                        if (!string.IsNullOrEmpty(idshop))
                                        {
                                            sqlpr[10] = new SqlParameter("@not2x", idshop);
                                            sqlpr[4] = new SqlParameter("@useradds",mameshop);
                                        }
                                        else
                                        {
                                            sqlpr[10] = new SqlParameter("@not2x", "لا توجد متاجر مستثناه");
                                            sqlpr[4] = new SqlParameter("@useradds", "لا توجد متاجر مستثناه");
                                        }

                                        sqlpr[11] = new SqlParameter("@not3x", "true");
                                        





                                        sqlpr[12] = new SqlParameter("@not4x", "new");

                                        sqlpr[13] = new SqlParameter("@timeopen3s", timeopen3s);
                                        sqlpr[14] = new SqlParameter("@timeclose3s", timeclose3s);



                                        int i = ExecuteNonQuery(CommandType.StoredProcedure, "sp_AddDoneDriver", sqlpr);


                                        Response.Redirect("/AdminShops/Drivers.aspx");
                                    }
                                    catch
                                    {
                                        Label1.Text = "خطاء -يرجي التاكد من عدم انتهاء الجلسه";
                                    }
                                }
                                else
                                {
                                    Label1.Text = "يرجى ادخال وقت الفترة الثانية";

                                }

                                   
                            }
                            else
                            {

                                try
                                {
                     
                                    string idcity = DropDownList1.SelectedItem.Value;

                                    TimeSpan timeopen1s = TimeSpan.Parse(TextBoxStartWork.Text);

                                    TimeSpan timeclose1s = TimeSpan.Parse(TextBoxEndWork.Text);
                                     

                                    SqlParameter[] sqlpr = new SqlParameter[15];
                                    sqlpr[0] = new SqlParameter("@IDdrivers", drivers.Id);
                                    sqlpr[1] = new SqlParameter("@nameDrivers", drivers.NameDriver);
                                    sqlpr[2] = new SqlParameter("@idCitys", int.Parse(idcity));
                                    sqlpr[3] = new SqlParameter("@staticDrivers", "false");
                                   
                                    sqlpr[5] = new SqlParameter("@timeopen1s", timeopen1s);
                                    sqlpr[6] = new SqlParameter("@timeclose1s", timeclose1s); 

                                    sqlpr[7] = new SqlParameter("@timeopen2s", timeopen1s);
                                    sqlpr[8] = new SqlParameter("@timeclose2s", timeclose1s);




                                    sqlpr[9] = new SqlParameter("@not1x", drivers.NumberDriver);






                                    string idshop = "";
                                    string Nameshop = "";
                                    try
                                    {
                                        var selectedItems = CheckBoxList1.Items.Cast<ListItem>().Where(x => x.Selected);

                                        foreach (ListItem item in selectedItems)
                                        {
                                            if (idshop == "")
                                            {
                                                idshop = item.Value;
                                                Nameshop = item.Text;
                                            }
                                            else
                                            {
                                                idshop = idshop + "," + item.Value;
                                                Nameshop = Nameshop + "-" + item.Text;
                                            }

                                        }
                                    }
                                    catch
                                    {

                                    }


                                    if (!string.IsNullOrEmpty(idshop))
                                    {
                                        sqlpr[10] = new SqlParameter("@not2x", idshop);
                                        sqlpr[4] = new SqlParameter("@useradds", Nameshop);
                                    }
                                    else
                                    {
                                        sqlpr[10] = new SqlParameter("@not2x", "لا توجد متاجر مستثناه");
                                        sqlpr[4] = new SqlParameter("@useradds", "لا توجد متاجر مستثناه");
                                    }





                                    

                                    sqlpr[11] = new SqlParameter("@not3x", "false");
                                      

                                    sqlpr[12] = new SqlParameter("@not4x", "new");

                                    sqlpr[13] = new SqlParameter("@timeopen3s", timeopen1s);
                                    sqlpr[14] = new SqlParameter("@timeclose3s", timeclose1s);



                                    int i = ExecuteNonQuery(CommandType.StoredProcedure, "sp_AddDoneDriver", sqlpr);


                                    Response.Redirect("/AdminShops/Drivers.aspx");
                                }
                                catch
                                {
                                    Label1.Text = "خطاء -يرجي التاكد من عدم انتهاء الجلسه";
                                }

                            }

                                



                            }
                            else
                            {
                            Label1.Text = "رقم معرف المندوب غير مسجل لدينا- يرجى تسجيل المندوب اولا - او التاكد من ادخال رقم المعرف المندوب بشكل صحيح";
                             }
                        }
                        catch
                        {
                        Label1.Text = "رقم معرف المندوب غير مسجل لدينا- يرجى تسجيل المندوب اولا - او التاكد من ادخال رقم المعرف المندوب بشكل صحيح";
                         }
                     
                    }
                    catch
                    {
                        Label1.Text = "خطاء";
                    }
                }
                else
                {
                    Label1.Text = "يرجى ادخال البيانات بشكل صحيح";
                }
             

        }

       

        protected void CheckBoxNo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes.Checked = false;

            Twos.Visible = false;
            TwosT.Visible= false;


            Twos1.Visible = false;
            TwosT1.Visible = false;

        }

        protected void CheckBoxYes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo.Checked = false;
            Twos.Visible = true;
            TwosT.Visible = true;
            Twos1.Visible = true;
            TwosT1.Visible = true;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        { 
                CheckBoxList1.DataSource = DataAccess.Instance.GetUserShopBoshhARENNEW(DropDownList1.SelectedItem.Value);
                CheckBoxList1.DataTextField = "NameBosh";
                CheckBoxList1.DataValueField = "Id";
                CheckBoxList1.DataBind();

          
        }
    }
   
}