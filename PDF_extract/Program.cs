/*
Author: Xianrun Qu (Me)
Description: A demo of mine which extracts information from texts;
External Functions: String Helper, a class of methods used for extracting.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnylisisFile;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            String out_txt = "";
            using (FileStream fsRead = new FileStream(@"C:\Users\xianrun.qu\Documents\try_stringhelper.txt", FileMode.Open))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                out_txt = System.Text.Encoding.UTF8.GetString(heByte);
            }
            //Get page to extract, Method #1, extract by User Input
            ArrayList result = new ArrayList();
            Console.WriteLine("please two consecutive Page code");
            String pdf_strt = Console.ReadLine();
            String pdf_end = Console.ReadLine();
            String new_txt = out_txt.Substring(out_txt.IndexOf(pdf_strt), out_txt.IndexOf(pdf_end) - out_txt.IndexOf(pdf_strt));

            // Method #2, Extract page Feature Automatically
            MatchCollection match_lst = Regex.Matches(out_txt, "[A-Za-z]+-[A-Za-z]+-\\d+");
            List<string> Aer_str=new List<string>();
            foreach (Match i in match_lst)
            {
                if (!match_str.Contains(i.ToString()))
                    match_str.Add(i.ToString());
            }
            
            //extract by String Helper
            string new_txt = StringHelper.GetString(out_txt, "pattern 1", "pattern2", false);
            List<String> tb_results = new List<string>();
            string[] arr = new_txt.Split('\r');
            int line_num = 1, count = 0, tracker = 0;
            string ret = "";
            //This section has multiple lines, so I loop through the lines to get required info
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Contains(line_num + "") && arr[i][1].ToString() == line_num + "")
                {

                    if (line_num != 1)
                    {
                        tracker += count;
                        while (count > 0)
                        {
                            ret = ret + arr[i - count];
                            count--;
                        }
                        tb_results.Add(ret);
                        ret = "";
                    }

                    line_num++;
                }
                count++;

            }
            //Get last line
            ret = "";
            while (tracker < arr.Length)
            {
                ret += arr[tracker];
                tracker++;
            }
            tb_results.Add(ret);

            //another attribute,extract with regex
            tb_results.Add(Regex.Match(out_txt, "\\d+/\\d+/\\d+").ToString());

            //Some Pattern, also extracted by regex
            Match rst_comb = Regex.Match(out_txt, @"some_pattern_in_Japanese\（ID\)\r\n(\D+)\d.*\n([\u0800-\u9fa5]*).*\r\n");
            tb_results.Add(rst_comb.Groups[1].ToString().Trim() + rst_comb.Groups[2].ToString().Trim());

           //This is also a multi-line feature, achieved by string methods and regex
            new_txt = StringHelper.GetString(out_txt, "pattern 1", "pattern 2").Trim();
            line_num = 1;
            List<string> exm_result = new List<string>();
            foreach (string m in new_txt.Split('\n'))
            {
                Console.WriteLine(new_txt.Split('\n').Length);
                string[] arr_new = m.Split(' ');

                if (arr_new[0] == line_num + "" || arr_new[1] == line_num + "")
                {
                    if (!Regex.IsMatch(arr_new[arr_new.Length - 3], @"[\u0800-\u9fa5]"))
                    {
                        exm_result.Add(arr_new[arr_new.Length - 2] + arr_new[arr_new.Length - 1]);
                    }
                    else
                    {
                        exm_result.Add(arr_new[arr_new.Length - 1]);
                    }
                    line_num++;
                }
                
                //a method write the information into a text file,the source is in japanese, so the encoding was a little tricky
                foreach (string mn in exm_result)
                {
                    byte[] myByte = System.Text.Encoding.UTF8.GetBytes(mn);


                    using (FileStream fsWrite = new FileStream(@"C:\Users\xianrun.qu\Documents\try_stringhelper.txt", FileMode.Append))
                    {
                       fsWrite.Write(myByte, 0, myByte.Length);
                   };
                }
                }
                

                //byte[] myByte = System.Text.Encoding.UTF8.GetBytes();


                //using (FileStream fsWrite = new FileStream(@"C:\Users\xianrun.qu\Documents\try_stringhelper.txt", FileMode.Append))
                //{
                //    fsWrite.Write(myByte, 0, myByte.Length);
                //};

            }
            Console.ReadKey();





        }
        }
    }
