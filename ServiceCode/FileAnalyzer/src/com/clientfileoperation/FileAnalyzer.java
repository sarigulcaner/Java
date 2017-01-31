package com.clientfileoperation;

import com.google.gson.Gson;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;

/**
 * Created by Caner on 23.01.2017.
 */
public class FileAnalyzer {
    static List<String> AllTxtFiles;
    private static void find(String path) {
        File directory = new File(path);

        // get all the files from a directory
        File[] fList = directory.listFiles();

        for (File file : fList) {
            if (file.isFile()) {
                if(file.getName().endsWith(".txt")) {
                    AllTxtFiles.add(file.getAbsolutePath());
                }
            } else if (file.isDirectory()) {
                find(file.getAbsolutePath());
            }
        }
    }

    // Counts how many words in the text
    private static int CountWords(String test)
    {
        int count = 0;
        boolean inWord = false;

        for (char t : test.toCharArray())
        {
            if (t == ' ')
            {
                inWord = false;
            }
            else
            {
                if (!inWord) count++;
                inWord = true;
            }
        }
        return count;
    }

    // Write small cache .chc for each text file , reduce great amount of processing time of re-analysing text file
    private static void WriteCache(File_s file) throws IOException {
        BufferedWriter bw = null;
        File f = new File(file.getLocation());
        FileWriter fw = null;
        file.setModifyDate(f.lastModified());
        Gson gson = new Gson();
        String json = gson.toJson(file);

        fw = new FileWriter(file.getLocation().substring(0, file.getLocation().lastIndexOf('.'))+".chc");
        bw = new BufferedWriter(fw);
        bw.write(json);
        bw.close();
    }

    // Check chc file extension for each text file, reduce great amount of processing time to re-analysing text file
    private static File_s CheckCache(File_s checkFile) throws IOException
    {
        File cacheFile = new File(checkFile.getName().substring(0, checkFile.getName().lastIndexOf('.'))+".chc");
        File  txtFile = new File(checkFile.getName().substring(0, checkFile.getName().lastIndexOf('.'))+".txt");
            String content = new String(Files.readAllBytes(Paths.get(cacheFile.getAbsolutePath())));
            Gson gson = new Gson();
            File_s json = gson.fromJson(content,File_s.class);
            if(txtFile.lastModified() == json.getModifyDate())
            {
                return json;
            }
            else
            {
                int wordCount = CountWords(content);
                checkFile.setwordcount(wordCount);

                AnalyseText(cacheFile.getAbsolutePath(), checkFile);
                return checkFile;

            }
    }

    // Main program starts
    public static void main(String[] args)
    {
        // Client requests json output. Prepare object for json output
        FileWrapper fileWrapper = new FileWrapper();
        fileWrapper.shortfiles = new ArrayList<File_s>();
        fileWrapper.longfiles = new ArrayList<File_s>();

        try
        {
            // Keep textfiles in the memory
            AllTxtFiles = new ArrayList<String>();
            // Find all text files current directory and subdirectories store AllTxtFiles
            find(args[0]);// First argument waits search directory path
            // Get filtered files extension txt
            for(String file : AllTxtFiles)
            {
                // Prepare micro data transfer object and fill it by text file properties
                File_s fileDto = new File_s();
                fileDto.setName(file);
                fileDto.setLocation(file);
                File f = new File(fileDto.getName().substring(0, fileDto.getName().lastIndexOf('.'))+".chc");
                // Checks current txt file has a cache file
                if(f.exists() && !f.isDirectory()) {
                    // Cache file founded and analyse it
                    fileDto = CheckCache(fileDto);

                    // Set again word counts
                    if (fileDto.getwordcount() > 1000) {
                        fileWrapper.longfiles.add(fileDto);
                    }else {
                        fileWrapper.shortfiles.add(fileDto);
                    }
                    // Write to cache again
                    WriteCache(fileDto);

                }
                else {
                    // There is no cache file found for this txt file. Get this txt for analysing
                    String content = new String(Files.readAllBytes(Paths.get(file)));
                    int wordCount = CountWords(content);
                    // Check that repeated words inside of the txt file
                    AnalyseText(file, fileDto);

                    // Check how many words inside of the txt file
                    // Business Req: If it has less than 1000 words: short file, If it has greater than 1000 words: long file
                    if (wordCount > 1000) {
                        // Put how many words there are in the text
                        fileDto.setwordcount(wordCount);
                        fileWrapper.longfiles.add(fileDto);
                    } else {
                        fileDto.setwordcount(wordCount);
                        fileWrapper.shortfiles.add(fileDto);
                    }
                    // Write cache first time
                    WriteCache(fileDto);
                }
            }

            // After it finishes all txt file analysing return json to the client
            Gson gson = new Gson();
            String json = gson.toJson(fileWrapper);
            System.out.println(json);
        }
        catch (Exception ex)
        {
            System.out.println("Exception:"+ex.getMessage());
        }
    }

    // Business Req: Analyse text file and find repeated words
    // Count how many times they are repeated. If it is greater than 50 put them to the output
    private static void AnalyseText(String fileName,File_s file) throws IOException
    {
        String inputString = new String(Files.readAllBytes(Paths.get(fileName)));
        // Convert our input to lowercase
        inputString = inputString.toLowerCase();

        // Define characters to strip from the input and do it
        String[] stripChars = { ";", ",", ".", "-", "_", "^", "(", ")", "[", "]",
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\n", "\t", "\r" };
        for (String character : stripChars)
        {
            inputString = inputString.replace(character, "");
        }

        // Split on spaces into a List of strings
        ArrayList<String> wordList=  new ArrayList<String>();
            wordList.addAll(Arrays.asList(inputString.split(" ")));

        // Define and remove stopwords
        /*
        String[] stopwords = new String[] { "and", "the", "she", "for", "this", "you", "but" };
        for (String word : stopwords)
        {
            // While there's still an instance of a stopword in the wordList, remove it.
            // If we don't use a while loop on this each call to Remove simply removes a single
            // instance of the stopword from our wordList, and we can't call Replace on the
            // entire string (as opposed to the individual words in the string) as it's
            // too indiscriminate (i.e. removing 'and' will turn words like 'bandage' into 'bdage'!)

            while (wordList.contains(word))
            {
                wordList.remove(word);
            }
        }
        */

        // Create a new Dictionary object
        Map<String, Integer> dictionary = new HashMap<String, Integer>();

        // Loop over all over the words in our wordList...
        for (String word : wordList)
        {
            // If the length of the word is at least three letters...
            if (word.length() >= 3)
            {
                // ...check if the dictionary already has the word.
                if (dictionary.containsKey(word))
                {
                    // If we already have the word in the dictionary, increment the count of how many times it appears
                    dictionary.put(word,dictionary.get(word)+1);
                }
                else
                {
                    // Otherwise, if it's a new word then add it to the dictionary with an initial count of 1
                    dictionary.put(word,1);
                }

            } // End of word length check

        } // End of loop over each word in our input
        file.mostusedwords = new ArrayList<MostUsedWord>();
        for (Map.Entry<String,Integer> pair : dictionary.entrySet())
        {
            // More than 50 times repeated , add to most used words
            if(pair.getValue() > 50)
            {
                MostUsedWord word = new MostUsedWord(pair.getKey(), pair.getValue());
                file.mostusedwords.add(word);
            }
        }

    }
}
