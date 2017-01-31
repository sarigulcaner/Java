package com.fileoperation.component;

import org.springframework.stereotype.Component;
import java.io.*;
import java.util.Properties;

/**
 * Created by Caner on 20.01.2017.
 */
@Component
public class FileOperationService  implements IFileOperationService {

    @Override
    public String getFiles(String filePath) throws IOException, InterruptedException {
        return listFilesForFolder(filePath);
    }

    private String listFilesForFolder(final String folder) throws IOException, InterruptedException {

        // Load configuration file
        ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
        InputStream stream = classLoader.getResourceAsStream("/config.properties");
        Properties prop = new Properties();
        prop.load(stream);
        String fileAnalyzerPath =prop.getProperty("FileAnalyzerPath");
        // Get working directory background process
        File file = new File(fileAnalyzerPath);
        if(file.exists() && !file.isDirectory()) {
            // Call background process
            Process proc = Runtime.getRuntime().exec("java -jar "+fileAnalyzerPath +" "+ folder);
            InputStream in = proc.getInputStream();
            BufferedReader input = new BufferedReader(new InputStreamReader(in));
            // Return output to client
            return input.readLine();
        }
        else
        {
            return "Couldn't find file:"+fileAnalyzerPath;
        }
    }

}
