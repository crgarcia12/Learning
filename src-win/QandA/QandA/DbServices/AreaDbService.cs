using System.Data;
using Npgsql;
using QandA.Models;

namespace QandA.DbServices
{
    internal class AreaDbService
    {
        private readonly string _databaseConnectionString;

        public AreaDbService(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        public async Task StoreNewArea(Area area)
        {
            // Convert the Area object into a SQL query
            string query = $"INSERT INTO areas (id, name) VALUES ('{area.Id}', '{area.Name}');";

            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, dbconn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        public async Task<List<Area>> GetAllAreas()
        {
            // Construct the SQL query to retrieve all areas
            string query = "SELECT id, name FROM public.areas ORDER BY name;";

            List<Area> areas = new List<Area>();

            TopicDbService topicDbService = new TopicDbService(_databaseConnectionString);

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
                            var area = new Area
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1)
                            };                           

                            // Add all topics
                            List<Topic> topics = topicDbService.GetAllTopicsByArea(area).Result;
                            area.Topics.AddRange(topics);

                            areas.Add(area);
                        }
                    }
                }
            }

            return areas;
        }

        public async Task UpdateArea(Area area)
        {
            // Convert the Area object into a SQL query
            string query = $"UPDATE areas SET name = '{area.Name}' WHERE id='{area.Id}';";

            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, dbconn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }
    }
}
