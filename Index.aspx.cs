using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

        request.KeepAlive = true;
        request.Method = "POST";
        request.ContentType = "application/json; charset=utf-8";

        request.Headers.Add("authorization", "Basic NzM3ZDA4NjItODIzNi00ZmEwLTliZmQtYzhjY2FhMWQ1NGFj");

        var serializer = new JavaScriptSerializer();
        var obj = new
        {
            app_id = "6de93b31-802f-4dcd-9bb6-d9e0e670e6d6",
            contents = new { en = txtContent.Text },
            headings = new { en = txtTtile.Text},
            included_segments = new string[] { "All" }
        };
        var param = serializer.Serialize(obj);
        byte[] byteArray = Encoding.UTF8.GetBytes(param);

        string responseContent = null;

        try
        {
            using (var writer = request.GetRequestStream())
            {
                writer.Write(byteArray, 0, byteArray.Length);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
        }
        catch (WebException ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
        }

        System.Diagnostics.Debug.WriteLine(responseContent);
    }
}