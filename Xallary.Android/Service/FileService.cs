﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xallary.Api;
using Xallary.Droid.Service;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace Xallary.Droid.Service
{

    public class FileService : IFileService
    {
        public void SavePicture(string name, byte[] photoData)
        {
            //// /data/user/0/com.companyname.xallary/files/Pictures
            //var documentsPath = Path.Combine(
            //    System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures), name);


            //string fileName = name + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

            //try
            //{
            //    File.WriteAllBytes(documentsPath, photoData);
            //    if (File.Exists(documentsPath))
            //    {

            //    }
            //}
            //catch (System.Exception e)
            //{
            //    System.Console.WriteLine(e.ToString());
            //}
            try
            {
                Java.IO.File storagePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                string path = System.IO.Path.Combine(storagePath.ToString(), name);
                System.IO.File.WriteAllBytes(path, photoData);
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(path)));
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}