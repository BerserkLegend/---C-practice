using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework31._10._23
{
    
    //2
    class ProccesFile
    {
        public int ReplaceWordToFile(string filename,string oldWord,string newWord)
        {
            string str="";
            string str2="";
            int count = 0;
            List<int> pos = new List<int>();
            if (File.Exists(filename))
            {

                using (FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    using(StreamReader w = new StreamReader(f))
                    {
                        str = w.ReadToEnd();
                      
                    }

                }
                //короч надо заменить ddd на www но если dddd то не изменяется
                int size = str.Length;
                /*for (int i = 0; i < size; i++)
                {
                    

                    if (str[i] == oldWord[0])
                    {
                        bool flag = true;
                        for(int j = 0;j<oldWord.Length;j++)
                        {
                            if (str[j + i] != oldWord[j])
                            {
                                flag = false;
                                break;
                            }
                            if (j == oldWord.Length - 1)
                            {
                                if (j + i+1 == size)
                                    flag= true;
                                else if (str[j + 1 + i] == ' ' || str[j + 1 + i] == '\n' || str[j + 1 + i] == '\r')
                                    flag = true;

                                else
                                    flag = false;

                            }
                        }
                        if(flag == true)
                        {
                            for (int j = 0; j < newWord.Length; j++)
                            {
                                str2 += newWord[j];
                            }
                            
                            i +=((newWord.Length)-(oldWord.Length-1));
                            
                            
                        }
                        if (flag == false)
                        {
                            for (int j = 0;true; j++) 
                            {
                                if (j + i + 1 == size)
                                {
                                    i += j;
                                    break;
                                }
                               else if (str[j + 1 + i] == ' ' || str[j + 1 + i] == '\n' ||  str[j + 1 + i] == '\r')
                                   {
                                    i += j;
                                    break;
                                   }
                                        
                            }
                            
                        }


                    }else
                        str2 += str[i];
                }*/
                str2 = str.Replace(oldWord, newWord); //я за ранее знал о этой функции перед тем как писать то что закоментировано
                Console.WriteLine(str2);
               
                for(int i = 0; i < str2.Length; i++) 
                {
                    bool flag = true;
                    if (str2[i] == newWord[0])
                    {
                        for(int j = 0; j < newWord.Length; j++)
                        {
                            if (str2[i] != newWord[0])
                                flag=false;
                            

                        }
                        if(flag)
                        {
                            count++;
                            i += newWord.Length -1;
                        }
                    }
                }
                Console.WriteLine(count);
                using (FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter w = new StreamWriter(f))
                    {
                        w.Write(str2);

                    }

                }
            }

            
            return count;
        }


       public int GetNocurs(string filename,char c=' ')
        {
            int count = 0;
            using(FileStream f = new FileStream(filename,FileMode.Open,FileAccess.Read))
            {
                using(StreamReader r = new StreamReader(f))
                {
                    while(r.Peek()!=-1)
                    {
                       c=(char)r.Read();
                       // if(char.IsLetter(c)) //  это чтобы подсчитать буквы 
                        count++;
                    }
                }
            }
            return count;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //2
            ProccesFile f = new ProccesFile();
            f.ReplaceWordToFile("file.txt", "ddd", "wwww");
            Console.WriteLine("------");
            Console.WriteLine( f.GetNocurs("file.txt"));

        }
    }
}
