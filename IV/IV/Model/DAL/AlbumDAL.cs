﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IV.Model.DAL {
    public class AlbumDAL : AbstractDAL {


        /// <summary>
        /// Delete an album from the database
        /// </summary>
        public static void DeleteAlbum(int albumID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.AlbumDelete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            } catch {
                throw new ApplicationException("An error occured while removing the album from the database.");
            }
        }

        /// <summary>
        /// Get all albums from the database
        /// </summary>
        public static IEnumerable<AlbumArtist> GetAlbums() {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var albums = new List<AlbumArtist>(100);

                    SqlCommand cmd = new SqlCommand("appScheme.AlbumsGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var releasedIndex = reader.GetOrdinal("Released");
                        var artistNameIndex = reader.GetOrdinal("ArtistName");

                        while (reader.Read()) {
                            albums.Add(new AlbumArtist {
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.IsDBNull(artistIDIndex) ? null : (int?) reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Released = reader.GetDateTime(releasedIndex),
                                ArtistName = reader.IsDBNull(artistNameIndex) ? null : reader.GetString(artistNameIndex),
                            });
                        }
                    }

                    albums.TrimExcess();

                    return albums;
                }
            } catch {
                throw new ApplicationException("An error occured while getting albums from the database.");
            }
        }


        /// <summary>
        /// Get albums page wise from the database
        /// </summary>
        public static IEnumerable<AlbumArtist> GetAlbumsPageWise(int maximumRows, int startRowIndex, out int totalRowCount) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var albums = new List<AlbumArtist>(maximumRows);

                    SqlCommand cmd = new SqlCommand("appScheme.AlbumsGetPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Start", SqlDbType.Int, 4).Value = startRowIndex;
                    cmd.Parameters.Add("@Rows", SqlDbType.Int, 4).Value = maximumRows;

                    cmd.Parameters.Add("@Total", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var releasedIndex = reader.GetOrdinal("Released");
                        var artistNameIndex = reader.GetOrdinal("ArtistName");

                        while (reader.Read()) {
                            albums.Add(new AlbumArtist {
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.IsDBNull(artistIDIndex) ? null : (int?) reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Released = reader.GetDateTime(releasedIndex),
                                ArtistName = reader.IsDBNull(artistNameIndex) ? null : reader.GetString(artistNameIndex),
                            });
                        }
                    }

                    totalRowCount = (int) cmd.Parameters["@Total"].Value;

                    albums.TrimExcess();

                    return albums;
                }
            } catch {
                throw new ApplicationException("An error occured while getting albums from the database.");
            }
        }

        /// <summary>
        /// Get an album from the database
        /// </summary>
        public static AlbumArtist GetAlbumById(int albumID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.AlbumGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = albumID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        if (reader.Read()) {
                            var albumIDIndex = reader.GetOrdinal("AlbumID");
                            var artistIDIndex = reader.GetOrdinal("ArtistID");
                            var nameIndex = reader.GetOrdinal("Name");
                            var releasedIndex = reader.GetOrdinal("Released");
                            var artistNameIndex = reader.GetOrdinal("ArtistName");

                            return new AlbumArtist {
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.IsDBNull(artistIDIndex) ? null : (int?) reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Released = reader.GetDateTime(releasedIndex),
                                ArtistName = reader.IsDBNull(artistNameIndex) ? null : reader.GetString(artistNameIndex),
                            };
                        }
                    }

                    return null;
                }
            } catch {
                throw new ApplicationException("An error occured while getting the album from the database.");
            }
        }

        /// <summary>
        /// Get an artists albums from the database
        /// </summary>
        public static IEnumerable<Album> GetAlbumsByArtistId(int artistID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var albums = new List<Album>(15);

                    SqlCommand cmd = new SqlCommand("appScheme.AlbumsByArtistGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = artistID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var releasedIndex = reader.GetOrdinal("Released");

                        while (reader.Read()) {
                            albums.Add(new Album {
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.IsDBNull(artistIDIndex) ? null : (int?) reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Released = reader.GetDateTime(releasedIndex),
                            });
                        }
                    }

                    albums.TrimExcess();

                    return albums;
                }
            } catch {
                throw new ApplicationException("An error occured while getting the albums from the database.");
            }
        }

        /// <summary>
        /// Get an artists albums from the database
        /// </summary>
        public static IEnumerable<Album> GetAlbumsArtistAppearsOn(int artistID) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var albums = new List<Album>(15);

                    SqlCommand cmd = new SqlCommand("appScheme.AlbumsArtistAppearsGet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = artistID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var releasedIndex = reader.GetOrdinal("Released");

                        while (reader.Read()) {
                            albums.Add(new Album {
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.IsDBNull(artistIDIndex) ? null : (int?) reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Released = reader.GetDateTime(releasedIndex),
                            });
                        }
                    }

                    albums.TrimExcess();

                    return albums;
                }
            } catch {
                throw new ApplicationException("An error occured while getting the albums from the database.");
            }
        }

        /// <summary>
        /// Search albums in the database
        /// </summary>
        public static IEnumerable<AlbumArtist> SearchAlbums(String query) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    var albums = new List<AlbumArtist>(20);

                    SqlCommand cmd = new SqlCommand("appScheme.AlbumsSearch", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Query", SqlDbType.VarChar, 35).Value = query;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        var albumIDIndex = reader.GetOrdinal("AlbumID");
                        var artistIDIndex = reader.GetOrdinal("ArtistID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var releasedIndex = reader.GetOrdinal("Released");
                        var artistNameIndex = reader.GetOrdinal("ArtistName");

                        while (reader.Read()) {
                            albums.Add(new AlbumArtist {
                                AlbumID = reader.GetInt32(albumIDIndex),
                                ArtistID = reader.IsDBNull(artistIDIndex) ? null : (int?) reader.GetInt32(artistIDIndex),
                                Name = reader.GetString(nameIndex),
                                Released = reader.GetDateTime(releasedIndex),
                                ArtistName = reader.IsDBNull(artistNameIndex) ? null : reader.GetString(artistNameIndex),
                            });
                        }
                    }

                    albums.TrimExcess();

                    return albums;
                }
            } catch {
                throw new ApplicationException("An error occured while getting albums from the database.");
            }
        }

        /// <summary>
        /// Insert an album to the database
        /// </summary>
        public static void InsertAlbum(Album album) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.AlbumInsert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = album.ArtistID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 35).Value = album.Name;
                    cmd.Parameters.Add("@Released", SqlDbType.Date, 4).Value = album.Released;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    album.AlbumID = (int) cmd.Parameters["@AlbumID"].Value;
                }
            } catch {
                throw new ApplicationException("An error occured while adding the album to the database.");
            }
        }

        /// <summary>
        /// Update an album in the database
        /// </summary>
        public static void UpdateAlbum(Album album) {
            try {
                using (SqlConnection conn = CreateConnection()) {
                    SqlCommand cmd = new SqlCommand("appScheme.AlbumUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int, 4).Value = album.AlbumID;
                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int, 4).Value = album.ArtistID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 35).Value = album.Name;
                    cmd.Parameters.Add("@Released", SqlDbType.Date, 4).Value = album.Released;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            } catch {
                throw new ApplicationException("An error occured while updating the album in the database.");
            }
        }
    }
}