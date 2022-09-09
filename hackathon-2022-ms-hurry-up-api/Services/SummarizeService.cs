using Azure;
using Azure.AI.TextAnalytics;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace hackathon_2022_ms_hurry_up_api.Services;

public class SummarizeService
{
    public string SummarizePython(string text)
    {
        ScriptEngine engine = Python.CreateEngine();
        ScriptScope scope = engine.CreateScope();
        engine.ExecuteFile(@"C:\test.py", scope);
        dynamic testFunction = scope.GetVariable("summarize");
        var result = testFunction(text);
        return result;
    }
    private static readonly AzureKeyCredential credentials = new AzureKeyCredential("63789c257c444863bc7447ecdf7ce362");
        private static readonly Uri endpoint = new Uri("https://mshurryup-ls.cognitiveservices.azure.com/");

        // Example method for summarizing text
        static async Task<string> TextSummarizationExample()
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            string document = @"The extractive summarization feature uses natural language processing techniques to locate key sentences in an unstructured text document. 
                These sentences collectively convey the main idea of the document. This feature is provided as an API for developers. 
                They can use it to build intelligent solutions based on the relevant information extracted to support various use cases. 
                In the public preview, extractive summarization supports several languages. It is based on pretrained multilingual transformer models, part of our quest for holistic representations. 
                It draws its strength from transfer learning across monolingual and harness the shared nature of languages to produce models of improved quality and efficiency." ;
            var result = "";
            // Prepare analyze operation input. You can add multiple documents to this list and perform the same
            // operation to all of them.
            var batchInput = new List<string>
            {
                document
            };
        
            var actions = new TextAnalyticsActions()
            {
                ExtractSummaryActions = new List<ExtractSummaryAction>() { new () }
            };
        
            // Start analysis process.
            var operation = await client.StartAnalyzeActionsAsync(batchInput, actions);
            await operation.WaitForCompletionAsync();
            // View operation status.
            Console.WriteLine($"AnalyzeActions operation has completed");
            Console.WriteLine();
        
            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
        
            Console.WriteLine();
            // View operation results.
            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<ExtractSummaryActionResult> summaryResults = documentsInPage.ExtractSummaryResults;
        
                foreach (ExtractSummaryActionResult summaryActionResults in summaryResults)
                {
                    if (summaryActionResults.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Action error code: {summaryActionResults.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {summaryActionResults.Error.Message}");
                        continue;
                    }
        
                    foreach (ExtractSummaryResult documentResults in summaryActionResults.DocumentsResults)
                    {
                        if (documentResults.HasError)
                        {
                            Console.WriteLine($"  Error!");
                            Console.WriteLine($"  Document error code: {documentResults.Error.ErrorCode}.");
                            Console.WriteLine($"  Message: {documentResults.Error.Message}");
                            continue;
                        }
        
                        Console.WriteLine($"  Extracted the following {documentResults.Sentences.Count} sentence(s):");
                        Console.WriteLine();
        
                        foreach (SummarySentence sentence in documentResults.Sentences)
                        {
                            Console.WriteLine($"  Sentence: {sentence.Text}");
                            Console.WriteLine();
                            result += sentence;
                        }
                    }
                }
            }

            return result;
        }
}