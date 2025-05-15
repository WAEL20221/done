<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/AdminShops/AdminUser.Master" AutoEventWireup="true" CodeBehind="DeliveryRequests.aspx.cs" Inherits="MyFast.AdminShops.DeliveryRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script>
    $(function () {
        setInterval(function () {
            $("[id*=dvTimes]").each(function () {
                var startdata = $(this).find("[id*=lblStartDateTime]").html();
                var startTime = $(this).find("[id*=lblStartDTime]").html();

                $(this).find("[id*=lblTimer]").html(GetTimer(startdata + " " + startTime));

            });
        }, 1000);
    });

    function GetTimer(startDate) {



        var startDate = new Date(startDate);



        var now = new Date().getTime();



        var distance = now - startDate;



        var obj = {};
        obj.days = Math.floor(distance / (1000 * 60 * 60 * 24));
        obj.hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        obj.minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        obj.seconds = Math.floor((distance % (1000 * 60)) / 1000);




        return obj.hours + ' ساعات -' + obj.minutes + ' دقائق -' + obj.seconds + ' ثواني ';
    };



</script>
    <style>
        /* تنسيق الكرت */
        .complaint-card {
            border: 1px solid #ddd;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            margin: 20px 0;
            background-color: #f9f9f9;
        }

        .complaint-card .card-header {
            background-color: #ff6666;
            color: white;
            font-size: 1.2rem;
            font-weight: bold;
            padding: 15px;
        }

        .complaint-card .card-body {
            padding: 20px;
        }

        .complaint-card .card-body p {
            font-size: 1.1rem;
        }

        .complaint-card .card-footer {
            background-color: #f0f0f0;
            padding: 10px;
            text-align: right;
        }

        .complaint-card .btn-respond {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 20px;
            font-size: 1rem;
            border-radius: 5px;
            cursor: pointer;
        }

        .complaint-card .btn-respond:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   

    <a  dir="ltr"   href="Admin.aspx" style="text-align:left;     " class="btn btn-success btn-sm">رجوع</a>
 
    <a id="hrefs" runat="server"  dir="ltr"  href="Ordersstepy.aspx" style="text-align:left;" Visible="false"  class="btn btn-google  btn-sm">طلبات تحت الانشاء</a>
    <a id="A1s" runat="server"  dir="ltr"  href="Orders.aspx" style="text-align:left;" Visible="false"   class="btn btn-outline-primary btn-sm">التصميم القديم</a>

      <div style="width:100%;  font-size:small; text-align:right;" class="card shadow mb-4">
           
          
          <div class="card-header py-3">
                      
                                                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>   
                           
                             


     
                             <br />
                             <div style="   margin-top:5px; width:60%; " class="input-group">
                            <asp:TextBox ID="TextBox14" AutoPostBack="true"  class="form-control text-success border-1 small" placeholder="رقم الطلب" runat="server"></asp:TextBox>
                           
                            <div>
             
                                 <asp:LinkButton AutoPostBack="true" class="btn btn-primary" OnClick="btnSearch_Click"   runat="server" ID="btnSearch">
   <i class="fas fa-search fa-sm"></i>
                     </asp:LinkButton>
                               
                            </div>
                        </div>
                             <br />


                           
                            <h6 class="m-0 font-weight-bold text-primary">الطلبيات</h6>
                           
                            <table class="table ">
                            <tbody>
     
     
    <tr>
      <th scope="row"><asp:Button ID="Button19" Font-Size="9" OnClick="btnview1_Click"  CssClass="btn btn-outline-danger btn-sm" runat="server" Text="انتظار المندوب" /> &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" Font-Size="9" OnClick="btnview5_Click"  CssClass="btn btn-outline-danger btn-sm" runat="server" Text="انتظار المتجر" />   </th>

         <td colspan="3" >   
                           <asp:Button ID="Button18" OnClick="Button18_Click"  Font-Size="9" CssClass="btn btn-outline-info btn-sm" runat="server" Text="مقبولة بدون مندوب" /> 
        <asp:Button ID="Button20" OnClick="btnview2_Click"  Font-Size="9" CssClass="btn btn-outline-warning btn-sm" runat="server" Text="المقبولة" />   
 
    &nbsp;&nbsp;&nbsp;
              <asp:Button ID="Button26" OnClick="Button26_Click"  Font-Size="9" CssClass="btn btn-outline-dark btn-sm" runat="server" Text="تحتاج متابعة" /> 
            <asp:Button ID="Button21" Font-Size="9" OnClick="btnview3_Click"  CssClass="btn btn-outline-primary btn-sm" runat="server" Text="استلمها المندوب" />  &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button223" OnClick="btnview4_Click" Font-Size="9"  CssClass="btn btn-outline-success btn-sm" runat="server" Text="منتهي" />&nbsp;&nbsp;&nbsp;
           <asp:Button ID="Button2" OnClick="btnview6_Click" Font-Size="9"  CssClass="btn btn-outline-danger btn-sm" runat="server" Text="مرفوض" />
         

         </td>




    </tr>
  </tbody>
</table>

                            
                    <asp:MultiView ID="MultiView1" runat="server">




                         <asp:View ID="View1" runat="server">
                           
                            
                                   
                          
                            
           
                                <div style="width:100%;   " class="card shadow mb-6">
                                   
                                    <div class="card-body"  >
                                       
                                        
                          
                <asp:Label BorderColor="Red" ID="Label40" Font-Size="Large"  BackColor="White"   ForeColor="Red" Font-Bold="true"  runat="server" Text="طلبات في انتظار قبول المندوب" ></asp:Label>
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView1"   AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                    <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table id="dvTimes"   class="table-responsive table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>

                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1" ID="Labeggl66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>
                  <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Labebbdl66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="متجر وهمي في انتظار اسناد للمندوب" ></asp:Label>
</span>
      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
    
 <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="lblStartDTime" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 </tr>
   
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td colspan="3">  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
  
  </tr>
                                      
 <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                     <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
      <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>

<tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
 


 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
  

      </td>
      
 </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
      
<asp:Button OnCommand="ButtonAddnotss_Command"   Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>

<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
          <asp:Button OnCommand="Button3_Command"    CommandName='<%# Eval("IdBosh") %>' ID="Button3" CssClass="btn btn-facebook btn-sm" runat="server" Text=" ارقام المتجر" />

           <asp:Button OnCommand="Button6_Command" Visible="false"  Font-Size="9"     CommandName='<%# Eval("Id") %>' ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text="رفض الطلب" /> 
          
          
          <asp:Button OnCommand="Button9_Command" Visible="false"  Font-Size="9"    CommandName='<%# Eval("IdCustomer") %>' ID="Button9" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للعميل" />

            <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>
                                           
                                    
          <asp:Button OnCommand="Button15_Command"     Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button15" CssClass="btn btn-facebook btn-sm" runat="server" Text="اسناد" /> 
             </span>
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
<asp:Button OnCommand="Button14444335_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button28" CssClass="btn btn-outline-danger btn-sm" runat="server" Text="اسناد سريع" /> 
 </span>
      </td>
      
    </tr>


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                  
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                
                                </div>
                                     </div>
                                   </div>
                                 <asp:DataPager ID="DataPager1" PagedControlID="ListView1" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                         

                        </asp:View>
                         <asp:View ID="View5" runat="server">
                           
                            
                                   
                          
                            
           
                                <div style="width:100%;   " class="card shadow mb-6">
                                   
                                    <div class="card-body"  >
                                       
                                        
                          
                <asp:Label BorderColor="Red" ID="Label31" Font-Size="Large"  BackColor="White"   ForeColor="Red" Font-Bold="true"  runat="server" Text="الطلبات في انتظار قبول المتجر" ></asp:Label>
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView7"   AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                       <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table id="dvTimes"   class="table-responsive table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
          
          


      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>

                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1" ID="Labeljj66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>

         <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Labebbdl66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="متجر وهمي في انتظار اسناد للمندوب" ></asp:Label>
