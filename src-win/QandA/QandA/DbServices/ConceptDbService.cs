using Npgsql;
using QandA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.DbServices
{
    internal class ConceptDbService
    {

        private string _databaseConnectionString;

        public ConceptDbService(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        internal async Task StoreNewConcept(Concept newConcept)
        {
            // Convert the Area object into a SQL query
            string query = $"INSERT INTO concepts (id, name, topic_id) VALUES ('{newConcept.Id}', '{newConcept.Name}', '{newConcept.Topic.Id}');";

            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, dbconn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        public async Task UpdateConcept(Concept concept)
        {
            // Convert the Area object into a SQL query
            string query = $"UPDATE concepts SET name = '{concept.Name}', concept_text = '{concept.ConceptText}' WHERE id='{concept.Id}';";

            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, dbconn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        public async Task<List<Concept>> GetAllConceptsByTopic(Topic topic)
        {
            // Construct the SQL query to retrieve all areas
            string query = $"SELECT id, name, topic_id, concept_text FROM public.concepts WHERE topic_id = '{topic.Id}' ORDER BY name;";

            List<Concept> concepts = new List<Concept>();

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
                            var concept = new Concept
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Topic = topic,
                                ConceptText = reader.IsDBNull(3) ? String.Empty : reader.GetString(3)
                            };
                            concepts.Add(concept);
                        }
                    }
                }
            }

            return concepts;
        }
    }
}
