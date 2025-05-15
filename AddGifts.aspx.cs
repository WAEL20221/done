 
using Microsoft.AspNet.Identity;
using MyFast.AdminShops.databa;
using MyFast.DAL;
using MyFast.Models;
using Nest;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFast.AdminShops
{
    public partial class AddGifts : System.Web.UI.Page
    {
     
      //  // private ApplicationDbContext db = new ApplicationDbContext();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string IdBerments = Request.QueryString["IdBerment"];
                
                //Session["IdBoshBepartmentsAdmin"] = IdBerments;
                //Session["IdUserShopBoshBepartmen"] = IdBerments;

            }
        }

 



        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            string IDSectio = "no";
            int INN = int.Parse(e.CommandName);
            try
            {
                 IDSectio = Request.QueryString["Sectio"];

            }
            catch
            {

            }


            if (IDSectio != "no" )
            {
                if(IDSectio== "5" || IDSectio == "0" )
                {
                    Response.Redirect("ShopBepartmentBepart.aspx?IdBermentBer=" + INN.ToString());
                }
                else
                {
                    Response.Redirect("Shopproget.aspx?IdBes=" + INN.ToString());
                }
                 

            }
            else
            {


                Response.Redirect("Shopproget.aspx?IdBes=" + INN.ToString());
            }

           


            //Session["IdBoshadmin"] = e.CommandName;
            //Response.Redirect("/Home/HomeServiceadmin");

        }

        protected void Button2_Command(object sender, CommandEventArgs e)
        {
            Session["IdBoshadmin"] = e.CommandName;
            Response.Redirect("/BoshServicsAdmin.aspx");
        }

        protected void Button1s_Command(object sender, CommandEventArgs e)
        {

        }

        protected void Button3_Command(object sender, CommandEventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string vd = e.CommandName;

                //UserShopBoshBepartment UserShopBoshBepartments = db.UserShopBoshBepartments.Find(int.Parse(vd));
                //db.UserShopBoshBepartments.Remove(UserShopBoshBepartments);
                //db.SaveChanges();

                UserShopBoshBepartment UserShopBoshBepartments = DataAccess.Instance.GetUserShopBoshBepartments(int.Parse(vd));
                try
                {
                    SqlParameter[] sqlpr = new SqlParameter[1];

                    sqlpr[0] = new SqlParameter("@Ids", UserShopBoshBepartments.Id);
                    int i = ExecuteNonQuery(CommandType.StoredProcedure, "sp_DELETEtoUserShopBoshBepartments", sqlpr);

                }
                catch
                {

                }

                try
                {
                    List<ProductsArEn> Producta = DataAccess.Instance.GetProducBepartments(int.Parse(vd));

                    foreach (ProductsArEn productsAr in Producta)
                    {
                        try
                        {
                            SqlParameter[] sqlpr = new SqlParameter[1];

                            sqlpr[0] = new SqlParameter("@Id", productsAr.Id);
                            int i = ExecuteNonQuery(CommandType.StoredProcedure, "sp_DELETEtoProductsArEns", sqlpr);

                        }
                        catch
                        {

                        }

                    }


                }
                catch
                {

                }







                Response.Redirect("/BoshBepartmentsAdmin");
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            }
            else
            {
                //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }




        }


        public int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
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


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("Gifts.aspx");
             


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

        protected void Button2_Click(object sender, EventArgs e)
        {

            LabelEroor.Text = "";

           if (!string.IsNullOrEmpty(TextBoxname_package_detailsar.Text) && !string.IsNullOrEmpty(TextBoxnot1EN.Text))
            { 

            if (FileUpload2.HasFile)
            {
                    string Imagess1 = "no";
                if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
                {
                    Guid uid = Guid.NewGuid();
                    string fn = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("~/Uploads/ImageChat/") + @"\" + uid + fn;
                   
                    try
                    {
                        string fileExtention = FileUpload2.PostedFile.ContentType;
                        // int fileLenght = FileUpload2.PostedFile.ContentLength;
                        if (fileExtention == "image/png" || fileExtention == "image/jpeg" || fileExtention == "image/x-png")
                        {
                            //if (fileLenght <= 1048576)
                            //{
                          //  System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(FileUpload2.PostedFile.InputStream);

                           // System.Drawing.Image objImage = ScaleImage(bmpPostedImage, 600, 100);
                            // Saving image in jpeg format

                          //  objImage.Save(SaveLocation, ImageFormat.Jpeg);
                          FileUpload2.SaveAs(SaveLocation);
                                string stsr = uid + fn;
                            string Imagess = stsr.ToString();

                                Imagess1 = Imagess;
                        }
                        else
                        {
                           
                            LabelEroor.Text = "يرجى أضافة صورة";
                            LabelEroor.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        LabelEroor.Text = "يرجى أضافة صورة";
                        LabelEroor.ForeColor = System.Drawing.Color.Red;
                        }
               
                    
                        try
                        {

                               package_details package_detai = new package_details();

                            package_detai.name_package_details = TextBoxname_package_detailsar.Text;

                            package_detai.not2 = TextBoxnot1EN.Text;
                                // [Display(Name = "صورة المنتج ")]

                              string imagtest=  "DoneLogeKsa.jpg";

                                if (Imagess1.Length > 0)
                                {
                                package_detai.image_package_details = Imagess1;

                                }
                                else
                                {

                                package_detai.image_package_details = imagtest;

                                }
                            package_detai.details_package_details = "new";
                            int idpackageb =0;
                            try
                            { 

                               string idpackageText = Request.QueryString["idpackageQuery"];

                                try
                                {
                                    idpackageb = int.Parse(idpackageText);
                                }
                                catch
                                {

                                }

                            }
                            catch
                            {

                            }

                            package_detai.idpackage = idpackageb;
                            package_detai.massege_package = "new";
                            package_detai.not1 = "new";
                            package_detai.not3 = "new";


                            SqlParameter[] sqlpr = new SqlParameter[8];


                            sqlpr[0] = new SqlParameter("@name_package_detailss", package_detai.name_package_details);



                            sqlpr[1] = new SqlParameter("@image_package_detailss", package_detai.image_package_details);


                            sqlpr[2] = new SqlParameter("@details_package_detailss", package_detai.details_package_details);

                            sqlpr[3] = new SqlParameter("@idpackages", package_detai.idpackage);

                            sqlpr[4] = new SqlParameter("@massege_packages", package_detai.massege_package);

                            sqlpr[5] = new SqlParameter("@not1s", package_detai.not1);

                            sqlpr[6] = new SqlParameter("@not2s", package_detai.not2);
                            sqlpr[7] = new SqlParameter("@not3s", package_detai.not3);

                             
                            int i = ExecuteNonQuery(CommandType.StoredProcedure, "sp_Addtopackage_details", sqlpr);

                            //  dbContexts.Products.Add(Productsss);
                            // dbContexts.SaveChanges();

                            try
                            {


                                string idpackageText = "0";



                                idpackageText = Request.QueryString["idpackageQuery"];
                               


                                Response.Redirect("AddGifts.aspx?idpackageQuery=" + idpackageText );

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

                LabelEroor.Text = "يرجى أضافة صورة";
                LabelEroor.ForeColor = System.Drawing.Color.Red;
            }

            }
            else
            {
                LabelEroor.Text = "يرجى أضافة الحقول الفارغة";
                LabelEroor.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}