</span>

      </td>



      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
      <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="lblSe" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 
  </tr>
     
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td colspan="3">  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
  
  </tr>
      <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                    
                                                     <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                     
                                                   
                                               </span>
        

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
      <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
 <tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="lblStartDTime" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="Label55" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text="في انتظار قبول المتجر" ></asp:Label></td>
 </tr>
 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>

<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
          <asp:Button OnCommand="Button3_Command"    CommandName='<%# Eval("IdBosh") %>' ID="Button3" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رقم المتجر" />
   <asp:Button OnCommand="Button6_Command" Visible="false"   Font-Size="9"     CommandName='<%# Eval("Id") %>' ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text="قبول او رفض الطلب" /> 
                                             <asp:Button OnCommand="Button7_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button7" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمتجر" /> 
                                             <asp:Button OnCommand="Button8_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button8" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمندوب" /> 
                                            <asp:Button OnCommand="Button9_Command" Visible="false" Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button9" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للعميل" /> 
              <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
          <asp:Button OnCommand="Button15_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button15" CssClass="btn btn-facebook btn-sm" runat="server" Text="اسناد" /> 
           </span>

   <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
<asp:Button OnCommand="Button14444335_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button28" CssClass="btn btn-outline-danger btn-sm" runat="server" Text="اسناد سريع" /> 
 </span>
      </td>
      
    </tr>


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                  
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                
                                <</div>
                                     </div>
                                   </div>
                                 <asp:DataPager ID="DataPager5" PagedControlID="ListView7" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                
                          


                                 
 
                                               
                                   
                          


                                 
 
                                               
                                          



                        </asp:View> 
                         <asp:View ID="View2" runat="server">
                           

                            
                              
                            
                            
                                <div style="width:100%;   " class="card shadow mb-6">
                         
                                    <div class="card-body"  >
                                       
                                                     <asp:Label BorderColor="Gold" ID="Label38" Font-Size="Large"  BackColor="White"   ForeColor="Goldenrod" Font-Bold="true"  runat="server" Text="الطلبات المقبولة" ></asp:Label>
                            
        
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView4"  AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                            <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table id="dvTimes"   class="table-responsive table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>
 
                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1" ID="Labebbdl66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>
                   <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label66" Font-Size="11"      ForeColor="Green" Font-Bold="true"  runat="server" Text="متجر وهمي " ></asp:Label>
</span>
      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
      <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="lbls" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 </tr>
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td >  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
   <td>معرف المندوب</td>
      <td >  <asp:Label ID="Label11" ForeColor="Black" Text=<%# Eval("IDDriver")  %>   Font-Bold="true"   runat="server"></asp:Label> 
           <span runat="server" Visible='<%# (int)Eval("IDDriver")==7 %>'>
               <asp:Label ID="Label12" ForeColor="Red" Text="لا يوجد مندوب بعد "  Font-Bold="true"   runat="server"></asp:Label> 
              </span>
      </td>

  </tr>
     <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                    <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
    <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
  <tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="Label53" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="lblStartDTime" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptBosh") %> ></asp:Label></td>
 </tr>
 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>

<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
          <asp:Button OnCommand="Button3_Command"    CommandName='<%# Eval("IdBosh") %>' ID="Button24" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رقم المتجر" />
   <asp:Button OnCommand="Button6_Command" Visible="false"   ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رفض الطلب" /> 
                                             <asp:Button OnCommand="Button7_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button7" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمتجر" /> 
                                             <asp:Button OnCommand="Button8_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button8" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمندوب" /> 
                                            <asp:Button OnCommand="Button9_Command" Visible="false"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button9" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للعميل" /> 
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                            
          <asp:Button OnCommand="Button15_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button15" CssClass="btn btn-facebook btn-sm" runat="server" Text="اسناد" />
          </span>
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
<asp:Button OnCommand="Button14444335_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button28" CssClass="btn btn-outline-danger btn-sm" runat="server" Text="اسناد سريع" /> 
 </span>
          <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
         <asp:Button OnCommand="Button773_Command"    Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button3" CssClass="btn btn-facebook btn-sm" runat="server" Text="اصدار فاتورة" /> 
           </span>
            

           <span runat="server" Visible='<%# (int)Eval("IDDriver")==11 %>'>
           <asp:Button OnCommand="Button23_Command"     Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button23" CssClass="btn btn-danger btn-sm" runat="server" Text="ترحيل الطلب" /> 
           </span>
                    <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>
 <span runat="server"  Visible='<%# (string)Eval("PostalCode")!="storedone" %>'  >
<asp:Button OnCommand="Button2DD8_Command"  Visible="false"   Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button2DD8" CssClass="btn btn-success btn-sm" runat="server" Text="اتمام الطلب" /> 
</span>

</span>
    <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
   <a href='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>' target="_blank"> 
   <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>'  />
</a>
    
</span>
      </td>
      
    </tr>


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                    
                                       
                                   
                                     
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                  </div>
                                     </div>
                                   </div>
                            
                                 <asp:DataPager ID="DataPager2" PagedControlID="ListView4" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                
                          


                                 
 
                                               
                                        



                        </asp:View> 
                         <asp:View ID="View8" runat="server">
                           

                      
                              
                            
                            
                                <div style="width:100%;   " class="card shadow mb-6">
                         
                                    <div class="card-body"  >
                                       
                                                     <asp:Label BorderColor="Teal" ID="Label30" Font-Size="Large"  BackColor="White"   ForeColor="Teal" Font-Bold="true"  runat="server" Text="مقبولة بدون مندوب" ></asp:Label>
                            
        
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView10"   AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                            <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table id="dvTimes"   class="table-responsive table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>
 
                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label6jjs6" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>
                   <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label66" Font-Size="11"      ForeColor="Green" Font-Bold="true"  runat="server" Text="متجر وهمي " ></asp:Label>
</span>
      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
      <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="lbls" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 </tr>
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td >  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
   <td>معرف المندوب</td>
      <td >  <asp:Label ID="Label11" ForeColor="Black" Text=<%# Eval("IDDriver")  %>   Font-Bold="true"   runat="server"></asp:Label> 
           <span runat="server" Visible='<%# (int)Eval("IDDriver")==7 %>'>
               <asp:Label ID="Label12" ForeColor="Red" Text="لا يوجد مندوب بعد "  Font-Bold="true"   runat="server"></asp:Label> 
              </span>
      </td>

  </tr>
     <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                    <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
    <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
  <tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="Label53" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="lblStartDTime" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptBosh") %> ></asp:Label></td>
 </tr>
 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>

<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
          <asp:Button OnCommand="Button3_Command"    CommandName='<%# Eval("IdBosh") %>' ID="Button24" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رقم المتجر" />
   <asp:Button OnCommand="Button6_Command"  Visible="false"  Font-Size="9"  CommandName='<%# Eval("Id") %>'    ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رفض الطلب" /> 
                                             <asp:Button OnCommand="Button7_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button7" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمتجر" /> 
                                             <asp:Button OnCommand="Button8_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button8" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمندوب" /> 
                                            <asp:Button OnCommand="Button9_Command" Visible="false"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button9" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للعميل" /> 
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                            
          <asp:Button OnCommand="Button15_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button15" CssClass="btn btn-facebook btn-sm" runat="server" Text="اسناد" />
          </span>
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
<asp:Button OnCommand="Button14444335_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button28" CssClass="btn btn-outline-danger btn-sm" runat="server" Text="اسناد سريع" /> 
 </span>
          <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
         <asp:Button OnCommand="Button773_Command" Visible="false"    Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button3" CssClass="btn btn-facebook btn-sm" runat="server" Text="اصدار فاتورة" /> 
           </span>
            

           <span runat="server" Visible='<%# (int)Eval("IDDriver")==11 %>'>
           <asp:Button OnCommand="Button23_Command"     Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button23" CssClass="btn btn-danger btn-sm" runat="server" Text="ترحيل الطلب" /> 
           </span>
 
              <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
   <a href='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>' target="_blank"> 
   <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>'  />
