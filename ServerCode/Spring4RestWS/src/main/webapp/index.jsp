<%--
  Created by IntelliJ IDEA.
  User: Caner
  Date: 20.01.2017
  Time: 19:25
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<h1>Welcome File Operation Service</h1>
In war file : </br>
""\WEB-INF\classes\config.properties, you can configure target path and fileanalyzer.jar file</br>
Service Type = REST </br>
Parameter name = Path </br>
Default parameter value = C://tmp </br>
Sample:</br>
http://localhost:4040/FileOperation/data/fileoperation?path=C://tmp</br>
<input type="button" value="Access Web Service Click Here" onclick="window.location.href='../FileOperation/data/fileoperation'"/>
</body>
</html>
