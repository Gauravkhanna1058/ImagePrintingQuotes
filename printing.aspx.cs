using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class printing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //creating a image object    
        System.Drawing.Image bitmap = (System.Drawing.Image)Bitmap.FromFile(Server.MapPath("Black1.jpg")); // set image     
                                                                                                           //draw the image object using a Graphics object    
        Graphics graphicsImage = Graphics.FromImage(bitmap);

        //Set the alignment based on the coordinates       
        StringFormat stringformat = new StringFormat();
        stringformat.Alignment = StringAlignment.Far;
        stringformat.LineAlignment = StringAlignment.Far;

        StringFormat stringformat2 = new StringFormat();
        stringformat2.Alignment = StringAlignment.Center;
        stringformat2.LineAlignment = StringAlignment.Center;

        //Set the font color/format/size etc..      
        Color StringColor = System.Drawing.ColorTranslator.FromHtml("#933eea");//direct color adding    
        Color StringColor2 = System.Drawing.ColorTranslator.FromHtml("#e80c88");//customise color adding    
        //string Str_TextOnImage = "\"";//Your Text On Image    
        string Str_TextOnImage2 = TextBox1.Text;
        //Your Text On Image    

        //graphicsImage.DrawString(Str_TextOnImage, new Font("arial", 40,
        //FontStyle.Regular), new SolidBrush(StringColor), new Point(268, 245),
        //stringformat); Response.ContentType = "image/jpeg";

        int stringleng = "A great deal of intelligence can be ".Length;
        int length = (Str_TextOnImage2.Length % stringleng) > 0 ? (Str_TextOnImage2.Length / stringleng) + 1 : Str_TextOnImage2.Length / stringleng;

        for (int i = 0; i < length; i++)
        {
            graphicsImage.DrawString(Str_TextOnImage2.Substring(i * stringleng, (i + 1 == length) ? (Str_TextOnImage2.Length - (i * stringleng)) : stringleng), new Font("Edwardian Script ITC", 40,
            FontStyle.Bold), new SolidBrush(StringColor2), new Point(304, 100 + (i * 100)),
            stringformat2); Response.ContentType = "image/jpeg";
        }

        bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
    }
}