</a>
    
</span>
      </td>
      
    </tr>


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                    
                                       
                                   
                                     
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                  </div>
                                     </div>
                                   </div>
                            
                                 <asp:DataPager ID="DataPager8" PagedControlID="ListView10" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                
                          


                                 
 
                                               
                                        



                        </asp:View> 
                         <asp:View ID="View3" runat="server">
                          
                            
                              
                                <div style="width:100%;   " class="card shadow mb-6">
                                    
                                    <div class="card-body"  >
                                       
                                          <asp:Label BorderColor="Blue" ID="Label39" Font-Size="Large"  BackColor="White"   ForeColor="Blue" Font-Bold="true"  runat="server" Text="استلمها المندوب" ></asp:Label>
                            
        
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView5"   AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                           <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table id="dvTimes"   class="table-responsive table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>
                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1" ID="Labelttsf66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>                   <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label66" Font-Size="11"      ForeColor="Green" Font-Bold="true"  runat="server" Text="متجر وهمي " ></asp:Label>
</span>
      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
      <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="sddfdfdf" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 </tr>
    
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td colspan="3">  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
  
  </tr>

      <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                    <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
    <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
<tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="Label53" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="Label55" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptBosh") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت استلام الطلب </th>
       <td><asp:Label BorderColor="Blue" ID="lblStartDTime" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptReceivedDriver") %> ></asp:Label></td>
      <td>وقت تسليم الطلب</td>
      <td><asp:Label BorderColor="Blue" ID="Label56" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text="في انتظار تسليم الطلب" ></asp:Label></td>
 </tr>


 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>

<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
   <asp:Button OnCommand="Button6_Command"    Visible="false" Font-Size="9"  CommandName='<%# Eval("Id") %>'   ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رفض الطلب" /> 
                                             <asp:Button OnCommand="Button7_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button7" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمتجر" /> 
                                             <asp:Button OnCommand="Button8_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button8" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمندوب" /> 
                                            <asp:Button OnCommand="Button9_Command" Visible="false"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button9" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للعميل" /> 
               <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                          
          <asp:Button OnCommand="Button15_Command"  Visible="false"  Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button15" CssClass="btn btn-facebook btn-sm" runat="server" Text="اسناد" /> 
         </span>
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
<asp:Button OnCommand="Button14444335_Command"     Visible="false"    Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button28" CssClass="btn btn-outline-danger btn-sm" runat="server" Text="اسناد سريع" /> 
 </span>
                   <asp:Button OnCommand="Button23_Command"  Visible="false"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button23" CssClass="btn btn-facebook btn-sm" runat="server" Text="اتمام الطلب" /> 
     
                    <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>
 <span runat="server"  Visible='<%# (string)Eval("PostalCode")!="storedone" %>'  >
<asp:Button OnCommand="Button2DD8_Command"  Visible="false"   Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button2DD8" CssClass="btn btn-success btn-sm" runat="server" Text="اتمام الطلب" /> 
</span>
</span>
          <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
   <a href='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>' target="_blank"> 
   <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>'  />
</a>
    
</span>
      </td>
      
    </tr>


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                    
                                       
                                   
                                     
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                  </div>
                                     </div>
                                   </div>
                            
                                 <asp:DataPager ID="DataPager3" PagedControlID="ListView5" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                


                        </asp:View>  
                         <asp:View ID="View4" runat="server">
                          
                            
                              
                                <div style="width:100%;   " class="card shadow mb-6">
                                    
                                    <div class="card-body"  >
                                       
                                          <asp:Label BorderColor="Blue" ID="Label42" Font-Size="Large"  BackColor="White"   ForeColor="Green" Font-Bold="true"  runat="server" Text="منتهيه" ></asp:Label>
                             
                             <div  class="row">
                                  
                       
 
                           <asp:ListView ID="ListView6"   AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                    


                                             <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                               <table id="dvTimes"  class="table-responsive table-bordered table-sm">
                                   <tbody >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>
                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1" ID="Labejrsssl66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>                   <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label66" Font-Size="11"      ForeColor="Green" Font-Bold="true"  runat="server" Text="متجر وهمي " ></asp:Label>
</span>
      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
     <tr>
   <th scope="row">الوقت</th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="sbtghh" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
      <td>التاريخ</td>
      <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
    </tr>

  <tr>
<th scope="row">الوقت المنقضي</th>
   <td colspan="3">  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
  
  </tr>

     <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                    <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
     <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
<tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="Label53" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="Label55" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptBosh") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت استلام الطلب </th>
       <td><asp:Label BorderColor="Blue" ID="Label54" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptReceivedDriver") %>   ></asp:Label></td>
      <td>وقت تسليم الطلب</td>
      <td><asp:Label BorderColor="Blue" ID="lblStartDTime" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeDriver") %>  ></asp:Label></td>
 </tr>

 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>

<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
   <asp:Button OnCommand="Button6_Command"  Visible="false"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رفض الطلب" /> 
               <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
   <a href='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>' target="_blank"> 
   <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>'  />
</a>
    
</span>
                             
      </td>
      
    </tr>


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                    
                                       
                                   
                                     
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                  </div>
                                     </div>
                                   </div>
                            
                                 <asp:DataPager ID="DataPager4" PagedControlID="ListView6" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                


                        </asp:View> 
                         <asp:View ID="View6" runat="server"> 
                                <div style="width:100%;   " class="card shadow mb-6" >
                                   
                                    <div class="card-body"   >
                                       
                                        
                          
                <asp:Label BorderColor="Red" ID="Label37" Font-Size="Large"  BackColor="White"   ForeColor="Red" Font-Bold="true"  runat="server" Text="الطلبات المرفوضه" ></asp:Label>
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView8"  AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                       <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table  id="dvTimes"  class="table-responsive table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>
                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1" ID="Lasgbel6hh6" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>                   <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label66" Font-Size="11"      ForeColor="Green" Font-Bold="true"  runat="server" Text="متجر وهمي " ></asp:Label>
</span>
      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
       <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="lblStartDTime" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 </tr>
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td colspan="3">  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
  
  </tr>
     <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                    <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
     <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
<tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr  >
   <th  style="color:forestgreen;" scope="row">سبب الرفض </th>
       <td colspan="3" >
           
             <span runat="server" Visible='<%# (string)Eval("CancelOrder")=="true" %>'>
               <asp:Label BorderColor="Brown" Font-Size="9" ID="Label5" ForeColor="Red" Font-Bold="true"    runat="server" Text="رفضها العميل"></asp:Label>
                 <asp:Label BorderColor="Brown" Font-Size="9" ID="Label6" ForeColor="Blue" Font-Bold="true"    runat="server"  Text=<%# Eval("NotCancelOrder") %>></asp:Label>
              </span>

           <span runat="server" Visible='<%# (string)Eval("StatusBosh")=="false" &&(string)Eval("StatusDriver")=="true" &&(string)Eval("CancelOrder")!="true" %>'>
               <asp:Label BorderColor="Brown" Font-Size="9" ID="Label7" ForeColor="Red" Font-Bold="true"    runat="server" Text="رفضها المتجر"></asp:Label>
              
              </span>

           <span runat="server" Visible='<%# (string)Eval("StatusBosh")=="false" &&(string)Eval("StatusDriver")=="false" &&(string)Eval("CancelOrder")!="true" %>'>
               <asp:Label BorderColor="Brown" Font-Size="9" ID="Label8" ForeColor="Red" Font-Bold="true"    runat="server" Text="رفضها"></asp:Label>
                <asp:Label BorderColor="Brown" Font-Size="9" ID="Label9" ForeColor="Blue" Font-Bold="true"    runat="server"  Text=<%# Eval("Arrived") %>></asp:Label>
              
              </span>

       </td>
       
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="Label53" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="Label55" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptBosh") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت استلام الطلب </th>
       <td><asp:Label BorderColor="Blue" ID="Label54" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptReceivedDriver") %>   ></asp:Label></td>
      <td>وقت تسليم الطلب</td>
      <td><asp:Label BorderColor="Blue" ID="Label56" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeDriver") %>  ></asp:Label></td>
 </tr>

 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>
