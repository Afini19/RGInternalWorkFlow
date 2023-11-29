using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Configuration;

public partial class UserControls_ListingPageControl : System.Web.UI.UserControl
{
    public delegate void EmptyDelegate();
    public event EventHandler PageNumberChanged;
    public event EmptyDelegate ExportToExcel;
    public event EmptyDelegate PrintableVersion;
    public ListingPageControlMode Mode
    {
        get
        {
            if (PlaceHolder1.Visible)
            {
                if (PlaceHolder2.Visible) return ListingPageControlMode.Full;
                else return ListingPageControlMode.Medium;
            }
            else return ListingPageControlMode.Simple;
            //return (PlaceHolder1.Visible ? ListingPageControlMode.Full : ListingPageControlMode.Simple);
        }
        set
        {
            PlaceHolder1.Visible = (value == ListingPageControlMode.Full || value == ListingPageControlMode.Medium);
            PlaceHolder2.Visible = (value == ListingPageControlMode.Full);
        }
    }

    int recordsPerPage = 25;
    public int RecordsPerPage
    {
        get
        {
            return recordsPerPage;
        }
        set
        {
            recordsPerPage = value;
        }
    }

    int currentPage = 1;
    public int CurrentPage
    {
        get
        {
            string k = "pg";
            if (ViewState[k] == null) ViewState.Add(k, 1);

            return (int)ViewState[k];
        }
        set
        {
            bool changed = (value != CurrentPage);

            string k = "pg";
            if (ViewState[k] == null) ViewState.Add(k, 1);

            ViewState[k] = value;

            if (changed) OnPageNumberChanged();
        }
    }
    int totalPages
    {
        get
        {
            string k = "tpg";
            if (ViewState[k] == null) ViewState.Add(k, 1);

            return (int)ViewState[k];
        }
        set
        {
            string k = "tpg";
            if (ViewState[k] == null) ViewState.Add(k, 1);

            ViewState[k] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Populate(ListData res)
    {
        totalPages = res.TotalPages;
        if (CurrentPage > totalPages) CurrentPage = 1;

        litTotalRecords.Text = res.TotalRecords.ToString("###,###,##0");
        litRecordsRange.Text = (res.ListingRecordFrom).ToString("###,###,##0") + " to " + res.ListingRecordTo.ToString("###,###,##0");
        int start = 1;
        int end = res.TotalPages;
        start = Math.Max(CurrentPage - 25, start);
        end = Math.Min(CurrentPage + 25, end);
        drpPage.Items.Clear();
        for (int i = start; i <= end; i++)
        {
            drpPage.Items.Add(new ListItem("Page " + i, i.ToString()));
        }
        int selected = CurrentPage - start;
        if (drpPage.Items.Count > 0) drpPage.Items[selected].Selected = true;
        litTotalPages.Text = res.TotalPages.ToString("###,###,##0");

        if (res.TotalRecords == 0)
            plcNoRecord.Visible = true;
        else
            plcNoRecord.Visible = false;

        lnkFirst.Enabled = (res.CurrentPage != 1);
        lnkPrev.Enabled = (res.CurrentPage != 1);
        lnkNext.Enabled = (res.CurrentPage < res.TotalPages);
        lnkLast.Enabled = (res.CurrentPage < res.TotalPages);

        //lnkPrt1.Enabled = (drpPage.Items.Count > 0 ? true : false);
        //lnkPrt2.Enabled = (drpPage.Items.Count > 0 ? true : false);
        lnkXls1.Enabled = (drpPage.Items.Count > 0 ? true : false);
        lnkXls2.Enabled = (drpPage.Items.Count > 0 ? true : false);

        //if (res.TotalRecords > MaxExcelRows)
        //{
        //    string js = "return confirm('The list contains too many records.\\nOnly the first " + MaxExcelRows.ToString(Common.IntegerFormat) + " records will be exported.\\n\\nProceed?');";
        //    lnkXls1.OnClientClick = lnkXls2.OnClientClick = js;
        //}
        //if (res.TotalRecords > MaxPrintableRows)
        //{
        //    string js = "return confirm('The list contains too many records.\\nOnly the first " + MaxPrintableRows.ToString(Common.IntegerFormat) + " records will be printed.\\n\\nProceed?');";
        //    lnkPrt1.OnClientClick = lnkPrt2.OnClientClick = js;
        //}
    }
    void OnPageNumberChanged()
    {
        if (PageNumberChanged != null)
        {
            PageNumberChanged(this, new EventArgs());
        }
    }
    protected void lnkXls_Click(object sender, EventArgs e)
    {
        if (ExportToExcel != null) ExportToExcel();
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        if (PrintableVersion != null) PrintableVersion();
    }
    protected void lnkFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
    }
    protected void lnkPrev_Click(object sender, EventArgs e)
    {
        CurrentPage--;
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        CurrentPage++;
    }
    protected void lnkLast_Click(object sender, EventArgs e)
    {
        CurrentPage = totalPages;
    }
    protected void drpPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = int.Parse(drpPage.SelectedValue);
    }
}
public enum ListingPageControlMode
{
    Full, Medium, Simple
}