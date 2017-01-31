using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SimpleClientWordProcessor
{

    [Serializable]
    public class File_s
    {
        /**
         * Created by Caner on 20.01.2017.
         */
        ///Server class file
        public int id;
        public String location;
        public String name;
        public int wordcount;
        public List<MostUsedWord> mostusedwords;

        public File_s()
        {
            mostusedwords = new List<MostUsedWord>();
        }

        public int getwordcount()
        {
            return wordcount;
        }
        public void setwordcount(int wordcount)
        {
            this.wordcount = wordcount;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getLocation()
        {
            return location;
        }

        public void setLocation(String location)
        {
            this.location = location;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

    }
}