<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
   <asp:Button OnCommand="Button5544_Command"  Visible="false"     Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button5544" CssClass="btn btn-facebook btn-sm" runat="server" Text="ارجاعه مقبول" /> 
           <br />
         
           <asp:Button OnCommand="Button31_Command" Visible="false"   Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button31" CssClass="btn btn-danger btn-sm" runat="server" Text="ارجاع المبلغ للعميل" />
     
              <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
   <a href='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>' target="_blank"> 
   <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>'  />
</a>
    
</span>
      
      </td>
      
    </tr>
 


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                  
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                
                                <</div>
                                     </div>
                                   </div>
                                 <asp:DataPager ID="DataPager6" PagedControlID="ListView8" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                
                          


                                 
 
                                               
                                   
                          


                                 
 
                                               
                                          



                        </asp:View>
                         <asp:View ID="View7" runat="server">
                           
                            
                                   
                          
                            
           
                                <div style="width:100%;   " class="card shadow mb-6" >
                                   
                                    <div class="card-body"   >
                                       
                                        
                          
                <asp:Label BorderColor="Red" ID="Label50" Font-Size="Large"  BackColor="White"   ForeColor="Aqua" Font-Bold="true"  runat="server" Text="البحث" ></asp:Label>
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView2"   AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                       <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table id="dvTimes"  class="table table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>
                              <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label BorderColor="Red"  BorderWidth="1"    ID="Labrhvcel66" Font-Size="11"     ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>
                             <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label66" Font-Size="11"      ForeColor="Green" Font-Bold="true"  runat="server" Text="متجر وهمي " ></asp:Label>
</span>
      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label>
                  
      </td>
    </tr>
      <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="lblStartDTime" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 </tr>
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td colspan="3">  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
  
  </tr>
     
                                  
                                       
          <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                     <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>

<tr>
       <th scope="row">حالة الطلب</th>
      <td colspan="3">
          
       <span runat="server" Visible='<%# (string)Eval("YESORNODriver")=="yes" %>'>
       <asp:Label BorderColor="Red"     Font-Size="15" ID="Label60" ForeColor="Green" Font-Bold="true"  runat="server" Text="تم توصيل الطلب"></asp:Label>
       </span>

       <span runat="server" Visible='<%# (string)Eval("StatusBosh")=="false" || (string)Eval("StatusDriver")=="false" || (string)Eval("CancelOrder")=="true" %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label57" ForeColor="Red" Font-Bold="true"  runat="server" Text="طلب مرفوض"></asp:Label>
       </span>

       <span runat="server" Visible='<%# (string)Eval("YESORNODriver")=="new" && (string)Eval("ReceivedDriver")=="true"  %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label58" ForeColor="Blue" Font-Bold="true"  runat="server" Text="استلمه المندوب"></asp:Label>
       </span>

       <span runat="server" Visible='<%# (string)Eval("YESORNODriver")=="new" && (string)Eval("ReceivedDriver")=="new" && (string)Eval("StatusBosh")=="true" && (string)Eval("StatusDriver")=="true"  %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label59" ForeColor="YellowGreen" Font-Bold="true"  runat="server" Text="طلب مقبول "></asp:Label>
       </span>

       <span runat="server" Visible='<%#  (string)Eval("StatusBosh")=="new" && (string)Eval("StatusDriver")=="new" && (string)Eval("PaymentStatus")=="true" || (string)Eval("StatusBosh")=="new" && (string)Eval("StatusDriver")=="new" && (string)Eval("cahckWallts")=="true"  %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label61" ForeColor="Red" Font-Bold="true"  runat="server" Text="في انتظار قبول المندوب"></asp:Label>
       </span>

          <span runat="server" Visible='<%#  (string)Eval("StatusBosh")=="new" && (string)Eval("StatusDriver")=="new" && (string)Eval("Cash")=="true"  %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label62" ForeColor="Red" Font-Bold="true"  runat="server" Text="في انتظار قبول المندوب"></asp:Label>
       </span>

         <span runat="server" Visible='<%#  (string)Eval("StatusBosh")=="new" && (string)Eval("StatusDriver")=="true" && (string)Eval("PaymentStatus")=="true" || (string)Eval("StatusBosh")=="new" && (string)Eval("StatusDriver")=="new" && (string)Eval("cahckWallts")=="true"  %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label63" ForeColor="Red" Font-Bold="true"  runat="server" Text="في انتظار قبول المتجر"></asp:Label>
       </span>

           <span runat="server" Visible='<%#  (string)Eval("StatusBosh")=="new" && (string)Eval("StatusDriver")=="true" && (string)Eval("Cash")=="true"  %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label64" ForeColor="Red" Font-Bold="true"  runat="server" Text="في انتظار قبول المتجر"></asp:Label>
       </span>


          <span runat="server" Visible='<%# (string)Eval("StatusBosh")=="new" && (string)Eval("StatusDriver")=="new" && (string)Eval("PaymentStatus")=="false" && (string)Eval("cahckWallts")=="false"  && (string)Eval("Cash")=="false"  %>'>
       <asp:Label BorderColor="Red"    Font-Size="15" ID="Label65" ForeColor="Red" Font-Bold="true"  runat="server" Text="طلب تحت الانشاء"></asp:Label>
       </span>


      </td>
    </tr>






     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
      <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
<tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr  >
   <th  style="color:forestgreen;" scope="row">سبب الرفض </th>
       <td colspan="3" >
           
             <span runat="server" Visible='<%# (string)Eval("CancelOrder")=="true" %>'>
               <asp:Label BorderColor="Brown" Font-Size="9" ID="Label5" ForeColor="Red" Font-Bold="true"    runat="server" Text="رفضها العميل"></asp:Label>
                 <asp:Label BorderColor="Brown" Font-Size="9" ID="Label6" ForeColor="Blue" Font-Bold="true"    runat="server"  Text=<%# Eval("NotCancelOrder") %>></asp:Label>
              </span>

           <span runat="server" Visible='<%# (string)Eval("StatusBosh")=="false" &&(string)Eval("StatusDriver")=="true" &&(string)Eval("CancelOrder")!="true" %>'>
               <asp:Label BorderColor="Brown" Font-Size="9" ID="Label7" ForeColor="Red" Font-Bold="true"    runat="server" Text="رفضها المتجر"></asp:Label>
              
              </span>

           <span runat="server" Visible='<%# (string)Eval("StatusBosh")=="false" &&(string)Eval("StatusDriver")=="false" &&(string)Eval("CancelOrder")!="true" %>'>
               <asp:Label BorderColor="Brown" Font-Size="9" ID="Label8" ForeColor="Red" Font-Bold="true"    runat="server" Text="رفضها"></asp:Label>
                <asp:Label BorderColor="Brown" Font-Size="9" ID="Label9" ForeColor="Blue" Font-Bold="true"    runat="server"  Text=<%# Eval("Arrived") %>></asp:Label>
              
              </span>

       </td>
       
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="Label53" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="Label55" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptBosh") %> ></asp:Label></td>
 </tr>
  <tr>
   <th scope="row">وقت استلام الطلب </th>
       <td><asp:Label BorderColor="Blue" ID="Label54" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptReceivedDriver") %>   ></asp:Label></td>
      <td>وقت تسليم الطلب</td>
      <td><asp:Label BorderColor="Blue" ID="Label56" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeDriver") %>  ></asp:Label></td>
 </tr>
 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>
