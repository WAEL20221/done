<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/AdminShops/AdminUser.Master" AutoEventWireup="true" CodeBehind="AddDrivers.aspx.cs" Inherits="MyFast.AdminShops.AddDrivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
     


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 
    <br />
      <div style="width:100%; color:black;   text-align:right;" class="card shadow mb-4">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
          <div class="card-header py-3">
                           
                    <div style=" text-align:left;" >
        
      <a  dir="ltr"  href="Drivers.aspx" style="text-align:left; margin:10px; padding-left:10px;  padding-right:10px;" class="btn btn-success">رجوع</a>

</div>

                           
                            <h4  >تسجيل مندوب دن جديد   &nbsp;&nbsp;&nbsp;&nbsp;   </h4>

            <br />
  <br />    
              
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
     
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
   
    

         

         
          <div class="form-outline mb-3">
                <label class="form-label" style="font-size:medium;"  for="form3Example4">رقم معرف مندوب دن</label>
           
               <asp:TextBox ID="TextBoxIdDriver" CssClass="form-control form-control-sm" TextMode="Number" placeholder="ادخل رقم المعرف" runat="server"></asp:TextBox>
              
          
          </div> 
          
           <div class="form-outline mb-3">
       <label class="form-label" style="font-size:medium;"  for="form3Example4">المدينة</label>
  
   
<asp:DropDownList ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"   AutoPostBack="true" Width="140px"    DataTextField="NameCitiesSaudiAR" DataValueField="Id" Font-Bold="True" Font-Size="Large"></asp:DropDownList>
 
     
 
 </div> 
          
          
          <div class="form-outline mb-3">
               <label   for="form3Example4" style="font-size: medium">هل وقت العمل 3 فترات ؟ </label>
                           <br />
                           <asp:CheckBox ID="CheckBoxYes" Checked="false" AutoPostBack="true" Text="نعم"  OnCheckedChanged="CheckBoxYes_CheckedChanged" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#003366" />
                          <br />
                           <asp:CheckBox ID="CheckBoxNo" Checked="true" AutoPostBack="true"  OnCheckedChanged="CheckBoxNo_CheckedChanged" Text="لا" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#003366" />

                
 
</div>
          
                     <div class="form-outline mb-3" style="background-color:cadetblue; color:white;">
                <label class="form-label" for="form3Example4">وقت بداء العمل الفترة الاوله </label>
 <asp:TextBox ID="TextBoxStartWork" CssClass="form-control form-control-sm" TextMode="Time" placeholder="12:00:00" runat="server"></asp:TextBox>
              
  
 </div>

                      


              <div class="form-outline mb-3" style="background-color:cadetblue; color:white;" >
                <label class="form-label" for="form3Example4">وقت انتهاء العمل الاوله </label>
 

                <asp:TextBox ID="TextBoxEndWork"    CssClass="form-control form-control-sm" TextMode="Time" placeholder="23:00:00" runat="server"></asp:TextBox>
              
  
 </div>

          
                              <div runat="server" visible="false" style="background-color:brown; color:white;" id="Twos" class="form-outline mb-3">
               <label class="form-label" for="form3Example4">وقت بداء العمل الفترة الثانية </label>
<asp:TextBox ID="TextBoxstrtTow" CssClass="form-control form-control-sm" TextMode="Time" placeholder="12:00:00" runat="server"></asp:TextBox>
             
 
</div>


          <div runat="server" id="TwosT" style="background-color:brown; color:white;" visible="false" class="form-outline mb-3">
               <label class="form-label" for="form3Example4">وقت انتهاء العمل الثانية </label>


               <asp:TextBox ID="TextBoxEndTow"    CssClass="form-control form-control-sm" TextMode="Time" placeholder="23:00:00" runat="server"></asp:TextBox>
             
 
</div>
                              <div runat="server" visible="false" style="background-color:black; color:white;" id="Twos1" class="form-outline mb-3">
               <label class="form-label" for="form3Example4">وقت بداء العمل الفترة الثالثة </label>
<asp:TextBox ID="TextBoxstrtThree" CssClass="form-control form-control-sm" TextMode="Time" placeholder="12:00:00" runat="server"></asp:TextBox>
             
 
</div>


          <div runat="server" id="TwosT1" style="background-color:black; color:white;" visible="false" class="form-outline mb-3">
               <label class="form-label" for="form3Example4">وقت انتهاء العمل الثالثة </label>


               <asp:TextBox ID="TextBoxEndThree"    CssClass="form-control form-control-sm" TextMode="Time" placeholder="23:00:00" runat="server"></asp:TextBox>
             
 
</div>


           <div class="form-outline mb-3">
                <label class="form-label" for="form3Example4">لا يدعم المتاجر</label>
 

                
                     <asp:CheckBoxList  RepeatDirection="Horizontal" 
    RepeatColumns="4" RepeatLayout="Table"   DataTextField="NameBosh"
DataValueField = "Id"  AutoPostBack="true"    runat="server" ID="CheckBoxList1">
 
      </asp:CheckBoxList>


  
 </div>


          <div class="text-center text-lg-start mt-4 pt-2">

              <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
            

              <asp:Button ID="ButtonSave" OnClick="ButtonSave_Click" runat="server"   CssClass="btn btn-outline-success btn-lg" Text="تسجيل" />


           




         
          </div>

        <br />
                       
 <br />
      </div>
    
    </div>
  </div>
  
 
                
          </div>
          </ContentTemplate>
       </asp:UpdatePanel> 
       </div>
    
           
</asp:Content>
