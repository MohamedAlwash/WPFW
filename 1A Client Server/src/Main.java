import java.net.*;
import java.io.*;
import java.util.Arrays;

public class Main {
    public static void main(String[] args) throws Exception {
        ServerSocket server = new ServerSocket(8080);
        int counter = 0;
        int privatecounter = 1;
        while(true) {
            try {
                Socket client = server.accept();
                BufferedReader in = new BufferedReader(new InputStreamReader(client.getInputStream()));
                String request = in.readLine();
                String s;
//                System.out.println(request);
                //Waarom als je in.readLine doet krijg je ander resultaat?
//                System.out.println(in.readLine());
                String webbrowser= "";
                while(!(s = in.readLine()).equals("")) {
                    if(s.startsWith("User-Agent")) {
                        String[] values = s.split(" ");
                        webbrowser = values[11];
                    }
                }

                OutputStream out = client.getOutputStream();
                    //Home page
                if(request.equals("GET / HTTP/1.1")) {
                    out.write((
                            "HTTP/1.0 200 OK\r\n" +
                            "Content-Type: text/html\r\n\r\n" +
                            "Hello <a href='https://www.google.com/'>World!</a>, more info go to  <a href='/about'>about</a> us page. U gebruikt " + webbrowser).getBytes());
                    //About page
                }else if(request.equals("GET /about HTTP/1.1")) {
                    out.write((
                            "HTTP/1.0 200 OK\r\n" +
                            "Content-Type: text/plain\r\n\r\n" +
                            "about").getBytes());
                    //Counnter page
                }else if(request.equals("GET /counter HTTP/1.1")) {
                    out.write((
                            "HTTP/1.0 200 OK\r\n" +
                            "Content-Type: text/plain\r\n\r\ncounter page " + counter++).getBytes());
                }else if(request.equals("GET /privatecounter HTTP/1.1")) {
                    out.write((
                            "HTTP/1.0 200 OK\r\n" +
                            "Content-Type: text/html\r\n\r\nDe teller staat op " + privatecounter + ", klik <a href=/privatecounter"+ privatecounter +">klik mij!</a> om te verhogen").getBytes());
                    System.out.println("normale ="+privatecounter);
                }else if(request.equals("GET /privatecounter"+privatecounter +" HTTP/1.1")) {
                    privatecounter++;
                    out.write((
                            "HTTP/1.0 200 OK\r\n" +
                            "Content-Type: text/html\r\n\r\nDe teller staat op " + privatecounter + ", klik <a href=/privatecounter"+ privatecounter +">klik mij!</a> om te verhogen").getBytes());
                    System.out.println("volgende ="+privatecounter);
                }
                else if(5 == request.indexOf("add")){
                    getQueryMap(request.replaceAll((" HTTP/1.1"), " "), "add");
                }else if(5 == request.indexOf("remove")) {
                    getQueryMap(request.replaceAll((" HTTP/1.1"), " "), "remove");
                }else if(5 == request.indexOf("multiply")) {
                    getQueryMap(request.replaceAll((" HTTP/1.1"), " "), "multiply");
                }else if(5 == request.indexOf("divide")) {
                    getQueryMap(request.replaceAll((" HTTP/1.1"), " "), "divide");
                }else {
                    out.write((
                            "HTTP/1.0 200 OK\r\n" +
                            "Content-Type: text/html\r\n\r\n404 error").getBytes());
                }
                in.close();
                out.close();
                client.close();
            } catch (IOException ioException) {
                System.out.println(ioException);
            }
        }
    }

    public static Integer getQueryMap(String query, String operation) {
        String[] params = query.split("&");
        int num = 0;
        for (String param : params) {
            String name = param.split("=")[0];
            String value = param.split("=")[1];
            System.out.println("value = " + value);
        }
        return num;
    }

}