<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
            <asp:Button OnCommand="Button3_Command"    CommandName='<%# Eval("IdBosh") %>' ID="Button3" CssClass="btn btn-facebook btn-sm" runat="server" Text=" ارقام المتجر" />

         
        

             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'> 
          <asp:Button OnCommand="Button15_Command"  Visible="false"  Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button15" CssClass="btn btn-facebook btn-sm" runat="server" Text="اسناد" /> 
          </span>
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
<asp:Button OnCommand="Button14444335_Command"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button28" CssClass="btn btn-outline-danger btn-sm" runat="server" Text="اسناد سريع" /> 
 </span>
          <asp:Button OnCommand="Button6_Command"    Visible="false"   Font-Size="9"    CommandName='<%# Eval("Id") %>' ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رفض الطلب" /> 
   <asp:Button OnCommand="Button5544_Command"  Visible="false"     Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button5544" CssClass="btn btn-facebook btn-sm" runat="server" Text="ارجاعه مقبول" /> 


 
                                             <asp:Button OnCommand="Button7_Command"  Visible="false" Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button7" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمتجر" /> 
                                             <asp:Button OnCommand="Button8_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button8" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمندوب" /> 
                                            <asp:Button OnCommand="Button9_Command" Visible="false"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button29" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للعميل" /> 
                                       
          <asp:Button OnCommand="Button23_Command" Visible="false"   Font-Size="9"    CommandName='<%# Eval("Id") %>' ID="Button23" CssClass="btn btn-facebook btn-sm" runat="server" Text="اتمام الطلب" /> 

                                  
          
          <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                    <asp:Button OnCommand="Button773_Command"  Visible="false"   Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button34" CssClass="btn btn-facebook btn-sm" runat="server" Text="اصدار فاتورة" /> 
           </span>
            
              <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
   <a href='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>' target="_blank"> 
   <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>'  />
</a>
    
</span>

        



                                         
      </td>
      
    </tr>
 


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                  
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                
                                <</div>
                                     </div>
                                   </div>
                                 <asp:DataPager ID="DataPager7" PagedControlID="ListView2" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                
                          


                                 
 
                                               
                                   
                          


                                 
 
                                               
                                          



                        </asp:View>
                         <asp:View ID="View9" runat="server">
                           

                      
                              
                            
                            
                                <div style="width:100%;   " class="card shadow mb-6">
                         
                                    <div class="card-body"  >
                                       
                                                     <asp:Label BorderColor="Teal" ID="Label46" Font-Size="Large"  BackColor="White"   ForeColor="Black" Font-Bold="true"  runat="server" Text="تحتاج متابعة المندوب" ></asp:Label>
                            
        
                                        
                                
                                    
                             <div  class="row">
                                  
                                  
 
                           <asp:ListView ID="ListView11"   AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                   
                                            <div runat="server" id="u1"   class="col-xl-3 col-md-4 mb-4">
                                             
                                                 
                                                 
                                                 
                                                    <table id="dvTimes"   class="table-responsive table-bordered table-sm">
                                   <tbody  >
     <tr>
      <th scope="row">رقم الطلب</th>
      <td><asp:Label BorderColor="Brown" ID="Label29" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("Id") %> ></asp:Label>
 
                             <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0.00" %>'>

   <span runat="server" Visible='<%# Eval("NoteBosh").ToString().Contains("DonePlus")  %>'  >
       <br />
       <asp:Label  BorderColor="Red"  BorderWidth="1" ID="Labejjjdhl66" Font-Size="11"      ForeColor="Red" Font-Bold="true"  runat="server" Text="دن بلس" ></asp:Label>
   </span>
</span>                   <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
    <br />
    <asp:Label BorderColor="Red"  BorderWidth="1" ID="Label66" Font-Size="11"      ForeColor="Green" Font-Bold="true"  runat="server" Text="متجر وهمي " ></asp:Label>
</span>

      </td>
      <td>المدينة</td>
      <td><asp:Label BorderColor="Blue" ID="Label41" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CityLocality") %> ></asp:Label></td>
    </tr>
      <tr>
<th scope="row">الوقت</th>
   <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="lbls" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeOrder")  %>   ></asp:Label></td>
   <td>التاريخ</td>
   <td><asp:Label BorderColor="Blue" ID="lblStartDateTime" Font-Size="9"       ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# DateTime.ParseExact(Eval("DataOrder", "{0}"), "yyyy:MM:dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") %>     ></asp:Label></td>
 </tr>
  <tr>
<th scope="row">الوقت المنقضي</th>
   <td >  <asp:Label ID="lblTimer" ForeColor="Green"  Font-Bold="true"   runat="server"></asp:Label>  </td>
   <td>معرف المندوب</td>
      <td >  <asp:Label ID="Label11" ForeColor="Black" Text=<%# Eval("IDDriver")  %>   Font-Bold="true"   runat="server"></asp:Label> 
           <span runat="server" Visible='<%# (int)Eval("IDDriver")==7 %>'>
               <asp:Label ID="Label12" ForeColor="Red" Text="لا يوجد مندوب بعد "  Font-Bold="true"   runat="server"></asp:Label> 
              </span>
      </td>

  </tr>
    
                                            
                                       
    <tr>
       <th scope="row">اسم المتجر </th>
      <td> <asp:Label BorderColor="Brown" Font-Size="9"  ID="Label45" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("SubThoroughfare")  %>   ></asp:Label></td>
      <td>الدفع</td>
      <td>
          <span runat="server" Visible='<%# (string)Eval("PaymentProcessNumber")!="000000000000" %>'>
                                                        <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label35" ForeColor="Black" Font-Bold="true"  runat="server" Text=<%# Eval("PaymentProcessNumber")  %>   ></asp:Label>
                                                       
                                               </span>

                                                    <span runat="server" Visible='<%# (string)Eval("cahckWallts")=="true" %>'>
                                                     <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label20" ForeColor="Black" Font-Bold="true"  runat="server" Text="المحفظة"></asp:Label>
                                                      </span>
                                               <span runat="server" Visible='<%# (string)Eval("Cash")=="true" %>'>
                                                    <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
                                                     <asp:Label BorderColor="Red"    Font-Size="9" ID="Label2" ForeColor="Green" Font-Bold="true"  runat="server" Text="فـــــزعة"></asp:Label>
                                                      </span>
                                                   <asp:Label BorderColor="Red"    Font-Size="9" ID="Label19" ForeColor="Red" Font-Bold="true"  runat="server" Text="عند الاستلام"></asp:Label>
                                                      </span>

      </td>
    </tr>
     <tr>
   <th scope="row">سعر التوصيل</th>
      <td> 
          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")=="0" %>'>
                                                     <asp:Label BorderColor="Brown" Font-Size="9" ID="Label17" ForeColor="Blue" Font-Bold="true"    runat="server" Text="استلام الطلب من المتجر"></asp:Label>
                                               </span>
                                          <span runat="server" Visible='<%# (string)Eval("DeliveryPrice")!="0" %>'>
                                           
                                                <asp:Label BorderColor="Brown"   Font-Size="9" ID="Label33" ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("DeliveryPrice")  %>   ></asp:Label>
                                                 </span>

      </td>
    <td>سعر الفاتورة</td>
      <td><asp:Label BorderColor="Blue" ID="Label48" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TotalPrice") %> ></asp:Label></td>
    </tr>
  <tr >
   <th style="color:forestgreen;" scope="row">مبلغ الخصم</th>
       <td><asp:Label BorderColor="Blue" ID="Label3" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenPrice") %> ></asp:Label></td>
      <td style="color:forestgreen;">بيان الخصم</td>
      <td><asp:Label BorderColor="Blue" ID="Label4" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("CobenNumber") %> ></asp:Label></td>
 </tr>
