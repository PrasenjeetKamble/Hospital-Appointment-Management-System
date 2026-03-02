<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospitalManagement.aspx.cs" Inherits="HospitalManagement.HospitalManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <div>

    
    <h2> Hospital Appointment Portal   </h2>
   <br />
     
       <script type="text/javascript">
           function allowOnlyLetters(e) {
               var charCode = e.which ? e.which : e.keyCode;

               // Allow letters (A-Z, a-z) and space
               if ((charCode >= 65 && charCode <= 90) ||
                (charCode >= 97 && charCode <= 122) ||
                charCode == 32) {
                   return true;
               }
               else {
                   return false;
               }
           }
    </script>

    Patient Name: <asp:TextBox ID="txtName" runat="server" onkeypress="return allowOnlyLetters(event)"></asp:TextBox> 

    <asp:RequiredFieldValidator 
    ID="rfvName" 
    runat="server" 
    ControlToValidate="txtName"
    ErrorMessage="Patient Name is required"
    ForeColor="Red"
    Display="Dynamic">
    </asp:RequiredFieldValidator>

  
        <br />
        <br />

    Doctor Name: <asp:DropDownList ID="ddlDoctor" runat="server">
        <asp:ListItem Value ="0">Select</asp:ListItem>
        <asp:ListItem>Dr. Patil (General)</asp:ListItem>
        <asp:ListItem>Dr. Deshmukh (Orthopedic)</asp:ListItem>
        <asp:ListItem>Dr. Sharma (Cardiologist)</asp:ListItem>
        <asp:ListItem>Dr. Reddy (Dermatologist)</asp:ListItem>

    </asp:DropDownList> 

    <asp:RequiredFieldValidator 
    ID="rfvDoctor" 
    runat="server" 
    ControlToValidate="ddlDoctor"
    InitialValue="0"
    ErrorMessage="Please select a doctor"
    ForeColor="Red"
    Display="Dynamic">
    </asp:RequiredFieldValidator>
        <br />
        <br />

        
    Date: <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox> 

    <asp:RequiredFieldValidator 
    ID="rfvDate" 
    runat="server" 
    ControlToValidate="txtDate"
    ErrorMessage="Date is required"
    ForeColor="Red"
    Display="Dynamic">
    </asp:RequiredFieldValidator>

    <br /><br />

        <asp:Button ID="Button1" runat="server" Text="ADD" BackColor="#339966" 
            ForeColor="White" onclick="Button1_Click" ViewStateMode="Enabled" />
            
        &nbsp;&nbsp;&nbsp;&nbsp;
            
        <asp:Button ID="Button2" runat="server" Text="MODIFY" BackColor="#0000CC" 
            ForeColor="White" onclick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="DELETE" BackColor="#CC0000" 
            ForeColor="White" onclick="Button3_Click" />


        <br />

        <asp:HiddenField ID="hfAppID" runat="server" />



</div>

<hr />



<%--  <asp:GridView ID="gvAppointments" runat="server" CellPadding="10"
    AutoGenerateColumns="True" 
    DataKeyNames="AppID"
    OnSelectedIndexChanged="gvAppointments_SelectedIndexChanged">

    <Columns>
        <asp:CommandField ShowSelectButton="True" />
    </Columns>

</asp:GridView>--%>

<asp:GridView ID="gvAppointments" runat="server" CellPadding="10"
    AutoGenerateColumns="False" 
    DataKeyNames="AppID"
    OnSelectedIndexChanged="gvAppointments_SelectedIndexChanged">

    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        
        <asp:BoundField DataField="AppID" HeaderText="AppID" />
        <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
        <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />

     
        <asp:BoundField DataField="AppDate" HeaderText="AppDate" 
                        DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" HtmlEncode="false" />

        <asp:BoundField DataField="Status" HeaderText="Status" />
    </Columns>

</asp:GridView>


    
    </div>
    </form>
</body>
</html>
