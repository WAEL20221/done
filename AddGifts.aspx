 
 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGifts.aspx.cs" Inherits="MyFast.AdminShops.AddGifts" %>

<!DOCTYPE html>
 
<html  >
<head runat="server">
 <meta charset="utf-8"/>
 <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
 <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
 <meta name="description" content=""/>
 <meta name="author" content=""/>
     
 <title>اضافة باقة هدية</title>
 
      <!-- Custom fonts for this template-->
    <link href="/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    
  <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Cairo:wght@300&display=swap" rel="stylesheet">
    <!-- Custom styles for this template-->
    

    <link href="/css/sb-admin-2.min.css" rel="stylesheet" />

  <script type = "text/javascript">
      function Confirm() {
          var confirm_value = document.createElement("INPUT");
          confirm_value.type = "hidden";
          confirm_value.name = "confirm_value";
          if (confirm("هل حقاً تريد حذف هذه الباقة  ؟ ")) {
              confirm_value.value = "Yes";
          } else {
              confirm_value.value = "No";
          }
          document.forms[0].appendChild(confirm_value);
      }
      function CopyToClipboard(myID) {
          var copyText = document.getElementById(myID);

          /* Select the text field */
          copyText.select();
          copyText.setSelectionRange(0, 99999); /* For mobile devices */

          /* Copy the text inside the text field */
          document.execCommand("copy");
      }

  </script>


    
</head>


    <body style="font-family: 'Cairo', sans-serif;" id="page-top">

          <form id="form1" runat="server">


           <div dir="rtl"   style="padding-top:40px; text-align:center;" class="container-fluid">
                     <div style=" text-align:left;" >
                 
                             
                         <asp:LinkButton ID="LinkButton1"  class="btn btn-success" style="text-align:left; margin:30px; padding-left:50px;  padding-right:50px;" OnClick="LinkButton1_Click" runat="server">رجوع</asp:LinkButton>






                        </div>
 
  
    <div class="row">
       <div style="width:100%; text-align:right;" class="card shadow mb-4">
                      
                      <a class="d-block card-header py-3" data-toggle="collapse" href="#collapseExamples" role="button" aria-expanded="false" aria-controls="collapseExamples">

      <h6 class="m-0 font-weight-bold text-primary"> أضافة باقة جديدة</h6>
 </a>
                                
<div class="collapse" id="collapseExamples">
  <div class="card card-body">
     <div class="table-responsive">
               <table class="table table-bordered">
  <thead>
    <tr>
     					 	  
      <th scope="col">اسم الباقة عربي</th>
      <th scope="col">اسم الباقة En</th>
      
        <th scope="col">صورة الباقة</th>
      
    </tr>
  </thead>
  <tbody>
    <tr>

     
         <td>  <asp:TextBox ID="TextBoxname_package_detailsar" runat="server"></asp:TextBox></td>
      
         <td>  <asp:TextBox ID="TextBoxnot1EN" runat="server"></asp:TextBox></td>
        
          <td> 
              <asp:FileUpload ID="FileUpload2" runat="server" />   </td>
        <td> <asp:Button ID="Button2" class="btn btn-success btn-sm" OnClick="Button2_Click" runat="server" Text="اضافة" />  </td>
    </tr>
      <tr>
          <td colspan="7" >
              <asp:Label ID="LabelEroor" runat="server" Text=""></asp:Label>  </td>

          </tr>
  </tbody>
</table>
     </div>
     
  </div>
</div>
           
           
           
        
            <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">باقات الهدايا</h6>
                        </div>
        
         


                        <div class="card-body">
                            <div class="table-responsive">
                                   
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>


                                   


                                <asp:GridView ID="GridView1"      DataKeyNames="id"  runat="server" AutoGenerateColumns="False" emptydatatext="لا توجد باقات"  DataSourceID="SqlDataSource1" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" >
                                                                        <Columns>
                                                                                                                                            
                                                                            <asp:CommandField CancelText="الغاء" DeleteText="حذف" EditText="تعديل" ShowDeleteButton="True" ShowEditButton="True" UpdateText="تحديث" />
                                                                             <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="true" />
         <asp:BoundField DataField="name_package_details" HeaderText="اسم الباقة عربي" 
            SortExpression="name_package_details" />
                                                                                                                
                                         <asp:BoundField DataField="not2" HeaderText="اسم الباقة En" 
   SortExpression="not2" />      
         
    
        <asp:BoundField DataField="image_package_details" HeaderText="صورة الباقة" 
SortExpression="image_package_details" />

                     
   <asp:TemplateField HeaderText="Image">
    <ItemTemplate>
      
         <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# string.Format("~/Uploads/ImageChat/{0}",Eval("image_package_details"))%>'  />
    </ItemTemplate>
</asp:TemplateField>  
                                                                           
    </Columns>
                                         <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Wrap="True" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                            
                                         </asp:GridView>



                                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                                             DeleteCommand="DELETE FROM [package_details] WHERE [id] = @id" 
                                           SelectCommand ="SELECT id, name_package_details ,
not2 ,
image_package_details


                                             FROM [package_details] WHERE ([idpackage] = @idpackage) Order by Id DESC" 
                                            
                                             UpdateCommand="UPDATE [package_details] SET
                                             [name_package_details] = @name_package_details,
                                             [not2] = @not2,
                                             [image_package_details] = @image_package_details
                                             WHERE [id] = @id">
                                    <DeleteParameters>
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>
                                    
                                     <SelectParameters>
                                       
                                    <asp:QueryStringParameter Name="idpackage" QueryStringField="idpackageQuery" DefaultValue="" ConvertEmptyStringToNull="True" />
                                           
                                    </SelectParameters>
                                  
                                    <UpdateParameters>
                                      <asp:Parameter Name="package_details" Type="String" />
                                         <asp:Parameter Name="name_package_details" Type="String" />
                                        <asp:Parameter Name="not2" Type="String" />
                                        <asp:Parameter Name="image_package_details" Type="String" />
                                         
                                    </UpdateParameters>
                                </asp:SqlDataSource>

                                            </ContentTemplate>

</asp:UpdatePanel>

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
    </form>
</body>

</html>