<tr>
   <th scope="row">وقت قبول المندوب</th>
       <td><asp:Label BorderColor="Blue" ID="Label53" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptDriver") %> ></asp:Label></td>
      <td>وقت قبول المتجر</td>
      <td><asp:Label BorderColor="Blue" ID="lblStartDTime" Font-Size="9"      ForeColor="Blue" Font-Bold="true"  runat="server" Text=<%# Eval("TimeAccsptBosh") %> ></asp:Label></td>
 </tr>
 <tr>
      <th scope="row">خيارات</th>
      <td colspan="3">
          <asp:Button  OnCommand="Button4_Command" Font-Size="9"   CommandName='<%# Eval("NoteYESORNODriver") %>' ID="Button4"  CssClass="btn btn-facebook btn-sm" runat="server" Text="الفاتورة" />  
           <asp:Button OnCommand="Button1_Command"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button144" CssClass="btn btn-facebook btn-sm" runat="server" Text=" العميل" />  
           <asp:Button OnCommand="Button2_Command"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button25" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المندوب" />  

      </td>
      
    </tr>

<tr>
      <th scope="row">الموقع</th>
      <td colspan="3">
         <a class="btn btn-facebook btn-sm" href="https://www.google.com.sa/maps/place/<%#Eval("LocalYY")%>,<%#Eval("LocalXX")%>" target="_blank"> العميل </a> 
<asp:Button OnCommand="Button5_Command"   Font-Size="9"  CommandName='<%# Eval("IDDriver") %>' ID="Button5" CssClass="btn btn-facebook btn-sm" runat="server" Text="المندوب" /> 
 <asp:Button OnCommand="Button17_Command"  Font-Size="9"   CommandName='<%# Eval("IdBosh") %>' ID="Button17" CssClass="btn btn-facebook btn-sm" runat="server" Text=" المتجر" /> 
          <asp:Button OnCommand="ButtonAddnotss_Command"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="ButtonAddnotss" CssClass="btn btn-facebook btn-sm" runat="server" Text="اضافة ملاحظة للطلب" /> 

      </td>
      
    </tr>

<tr>
      <th scope="row">اخرى</th>
      <td colspan="3">
          <asp:Button OnCommand="Button3_Command"    CommandName='<%# Eval("IdBosh") %>' ID="Button24" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رقم المتجر" />
   <asp:Button OnCommand="Button6_Command"    Visible="false"   ID="Button6" CssClass="btn btn-facebook btn-sm" runat="server" Text=" رفض الطلب" /> 
                                             <asp:Button OnCommand="Button7_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("Id") %>' ID="Button7" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمتجر" /> 
                                             <asp:Button OnCommand="Button8_Command" Visible="false"  Font-Size="9"   CommandName='<%# Eval("IDDriver") %>' ID="Button8" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للمندوب" /> 
                                            <asp:Button OnCommand="Button9_Command" Visible="false"  Font-Size="9"  CommandName='<%# Eval("IdCustomer") %>' ID="Button9" CssClass="btn btn-facebook btn-sm" runat="server" Text=" تنبية للعميل" /> 
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                            
          <asp:Button OnCommand="Button15_Command"   Visible="false"   Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button15" CssClass="btn btn-facebook btn-sm" runat="server" Text="اسناد" />
          </span>
             <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>                           
<asp:Button OnCommand="Button14444335_Command"      Font-Size="9" Visible="false"  CommandName='<%# Eval("Id") %>' ID="Button28" CssClass="btn btn-outline-danger btn-sm" runat="server" Text="اسناد سريع" /> 
 </span>
          <span runat="server" Visible='<%# (int)Eval("IdBosh")==43 %>'>
         <asp:Button OnCommand="Button773_Command" Visible="false"    Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button3" CssClass="btn btn-facebook btn-sm" runat="server" Text="اصدار فاتورة" /> 
           </span>
            

           <span runat="server" Visible='<%# (int)Eval("IDDriver")==11 %>'>
           <asp:Button OnCommand="Button23_Command"     Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button23" CssClass="btn btn-danger btn-sm" runat="server" Text="ترحيل الطلب" /> 
           </span>
                    <span runat="server" Visible='<%# (int)Eval("IDDriver")!=11 %>'>
<asp:Button OnCommand="Button2DD8_Command"  Visible="false"      Font-Size="9"  CommandName='<%# Eval("Id") %>' ID="Button2DD8" CssClass="btn btn-success btn-sm" runat="server" Text="اتمام الطلب" /> 
</span>

    <span runat="server" Visible='<%# Eval("PostalCode").ToString().Contains("storedone")  %>'  >
   <a href='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>' target="_blank"> 
   <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("/Uploads/ImageDriveComplaints/{0}",Eval("Note"))%>'  />
</a>
    
</span>

      </td>
      
    </tr>


  </tbody>
</table>
                                                 
                                                 
                                                 
                                                 
                                                 
                                             

                                        
                                    </div>
                                    
                                       
                                   
                                     
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                             
                                  </div>
                                     </div>
                                   </div>
                            
                                 <asp:DataPager ID="DataPager9" PagedControlID="ListView11" PageSize="200" runat="server">  
    <Fields>  
        <asp:NextPreviousPagerField ButtonType="Button" FirstPageText="اول صفحة" LastPageText="اخر صفحة" NextPageText="التالي" PreviousPageText="السابق" ShowFirstPageButton="True" ShowLastPageButton="True" />  
    </Fields>  
</asp:DataPager> 
                        
                            
                                
                          


                                 
 
                                               
                                        



                        </asp:View> 

                    </asp:MultiView>
                


           <div style="text-align:right;" class="modal fade" id="logoutModalWastp" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
                <asp:Label ID="Label36" runat="server" Font-Size="0" Text=""></asp:Label>
         <asp:Label ID="Label43" runat="server" Font-Size="0" Text=" "></asp:Label>
      
        الاسم <asp:Label ID="Label44" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>

        
         <div class="table-responsive">
                                <table class="table " id="dataTabless" width="100%" cellspacing="0">
                                  
                           <asp:ListView ID="ListView9" AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                       <tbody style="border:solid; border-color:dodgerblue;">
                                        <tr style="font-size:12px; font-weight:bold; color:black;">
                                            <td>
                                                  <h6 style="font-size:12px; font-weight:bold; color:black; background-color:lightblue;">اسم المتجر</h6>
                                                <%# Eval("NameServic") %>  </td>
                                            <td> 
                                                 <h6 style="font-size:12px; font-weight:bold; color:black; background-color:lightblue;">الوضف الوظيفي</h6>
                                                <%# Eval("ImageServic") %>  </td>
                                            <td> 
                                                 <h6 style="font-size:12px; font-weight:bold; color:black; background-color:lightblue;">الاسم</h6>
                                                <%# Eval("NoteServic") %>  </td>


                                            <td>
                                                    <h6 style="font-size:12px; font-weight:bold; color:black; background-color:lightblue;">رقم الهاتف </h6>
                                                <%# Eval("Size1") %> </td>
                                           
                                        
                                           
 

                                        </tr>
 
                                        
                                    </tbody>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </table>

                            </div>  







            </div>





            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div> 


          
           <div style="text-align:right;" class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               


               
                <asp:Label ID="Labelssxx" runat="server" Font-Size="0" Text=""></asp:Label>
         <asp:Label ID="Labelssyy" runat="server" Font-Size="0" Text=" "></asp:Label>
      

        الاسم <asp:Label ID="name" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>

       رقم الهاتف<asp:Label ID="Number" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

              رقم المعرف   <asp:Label ID="Label49" runat="server" Font-Size="Medium" ForeColor="Black" Font-Bold="True"  Text=""></asp:Label>

                <span itemprop="telephone"><a href="tel:"+<asp:Label ID="Label28" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>
