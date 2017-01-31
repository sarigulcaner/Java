package com.fileoperation.component;

import java.io.IOException;

/**
 * Created by Caner on 20.01.2017.
 */
// Interface for future developments or extensions
public interface IFileOperationService {
    String getFiles(String filePath) throws IOException, InterruptedException;
}
