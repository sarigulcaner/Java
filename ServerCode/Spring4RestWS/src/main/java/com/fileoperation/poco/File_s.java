package com.fileoperation.poco;

/**
 * Created by Caner on 20.01.2017.
 */
///Server class file
public class File_s {
    private int id;
    private String location;
    private String name;
    private int wordcount;

    public int getwordcount() {
        return wordcount;
    }
    public void setwordcount(int wordcount) {
        this.wordcount = wordcount;
    }
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
