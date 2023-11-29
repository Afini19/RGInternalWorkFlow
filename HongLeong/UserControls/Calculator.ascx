<%@ Control Language="VB" AutoEventWireup="true" Inherits="calculator_class" %>

    <div style="DISPLAY:inline-block;">
        <table width="240">
        <tr><td colspan="3"><asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox></td></tr>
        <tr><td><input type="button" class="touchscreenbutton" value="1" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='1';"></td>
            <td><input type="button" class="touchscreenbutton" value="2" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='2';"></td>
            <td><input type="button" class="touchscreenbutton" value="3" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='3';"></td>
        </tr>
        <tr><td><input type="button" class="touchscreenbutton" value="4" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='4';"></td>
            <td><input type="button" class="touchscreenbutton" value="5" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='5';"></td>
            <td><input type="button" class="touchscreenbutton" value="6" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='6';"></td>
        </tr>
        <tr><td><input type="button" class="touchscreenbutton" value="7" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='7';"></td>
            <td><input type="button" class="touchscreenbutton" value="8" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='8';"></td>
            <td><input type="button" class="touchscreenbutton" value="9" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='9';"></td>
        </tr>
        <tr><td><input type="button" class="touchscreenbutton" value="." style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='.';"></td>
            <td><input type="button" class="touchscreenbutton" value="0" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value+='0';"></td>
            <td><input type="button" class="touchscreenbutton" value="Clear" style="width:80px" OnClick="javascript:document.getElementById('<%=TextBox1.ClientID%>').value='';"></td>
        </tr>

        </table>        

    </div>


