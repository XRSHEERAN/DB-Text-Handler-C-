/*
Author: Xianrun Qu
Description: A helper Class for pattern Extraction
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnylisisFile
{
    public static class StringHelper
    {
        /// <summary>
        /// Get featured string from source string between start and end patterns,not including the two patterns
        /// Used when the patterns are fixed and only the texts between them are required 
        /// </summary>
        /// <param name="source">the text file contains all desired information</param>
        /// <param name="start">The pattern at the beginning of extraction</param>
        /// <param name="end">the pattern marks the end of extraction</param>
        /// <returns>The extracted info<returns>
        public static string GetString(string source,string start,string end)
        {
            string result = "";
            try
            {
                //check validation of start and end
                if (source.Contains(start) && source.Contains(end))
                {
                    int startIndex = source.IndexOf(start) + start.Length;
                    int endIndex = source.IndexOf(end);
                    if (startIndex > -1 && endIndex > startIndex)
                    {
                        //extracting the length between two patterns' indexes
                        result = source.Substring(startIndex, endIndex - startIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
            }
            return result;
        }
        /// <summary>
        /// Get string before or after the pattern, not including the pattern
        /// Used when the beginning pattern is fixed but the end point is not secured, thus extract the whole after/before
        /// </summary>
        /// <param name="source">same as above</param>
        /// <param name="pattern">The pattern marks the starting point</param>
        /// <param name="isBackwd">true: backward (left), false: forward (right)</param>
        /// <returns>the extracted info</returns>
        public static string GetString(string source, string pattern,bool isBackwd)
        {
            string result = "";
            try
            {
                if (source.Contains(pattern))
                {
                    if (isBackwd)
                    {
                        result = source.Substring(0, source.IndexOf(pattern) + 1);
                    }
                    else
                    {
                        result = source.Substring(source.IndexOf(pattern)+pattern.Length);
                    }
                    
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
            return result;
        }
       
    }
}
