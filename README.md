# Alias-Node-service

The solution consists of 4 projects. 
SqliteDB The database that serves the base of the Sqlite and consists of 2 table.  
WindowsFormConfiguration is the Database Configurator.  
WcfService  launches the services.  
WpfClient  is a client program.

The project is using the version .NET Framework 4.6.1
The project is written in Microsoft Visual Studio Community 2017 

To specify the address for the services - use the file App.config, specify the address as in the example   
` <add baseAddress="http://192.168.0.101:8000/WcfService/ServiceAlias/"/>`   

 A similar address should be put in the client program in the file App.config, as shown in the example:    
 `<endpoint address="http://192.168.0.101:8000/WcfService/ServiceAlias/"`

First, on the server machine, run the configurator to specify the required aliases-folders. 
Then, on the same machine, run the server program to provide services.
And finally, on the client machine, launch a client program.

`
 
 
