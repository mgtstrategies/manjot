using RDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//dummy comment + more text
namespace rnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            // Database Connection and Fetch data
            // if no package installed install.packages("RODBC")
            engine.Evaluate("library(RODBC)");
            engine.Evaluate("odbcChannel <- odbcConnect('rtest')");
            engine.Evaluate("d <- sqlFetch(odbcChannel,'oilprices')");

            // graph 1
            //engine.Evaluate("head(d)");
            //engine.Evaluate("str(d)");
            //engine.Evaluate("summary(d$Price)");
            //engine.Evaluate("plot(d$Price)");

            //Graph 2
            //engine.Evaluate("counts <- table(d$Price)");
            //engine.Evaluate("barplot(counts, main = 'Last 10 Years Oil Prices', xlab = 'Oil Prices')");


            //Graph 3
            // if no package installed install.packages("ggplot2")
            engine.Evaluate("library(ggplot2)");
            engine.Evaluate("levels(d$Date) <- gsub('-', '\n-\n', levels(d$Date))");            
            engine.Evaluate("ggplot(d, aes(x = Date, y = Price)) + geom_bar(stat = 'identity') + labs(x = 'Date', y = 'Price')");


            engine.Evaluate("odbcClose(odbcChannel)");

            // .NET Framework array to R vector.

            NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
            engine.SetSymbol("group1", group1);
            // Direct parsing from R script.
            NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();
           
            // Test difference of mean and get the P-value.
            GenericVector testResult = engine.Evaluate("t.test(group1, group2)").AsList();
            double p = testResult["p.value"].AsNumeric().First();

            Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
            Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
            Console.WriteLine("P-value = {0:0.000}", p);

            // you should always dispose of the REngine properly.
            // After disposing of the engine, you cannot reinitialize nor reuse it
            engine.Dispose();
        }
    }
}
