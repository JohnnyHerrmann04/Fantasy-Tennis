// From Web
using HtmlAgilityPack;
using PuppeteerSharp;

var url = "https://www.espn.com/nfl/boxscore/_/gameId/401547469";

await new BrowserFetcher().DownloadAsync();

using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }))
using (var page = await browser.NewPageAsync())
{
    await page.GoToAsync(url);

    string htmlContent = await page.GetContentAsync();

    var htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(htmlContent);

    File.WriteAllText("myFile", htmlDoc.DocumentNode.OuterHtml);

    string classNameToSelect = "ScoreCell__Time Gamestrip__Time h9 clr-gray-01"; // Replace with the actual class name
    HtmlNode divElement = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='" + classNameToSelect + "']");
    System.Console.WriteLine(divElement.OuterHtml);

}

