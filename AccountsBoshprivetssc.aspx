 
 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsBoshprivetssc.aspx.cs" Inherits="MyFast.AdminShops.AccountsBoshprivetssc" %>

<!DOCTYPE html>
 
<html  >
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>أضافة حساب</title>
    
    <!-- Custom fonts for this template-->
    <link href="/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    
  <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Cairo:wght@300&display=swap" rel="stylesheet">
    <!-- Custom styles for this template-->
    

    <link href="/css/sb-admin-2.min.css" rel="stylesheet" />


    
</head>


    <body style="font-family: 'Cairo', sans-serif;" id="page-top">

    <form id="form1" runat="server">
    <div   id="wrapper">

        <!-- Sidebar -->
         
        <!-- End of Sidebar -->

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">
   
              

                <!-- Begin Page Content -->
                <div dir="rtl" style="padding-top:40px;" class="container-fluid">

                    <!-- Page Heading -->
                     
                    <!-- Content Row -->
                    <div class="row">
   

        <div style="width:100%;  font-size:small; text-align:right;" class="card shadow mb-4">
             <div style=" text-align:left;" >
                 
                             <a  dir="ltr"  href="AdminBoshSelectCityperivet.aspx" style="text-align:left; margin:30px; padding-left:50px;  padding-right:50px;" class="btn btn-success">رجوع</a>

                        </div>
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">الحسابات</h6>
                             
                        </div>


            
                        <div   class="card-body">
                            
             <asp:ScriptManager ID="ScriptManager2" runat="server">
 </asp:ScriptManager>






<div class="card shadow mb-4">
                                <!-- Card Header - Accordion -->
                                <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse"
                                    role="button" aria-expanded="false" aria-controls="collapseCardExample">
                                    <h6 class="m-0 font-weight-bold text-primary">أضافة حساب جديد</h6>
                                </a>
                                <!-- Card Content - Collapse -->
                                <div class="collapse show " id="collapseCardExample">
                                    <div class="card-body">
                                         <div class="table-responsive">
                                  <table class="table " id="dataTable" width="100%" cellspacing="0">
                                  
                               
                                        <tr style="font-size:12px; font-weight:bold; color:black;">
                                            <td>
                                               المتجر : 
                                               <asp:DropDownList class="btn btn-info dropdown-toggle"    AutoPostBack="true" Width="150" style="font-size:12px;"   
                DataValueField="Id" 
             DataTextField="NameBosh" ID="DropDowncarier" runat="server">

         </asp:DropDownList> 
                                                 </td>
                                           
                                            
                                     <tr style="font-size:12px; font-weight:bold; color:black;">
                                                <td>
                                                رقم الحساب البنكي  : 
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </td>
                                                     
                                            <td>
                                                اسم صاحب الحساب  : 
                                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            </td>
                                            
                                             </tr>
                                             <tr style="font-size:12px; font-weight:bold; color:black;">

                                         
                                            <td>
                                                البنك  : 
                                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                            </td>
                                                 <td>
                                                رقم الهاتف  : 
                                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                            </td>
                                         </tr>
                                       <tr style="font-size:12px; font-weight:bold; color:black;">
                                           
                                             <td> <asp:Button Class="btn btn-success btn-lg" ID="ButtonADD"  OnClick="ButtonADD_Click"  runat="server" Text="أضافة" /></td>
                                           <td>
                                                
                                            </td>
                                           
                                       </tr>
                                     
                                     
                                            
                                         

                                           
                                            
                                     
                           
                  
                                </table>

                             </div>
                                    </div>
                                </div>
                            </div>

 

      </div>

                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                      <ContentTemplate>
                                 
                            <div class="row">
                                 <h1 class="h3 mb-2 text-gray-800">اعلانات سابقة</h1>
                    
                            <div class="table-responsive">
                                <table style="text-align:center; font-size:large; color:black; font-weight:bold; "  class="table table-bordered border-primary" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                       <th>المعرف</th>
                                             <th>اسم المتجر</th>
                                            <th>رقم الحساب</th>
                                              <th>البنك</th>
                                              <th>رقم الهاتف</th>
                                             <th>الخيارات</th>
                                            
                                        </tr>
                                    </thead>
                           <asp:ListView ID="ListView1" AutoPostBack="true" runat="server" DataKeyNames="Id" >
                               <ItemTemplate>
                                    <tbody>
                                        <tr >
                                              <td> <%# Eval("Id") %>  </td>
                                            <td> <%# Eval("IdCUstomer") %>  </td>
                                            <td> <%# Eval("IdPorducts") %>  </td>
                                            <td> <%# Eval("Count") %>  </td>
                                             <td> <%# Eval("Pric") %>  </td>
                                           
                                           
                                            
                                           
                                         
                                              <td>
                                                
                                                  <asp:LinkButton Text="حذف" class="btn btn-primary" ID="lkbCommandAction" CommandArgument='<%# Eval("Id") %>' OnCommand="lkbCommandAction_Command" runat="server" />
                                               
                                                  </td>
                                            
                                        </tr>
                                        
                                    </tbody>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </table>

                            </div>
                            
                                </div>
                          
                                     </ContentTemplate>                
                              </asp:UpdatePanel>         
                                          </div>
          

     
      </div>
    




</div>

</div>
                </div>
            </div>
        </div>






  
<script src="../vendor/jquery/jquery.min.js"></script>
    <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    

    <!-- Custom scripts for all pages-->
    <script src="../js/sb-admin-2.min.js"></script>
    <!-- Page level plugins -->







    
    <!-- Page level plugins -->
    </form>
</body>

</html>
