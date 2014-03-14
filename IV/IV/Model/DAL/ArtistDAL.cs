using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IV.Model.DAL {
    public class ArtistDAL : AbstractDAL {

        /// <summary>
        /// Delete an artist from the database
        /// </summary>
        public static void DeleteArtist(int artistID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.ArtistDelete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = artistID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            } catch {
                throw new ApplicationException("An error occured while removing the artist from the database.");
            }
        }

        /// <summary>
        /// Get all artists from the database
        /// </summary>
        public static IEnumerable<Artist> GetArtists() {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var artists = new List<Artist>(100);

                    SqlCommand cmd = new SqlCommand("appScheme.ArtistsGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var formedIndex = reader.GetOrdinal("Formed");
                        var descriptionIndex = reader.GetOrdinal("Description");

                        while (reader.Read()) {
                            artists.Add(new Artist {
                                ArtistID = reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Formed = reader.GetDateTime(formedIndex),
                                Description = reader.GetString(descriptionIndex)
                            });
                        }
                    }

                    artists.TrimExcess();

                    return artists;
                }
            } catch {
                throw new ApplicationException("An error occured while getting artists from the database.");
            }
        }

        /// <summary>
        /// Get an artist from the database
        /// </summary>
        public static Artist GetArtistById(int artistID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.ArtistGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = artistID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        if (reader.Read()) {
                            var artistIDIndex = reader.GetOrdinal("ArtistID");
                            var nameIndex = reader.GetOrdinal("Name");
                            var formedIndex = reader.GetOrdinal("Formed");
                            var descriptionIndex = reader.GetOrdinal("Description");

                            return new Artist {
                                ArtistID = reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Formed = reader.GetDateTime(formedIndex),
                                Description = reader.GetString(descriptionIndex)
                            };
                        }
                    }

                    return null;
                }
            } catch {
                throw new ApplicationException("An error occured while getting the artist from the database.");
            }
        }

        /// <summary>
        /// Search artists in the database
        /// </summary>
        public static IEnumerable<Artist> SearchArtists(String query) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var artists = new List<Artist>(20);

                    SqlCommand cmd = new SqlCommand("appScheme.ArtistsSearch", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Query", SqlDbType.VarChar, 35).Value = query;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var formedIndex = reader.GetOrdinal("Formed");
                        var descriptionIndex = reader.GetOrdinal("Description");

                        while (reader.Read()) {
                            artists.Add(new Artist {
                                ArtistID = reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Formed = reader.GetDateTime(formedIndex),
                                Description = reader.GetString(descriptionIndex)
                            });
                        }
                    }

                    artists.TrimExcess();

                    return artists;
                }
            } catch {
                throw new ApplicationException("An error occured while getting artists from the database.");
            }
        }

        /// <summary>
        /// Insert an artist to the database
        /// </summary>
        public static void InsertArtist(Artist artist) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.ArtistInsert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = artist.Name;
                    cmd.Parameters.Add("@Formed", SqlDbType.Date, 4).Value = artist.Formed;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, -1).Value = artist.Description;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    artist.ArtistID = (int) cmd.Parameters["@ArtistID"].Value;
                }
            } catch {
                throw new ApplicationException("An error occured while adding the artist to the database.");
            }
        }

        /// <summary>
        /// Update an artist in the database
        /// </summary>
        public static void UpdateArtist(Artist artist) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.ArtistUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = artist.ArtistID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = artist.Name;
                    cmd.Parameters.Add("@Formed", SqlDbType.Date, 4).Value = artist.Formed;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, -1).Value = artist.Description;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            } catch {
                throw new ApplicationException("An error occured while updating the artist in the database.");
            }
        }
    }
}