package com.clientfileoperation;

import java.io.Serializable;

/**
 * Created by Caner on 23.01.2017.
 */
public class MostUsedWord implements Serializable {
    public String word;
    public int count;


    public MostUsedWord(String word, int count)
    {
        this.word = word;
        this.count = count;
    }
}
