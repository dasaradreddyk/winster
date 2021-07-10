using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.IO.Compression;
using System.Xml;

namespace winster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private List<ProfieData> lst = new List<ProfieData>();
        public DataController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("[Action]")]
        public ActionResult Getprofies(string input)
        {
            if (input.Equals("General"))
                get_olddata();
            else
                 Get_NewdataFormat();
            lst = ShuffleList(lst);
            var list = JsonConvert.SerializeObject(lst.Take(200), Newtonsoft.Json.Formatting.None,
           new JsonSerializerSettings()
           {
               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           });

            return Content(list, "application/json");

        }
        public  void  get_newdata_1()
        { 
            string lineOfText1 = "";

            string folderName = "Upload";

            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            // var filestream = new System.IO.FileStream("./app_data/" + input + ".txt",
            var filestream = new System.IO.FileStream(newPath + "/" + "links" + ".txt",

                                         // var filestream = new System.IO.FileStream("./app_data/" + input + ".txt",
                                         System.IO.FileMode.Open,
                                         System.IO.FileAccess.Read,
                                         System.IO.FileShare.ReadWrite);


            System.IO.BufferedStream bs = new System.IO.BufferedStream(filestream);

            var file = new System.IO.StreamReader(bs, System.Text.Encoding.UTF8, true, 128);

            while ((lineOfText1 = file.ReadLine()) != null)
            {
                long profileid = 0;
                string url = "";
                try
                {
                    if (lineOfText1.Contains("https://www.facebook.com/groups/"))
                    {
                        var arr = lineOfText1.Split('/');
                        profileid = Int64.Parse(arr[6].ToString());
                        url = "https://facebook.com/" + profileid.ToString();
                        ProfieData obj = new ProfieData();
                        obj.name = profileid.ToString();
                        obj.url = url;
                        string pagedata = "";
                        //WebClient client = new WebCient();
                      //  string webpage = Gethttppage(url);
                        lst.Add(obj);
                        if (lst.Count > 2000)
                            break;

                    }
                } //return Json(lst.Take(5));
                catch (Exception ex)
                {
                }
            }
            
        }
        public void get_olddata()
        {
            string lineOfText1 = "";
            string lineOfText2 = "";
            try
            {
                var filestream = new System.IO.FileStream("./wwwroot/upload/" + "rise" + ".txt",//C:\Project\gallary\backup\gallary version 1\Gallary2\Gallary\wwwroot\Upload\rise.txt
                                               System.IO.FileMode.Open,
                                         System.IO.FileAccess.Read,
                                         System.IO.FileShare.ReadWrite);


                System.IO.BufferedStream bs = new System.IO.BufferedStream(filestream);

                var file = new System.IO.StreamReader(bs, System.Text.Encoding.UTF8, true, 128);
               // List<ProfieData> lst = new List<ProfieData>();
                while ((lineOfText1 = file.ReadLine()) != null)
                {
                    try
                    {
                        ProfieData obj = new ProfieData();
                        lineOfText2 = file.ReadLine();
                        Boolean found;
                        //Do something with the lineOfText(
                        if (lineOfText2 == null || !lineOfText2.Contains("profile"))
                            continue;
                        else
                        {
                            var line1 = lineOfText1.Replace("FileName", "");
                           

                            string output = lineOfText2.Split(':', ',')[1];
                            //  obj.url = output.Replace("\"", "");

                            obj.name = lineOfText2.Replace("FileName", "");
                            obj.name = obj.name.Replace("Filename", "");
                            obj.name = obj.name.Replace("filename", "");
                            obj.name = obj.name.Replace(" ", "");
                            obj.name = obj.name.Replace(":", "");
                                var s = obj.name.Split("_");
                            obj.name = s[0];
                            int index = obj.name.IndexOf('(');
                            if(index > 0) obj.name = obj.name.Substring(0, index);
                            obj.name = obj.name.Replace("\"", "");
                            obj.url = "https://facebook.com/" + obj.name;
                            lst.Add(obj);

                            var lineOfText3 = file.ReadLine();
                            if (lineOfText3 != null)
                            {
                                var line3 = lineOfText3.Replace("FileName", "");
                                
                            }
                            var lineOfText4 = file.ReadLine();
                            if (lineOfText4 != null)
                            {
                                obj.name = lineOfText4.Split(':', ',')[1];
                                obj.name = obj.name.Replace("Filename", "");
                                obj.name = obj.name.Replace("filename", "");
                                obj.name = obj.name.Replace(" ", "");
                                obj.name = obj.name.Replace(":", "");
                                var s1 = obj.name.Split("_");
                                obj.name = s1[0];

                                 index = obj.name.IndexOf('(');
                                if (index > 0) obj.name = obj.name.Substring(0, index);
                                obj.name = obj.name.Replace("\"","");
                                obj.url = "https://facebook.com/" + obj.name;
                                
                            }
                            lst.Add(obj);

                            var lineOfText5 = file.ReadLine();
                            if (lineOfText5 != null)
                            {
                                var line5 = lineOfText5.Replace("FileName:", "");
                                
                            }
                            var lineOfText6 = file.ReadLine();
                            if (lineOfText6 != null)
                            {
                                obj.name = lineOfText6.Split(':', ',')[1];
                                obj.name = obj.name.Replace("Filename", "");
                                obj.name = obj.name.Replace("filename", "");
                                obj.name = obj.name.Replace(" ", "");
                                obj.name = obj.name.Replace(":", "");
                                var s2 = obj.name.Split("_");
                                obj.name = s2[0];
                                 index = obj.name.IndexOf('(');
                                if (index > 0) obj.name = obj.name.Substring(0, index);
                                obj.name = obj.name.Replace("\"", "");
                                obj.url = "https://www.facebook.com/" + obj.name;
                            }
                            //obj.species = obj.species.Replace("entity_id\":\"","");
                            lst.Add(obj);
                        }
                        if (lst.Count > 2000)
                            break;
                    }
                    catch (Exception ex)

                    {
                        continue;
                    }
                }
            }
            catch(Exception)
            { }
            }
        public void Get_NewdataFormat()
        {

            string lineOfText1 = "";

            string folderName = "Upload";

            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            // var filestream = new System.IO.FileStream("./app_data/" + input + ".txt",
            var filestream = new System.IO.FileStream(newPath + "/" + "test" + ".xml",

                                         // var filestream = new System.IO.FileStream("./app_data/" + input + ".txt",
                                         System.IO.FileMode.Open,
                                         System.IO.FileAccess.Read,
                                         System.IO.FileShare.ReadWrite);

            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
            xmldoc.Load(filestream);
            xmlnode = xmldoc.GetElementsByTagName("file");
             for( i =0; i < xmlnode.Count; i++)
             {
                long profileid = 0;
                string url = "";
                string name = "";
                try
                {
                    //if (lineOfText1.Contains("https://www.facebook.com/groups/"))
                    // if (lineOfText1.Contains("https://www.facebook.com/groups/"))
                    {
                        if (xmlnode[i].ChildNodes.Count < 1) continue;
                        //if (!xmlnode[i].ChildNodes.Item(1).InnerText.Contains("friends_current_city"))
                        //    continue;

                        name = xmlnode[i].ChildNodes.Item(0).InnerText;
                        var temp  =(xmlnode[i].ChildNodes.Item(1).InnerText.ToString());
                        var arr = temp.Split('/');
                        //profileid = Int64.Parse(arr[6].ToString());
                        name = xmlnode[i].ChildNodes.Item(0).InnerText.ToString();
                        url = "https://facebook.com/" + profileid.ToString();
                        url = xmlnode[i].ChildNodes.Item(1).InnerText.ToString();

                        ProfieData obj = new ProfieData();
                        obj.name = name;
                        obj.url = url;
                        string pagedata = "";
                        //WebClient client = new WebCient();
                        //  string webpage = Gethttppage(url);
                        lst.Add(obj);
                        if (lst.Count > 58000)
                            break;

                    }
                } //return Json(lst.Take(5));
                catch (Exception ex)
                {
                }
            }
           // lst = ShuffleList(lst);
           // var list = JsonConvert.SerializeObject(lst.Take(20), Newtonsoft.Json.Formatting.None,
           //new JsonSerializerSettings()
           //{
           //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           //});

           // return Content(list, "application/json");
            
        }
        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }


        public string Gethttppage(string url)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.AllowAutoRedirect = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17";

            string content;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var decompressedStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
            using (var streamReader = new StreamReader(decompressedStream))
            {
                content = streamReader.ReadToEnd();
            }
            return content;
        }
    }
}
public class ProfieData
{
     public string name { get; set; }
    public string url { get; set; }
   // public string pagedata { get; set; }
}