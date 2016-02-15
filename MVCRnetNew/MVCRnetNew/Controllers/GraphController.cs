using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRnetNew.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Index()
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:

            REngine engine = REngine.GetInstance();

            engine.Initialize();

            //Graph directly to image
            var fname = "C:/_NET/rgraph1.png";
            engine.Evaluate("library(RODBC)");
            engine.Evaluate("library(ggplot2)");
            engine.Evaluate("library(scales)");
            engine.Evaluate("library(plyr)");
            engine.Evaluate("odbcChannel <- odbcConnect('rtest')");
            engine.Evaluate("d <- sqlFetch(odbcChannel,'oilprices')");

            engine.Evaluate("levels(d$Date) <- gsub('-', '\n-\n', levels(d$Date))");
            engine.Evaluate("p <- ggplot(d, aes(x = Date, y = Price)) + geom_bar(stat = 'identity') + labs(x = 'Date', y = 'Price')");
            engine.Evaluate("png('" + fname + "')");
            engine.Evaluate("print(p)");
            engine.Evaluate("dev.off()");


            // Database Connection and Fetch data
            // if no package installed install.packages("RODBC")

            //engine.Evaluate("library(RODBC)");
            //engine.Evaluate("library(ggplot2)");
            //engine.Evaluate("odbcChannel <- odbcConnect('rtest')");
            //engine.Evaluate("d <- sqlFetch(odbcChannel,'oilprices')");

            //Graph 1
            //engine.Evaluate("head(d)");
            //engine.Evaluate("str(d)");
            //engine.Evaluate("summary(d$Price)");
            //engine.Evaluate("plot(d$Price)");

            //Graph 2
            //engine.Evaluate("counts <- table(d$Price)");
            //engine.Evaluate("barplot(counts, main = 'Last 10 Years Oil Prices', xlab = 'Oil Prices')");


            //Graph 3
            // if no package installed install.packages("ggplot2")
            //engine.Evaluate("library(ggplot2)");
            //engine.Evaluate("levels(d$Date) <- gsub('-', '\n-\n', levels(d$Date))");
            //engine.Evaluate("chartnew <- ggplot(d, aes(x = Date, y = Price)) + geom_bar(stat = 'identity') + labs(x = 'Date', y = 'Price')");
            //engine.Evaluate("print(chartnew)");

            //engine.Evaluate("odbcClose(odbcChannel)");

            // .NET Framework array to R vector.

            //NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
            //engine.SetSymbol("group1", group1);
            //// Direct parsing from R script.
            //NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

            //// Test difference of mean and get the P-value.
            //GenericVector testResult = engine.Evaluate("t.test(group1, group2)").AsList();
            //double p = testResult["p.value"].AsNumeric().First();

            //Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
            //Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
            //Console.WriteLine("P-value = {0:0.000}", p);

            // you should always dispose of the REngine properly.
            // After disposing of the engine, you cannot reinitialize nor reuse it
            engine.Dispose();
            return View();
        }




    }
}