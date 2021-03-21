#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
EXPOSE 80/tcp
EXPOSE 8080/tcp
EXPOSE 21/tcp
EXPOSE 22/tcp
EXPOSE 3306/tcp
EXPOSE 27017/tcp
EXPOSE 27018/tcp
