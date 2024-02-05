<HTML>
<BODY>
<FORM name=frmForm method=Post action="<%=Request.QueryString("NextPage")%>">
<Input type=hidden value="<%=Request.QueryString("la")%>" name="la">
<Input type=hidden value="<%=Request.QueryString("ba")%>" name="ba">
<Input type=hidden value="<%=Request.QueryString("da")%>" name="da">
<Input type=hidden value="<%=Request.QueryString("ga")%>" name="ga">
<Input type=hidden value="<%=Request.QueryString("ST")%>" name="ST">
<Input type=hidden value="<%=Request.QueryString("tc")%>" name="tc">
<Input type=hidden value="<%=Request.QueryString("rc")%>" name="rc">
<Input type=hidden value="<%=Request.QueryString("events")%>" name="events">

<Input type=hidden value="3" name="dadu">

</Form>
<script language=Javascript>
	document.frmForm.submit();
</script>

</Body>
</HTML>
