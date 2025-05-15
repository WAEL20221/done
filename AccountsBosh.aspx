<%@ Page Title="" Language="C#" MasterPageFile="~/AdminShops/AdminUser.Master" AutoEventWireup="true" CodeBehind="AccountsBosh.aspx.cs" Inherits="MyFast.AdminShops.AccountsBosh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%;  font-size:small; text-align:right;" class="card shadow mb-4">
         <div style=" text-align:left;" >
                 
                             <a  dir="ltr"  href="AdminShopsCity.aspx" style="text-align:left; margin:30px; padding-left:50px;  padding-right:50px;" class="btn btn-success">رجوع</a>

                        </div>
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">حسابات المتاجر   </h6>
                             
                        </div>
            
                        <div   class="card-body">
    <div class="card shadow mb-4">
                                <!-- Card Header - Accordion -->
                                <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse"
                                    role="button" aria-expanded="false" aria-controls="collapseCardExample">
                                    <h6 class="m-0 font-weight-bold text-primary">اضافة حساب بنكي جديد</h6>
                                </a>
                                <!-- Card Content - Collapse -->
                                <div class="collapse show " id="collapseCardExample">
                                    <div class="card-body">
                                         <div class="table-responsive">
                                <table class="table " id="dataTable" width="100%" cellspacing="0">
                                  
                               
                                        <tr style="font-size:12px; font-weight:bold; color:black;">
                                            <td>
                                               المتجر : 
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="NameBosh" DataValueField="Id" Font-Bold="True" Font-Size="Large"></asp:DropDownList>
                                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [UserShopBoshesArEn] ORDER BY [Id] DESC"></asp:SqlDataSource>
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


                             <div class="table-responsive">
                              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource3" Height="174px" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="IdCUstomer" HeaderText="اسم المتجر" SortExpression="IdCUstomer" />
                                  
                                    <asp:BoundField DataField="IdPorducts" HeaderText="رقم الحساب البنكي" SortExpression="IdPorducts" />
                                    <asp:BoundField DataField="NamePorducts" HeaderText="اسم صاحب الحساب" SortExpression="NamePorducts" />
                                      <asp:BoundField DataField="Count" HeaderText="البنك" SortExpression="Count" />
                                    <asp:BoundField DataField="Pric" HeaderText="رقم الهاتف" SortExpression="Pric" />
                                    <asp:BoundField DataField="DataBill" HeaderText="تاريخ الاضافة" SortExpression="DataBill" />
                                    <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                                </Columns>
                                <EditRowStyle Font-Bold="False" />
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" Font-Size="Large" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>     
 </div>



                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [BillInterims] WHERE [Id] = @Id" SelectCommand="SELECT [Id], [IdCUstomer], [IdBosh], [IdPorducts], [NamePorducts], [Count], [Pric], [DataBill] FROM [BillInterims] ORDER BY [Id]" InsertCommand="INSERT INTO [BillInterims] ([IdCUstomer], [IdBosh], [IdPorducts], [NamePorducts], [Count], [Pric], [DataBill]) VALUES (@IdCUstomer, @IdBosh, @IdPorducts, @NamePorducts, @Count, @Pric, @DataBill)" UpdateCommand="UPDATE [BillInterims] SET [IdCUstomer] = @IdCUstomer, [IdBosh] = @IdBosh, [IdPorducts] = @IdPorducts, [NamePorducts] = @NamePorducts, [Count] = @Count, [Pric] = @Pric, [DataBill] = @DataBill WHERE [Id] = @Id">
                           <DeleteParameters>
                               <asp:Parameter Name="Id" Type="Int32" />
                         </DeleteParameters>
                                
                                <InsertParameters>
                                    <asp:Parameter Name="IdCUstomer" Type="String" />
                                    <asp:Parameter Name="IdBosh" Type="String" />
                                    <asp:Parameter Name="IdPorducts" Type="String" />
                                    <asp:Parameter Name="NamePorducts" Type="String" />
                                    <asp:Parameter Name="Count" Type="String" />
                                    <asp:Parameter Name="Pric" Type="String" />
                                    <asp:Parameter Name="DataBill" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="IdCUstomer" Type="String" />
                                    <asp:Parameter Name="IdBosh" Type="String" />
                                    <asp:Parameter Name="IdPorducts" Type="String" />
                                    <asp:Parameter Name="NamePorducts" Type="String" />
                                    <asp:Parameter Name="Count" Type="String" />
                                    <asp:Parameter Name="Pric" Type="String" />
                                    <asp:Parameter Name="DataBill" Type="String" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                                
                            </asp:SqlDataSource>

                             


</div>
        </div>




</asp:Content>
 