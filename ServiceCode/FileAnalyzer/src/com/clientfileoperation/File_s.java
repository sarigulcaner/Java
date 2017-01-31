package com.clientfileoperation;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Caner on 23.01.2017.
 */
public class File_s implements Serializable {
    /**
     * Created by Caner on 20.01.2017.
     */
    ///Server class file
    public int id;
    public String location;
    public String name;
    public int wordcount;
    public long modifyDate;

    public List<MostUsedWord> mostusedwords;

    public File_s()
    {
        mostusedwords = new ArrayList<MostUsedWord>();
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
    public long getModifyDate()
    {
        return modifyDate;
    }
    public void setModifyDate(long modifyDate)
    {
        this.modifyDate = modifyDate;
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
