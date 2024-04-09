using Npgsql;
using QandA.Models;

namespace QandA.DbServices
{
    internal class TopicDbService
    {
        private string _databaseConnectionString;

        public TopicDbService(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        internal async Task StoreNewTopic(Topic newTopic)
        {
            // Convert the Area object into a SQL query
            string query = $"INSERT INTO topics (id, name, area_id) VALUES ('{newTopic.Id}', '{newTopic.Name}', '{newTopic.Area.Id}');";

            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, dbconn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        public async Task UpdateTopic(Topic newTopic)
        {
            // Convert the Area object into a SQL query
            string query = $"UPDATE topics SET name = '{newTopic.Name}' WHERE id='{newTopic.Id}';";

            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, dbconn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        public async Task<List<Topic>> GetAllTopicsByArea(Area area)
        {
            var conceptDbService = new ConceptDbService(_databaseConnectionString);
            var questionDbService = new QuestionDbService(_databaseConnectionString);

            // Construct the SQL query to retrieve all areas
            string query = $"SELECT id, name, area_id FROM public.topics WHERE area_id = '{area.Id}' ORDER BY name;";

            List<Topic> topics = new List<Topic>();
            

            // Use the PostgreSqlService to run the query and get the result
            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var command = new NpgsqlCommand(query, dbconn))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var topic = new Topic
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Area = area
                            };

                            (await conceptDbService.GetAllConceptsByTopic(topic)).ForEach(concept => topic.Concepts.Add(concept));
                            (await questionDbService.GetAllQuestionsByTopic(topic)).ForEach(question => topic.Questions.Add(question));
                            topics.Add(topic);
                        }
                    }
                }
            }

            return topics;
        }
    }
}