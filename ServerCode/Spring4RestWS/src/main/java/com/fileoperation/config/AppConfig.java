package com.fileoperation.config;
  
import com.fileoperation.component.FileOperationService;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.EnableWebMvc;
  
@Configuration 
@ComponentScan("com.fileoperation")
@EnableWebMvc   
public class AppConfig{


}
