using Azure.AI.OpenAI;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QandA.Models;
using Newtonsoft.Json;
using System.Security.Policy;

namespace QandA.Services
{
    internal class OpenAIService
    {
        OpenAIClient client;

        public class QuestionsReplyWrapper
        {
            public List<Question> Questions { get; set; }
        }


        public OpenAIService()
        {
            OpenAIClientOptions openAIClientOptions = new OpenAIClientOptions();
            openAIClientOptions.Retry.NetworkTimeout = TimeSpan.FromSeconds(120);
            openAIClientOptions.Retry.MaxRetries = 0;

            client = new OpenAIClient(
                new Uri("https://crgar-openai-openai-sw.openai.azure.com/"),
                new AzureKeyCredential(""),
                openAIClientOptions
            );
        }


        public async Task<List<Question>> GenerateQuestionsFromText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text cannot be null or empty", nameof(text));
            }

            List<ChatRequestMessage> messages = new List<ChatRequestMessage>();
            var prompt = @"Respond with a JSON with a list of questions with this format: 
                {""Questions"":[{""QuestionText"": ""thequestion"", ""OptionCorrect"": ""thecorrectanswer"", ""OptionIncorrect1"": ""incorrectAnswer"", ""OptionIncorrect2"": ""incorrectAnswer"", ""OptionIncorrect3"": ""incorrectAnswer""}, {""QuestionText"": ""thequestion"", ""OptionCorrect"": ""thecorrectanswer"", ""OptionIncorrect1"": ""incorrectAnswer"", ""OptionIncorrect2"": ""incorrectAnswer"", ""OptionIncorrect3"": ""incorrectAnswer""}, ...]}
                """;

            messages.Add(new ChatRequestSystemMessage(prompt));
            prompt = "Generate 5 questions. Each with and 4 multiple choise answers from the text bellow. Answer1 should always be the correct one ---" + Environment.NewLine;
            messages.Add(new ChatRequestSystemMessage(prompt));
            messages.Add(new ChatRequestUserMessage(text));
            
            var chatCompletionOptions = new ChatCompletionsOptions("gpt-4", messages)
            {
                ResponseFormat = ChatCompletionsResponseFormat.JsonObject,
            };

            // Measure the time it takes to get the response
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionOptions);
            watch.Stop();
            string result = response.Value.Choices[0].Message.Content;
            

            // Parse the json result to a list of objects of type questions
            var questionsWrapper = JsonConvert.DeserializeObject<QuestionsReplyWrapper>(result);

            return questionsWrapper.Questions;
        }
    }
}
