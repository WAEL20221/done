using MyFast.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.Data.Entity;
using System.Configuration;
using DocumentFormat.OpenXml.Spreadsheet;
using Org.BouncyCastle.Math;

namespace MyFast.AdminShops
{
    public partial class AccountsBosh : System.Web.UI.Page
    {
      //// public ApplicationDbContext dbContexts = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ANUser"] != null)
            {
                string name = Session["ANUser"].ToString();
                UserRoleDone  UserRoleDonesc = MyFast.DAL.DataTableToModelHelper.GetUserRoleDoneData(name, "AccountsBosh");
                if (UserRoleDonesc != null)
                {   
                    
                    if(UserRoleDonesc.ADDData=="0")
                    {
                        ButtonADD.Visible = false;
                    }


                }
                else
                {
                    Response.Redirect("/AdminShops/AL");
                }

             }
            else
            {

                Response.Redirect("/AdminShops/AL");
            }
             
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

        protected void ButtonADD_Click(object sender, EventArgs e)
        {
            // رقم الحساب البنكي
            // TextBox2

            //اسم صاحب الحساب
            //TextBox3

            //البنك
            //TextBox4

            // رقم الهاتف
            //TextBox5


            if (!string.IsNullOrWhiteSpace(TextBox2.Text)&& !string.IsNullOrWhiteSpace(TextBox3.Text)
                && !string.IsNullOrWhiteSpace(TextBox4.Text)&& !string.IsNullOrWhiteSpace(TextBox5.Text))
            {
            
             int CIDCity = int.Parse(DropDownList1.SelectedValue); 
             string CNameCity = DropDownList1.SelectedItem.ToString();
            


            BillInterim BillInterimSS = new BillInterim();

            // IdCUstomer, IdBosh, IdPorducts, NamePorducts, Count, Pric, ADDAndNoAdd, IdOrder, DataBill, TimeBill

            //معرف المتجر
            BillInterimSS.IdBosh = CIDCity.ToString();
            //اسم المتجر
            BillInterimSS.IdCUstomer = CNameCity;
            // رقم الحساب البنكي
            BillInterimSS.IdPorducts = TextBox2.Text;
            //اسم صاحب الحساب
            BillInterimSS.NamePorducts = TextBox3.Text;
            //البنك
            BillInterimSS.Count = TextBox4.Text;
            // رقم الهاتف
            BillInterimSS.Pric = TextBox5.Text;

            // تاريخ الاضافة
            BillInterimSS.DataBill = System.DateTime.Now.ToString("yyyy/MM/dd");
            // وقت الاضافة
            BillInterimSS.TimeBill = DateTime.Now.ToString("HH:mm");



           // dbContexts.BillInterims.Add(BillInterimSS);
          //  dbContexts.SaveChanges();

                SqlParameter[] sqlpr = new SqlParameter[10];

                sqlpr[0] = new SqlParameter("@IdCUstomers", BillInterimSS.IdCUstomer);
                sqlpr[1] = new SqlParameter("@IdBoshs", BillInterimSS.IdBosh);
                sqlpr[2] = new SqlParameter("@IdPorductss", BillInterimSS.IdPorducts);
                sqlpr[3] = new SqlParameter("@NamePorductss", BillInterimSS.NamePorducts);
                sqlpr[4] = new SqlParameter("@Counts", BillInterimSS.Count);
                sqlpr[5] = new SqlParameter("@Prics", BillInterimSS.Pric);
                sqlpr[6] = new SqlParameter("@ADDAndNoAdd", BillInterimSS.ADDAndNoAdd);
                sqlpr[7] = new SqlParameter("@IdOrders", BillInterimSS.IdOrder);
                sqlpr[8] = new SqlParameter("@@DataBills", BillInterimSS.DataBill);
                sqlpr[9] = new SqlParameter("@@TimeBills", BillInterimSS.TimeBill);
 
                int isd = ExecuteNonQuery(CommandType.StoredProcedure, "sp_AddBillInterims", sqlpr);


                Response.Redirect("/AdminShops/AccountsBosh.aspx");
            }

        }

        
    }
}