FROM microsoft/dotnet:runtime

WORKDIR /dotnetapp
COPY out .
ENTRYPOINT ["dotnet", "jspmdnx.dll"]
