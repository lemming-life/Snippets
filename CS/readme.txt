Collection of C# snippets.

Programmed with Visual Studio Code on a Mac.
- Get C# .Net Core from the web.
 - How to .Net Core on Mac:
   https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core-on-MacOS
 - (windows and mac) https://www.visualstudio.com

To setup in console do:
dotnet restore
dotnet run

If that doesn't work then you have to do this in console:
dotnet new
dotnet restore
dotnet run

Then copy and paste the contents from Program.cs on github to the newly created Program.cs

The file Program.cs contains public static void Main(string[] args)