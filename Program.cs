using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
namespace bmp_create
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap SourcePicture;
            int i, j;
            if(args[0] == "1"){
                SourcePicture = new Bitmap(args[1]);
                int length = SourcePicture.Width * SourcePicture.Height;
                byte[] raw_data = new byte[length];
                for (i = 0; i < SourcePicture.Height; i++)
                {
                    for (j = 0; j < SourcePicture.Width; j++)
                    {
                        var pix = SourcePicture.GetPixel(i, j);
                        raw_data[i * SourcePicture.Width + j] = pix.R;
                    }
                }
                var raw_file = File.Create(args[2]);
                raw_file.Write(raw_data, 0, length);
                raw_file.Close();
            }
            if (args[0] == "2")
            {
                SourcePicture = new Bitmap(args[1]);
                Bitmap DestPicture = new Bitmap(SourcePicture.Height, SourcePicture.Width);

                int length = SourcePicture.Width * SourcePicture.Height;
                byte[] raw_data = File.ReadAllBytes(args[2]);
                
                for (i = 0; i < SourcePicture.Height; i++)
                {
                    for (j = 0; j < SourcePicture.Width; j++)
                    {
                        byte bt = raw_data[i * SourcePicture.Width + j];
                        Color clr = Color.FromArgb(bt, bt, bt);
                        DestPicture.SetPixel(i, j, clr);
                        
                    }
                }
                DestPicture.Save(args[3]);
                
            }
            
        }
    }
}
