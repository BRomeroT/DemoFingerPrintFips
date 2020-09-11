using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Java.IO;
using Java.Lang;
using System.IO;
using Android.Util;

namespace demo_fingerprint_fips
{
    class FileUtils
    {

        public static string PATH_Grab = Android.OS.Environment.ExternalStorageDirectory
         + Java.IO.File.Separator
         + "fingerprint_fips"
         + Java.IO.File.Separator;
        public static string PATH = Android.OS.Environment
                .ExternalStorageDirectory
                + Java.IO.File.Separator
                + "fingerprint_fips"
                + Java.IO.File.Separator
                + "Template"
                + Java.IO.File.Separator;
        public static string PATH_Grab_img = PATH_Grab + "finger.bmp";
        public static void WritFile2(string fileName, byte[] data)
        {
            if (data == null && data.Length > 0)
                return;
            Java.IO.File file2 = new Java.IO.File(PATH);
            if (!file2.Exists())
            {
                bool rss = file2.Mkdirs();
            }
            string filePath = PATH + fileName;
            Java.IO.File file = new Java.IO.File(filePath);
            if (!file.Exists())
            {
                try
                {
                    // String aaa=    mkdirs2(PATH);

                    file.CreateNewFile();
                    Runtime runtime = Runtime.GetRuntime();
                    runtime.Exec("chmod 0666 " + file);
                }
                catch (Java.Lang.Exception ex)
                {
                    ex.PrintStackTrace();
                }
            }
            RandomAccessFile randomAccessFile = null;

            try
            {
                randomAccessFile = new RandomAccessFile(filePath, "rw");
                randomAccessFile.Write(data);
            }
            catch (Java.Lang.Exception e)
            {
                e.PrintStackTrace();
            }
            finally
            {
                try
                {
                    if (randomAccessFile != null)
                        randomAccessFile.Close();
                }
                catch (Java.Lang.Exception e)
                {
                }
            }
        }
        public static void ClearFile()
        {
           
            Java.IO.File file2 = new Java.IO.File(PATH);
            if (file2.Exists())
                try
                {
                    file2.Delete();
                   // file2.Mkdirs();//.CreateNewFile();
                }
                catch (System.IO.IOException e)
                {

                }
        }
        public static void WritFile(string fileName, string data)
        {
            if (string.IsNullOrEmpty(data))
                return;
            string filePath = PATH + fileName;
            Java.IO.File file2 = new Java.IO.File(PATH);
            if (!file2.Exists())
                try {
                    file2.Mkdirs();//.CreateNewFile();
                } catch(System.IO.IOException e)
                {

                }
               
            Java.IO.File file = new Java.IO.File(filePath);
            FileOutputStream fileOutputStream = null;
            if (!file.Exists())
            {
                try
                {
                   
                    file.CreateNewFile();
                    Runtime runtime = Runtime.GetRuntime();
                    runtime.Exec("chmod 0666 " + file);
                }
                catch (Java.Lang.Exception ex)
                {
                    Log.Info("create fall", ex.Message);
                }
            }
            try
            {
                fileOutputStream = new FileOutputStream(file);
                fileOutputStream.Write(Encoding.ASCII.GetBytes(data));
            }
            catch (Java.Lang.Exception e)
            {
                e.PrintStackTrace();
            }
            finally
            {
                try
                {
                    fileOutputStream.Close();
                }
                catch (Java.Lang.Exception e)
                {
                }
            }
        }
        public static void WritFile(string path, string fileName, string data)
        {
            if (string.IsNullOrEmpty(data))
                return;
            string filePath = path + fileName;
            Java.IO.File file = new Java.IO.File(filePath);
            FileOutputStream fileOutputStream = null;
            if (!file.Exists())
            {
                try
                {
                    file.CreateNewFile();
                    Runtime runtime = Runtime.GetRuntime();
                    runtime.Exec("chmod 0666 " + file);
                }
                catch (Java.Lang.Exception ex)
                {
                    ex.PrintStackTrace();
                }
            }
            try
            {
                fileOutputStream = new FileOutputStream(file);
                fileOutputStream.Write(Encoding.ASCII.GetBytes(data));
            }
            catch (Java.Lang.Exception e)
            {
                e.PrintStackTrace();
            }
            finally
            {
                try
                {
                    fileOutputStream.Close();
                }
                catch (Java.Lang.Exception e)
                {
                }
            }
        }

        public static string ReadFile(string fileName)
        {
            try
            {
                string filePath = PATH + fileName;
                Java.IO.File file = new Java.IO.File(filePath);


                if (!file.Exists())
                    return null;

                using (StreamReader sr = new StreamReader(filePath))
                {
                    return sr.ReadToEnd();
                }
            }
            catch
            {
                return "";

            }


        }
        public static List<IDictionary<string, object>> ReadFileName()
        {
            List<IDictionary<string, object>> map = new List<IDictionary<string, object>>();
         
            Java.IO.File file = new Java.IO.File(PATH);
            if (file.Exists())
            {
                Java.IO.File[] files = file.ListFiles();
                for (int k = 0; k < files.Length; k++)
                {
                    JavaDictionary<string, object> map2 = new JavaDictionary<string, object>();
                    ///   String str1=files[k].getAbsolutePath();
                    //  String str2=files[k].getPath();

                    map2.Add("fname", files[k].Name);
                    map2.Add("fpath", files[k].AbsolutePath);
                    map.Add(map2);
                }
                return map;
            }
            return map;
        }

        //public static HashMap<String, String> ReadFileName()
        //{
        //    var datalist = new List<IDictionary<string, object>>();
        //    HashMap<String, String> map = new HashMap<String, String>();
        //    File file = new File(PATH);
        //    if (file.Exists())
        //    {
        //        File[] files = file.ListFiles();
        //        for (int k = 0; k < files.Length; k++)
        //        {
        //            ///   String str1=files[k].getAbsolutePath();
        //            //  String str2=files[k].getPath();
        //            map.put(files[k].Name, files[k].AbsolutePath);
        //        }
        //        return map;
        //    }
        //    return null;
        //}
        /**
         * byte类型数组转十六进制字符串
         *
         * @param b
         *            byte类型数组
         * @param size
         *            数组长度
         * @return 十六进制字符串
         */
        public static string bytes2HexString(byte[] b, int size)
        {
            string ret = "";

            try
            {
                for (int i = 0; i < size; i++)
                {
                    string hex = Integer.ToHexString(b[i] & 0xFF);
                    if (hex.Length == 1)
                    {
                        hex = "0" + hex;
                    }
                    //   ret += hex.toUpperCase();
                    ret = ret + ("0x" + hex.ToUpper() + ",");
                }
            }
            catch (Java.Lang.Exception e)
            {
                e.PrintStackTrace();
            }
            return ret;
        }

        public static string bytes2HexString2(byte[] b, int size)
        {

            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            try
            {
                for (int i = 0; i < size; i++)
                {
                    string hex = Integer.ToHexString(b[i] & 0xFF);
                    if (hex.Length == 1)
                    {
                        stringBuilder.Append("0");
                        //   hex = "0" + hex;
                    }
                    stringBuilder.Append(hex);

                }
            }
            catch (Java.Lang.Exception e)
            {
                e.PrintStackTrace();
            }
            return stringBuilder.ToString();
        }
    }
}