<i class="icofont-phone"></i></a></span>


        







            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  




           <div style="text-align:right;" class="modal fade" id="logoutModalBill" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
          
            <div class="modal-body">
               
              

        
                 
                           <div class="table-responsive">
                                 
                                <table class="table">
  <thead>
    <tr>
      <th scope="col">الكمية</th>
      <th scope="col">المنتج</th>
       <th scope="col">العبوة</th>
      <th scope="col">الاضافات</th>
        <th scope="col">السعر</th>
    </tr>
  </thead>
                                <asp:ListView ID="MyBill"  AutoPostBack="true" runat="server"   >
                               <ItemTemplate>
                                    <tbody>
    <tr>
      <th scope="row"> <%# Eval("Cost") %> </th>
      <td> <%# Eval("sproar") %> </td>
      <td><%# Eval("spakerar") %>  </td>
      <td><%# Eval("stAdd") %>  </td>
         <td><%# Eval("spric") %>   </td>
    </tr>
    
  </tbody>
                                             
                                              
                                             
                                            
                                              
                                             
                                        <br />
                                        </ItemTemplate>
                                    </asp:ListView>

                                   </table>


                            </div>  
             


  <asp:Label ID="Label314"  runat="server" Font-Size="Medium" Text=" " ForeColor="Red"  Font-Bold="True"></asp:Label>



            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  


 
<div style="text-align:right;" class="modal fade" id="logoutModalConselOrder" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
      
     

        <div style=" text-align:center;" >
                  <div class="table-responsive">
                                 
 رقم الطلب<asp:Label ID="Label21" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>
                      <br />
       اسم المتجر<asp:Label ID="Label1" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>


                            </div>  
                   <br />        
            
             <asp:Label ID="Label22" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>
             <br />
            <br />
             <br />
            <br />
              <asp:Button ID="Button13" OnClick="Button13_Click" OnClientClick="CloseModal()" runat="server" Text="الغاء الطلب" CssClass="btn btn-danger btn-lg" />
           
            <br />
            <br />
            <br />
            <br />
               
            <asp:Button ID="Button14"  OnClick="Button14_Click" OnClientClick="CloseModal()" runat="server" Text="قبول الطلب" CssClass="btn btn-success btn-lg" />   

                        </div>







            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  


<div style="text-align:right;" class="modal fade" id="logoutModalConselOrderNew" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
       رقم الطلب<asp:Label ID="Label13" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                         
            
             <asp:Label ID="Label14" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>
             <br />
            <br />
             <br />
            

            <br />
              <asp:Button ID="Button27df" OnClick="Button27df_Click" Visible="false" runat="server" Text="ارجاع الطلب مقبولا" CssClass="btn btn-success btn-sm" />
            </div> 
            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
 
<div style="text-align:right;" class="modal fade" id="logoutrefund" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
       رقم الطلب<asp:Label ID="Label51" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                         
            <asp:TextBox ID="TextBox15"    placeholder="كلمة السر"  runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:TextBox>
            <br />
           المبلغ المراد ارجاعه
         
            <asp:TextBox ID="TextBox16"    placeholder="المبلغ"  runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:TextBox>
            <br />
            <br />
           رقم عملية تلير
             <asp:Label ID="Label52" runat="server"  Font-Size="Medium"   Font-Bold="True" Text="0" ForeColor="Black"></asp:Label>
             <br />
            <br />
             <br />
            

            <br />
              <asp:Button ID="Button30" OnClick="Button30_Click" OnClientClick="CloseModal()" runat="server" Text="ارجاع المبلغ" CssClass="btn btn-success btn-sm" />
           
             

                        </div>







            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
<div style="text-align:right;" class="modal fade" id="logoutModalConselOrderfinsh" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
       رقم الطلب<asp:Label ID="Labelidorder" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                         
            <asp:TextBox ID="TextBoxpassword"    placeholder="كلمة السر"  runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label67ss" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>
             <br />
            <br />
             
              <asp:Button ID="Buttonfinsh" OnClick="Buttonfinsh_Click" OnClientClick="CloseModal()" runat="server" Text="اتمام الطلب " CssClass="btn btn-success btn-sm" />
            </div> 

            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
<div style="text-align:right;" class="modal fade" id="logoutModalConselOrderSusses" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
       رقم الطلب<asp:Label ID="Label15" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                         
            
             <asp:Label ID="Label16" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>
             <br />
            <br />
             <br />
            <br />
              <asp:Button ID="Button27" OnClick="Button27_Click" OnClientClick="CloseModal()" runat="server" Text="ترحيل طلب استلمه بنفسك " CssClass="btn btn-success btn-sm" />
            </div> 

            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
 
<div style="text-align:right;" class="modal fade" id="logoutModalAddNots" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            
            <div class="modal-body">
               
 
    <div class="table-responsive">

                 <br />
<br />

           رقم الطلب   &nbsp;&nbsp;&nbsp;    
       <asp:Label ID="Label67" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

          <br />
 <br />
        حدد نوع الاجراء :
         &nbsp;&nbsp;&nbsp;   
        
        <asp:DropDownList ID="DropDownList1"    CssClass="checkbox" runat="server">
             <asp:ListItem Value="0">اختار</asp:ListItem>
               <asp:ListItem Value="1">خصم مبلغ من المندوب</asp:ListItem>
               <asp:ListItem Value="2">خصم مبلغ من المتجر</asp:ListItem>
               <asp:ListItem Value="3">اضافة مبلغ للمندوب</asp:ListItem>
            <asp:ListItem Value="4">اضافة مبلغ للعميل</asp:ListItem>
            <asp:ListItem Value="5">خصم من المتجر واضافتة للعميل</asp:ListItem>
            <asp:ListItem Value="6">خصم من المتجر واضافتة للمندوب</asp:ListItem> 
               <asp:ListItem Value="7">ملاحظة عادية فقط</asp:ListItem> 

        </asp:DropDownList>
                 <br />
<br />

        المبلغ :     &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxpricrnoots" Width="120px" runat="server"></asp:TextBox> ريال
        <br />
           <br />
        الملاحظة & البيان :
            <asp:TextBox ID="TextBoxnotsss" Width="120px"  TextMode="MultiLine" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonAddnotsss" class="btn btn-facebook" OnClientClick="CloseModal()" OnClick="ButtonAddnotsss_Click" runat="server" Text="حفظ" />
        <br />
        <br />
         &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelErrornotss" ForeColor="Brown" Font-Bold="true" Font-Size="13" runat="server" Text=""></asp:Label>

                 <br />
<br />

           </div>   
            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>



<div style="text-align:right;" class="modal fade" id="logoutModalADDOrder" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            
            <div class="modal-body">
               
 
                                              <div class="table-responsive">
                         <table style="color:black; " class="table table-striped">
<thead>
  <tr>
   
    <th scope="col">معرف المندوب</th>
    <th scope="col">اسم المندوب</th>
     
      <th scope="col">عدد الطلبات</th>
      <th scope="col">المتاجر</th>
  </tr>
</thead>
                    <asp:ListView ID="ListView3" runat="server">
                             <ItemTemplate>


  <tbody>
    <tr>

      <th scope="row"> <%# Eval("IDdriver") %> </th>
     
      <td> 
          <asp:Label ID="Label3" runat="server" Text=<%# Eval("nameDriver") %>></asp:Label>
      </td>
           <td> 
       <asp:Label ID="Label4" runat="server" Text=<%# Eval("not1") %>></asp:Label>
   </td>
                <td> 
    <asp:Label ID="Label10" runat="server" Text=<%# Eval("not2") %>></asp:Label>
