<html>
<body>
<form name=frmForm method=Post action="<%=Request.QueryString("NextPage")%>">
<Input type=hidden value="<%=Request.QueryString("la")%>" name="la">
<Input type=hidden value="<%=Request.QueryString("ba")%>" name="ba">
<Input type=hidden value="<%=Request.QueryString("da")%>" name="da">
<Input type=hidden value="<%=Request.QueryString("ga")%>" name="ga">
<Input type=hidden value="<%=Request.QueryString("ST")%>" name="ST">
<Input type=hidden value="<%=Request.QueryString("tc")%>" name="tc">
<Input type=hidden value="<%=Request.QueryString("rc")%>" name="rc">
<Input type=hidden value="<%=Request.QueryString("events")%>" name="events">
<Input type=hidden value="<%=Request.QueryString("msg")%>" name="msg">
<Input type=hidden value="<%=Request.QueryString("wp1")%>" name="wp1">
<Input type=hidden value="<%=Request.QueryString("wp2")%>" name="wp2">
<Input type=hidden value="<%=Request.QueryString("wp3")%>" name="wp3">
<Input type=hidden value="<%=Request.QueryString("wp4")%>" name="wp4">
<Input type=hidden value="<%=Request.QueryString("wp5")%>" name="wp5">
<Input type=hidden value="<%=Request.QueryString("wp6")%>" name="wp6">
<Input type=hidden value="<%=Request.QueryString("wp7")%>" name="wp7">
<Input type=hidden value="3" name="dadu">

</form>
<script language=Javascript>
	document.frmForm.submit();
</script>

</body>
</html>
