using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace SouthavenFeed.FeedTaskManager
{
    public class Jsonifiyer
    {
        private static string TO_FOLDER_DATA_PATH = AppDomain.CurrentDomain.BaseDirectory + @"\\Website\\html\\data\\";

        public static bool BuildJSONFile(Dictionary<string, string> data)
        {
            return _BuildJSONFile(data, "data.json", TO_FOLDER_DATA_PATH);
        }  
        public static bool BuildJSONFile(Dictionary<string, string> data, string filename)
        {
            return _BuildJSONFile(data, filename, TO_FOLDER_DATA_PATH);
        }
        public static bool BuildJSONFile(Dictionary<string, string> data, string filename, string filelocation)
        {
            return _BuildJSONFile(data, filename, filelocation);
        }

        public static bool BuildJSONFile(object data)
        {
            return _BuildJSONFile(data, "data.json", TO_FOLDER_DATA_PATH);
        }
        public static bool BuildJSONFile(object data, string filename)
        {
            return _BuildJSONFile(data, filename, TO_FOLDER_DATA_PATH);
        }
        public static bool BuildJSONFile(object data, string filename, string filelocation)
        {
            return _BuildJSONFile(data, filename, filelocation);
        }

        private static bool _BuildJSONFile(Dictionary<string, string> data, string filename, string filelocation)
        {
            try
            {
                File.WriteAllText(filename, JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            catch (Exception wError)
            {
                return false;
            }

            try
            {
                File.Delete(TO_FOLDER_DATA_PATH + filename);                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                File.Move(filename, TO_FOLDER_DATA_PATH + filename);
                
            }

            return true;
        }
        private static bool _BuildJSONFile(object data, string filename, string filelocation)
        {
            try
            {
                File.WriteAllText(filename, JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            catch (Exception wError)
            {
                return false;
            }

            try
            {
                File.Delete(TO_FOLDER_DATA_PATH + filename);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                File.Move(filename, TO_FOLDER_DATA_PATH + filename);

            }

            return true;
        }

    }
}
