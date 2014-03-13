using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IV.Model.DAL {
    public class SongDAL : AbstractDAL {

        /// <summary>
        /// Delete a song from the database
        /// </summary>
        public static void DeleteSong(int songID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.SongDelete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SongID", SqlDbType.Int, 4).Value = songID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            } catch {
                throw new ApplicationException("An error occured while removing the song from the database.");
            }
        }

        /// <summary>
        /// Get a song from the database
        /// </summary>
        public static SongArtist GetSongById(int songId) {
            try {
                using (SqlConnection conn = CreateConnection()) {

                    SqlCommand cmd = new SqlCommand("appScheme.SongGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SongID", SqlDbType.Int, 4).Value = songId;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var songIDIndex = reader.GetOrdinal("SongID");
                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var numberIndex = reader.GetOrdinal("Number");
                        var nameIndex = reader.GetOrdinal("Name");
                        var lengthIndex = reader.GetOrdinal("Length");
                        var artistNameIndex = reader.GetOrdinal("ArtistName");

                        if (reader.Read()) {
                            return new SongArtist {
                                SongID = reader.GetInt32(songIDIndex),
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.GetInt32(artistIDIndex),
                                Number = reader.GetByte(numberIndex),
                                Name = reader.GetString(nameIndex),
                                Length = reader.GetInt16(lengthIndex),
                                ArtistName = reader.GetString(artistNameIndex)
                            };
                        }
                    }

                    return null;
                }
            } catch {
                throw new ApplicationException("An error occured while getting the song from the database.");
            }
        }

        /// <summary>
        /// Get an albums songs from the database
        /// </summary>
        public static IEnumerable<SongArtist> GetSongsByAlbumId(int albumID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var songs = new List<SongArtist>(15);

                    SqlCommand cmd = new SqlCommand("appScheme.SongsGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var songIDIndex = reader.GetOrdinal("SongID");
                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var numberIndex = reader.GetOrdinal("Number");
                        var nameIndex = reader.GetOrdinal("Name");
                        var lengthIndex = reader.GetOrdinal("Length");
                        var artistNameIndex = reader.GetOrdinal("ArtistName");

                        while (reader.Read()) {
                            songs.Add(new SongArtist {
                                SongID = reader.GetInt32(songIDIndex),
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.GetInt32(artistIDIndex),
                                Number = reader.GetByte(numberIndex),
                                Name = reader.GetString(nameIndex),
                                Length = reader.GetInt16(lengthIndex),
                                ArtistName = reader.GetString(artistNameIndex)
                            });
                        }
                    }

                    return songs;
                }
            } catch {
                throw new ApplicationException("An error occured while getting the songs from the database.");
            }
        }

        /// <summary>
        /// Insert a song to the database
        /// </summary>
        public static void InsertSong(Song song) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.SongInsert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = song.AlbumID;
                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = song.ArtistID;
                    cmd.Parameters.Add("@Number", SqlDbType.TinyInt, 1).Value = song.Number;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = song.Name;
                    cmd.Parameters.Add("@Length", SqlDbType.SmallInt, 2).Value = song.Length;

                    cmd.Parameters.Add("@SongID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    song.SongID = (int) cmd.Parameters["@SongID"].Value;
                }
            } catch {
                //throw new ApplicationException("An error occured while adding the song to the database.");
                throw;
            }
        }

        /// <summary>
        /// Update a song in the database
        /// </summary>
        public static void UpdateSong(Song song) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.SongUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SongID", SqlDbType.Int, 4).Value = song.SongID;
                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = song.AlbumID;
                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = song.ArtistID;
                    cmd.Parameters.Add("@Number", SqlDbType.TinyInt, 1).Value = song.Number;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = song.Name;
                    cmd.Parameters.Add("@Length", SqlDbType.SmallInt, 2).Value = song.Length;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            } catch {
                throw new ApplicationException("An error occured while updating the song in the database.");
            }
        }
    }
}