</td>
      
    </tr>
    
  </tbody>        
     
    </ItemTemplate>
                    </asp:ListView>
           
</table>

        </div>  



                <br />
                
       رقم الطلب<asp:Label ID="Label26" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                  <div class="table-responsive">
                                
                      <asp:TextBox ID="TextBox9"    placeholder="رقم المعرف" Text=""  runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:TextBox>
                            </div>  
                   <br />        
            
            <br />
             <asp:Label ID="Label27" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>
             <br />
            <br />
             <br />
            <br />
              <asp:Button ID="Button16" OnClick="Button16_Click"  OnClientClick="CloseModal()" runat="server" Text="أسناد" CssClass="btn btn-danger btn-lg" />
           
                        </div>

            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
 
<div style="text-align:right;" class="modal fade" id="logoutModalADDOrderQuicly" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            
            <div class="modal-body"> 
                <br />
                
       رقم الطلب<asp:Label ID="Label6867" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                  <div class="table-responsive">
                                
                      <asp:TextBox ID="TextBox17"    placeholder="رقم معرف المندوب" Text=""  runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:TextBox>
                            </div>   
            <br />
             <br />
            <br />
              <asp:Button ID="Button3542" OnClick="Button3542_Click"  OnClientClick="CloseModal()" runat="server" Text="اسناد سريع" CssClass="btn btn-outline-primary btn-lg" />
           
                        </div>

            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  


<div style="text-align:right;" class="modal fade" id="logoutModalADDOrderAuto" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            
            <div class="modal-body">
               
       رقم الطلب<asp:Label ID="Label50Auto" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                  
                          
            
             <asp:Label ID="Label51Auto" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>
             <br />
            <br />
             <br />
            <br />
              <asp:Button ID="Button26Auto" OnClick="Button26Auto_Click" runat="server" Text="اسناد" CssClass="btn btn-danger btn-lg" />
           
                        </div>

            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
 
<div style="text-align:right;" class="modal fade" id="logoutModalADDBillPrice" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            
            <div class="modal-body">
               
       رقم الطلب<asp:Label ID="Label32" runat="server" Font-Size="Medium" Text=" " ForeColor="Black" Font-Bold="True"></asp:Label>

        <div style=" text-align:center;" >
                  <div class="table-responsive">
                                
                      <asp:TextBox ID="TextBox10"    placeholder="سعر الطلب"  runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:TextBox>
                            </div>  
                   <br />        
            
             <asp:Label ID="Label34" runat="server"  Font-Size="Medium" Text="" Font-Bold="True" ForeColor="Black"></asp:Label>
             <br />
            <br />
             <br />
            <br />
              <asp:Button ID="Button22" OnClick="Button22_Click" OnClientClick="CloseModal()" runat="server" Text="اصدار" CssClass="btn btn-danger btn-lg" />
           
                        </div>

            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
  
<div style="text-align:right;" class="modal fade" id="logoutModalErorr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
 تنوية

        <div style=" text-align:center;" >
                  
               
                     <asp:Label ID="Label18" runat="server" Font-Size="Medium" Text="كلمة المرور خطاء" ForeColor="Black" Font-Bold="True"></asp:Label>

                        </div>







            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  
 
<div style="text-align:right;" class="modal fade" id="logoutModalNofBosh" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
 أرسال أشعار لكاشير المتجر

        <div style=" text-align:center;" >
                  
 
            <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
             <asp:Label ID="Label47" runat="server" Text=""></asp:Label>

             <br />        
            <asp:TextBox ID="TextBox2"    placeholder="العنوان"  runat="server" Font-Bold="True" Text="تنوية" Font-Size="Large" ForeColor="Red"></asp:TextBox>
            <br />
            <br />
             <asp:TextBox ID="TextBox3"    placeholder="نص الرسالة" TextMode="SingleLine"  runat="server" Font-Bold="True" Text="لديك طلب جديد" Font-Size="Large" ForeColor="Red"></asp:TextBox>
             <br />
            <br />
             
              
               
                          <asp:Button ID="Button11" OnClick="Button11_Click" runat="server" Text="أرسال" CssClass="btn btn-success btn-lg" />   
            

                        </div>







            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  

<div style="text-align:right;" class="modal fade" id="logoutModalNofClien" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
 أرسال أشعار  للعميل

        <div style=" text-align:center;" >
                  
               
            <asp:Label ID="Label24" runat="server" Text=""></asp:Label>

             <br />        
            <asp:TextBox ID="TextBox4"    placeholder="العنوان"  runat="server" Font-Bold="True" Text="Done" Font-Size="Large" ForeColor="Red"></asp:TextBox>
            <br />
            <br />
             <asp:TextBox ID="TextBox5"    placeholder="نص الرسالة" TextMode="SingleLine"  runat="server" Font-Bold="True" Text="عميلنا العزيز نعتذر لتاخر الطلب" Font-Size="Large" ForeColor="Red"></asp:TextBox>
             <br />
            <br />
             
              
               
                          <asp:Button ID="Button10" OnClick="Button10_Click" runat="server" Text="أرسال" CssClass="btn btn-success btn-lg" />   
            

                        </div>
                 
            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>  

 <div style="text-align:right;" class="modal fade" id="logoutModalNofDriver" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">

               
            </div>
            <div class="modal-body">
               
 أرسال أشعار  للمندوب

        <div style=" text-align:center;" >
                  
               
           <asp:Label ID="Label25" runat="server" Text=""></asp:Label>

             <br />        
            <asp:TextBox ID="TextBox6"    placeholder="العنوان"  runat="server" Font-Bold="True" Text="تنوية" Font-Size="Large" ForeColor="Red"></asp:TextBox>
            <br />
            <br />
             <asp:TextBox ID="TextBox7"    placeholder="نص الرسالة" TextMode="SingleLine"  runat="server" Font-Bold="True" Text="يجب الاسراع في توصيل الطلب" Font-Size="Large" ForeColor="Red"></asp:TextBox>
             <br />
            <br />
               <asp:Button ID="Button12" OnClick="Button12_Click" runat="server" Text="أرسال" CssClass="btn btn-success btn-lg" />   
              </div>




              </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">الغاء</button>
                
            </div>
        </div>
    </div>
</div>     
     <script type="text/javascript">



         function CloseModal() {

             $("#logoutModalAddNots").modal("hide");
             $("#logoutModalADDOrder").modal("hide");
             $("#logoutModalADDOrderQuicly").modal("hide");
             $("#logoutModalConselOrder").modal("hide");
             $("#logoutModalConselOrderfinsh").modal("hide");
             $("#logoutrefund").modal("hide");
             $("#logoutModalConselOrderSusses").modal("hide");
             $("#logoutModalADDBillPrice").modal("hide");

         }
     </script>



              </ContentTemplate>
  
</asp:UpdatePanel>
      </div>
             <!-- Bootstrap Modal لرفع صورة -->
 
      
        <!-- Modal Bootstrap -->
 <div class="modal fade" id="imageModal" tabindex="-1" aria-labelledby="imageModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered modal-lg">
    <div class="modal-content border-0 shadow">
      <div class="modal-header bg-dark text-white">
        <h5 class="modal-title" id="imageModalLabel">عرض الصورة</h5>
           
          <button   class="btn-close btn-close-white" type="button" data-dismiss="modal">X</button>
      </div>
      <div class="modal-body text-center">
        <img id="modalImage" src="" class="img-fluid rounded shadow" />
      </div>
    </div>
  </div>
</div>
      
      </div>



      <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />
   
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
     

</asp:Content>
