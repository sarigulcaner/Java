package com.fileoperation;

import com.fileoperation.component.IFileOperationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

/**
 * Created by Caner on 20.01.2017.
 */
@RestController
@RequestMapping("/data")
public class FileOperationController {
    @Autowired
    private IFileOperationService fileService;
/**
    @RequestMapping("/fileoperation")
    public String getFiles() {
        File_s file = fileService.getFileOperationDetails();
        return file.getLocation();
    }
**/
    @RequestMapping("/fileoperation")
    public String getFiles(@RequestParam(value = "path",required = false,
            defaultValue = "") String FolderPath) throws IOException, InterruptedException {

        ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
        InputStream stream = classLoader.getResourceAsStream("/config.properties");
        Properties prop = new Properties();
        prop.load(stream);
        if(FolderPath.isEmpty())
            return fileService.getFiles(prop.getProperty("DefaultSearchPath"));
         else
            return fileService.getFiles(FolderPath);

    }

}