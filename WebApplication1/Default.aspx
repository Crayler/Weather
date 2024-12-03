<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" Async="true"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div height="450px" width="800px" align="center">
           <hl>
               <asp:Label ID="forcastLabel" runat="server" Text="天气预报" align="center" style="text-align:center;" height="100px" width="800px"></asp:Label>
           </hl>
            <asp:Label ID="tbZone" runat="server" Text="" style="text-align:left;" align="left" height="30px" Width="800px"></asp:Label>
            <asp:Table ID="tablel" runat="server" Width="800px">
                <asp:TableRow Height="30px">
                    <asp:TableCell Width="100px">
                        <asp:Label ID="provinceLabel" runat="server" Text="省份"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="nowWeather" runat="server" Text="天气预报"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="firstDate" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="secondDate" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="thirdDate" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow Height="30px">
                     <asp:TableCell >
                        <asp:DropDownList ID="cbProvince" runat="server" height="20px" width="100px" AutoPostBack="true" OnSelectedIndexChanged="cbProvince_SelectionChanged">
                            <asp:ListItem>直辖市</asp:ListItem>
                            <asp:ListItem>广东</asp:ListItem>
                            <asp:ListItem>湖北</asp:ListItem>
                            <asp:ListItem>四川</asp:ListItem>
                        </asp:DropDownList>
                     </asp:TableCell>
                     <asp:TableCell Width="100px">
                         <asp:Label ID="nowText" runat="server" Text="天气预报"></asp:Label>
                     </asp:TableCell>
                     <asp:TableCell Width="100px">
                         <asp:Label ID="firstDayText" runat="server" Text=""></asp:Label>
                     </asp:TableCell>
                     <asp:TableCell Width="100px">
                         <asp:Label ID="secondDayText" runat="server" Text=""></asp:Label>
                     </asp:TableCell>
                     <asp:TableCell Width="100px">
                         <asp:Label ID="thirdDayText" runat="server" Text=""></asp:Label>
                     </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow Height="30px">
                    <asp:TableCell Width="100px">
                        <asp:Label ID="cityLabel" runat="server" Text="城市"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="nowTemp" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="firstDayTemp" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="secondDayTemp" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="thirdDayTemp" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow Height="100px">
                     <asp:TableCell >
                        <asp:DropDownList ID="lsCities" runat="server" height="20px" width="100px" AutoPostBack="true" OnSelectedIndexChanged="lsCities_SelectionChanged"></asp:DropDownList>
                     </asp:TableCell>
                     <asp:TableCell Width="100px" Height="100px">
                         <asp:image ID="nowIcon" runat="server" ></asp:image>
                     </asp:TableCell>
                     <asp:TableCell Width="100px" Height="100px">
                         <asp:image ID="firstDayIcon" runat="server"></asp:image>
                     </asp:TableCell>
                     <asp:TableCell Width="100px " Height="100px">
                         <asp:image ID="secondDayIcon" runat="server" ></asp:image>
                     </asp:TableCell>
                     <asp:TableCell Width="100px " Height="100px">
                         <asp:image ID="thirdDayIcon" runat="server" ></asp:image>
                     </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
