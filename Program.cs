// From Web
using HtmlAgilityPack;

var url = "http://html-agility-pack.net/";
var web = new HtmlWeb();
var doc = web.Load(url);
System.Console.WriteLine(doc.DocumentNode.OuterHtml);